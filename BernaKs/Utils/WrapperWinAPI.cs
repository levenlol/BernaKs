using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace BernaKs.Utils
{
    public static class WrapperWinAPI
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out IntPtr lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        public static extern void GetSystemInfo(out SYSTEM_INFO lpSystemInfo);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int VirtualQueryEx(IntPtr hProcess, IntPtr lpAddress, out MEMORY_BASIC_INFORMATION lpBuffer, int dwLength);

        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool IsWow64Process([In] IntPtr process, [Out] out bool wow64Process);
    }

    public static class FlagsUtility
    {
        public static string MemoryDataTypeToStr(MemoryDataType type)
        {
            switch (type)
            {
                case MemoryDataType.Byte_1:
                    return "1-Byte";
                case MemoryDataType.Byte_2:
                    return "2-Byte";
                case MemoryDataType.Byte_4:
                    return "4-Byte";
                case MemoryDataType.Byte_8:
                    return "8-Byte";
                case MemoryDataType.Integer:
                    return "Integer";
                case MemoryDataType.Float:
                    return "Float";
                case MemoryDataType.Double:
                    return "Double";
            }

            System.Diagnostics.Debug.Fail("cannot handle MemoryDataType: " + type);
            return "invalid type";
        }

        public static int GetMemoryDataSize(MemoryDataType type)
        {
            switch (type)
            {
                case MemoryDataType.Byte_1:
                    return 1;
                case MemoryDataType.Byte_2:
                    return 2;
                case MemoryDataType.Byte_4:
                    return 4;
                case MemoryDataType.Byte_8:
                    return 8;
                case MemoryDataType.Integer:
                    return sizeof(int);
                case MemoryDataType.Float:
                    return sizeof(float);
                case MemoryDataType.Double:
                    return sizeof(double);
            }

            System.Diagnostics.Debug.Fail("cannot handle MemoryDataType: " + type);
            return 4;
        }
    }
}

public class SePrivilegeNames
{
    public const string SE_ASSIGNPRIMARYTOKEN_NAME = "SeAssignPrimaryTokenPrivilege";
    public const string SE_AUDIT_NAME = "SeAuditPrivilege";
    public const string SE_BACKUP_NAME = "SeBackupPrivilege";
    public const string SE_CHANGE_NOTIFY_NAME = "SeChangeNotifyPrivilege";
    public const string SE_CREATE_GLOBAL_NAME = "SeCreateGlobalPrivilege";
    public const string SE_CREATE_PAGEFILE_NAME = "SeCreatePagefilePrivilege";
    public const string SE_CREATE_PERMANENT_NAME = "SeCreatePermanentPrivilege";
    public const string SE_CREATE_SYMBOLIC_LINK_NAME = "SeCreateSymbolicLinkPrivilege";
    public const string SE_CREATE_TOKEN_NAME = "SeCreateTokenPrivilege";
    public const string SE_DEBUG_NAME = "SeDebugPrivilege";
    public const string SE_ENABLE_DELEGATION_NAME = "SeEnableDelegationPrivilege";
    public const string SE_IMPERSONATE_NAME = "SeImpersonatePrivilege";
    public const string SE_INC_BASE_PRIORITY_NAME = "SeIncreaseBasePriorityPrivilege";
    public const string SE_INCREASE_QUOTA_NAME = "SeIncreaseQuotaPrivilege";
    public const string SE_INC_WORKING_SET_NAME = "SeIncreaseWorkingSetPrivilege";
    public const string SE_LOAD_DRIVER_NAME = "SeLoadDriverPrivilege";
    public const string SE_LOCK_MEMORY_NAME = "SeLockMemoryPrivilege";
    public const string SE_MACHINE_ACCOUNT_NAME = "SeMachineAccountPrivilege";
    public const string SE_MANAGE_VOLUME_NAME = "SeManageVolumePrivilege";
    public const string SE_PROF_SINGLE_PROCESS_NAME = "SeProfileSingleProcessPrivilege";
    public const string SE_RELABEL_NAME = "SeRelabelPrivilege";
    public const string SE_REMOTE_SHUTDOWN_NAME = "SeRemoteShutdownPrivilege";
    public const string SE_RESTORE_NAME = "SeRestorePrivilege";
    public const string SE_SECURITY_NAME = "SeSecurityPrivilege";
    public const string SE_SHUTDOWN_NAME = "SeShutdownPrivilege";
    public const string SE_SYNC_AGENT_NAME = "SeSyncAgentPrivilege";
    public const string SE_SYSTEM_ENVIRONMENT_NAME = "SeSystemEnvironmentPrivilege";
    public const string SE_SYSTEM_PROFILE_NAME = "SeSystemProfilePrivilege";
    public const string SE_SYSTEMTIME_NAME = "SeSystemtimePrivilege";
    public const string SE_TAKE_OWNERSHIP_NAME = "SeTakeOwnershipPrivilege";
    public const string SE_TCB_NAME = "SeTcbPrivilege";
    public const string SE_TIME_ZONE_NAME = "SeTimeZonePrivilege";
    public const string SE_TRUSTED_CREDMAN_ACCESS_NAME = "SeTrustedCredManAccessPrivilege";
    public const string SE_UNDOCK_NAME = "SeUndockPrivilege";
    public const string SE_UNSOLICITED_INPUT_NAME = "SeUnsolicitedInputPrivilege";
}
[Flags]
public enum SePrivilege : uint
{
    SE_PRIVILEGE_ENABLED_BY_DEFAULT = 0x00000001,
    SE_PRIVILEGE_ENABLED = 0x00000002,
    SE_PRIVILEGE_REMOVED = 0x00000004,
    SE_PRIVILEGE_USED_FOR_ACCESS = 0x80000000,
}

[Flags]
public enum TokenAccess : uint
{
    STANDARD_RIGHTS_REQUIRED = 0x000F0000,
    STANDARD_RIGHTS_READ = 0x00020000,
    TOKEN_ASSIGN_PRIMARY = 0x0001,
    TOKEN_DUPLICATE = 0x0002,
    TOKEN_IMPERSONATE = 0x0004,
    TOKEN_QUERY = 0x0008,
    TOKEN_QUERY_SOURCE = 0x0010,
    TOKEN_ADJUST_PRIVILEGES = 0x0020,
    TOKEN_ADJUST_GROUPS = 0x0040,
    TOKEN_ADJUST_DEFAULT = 0x0080,
    TOKEN_ADJUST_SESSIONID = 0x0100,
    TOKEN_READ = (STANDARD_RIGHTS_READ | TOKEN_QUERY),
    TOKEN_ALL_ACCESS = (STANDARD_RIGHTS_REQUIRED | TOKEN_ASSIGN_PRIMARY |
        TOKEN_DUPLICATE | TOKEN_IMPERSONATE | TOKEN_QUERY | TOKEN_QUERY_SOURCE |
        TOKEN_ADJUST_PRIVILEGES | TOKEN_ADJUST_GROUPS | TOKEN_ADJUST_DEFAULT |
        TOKEN_ADJUST_SESSIONID)
}

[StructLayout(LayoutKind.Sequential)]
public struct SYSTEM_INFO
{
    public ushort wProcessorArchitecture;
    public ushort wReserved;
    public uint dwPageSize;
    public IntPtr lpMinimumApplicationAddress;
    public IntPtr lpMaximumApplicationAddress;
    public IntPtr dwActiveProcessorMask;
    public uint dwNumberOfProcessors;
    public uint dwProcessorType;
    public uint dwAllocationGranularity;
    public ushort wProcessorLevel;
    public ushort wProcessorRevision;
}

public enum AllocationProtectEnum : uint
{
    PAGE_EXECUTE = 0x00000010,
    PAGE_EXECUTE_READ = 0x00000020,
    PAGE_EXECUTE_READWRITE = 0x00000040,
    PAGE_EXECUTE_WRITECOPY = 0x00000080,
    PAGE_NOACCESS = 0x00000001,
    PAGE_READONLY = 0x00000002,
    PAGE_READWRITE = 0x00000004,
    PAGE_WRITECOPY = 0x00000008,
    PAGE_GUARD = 0x00000100,
    PAGE_NOCACHE = 0x00000200,
    PAGE_WRITECOMBINE = 0x00000400
}

public enum StateEnum : uint
{
    MEM_COMMIT = 0x1000,
    MEM_FREE = 0x10000,
    MEM_RESERVE = 0x2000
}

public enum TypeEnum : uint
{
    MEM_IMAGE = 0x1000000,
    MEM_MAPPED = 0x40000,
    MEM_PRIVATE = 0x20000
}

[StructLayout(LayoutKind.Sequential)]
public struct MEMORY_BASIC_INFORMATION // #todo ok for 32 bit applications
{
    public IntPtr BaseAddress;
    public IntPtr AllocationBase;
    public AllocationProtectEnum AllocationProtect;
    public int __alignment1;
    public IntPtr RegionSize;
    public StateEnum State;
    public AllocationProtectEnum Protect;
    public TypeEnum Type;
    public int __alignment2;
}

[Flags]
public enum ProcessAccessFlags : uint
{
    All = 0x001F0FFF,
    Terminate = 0x00000001,
    CreateThread = 0x00000002,
    VirtualMemoryOperation = 0x00000008,
    VirtualMemoryRead = 0x00000010,
    VirtualMemoryWrite = 0x00000020,
    DuplicateHandle = 0x00000040,
    CreateProcess = 0x000000080,
    SetQuota = 0x00000100,
    SetInformation = 0x00000200,
    QueryInformation = 0x00000400,
    QueryLimitedInformation = 0x00001000,
    Synchronize = 0x00100000
}

public enum MemoryDataType : uint
{
    Byte_1,
    Byte_2,
    Byte_4,
    Byte_8,
    Integer,
    Float,
    Double
}

public enum RoundType : uint
{
    Exact,
    Round,
    Truncate
}
