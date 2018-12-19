using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SharpKernel
{
    public static class Kernel
    {
        public const uint CP_UTF8 = 65001u;

        public const int PROCESS_ALL_ACCESS = 0x1F0FFF;

        public static Process[] GetProcessesByName(string ProcessName)
        {
            return Process.GetProcessesByName(ProcessName);
        }
        public static Process[] GetProcessesByName(string ProcessName, string MachineName)
        {
            return Process.GetProcessesByName(ProcessName, MachineName);
        }

        [DllImport("kernel32.dll", EntryPoint = "OpenProcess", SetLastError = true)]
        public static extern int OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", EntryPoint = "ReadProcessMemory", SetLastError = true)]
        public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out int lpNumberOfBytesRead);

        [DllImport("kernel32.dll", EntryPoint = "WriteProcessMemory", SetLastError = true)]
        public static extern bool WriteProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, out int lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]
        public static extern bool SetProcessWorkingSetSize(IntPtr handle, int minimumWorkingSetSize, int maximumWorkingSetSize);

        
        [DllImport("kernel32", EntryPoint = "GetProcAddress", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);
        
        [DllImport("kernel32", EntryPoint = "FreeLibrary", SetLastError = true)]
        public static extern bool FreeLibrary(IntPtr hModule);
        
        [DllImport("kernel32", EntryPoint = "LoadLibrary", SetLastError = true)]
        public static extern IntPtr LoadLibrary(string lpFileName);
        
        [DllImport("kernel32", EntryPoint = "CloseHandle", SetLastError = true)]
        public static extern bool CloseHandle(IntPtr handle);
        
        [DllImport("user32.dll", EntryPoint = "SetParent", SetLastError = true)]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        
        [DllImport("msvcrt.dll", EntryPoint = "vsprintf", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int vsprintf(IntPtr buffer, string format, IntPtr args);
        
        [DllImport("msvcrt.dll", EntryPoint = "_vscprintf", CallingConvention = CallingConvention.Cdecl)]
        public static extern int _vscprintf(string format, IntPtr ptr);
        
        [DllImport("kernel32.dll", EntryPoint = "MultiByteToWideChar", SetLastError = true)]
        public static extern int MultiByteToWideChar(uint CodePage, uint dwFlags, IntPtr lpMultiByteStr, int cbMultiByte, [MarshalAs(UnmanagedType.LPWStr)] [Out] StringBuilder lpWideCharStr, int cchWideChar);

        public static T LoadFunction <T> (IntPtr hModule, string functionName)
        {
            var procAddr = SharpKernel.Kernel.GetProcAddress(hModule, functionName);
            if (procAddr == IntPtr.Zero)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            return (T)(object) Marshal.GetDelegateForFunctionPointer(procAddr, typeof(T));
        }
    }
}
