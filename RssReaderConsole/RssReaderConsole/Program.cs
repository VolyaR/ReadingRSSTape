using System;

using Services;

namespace RssReaderConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new NewsReader();

            int generalNewsCount = reader.GetGeneralNewsCount();
            Console.WriteLine($"Was read: {generalNewsCount}");

            Console.ReadLine();
        }
    }
}
