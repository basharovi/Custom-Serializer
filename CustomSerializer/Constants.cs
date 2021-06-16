using System;
using System.IO;

namespace CustomSerializer
{
    public static class Constants
    {
        public static string DataDirectory { get; set; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data");
        public static string InputDirectory { get; set; } = Path.Combine(DataDirectory, "Input");
    }
}
