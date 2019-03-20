using BlackJack.ViewLayer.ViewModels;
using System.Collections.Generic;

namespace BlackJack.ViewLayer
{
    public static class Mapper
    {

        public static Player ToViewModel(BusinessLogic.Models.Player player)
        {
            var playerOut = new Player
            {
                Id = player.Id,
                Name = player.Name,
            };
            return playerOut;
        }

        public static IEnumerable<Player> ToViewModel(IEnumerable<BusinessLogic.Models.Player> players)
        {
            var playersOut = new List<Player>();
            foreach (BusinessLogic.Models.Player player in players)
            {
                playersOut.Add(ToViewModel(player));
            }
            return playersOut;
        }
    }
}
