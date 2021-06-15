using CsvHelper;
using CustomSerializer.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace CustomSerializer
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileNames = ReadAllFileNames(Constants.InputDirectory);

            ReadFromJsonFile(fileNames);

            Console.WriteLine("Hello World!");
        }

        private static string[] ReadAllFileNames(string path)
        {
            if (!Directory.Exists(path))
                throw new DirectoryNotFoundException();

            var fileNames = Directory.GetFiles(path);

            return fileNames;
        }
        
        private static void ReadFromJsonFile(string[] fileNames)
        {
            foreach (var fileName in fileNames)
            {
                using (var reader = new StreamReader(fileName))
                {
                    var jsonList = new List<JsonModel>();

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        jsonList.Add( new JsonModel{ 
                            LocationName = values[0]
                        });
                    }
                }
            }
        }
    }
}
