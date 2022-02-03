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
                string[] keyValue = entry.Split("=", StringSplitOptions.RemoveEmptyEntries);
                if (keyValue.Length == 2)
                {
                    Environment.SetEnvironmentVariable(keyValue[0], keyValue[1]);
                }
            }

            Console.WriteLine(Environment.GetEnvironmentVariable("BLOCKBUSTER_CONNECTION_STRING"));
        }

        private static string GetDefaultPath()
        {
            // SPECIFIC FOR THIS PROJECT STRUCTURE!!
            return Path.GetFullPath(@"..\..\..\..\");
        }

    }
}
