using BlackJack.BusinessLogic.Services;
using BlackJack.ViewLayer.ViewModels;
using System;
using System.Collections.Generic;

namespace BlackJack.ViewLayer.Steps
{
    public class PlayerMenu
    {

        private PlayerService _playerService;
        public Player Player { get; set; }

        public PlayerMenu()
        {
            _playerService = new PlayerService();
        }

        public void Start()
        {
            ClearPage();
            byte userChoice = ShowMenu();
            AcceptChoice(userChoice);
            Player = Mapper.ToViewModel(_playerService.Player);
        }

        private void ClearPage()
        {
            Console.Clear();
            Console.WriteLine("Меню игрока:");
        }

        private byte ShowMenu()
        {
            if (_playerService.GetIsEmpty())
            {
                Console.WriteLine("Для начала нужно добавить аккаунт");
                return 0;
            }
            Console.WriteLine("0 - Новый игрок");
            Console.WriteLine("1 - Выбрать игрока");
            return GetChoiсe();
        }

        private byte GetChoiсe()
        {
            string userChoiseString = Console.ReadLine();
            if (!((userChoiseString == "1") || (userChoiseString == "0")))
            {
                Console.WriteLine("Ошибка! Введите 0 или 1!");
                return GetChoiсe();
            }
            return Convert.ToByte(userChoiseString);
        }

        private void AcceptChoice(byte userChoise)
        {
            ClearPage();
            if (userChoise == 1)
            {
                ShowListPlayers();
                SelectPlayer();
            }
            if (userChoise == 0)
            {
                CreatePlayer();
            }
        }

        private void SelectPlayer()
        {           
            Console.WriteLine("Введите имя игрока: ");
            string name = Console.ReadLine();
            try
            {
                _playerService.Select(name);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                SelectPlayer();
            }
        }

        private void ShowListPlayers()
        {
            Console.WriteLine("Список игроков: ");
            IEnumerable<Player> listPlayers = Mapper.ToViewModel(_playerService.ShowListPlayers());
            foreach (Player player in listPlayers)
            {
                Console.WriteLine($"{player.Id}: {player.Name};");
            }
        }

        private void CreatePlayer()
        {
            Console.Write("Введите имя игрока: ");
            string name = Console.ReadLine();
            try
            {
                _playerService.Create(name);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                CreatePlayer();
            }
        }

    }
}
