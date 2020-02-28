using BernaKs;
using BernaKs.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Principal;

public class BMemory
{
    private static Process m_Process;
    private static IntPtr m_ProcessHandle;

    const int PROCESS_WM_READ = 0x0010;
    const int PROCESS_WM_WRITE = 0x0020;

    public BMemory(int processID)
    {
        BindToProcessById(processID);
    }

    ~BMemory()
    {
        Release();
    }

    public string GetUserOwningProcess()
    {
        try
        {
            WindowsIdentity WI = new WindowsIdentity(m_Process.Handle);
            string user = WI.Name;

            return user.Contains(@"\") ? user.Substring(user.IndexOf(@"\") + 1) : user;

        }
        catch
        {
            return null;
        }
        finally
        {
            WrapperWinAPI.CloseHandle(m_ProcessHandle);
        }
    }

    public string GetProcessName()
    {
        if(!IsBound())
        {
            return "None";
        }

        return m_Process.ProcessName;
    }

    public bool IsBound()
    {
        return m_Process != null;
    }

    public static List<Process> GetAllProcresses(bool bSort = false)
    {
        List<Process> ProcessesList = new List<Process>(Process.GetProcesses());

        if(bSort)
        {
            ProcessesList.Sort((Process p1, Process p2) => p1.ProcessName.CompareTo(p2.ProcessName));
        }

        return ProcessesList;
    }

    public void BindToProcessById(int processId)
    {
        // release previous binded process.
        Release();

        try
        {
            m_Process = Process.GetProcessById(processId);
            m_ProcessHandle = WrapperWinAPI.OpenProcess((int)ProcessAccessFlags.All, false, m_Process.Id);
        }
        catch
        {
            m_Process = null;
            m_ProcessHandle = new IntPtr(0);
            
            // do nothing
            Console.WriteLine("Cannot attach to that process... try with admin.");
        }
    }

    public IntPtr GetBaseMemoryAddress()
    {
        if(!IsBound())
        {
            return new IntPtr(0);
        }

        return new IntPtr(m_Process.MainModule.BaseAddress.ToInt64());
    }

    public int GetMemorySize()
    {
        if (!IsBound())
        {
            return 0;
        }

        return m_Process.MainModule.ModuleMemorySize;
    }

    public bool ReadMemoryAt(long address, int bytesToRead, out byte[] buffer)
    {
        buffer = new byte[bytesToRead];
        IntPtr read = new IntPtr();

        MEMORY_BASIC_INFORMATION memInfo;
        int dwLength = Marshal.SizeOf(typeof(MEMORY_BASIC_INFORMATION));

        WrapperWinAPI.VirtualQueryEx(m_ProcessHandle, (IntPtr)address, out memInfo, dwLength);

        return WrapperWinAPI.ReadProcessMemory(m_ProcessHandle, new IntPtr(address), buffer, bytesToRead, out read);
    }

    public bool ReadMemory(out Dictionary<IntPtr, byte[]> dictionary)
    {
        SYSTEM_INFO sysInfo;
        WrapperWinAPI.GetSystemInfo(out sysInfo);

        IntPtr start = new IntPtr(0);
        IntPtr end = sysInfo.lpMaximumApplicationAddress;

        long current = 0;

        MEMORY_BASIC_INFORMATION memInfo;
        int dwLength = Marshal.SizeOf(typeof(MEMORY_BASIC_INFORMATION));

        dictionary = new Dictionary<IntPtr, byte[]>();

        while(current <= end.ToInt64() && WrapperWinAPI.VirtualQueryEx(m_ProcessHandle, (IntPtr)current, out memInfo, dwLength) != 0)
        {
            if (memInfo.State == StateEnum.MEM_COMMIT && memInfo.Protect == AllocationProtectEnum.PAGE_READWRITE)
            {
                byte[] buffer = new byte[memInfo.RegionSize.ToInt32()];
                IntPtr read = new IntPtr(0);

                IntPtr baseAddr = new IntPtr((long)memInfo.BaseAddress);

                if(WrapperWinAPI.ReadProcessMemory(m_ProcessHandle, baseAddr, buffer, buffer.Length, out read))
                {
                    dictionary.Add(baseAddr, buffer);
                }
            }

            // next memory chunck.
            current = (long)memInfo.BaseAddress + (long)memInfo.RegionSize;
        }

        return dictionary.Count > 0;
    }

    public void Release()
    {
        try
        {
            WrapperWinAPI.CloseHandle(m_ProcessHandle);
        }
        catch
        {
            // do nothing
            Console.WriteLine("Nothing to release.");
        }
        finally
        {
            m_ProcessHandle = new IntPtr(0);
            m_Process = null;
        }
    }
}

