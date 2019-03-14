using System;

using Services;

namespace RssReaderConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new NewsReader();
            var writer = new DataBaseWriter();

            int generalNewsCount = reader.GetGeneralNewsCount();
            Console.WriteLine($"Was read: {generalNewsCount}");

            var recordCounter = writer.WriteToDataBaseAndReturnCounter();

            Console.WriteLine($"Was written: {recordCounter}");

            Console.ReadLine();
        }
    }
}
