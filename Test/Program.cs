using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            try
            {
                Moraba.Images.Webp.Convert.PngToWebP("test.png", "webp.webp", 440, 200);
                //convert png image to webp and save on local path


                Moraba.Images.Webp.Convert.PngToWebPFromWeb("https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png", "webp.webp", 100, 50);
                //convert web png image to webp and save on local path
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
