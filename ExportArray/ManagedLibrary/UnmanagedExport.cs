namespace ManagedLibrary
{
    using System;
    using System.Linq;
    using System.Runtime.InteropServices;

    using RGiesecke.DllExport;

    internal static class UnmanagedExport
    {
        [DllExport(ExportName = "OutputArray", CallingConvention = CallingConvention.Cdecl)]
        private static void OutputArray(
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeConst = 3)] string[] array)
        {
            foreach (var line in array)
            {
                Console.WriteLine(line);
            }
        }

        [DllExport(ExportName = "OutputArrayIntPtr", CallingConvention = CallingConvention.Cdecl)]
        private static void OutputArrayIntPtr(
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.SysInt, SizeConst = 3)] IntPtr[] array)
        {
            foreach (var line in array.Select(ptr => Marshal.PtrToStringUni(ptr)))
            {
                Console.WriteLine(line);
            }
        }

        [DllExport(ExportName = "OutputArrayIntPtrNoSubType", CallingConvention = CallingConvention.Cdecl)]
        private static void OutputArrayIntPtrNoSubType(
            [MarshalAs(UnmanagedType.LPArray, SizeConst = 3)] IntPtr[] array)
        {
            foreach (var line in array.Select(ptr => Marshal.PtrToStringUni(ptr)))
            {
                Console.WriteLine(line);
            }
        }
    }
}
