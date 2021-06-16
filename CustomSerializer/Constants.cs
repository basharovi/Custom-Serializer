using System;
using System.IO;

namespace CustomSerializer
{
    public static class Constants
    {
        public static string InputDirectory { get; set; } = Path.Combine(ProjectDirectory, "Data","Input");

        private static string ProjectDirectory
        {
            get
            {
                var baseDirectory = Environment.CurrentDirectory;
                return Directory.GetParent(baseDirectory).Parent.Parent.FullName;
            }
        }
    }
}
