using BlackJack.DAL.EF;
using BlackJack.DAL.Repositories;
using BlackJack.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Services
{
    public class RoundService 
    {
        private readonly RoundRepository _roundRepository;

        public RoundService(BlackJackContext database)
        {
            _roundRepository = new RoundRepository(database);
        }

        public void Create()
        {

        }

        public void Continue()
        {

        }
    }
}
