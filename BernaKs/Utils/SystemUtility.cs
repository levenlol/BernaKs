using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace BernaKs.Utils
{
    class SystemUtility
    {
        public static bool IsProcess64Bit(Process p)
        {
            if (IsSystem64BitEmulator())
            {
                bool b;
                return WrapperWinAPI.IsWow64Process(p.Handle, out b) && b;
            }

            return false;
        }

        public static bool IsSystem64BitEmulator()
        {
            return Environment.Is64BitOperatingSystem;
            //return (Environment.OSVersion.Version.Major > 5) || ((Environment.OSVersion.Version.Major == 5) && (Environment.OSVersion.Version.Minor >= 1));
        }
    }
}
