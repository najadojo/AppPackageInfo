namespace AppPackageInfo
{
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.Versioning;

    /// <summary>
    /// Appx packaging helper class
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Appx")]
    public static class AppxPackagingHelper
    {
        /// <summary>
        /// The id of class that implements IAppxFactoryInternal
        /// </summary>
        private const string AppxInternalClassId = "341301BA-111C-408D-A8E3-14D1DDC62A6F";

        /// <summary>
        /// The id of IAppxFactoryInternal
        /// </summary>
        private const string AppxInternalInterfaceId = "95903D88-B56C-4230-8278-941A59BD4335";

        /// <summary>
        /// Gets the SID from the given package family name
        /// </summary>
        /// <param name="packageName">Name of the package.</param>
        /// <param name="publisher">The publisher.</param>
        /// <returns>String representing an SID</returns>
        [SupportedOSPlatform("windows")]
        public static string GetSidFromPackageName(string packageName, string publisher)
        {
            string resultSid = null;
            IAppxFactoryInternal factoryInternal = null;

            try
            {
                factoryInternal = (IAppxFactoryInternal)Win32InteropHelper.CoCreateInstance(new Guid(AppxInternalClassId),
                                                                   null, CLSCTX.INPROC,
                                                                   new Guid(AppxInternalInterfaceId));

                if (factoryInternal == null)
                {
                    return null;
                }

                var packageFamilyName = factoryInternal.GetPackageFamilyNameFromPackageId(packageName, publisher);

                if (!string.IsNullOrWhiteSpace(packageFamilyName))
                {
                    resultSid = factoryInternal.GetPackageSidFromPackageFamilyName(packageFamilyName);
                }
            }
            finally
            {
                if (factoryInternal != null)
                {
                    Marshal.FinalReleaseComObject(factoryInternal);
                }
            }

            return resultSid;
        }

        /// <summary>
        /// Gets the SID from the given package family name
        /// </summary>
        /// <param name="packageFamilyName">Package family name.</param>
        /// <returns>String representing an SID</returns>
        [SupportedOSPlatform("windows")]
        public static string GetSidFromPackageFamilyName(string packageFamilyName)
        {
            if (string.IsNullOrEmpty(packageFamilyName))
            {
                throw new ArgumentNullException("packageFamilyName");
            }

            string packageSid;
            IAppxFactoryInternal appxInternalFactory = null;

            try
            {
                appxInternalFactory = (IAppxFactoryInternal)Win32InteropHelper.CoCreateInstance(new Guid(AppxInternalClassId),
                                                                   null, CLSCTX.INPROC,
                                                                   new Guid(AppxInternalInterfaceId));

                if (appxInternalFactory == null)
                {
                    return null;
                }

                packageSid = appxInternalFactory.GetPackageSidFromPackageFamilyName(packageFamilyName);
            }
            finally
            {
                if (appxInternalFactory != null)
                {
                    Marshal.FinalReleaseComObject(appxInternalFactory);
                }
            }

            return packageSid;
        }

        /// <summary>
        /// Gets the Package Family Name (PFN) from the given identity name and publisher
        /// </summary>
        /// <param name="packageName">Name of the package.</param>
        /// <param name="publisher">The publisher.</param>
        /// <returns>String representing an SID</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Pfn")]
        [SupportedOSPlatform("windows")]
        public static string GetPfnFromPackageName(string packageName, string publisher)
        {
            string resultPfn = null;
            IAppxFactoryInternal factoryInternal = null;

            try
            {
                factoryInternal = (IAppxFactoryInternal)Win32InteropHelper.CoCreateInstance(new Guid(AppxInternalClassId),
                                                                   null, CLSCTX.INPROC,
                                                                   new Guid(AppxInternalInterfaceId));

                if (factoryInternal == null)
                {
                    return null;
                }

                resultPfn = factoryInternal.GetPackageFamilyNameFromPackageId(packageName, publisher);
            }
            finally
            {
                if (factoryInternal != null)
                {
                    Marshal.FinalReleaseComObject(factoryInternal);
                }
            }

            return resultPfn;
        }
    }
}
