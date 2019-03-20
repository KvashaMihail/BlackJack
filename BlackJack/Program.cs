using BlackJack.ViewLayer.Steps;
using System;
using System.Text;


namespace BlackJack.ViewLayer
{
    public class Program
    {
        public static SetSteps setSteps;

        public Program()
        {
            
        }

        static void Main(string[] args)
        {
            setSteps = new SetSteps();
            Console.OutputEncoding = Encoding.UTF8;
            setSteps.ShowStartMessage();
            setSteps.PlayerMenu.Start();
            Console.WriteLine($"Мы зашли за игрока {setSteps.PlayerMenu.Player.Name}. Дальше переход в игровое меню");
            //setSteps.GameStep.StartStep();
            Console.ReadLine();
        }

    }
}
