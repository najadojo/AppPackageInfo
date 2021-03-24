namespace AppPackageInfo
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    /// <summary>
    /// CLSCTX
    /// </summary>
    [Flags]
    internal enum CLSCTX
    {
        ACTIVATE_32_BIT_SERVER = 0x40000,
        ACTIVATE_64_BIT_SERVER = 0x80000,
        ACTIVATE_AAA_AS_IU = 0x800000,
        APPCONTAINER = 0x400000,
        DISABLE_AAA = 0x8000,
        ENABLE_AAA = 0x10000,
        ENABLE_CLOAKING = 0x100000,
        ENABLE_CODE_DOWNLOAD = 0x2000,
        FROM_DEFAULT_CONTEXT = 0x20000,
        INPROC = 0x3,
        INPROC_HANDLER = 0x2,
        INPROC_HANDLER16 = 0x20,
        INPROC_SERVER = 0x1,
        INPROC_SERVER16 = 0x8,
        LOCAL_SERVER = 0x4,
        NO_CODE_DOWNLOAD = 0x400,
        NO_CUSTOM_MARSHAL = 0x1000,
        NO_FAILURE_LOG = 0x4000,
        PS_DLL = 0x8000000,
        REMOTE_SERVER = 0x10,
        RESERVED1 = 0x40,
        RESERVED2 = 0x80,
        RESERVED3 = 0x100,
        RESERVED4 = 0x200,
        RESERVED5 = 0x800
    }

    /// <summary>
    /// Helper class to call into Win32 APIs.
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal class Win32InteropHelper
    {
        /// <summary>
        /// Creates an instance of a class using COM interface
        /// </summary>
        /// <param name="rclsid">The class ID.</param>
        /// <param name="outerUnknown">The outer unknown.</param>
        /// <param name="classContext">The class context.</param>
        /// <param name="riid">The interface ID.</param>
        /// <returns>An instance of the created object</returns>
        [return: MarshalAs(UnmanagedType.Interface)]
        [DllImport("ole32.dll", ExactSpelling = true, PreserveSig = false)]
        internal static extern object CoCreateInstance(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid rclsid,
            [In, MarshalAs(UnmanagedType.IUnknown)] object outerUnknown,
            [In] CLSCTX classContext,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);
    }
}
