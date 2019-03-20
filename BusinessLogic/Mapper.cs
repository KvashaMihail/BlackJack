using BlackJack.BusinessLogic.Models;
using System.Collections.Generic;

namespace BlackJack.BusinessLogic
{
    public static class Mapper
    {
        public static Player ToModel(DAL.Entities.Player player)
        {
            Player playerOut = new Player
            {
                Id = player.Id,
                Name = player.Name,
                IsBot = player.IsBot
            };
            return playerOut;
        }

        public static IEnumerable<Player> ToModel(IEnumerable<DAL.Entities.Player> players)
        {
            var playersOut = new List<Player>();
            foreach (DAL.Entities.Player player in players)
            {
                playersOut.Add(ToModel(player));
            }
            return playersOut;
        }

        public static DAL.Entities.Player ToEntity(Player player)
        {
            DAL.Entities.Player playerOut = new DAL.Entities.Player
            {
                Id = player.Id,
                Name = player.Name,
                IsBot = player.IsBot
            };
            return playerOut;
        }


    }
}
