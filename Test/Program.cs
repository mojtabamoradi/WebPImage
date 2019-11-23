using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Moraba.Images.Webp.Convert.PngToWebP("test.png", "webp.webp", 440, 200);
        }
    }
}
