using System;
using System.IO;
using System.IO.Compression;
using System.Runtime.Versioning;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace AppPackageInfo
{
    class Program
    {
        static string ReadAppxManifestFromZip(Stream stream)
        {
            using (var zip = new ZipArchive(stream))
            {
                foreach (var entry in zip.Entries)
                {
                    if (entry.Name.Equals("appxmanifest.xml", StringComparison.OrdinalIgnoreCase))
                    {
                        using (var manifestStream = new StreamReader(entry.Open()))
                        {
                            return manifestStream.ReadToEnd();
                        }
                    }
                    else if (entry.Name.EndsWith(".appx", StringComparison.OrdinalIgnoreCase) || entry.Name.EndsWith(".msix", StringComparison.OrdinalIgnoreCase))
                    {
                        using (var appxStream = entry.Open())
                        {
                            return ReadAppxManifestFromZip(appxStream);
                        }
                    }
                }
            }

            return null;
        }

        [SupportedOSPlatform("windows")]
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("AppPackageInfo <appxmanifest.xml|package.appxmanifest|<package>.[appx|appxbundle]>|<package>.[msix|msixbundle]>");
                return;
            }
            var filename = args[0];

            string manifestText = null;
            try
            {
                using (var fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read))
                {
                    manifestText = ReadAppxManifestFromZip(fileStream);
                }
            }
            catch
            {
            }

            if (manifestText == null)
            {
                manifestText = File.ReadAllText(filename);
            }

            var doc = XDocument.Parse(manifestText);
            var ns = new XmlNamespaceManager(new NameTable());
            ns.AddNamespace("x", "http://schemas.microsoft.com/appx/manifest/foundation/windows10");
            var identity = doc.XPathSelectElement("/x:Package/x:Identity", ns);
            var packageName = identity?.Attribute("Name")?.Value;
            Console.WriteLine($"Package/Identity/Name = {packageName}");
            var publisher = identity?.Attribute("Publisher")?.Value;
            Console.WriteLine($"Package/Identity/Publisher = {publisher}");
            var publisherDisplayName = doc.XPathSelectElement("/x:Package/x:Properties/x:PublisherDisplayName", ns)?.Value;
            Console.WriteLine($"Package/Properties/PublisherDisplayName = {publisherDisplayName}");

            var pfn = AppxPackagingHelper.GetPfnFromPackageName(packageName, publisher);
            Console.WriteLine($"Package Family Name (PFN) = {pfn}");
            var sid = AppxPackagingHelper.GetSidFromPackageFamilyName(pfn);
            Console.WriteLine($"Package SID = {sid}");
        }
    }
}
