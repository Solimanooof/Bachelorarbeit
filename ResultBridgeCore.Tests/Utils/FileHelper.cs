using System;
using System.IO;

namespace ResultBridgeCore.Tests.Utils
{
    public static class FileHelper
    {
        public static string TestResourcesFolderPath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources");

        /// <summary>
        /// Resolves path to file in test resources folder. Does not
        /// check whether file exists.
        /// </summary>
        /// <param name="fileName">Name of file of which file path in test resources folder should be resolved</param>
        /// <returns>File path to file provided in method signature</returns>
        public static string ResolveFileFromTestResources(string fileName)
        {
            return Path.Combine(TestResourcesFolderPath, fileName);
        }
    }
}