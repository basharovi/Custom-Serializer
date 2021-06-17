using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using CustomSerializer.Model;

namespace CustomSerializer.Services
{
    public class OperationService
    {
        public void ExecuteReadAndWrite()
        {
            var filesPath = ReadAllFilesPathFromTheDirectory(Constants.InputDirectory);

            ReadAndWriteFiles(filesPath);
        }

        private static string[] ReadAllFilesPathFromTheDirectory(string path)
        {
            if (!Directory.Exists(path))
                throw new DirectoryNotFoundException();

            var filesPath = Directory.GetFiles(path);

            return filesPath;
        }

        private static void ReadAndWriteFiles(string[] filePaths)
        {
            foreach (var filePath in filePaths)
            {
                //Read
                var jsonString = string.Empty;
                using var reader = new StreamReader(filePath);

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    if (line.Contains("device_id"))
                        continue;

                    var jsonModel = MapToJsonModel(values);
                    jsonString += $"{jsonModel.Endpoint}:{JsonSerializer.Serialize(jsonModel)}\n";
                }

                //Write
                var outputPath = filePath.Replace("Input", "Output").Replace(".csv", ".txt");

                using StreamWriter streamWrite = File.CreateText(outputPath);
                streamWrite.WriteLine(jsonString);
            }
        }

        private static JsonModel MapToJsonModel(string[] values)
        {
            var model = new JsonModel
            {
                LocationName = values[0],
                LocationLabel = values[0],
                TimeSeries = "BlueGate",
                Tenant = "TH",
                Endpoint = values[1],
                Variables = new Variables
                {
                    RSSI = Convert.ToInt32(values[3]),
                    TokenSerial = values[2],
                    TokenTimestamp = ToSpecificFormat(values[4])
                }
            };

            if (values.ElementAtOrDefault(5) != null)
            {
                model.Timestamp = ToSpecificFormat(values[5]);
            }

            return model;
        }

        private static string ToSpecificFormat(string dateTime)
        {
            var formattedDateTime = Convert.ToDateTime(dateTime).ToString("yyyy-MM-dd'T'HH:mm:ss'Z'");
            return formattedDateTime;
        }
    }
}
