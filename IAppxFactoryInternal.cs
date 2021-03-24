namespace AppPackageInfo
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    /// <summary>
    /// IAppxFactoryInternal defined in AppxPackaging.dll
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Appx"), ComImport, InterfaceType((short)1), Guid("95903D88-B56C-4230-8278-941A59BD4335")]
    public interface IAppxFactoryInternal
    {
        /// <summary>
        /// Creates the package streaming reader.
        /// </summary>
        /// <param name="streamingDataSource">The streaming data source.</param>
        /// <param name="options">The options.</param>
        /// <returns>Stream reader instance</returns>
        [return: MarshalAs(UnmanagedType.Interface)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        IAppxPackageStreamingReader CreatePackageStreamingReader([In, MarshalAs(UnmanagedType.Interface)] IAppxStreamingDataSource streamingDataSource, [In] APPX_PACKAGE_READER_OPTIONS options);

        /// <summary>
        /// Creates the package streaming reader from source URI.
        /// </summary>
        /// <param name="sourceUri">The source URI.</param>
        /// <param name="options">The options.</param>
        /// <returns>Stream reader instance</returns>
        [return: MarshalAs(UnmanagedType.Interface)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "0#"), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        IAppxPackageStreamingReader CreatePackageStreamingReaderFromSourceUri([In, MarshalAs(UnmanagedType.LPWStr)] string sourceUri, [In] APPX_PACKAGE_READER_OPTIONS options);

        /// <summary>
        /// Gets the package family name from package id.
        /// </summary>
        /// <param name="packageName">Name of the package.</param>
        /// <param name="publisher">The publisher.</param>
        /// <returns>PFN of the given package</returns>
        [return: MarshalAs(UnmanagedType.LPWStr)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        string GetPackageFamilyNameFromPackageId([In, MarshalAs(UnmanagedType.LPWStr)] string packageName, [In, MarshalAs(UnmanagedType.LPWStr)] string publisher);

        /// <summary>
        /// Gets the name of the package sid from package family.
        /// </summary>
        /// <param name="packageFamilyName">Name of the package family.</param>
        /// <returns>String representing an SID</returns>
        [return: MarshalAs(UnmanagedType.LPWStr)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        string GetPackageSidFromPackageFamilyName([In, MarshalAs(UnmanagedType.LPWStr)] string packageFamilyName);
    }

    #region Unused interfaces and data structures (required to compile the IAppxFactoryInternal interface

    /// <summary>
    /// IAppxPackageStreamingReader - unused
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Appx"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1040:AvoidEmptyInterfaces")]
    public interface IAppxPackageStreamingReader
    {
    }

    /// <summary>
    /// APPX_PACKAGE_READER_OPTIONS - unused
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "OPTIONS"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "READER"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "PACKAGE"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "APPX"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
    public enum APPX_PACKAGE_READER_OPTIONS
    {
    }

    /// <summary>
    /// IAppxStreamingDataSource - unused
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Appx"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1040:AvoidEmptyInterfaces")]
    public interface IAppxStreamingDataSource
    {
    }

    #endregion
}
