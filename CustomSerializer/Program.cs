using System;
using CustomSerializer.Services;

namespace CustomSerializer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Convertion has started.....!!");

                var operationService = new OperationService();
                operationService.ExecuteReadAndWrite();

                Console.WriteLine("\n\nConvertion Completed Successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
