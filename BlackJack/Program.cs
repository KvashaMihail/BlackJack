using System;
using BlackJack.DAL.Repositories;
using BlackJack.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Program
    {
        
        static Card card = new Card{  Value =10, Suit = 2 };
        
        static void Main(string[] args)
        {
            EFUnitOfWork eFUnitOfWork = new EFUnitOfWork(@"data source=(localdb)\MSSQLLocalDB;Initial Catalog=userstore;Integrated Security=True;");
            eFUnitOfWork.Cards.Create(card);
        }
    }
}
