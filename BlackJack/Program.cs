using BlackJack.Services;
using System;
using System.Text;


namespace BlackJack
{
    public class Program
    {
        public static TotalService totalService;

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            totalService = new TotalService();
            totalService.Init();
            Console.ReadLine();
        }

    }
}
