using System;
using System.IO;
using CustomSerializer.Model;
using System.Collections.Generic;

namespace CustomSerializer
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileNames = ReadAllFileNames(Constants.InputDirectory);

            ReadFromCsvFile(fileNames);

            Console.WriteLine("Hello World!");
        }

        private static string[] ReadAllFileNames(string path)
        {
            if (!Directory.Exists(path))
                throw new DirectoryNotFoundException();

            var fileNames = Directory.GetFiles(path);

            return fileNames;
        }
        
        private static void ReadFromCsvFile(string[] fileNames)
        {
            foreach (var fileName in fileNames)
            {
                using var reader = new StreamReader(fileName);
                var jsonList = new List<JsonModel>();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    jsonList.Add(MapToJsonModel(values));
                }
            }
        }

        private static JsonModel MapToJsonModel(string[] values)
        {
            var model = new JsonModel
            {
                LocationName = values[0],
                LocationLabel = values[0],
                Timestamp = values[5],
                TimeSeries = "Blue Gate",
                Tenant = "TH",
                Endpoint = values[1],
                Variable = new Variable
                {
                    RSSI = values[3],
                    TokenSerial = values[2],
                    TokenTimestamp = values[4]
                }
            };

            return model;
        }
    }
}
