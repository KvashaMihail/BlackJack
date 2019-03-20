using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.ViewLayer.Steps
{
    public class SetSteps
    {
        public PlayerMenu PlayerMenu { get; private set; }
        public GameMenu GameMenu { get; private set; }
        public GamePlay GamePlay { get; private set; }

        public SetSteps()
        {
            PlayerMenu = new PlayerMenu();
            GameMenu = new GameMenu();
            GamePlay = new GamePlay();
        }

        public void ShowStartMessage()
        {
            Console.WriteLine("Игра BlackJack (БлэкДжэк)!");
            Console.WriteLine("Для продолжения нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
