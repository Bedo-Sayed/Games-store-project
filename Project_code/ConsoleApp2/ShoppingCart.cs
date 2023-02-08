using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// This class holds the current added games in the shopping cart during the run time.
/// </summary>

namespace ConsoleApp2
{
    public class ShoppingCart
    {
        public List<game> games;
        public float totalPrice;

        public ShoppingCart()
        {
            games = new List<game>();
            totalPrice = 0;
        }
        
        public void addGame(game gm)
        {
            games.Add(gm);
            totalPrice += gm.Price;
        }

        public void clear()
        {
            games.Clear();
            totalPrice = 0;
        }
    }
}
