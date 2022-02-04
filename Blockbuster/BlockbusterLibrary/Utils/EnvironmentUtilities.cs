using System;
using System.IO;

namespace BlockBusterLibrary.Utils
{
    public static class EnvironmentUtilities
    {

        public static void Init(string path = "")
        {
            if (path.Length == 0)
            {
                path = GetDefaultPath();
            }

            path = Path.Combine(path, ".env");


            foreach (string entry in File.ReadAllLines(path))
            {
                var index = entry.IndexOf("=");

                if (index != -1)
                {
                    Environment.SetEnvironmentVariable(entry.Substring(0, index), entry.Substring(index+1));
                }
            }

        }

        private static string GetDefaultPath()
        {
            // SPECIFIC FOR THIS PROJECT STRUCTURE!!
            return Path.GetFullPath(@"..\..\..\..\");
        }

    }
}
