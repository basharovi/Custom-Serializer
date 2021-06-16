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
                var operationService = new OperationService();
                operationService.ExecuteReadAndWrite();

                Console.WriteLine("Convertion Completed Successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
