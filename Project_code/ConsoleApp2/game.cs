using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

/// <summary>
/// The class which holds the information of a game.
/// </summary>

namespace ConsoleApp2
{
    public class game
    {
        private int id;
        private string name, category, description;
        private float price, rating;
        private byte[] poster;

        public game()
        {

        }

        public game(MySqlDataReader dr)
        {
            ID = (int)dr["id"];
            Name = dr["name"].ToString();
            Category = dr["category"].ToString();
            Price = (float)dr["price"];
            Rating = (float)dr["rating"];
            Description = dr["description"].ToString();
            Poster = (byte[])dr["poster"];
        }

        public int ID
        {
            set { id = value; }
            get { return id; }
        }

        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        public string Category
        {
            set { category = value; }
            get { return category; }
        }

        public string Description
        {
            set { description = value; }
            get { return description; }
        }

        public float Price
        {
            set { price = value; }
            get { return price; }
        }

        public float Rating
        {
            set { rating = value; }
            get { return rating; }
        }

        public byte[] Poster
        {
            set { poster = value; }
            get { return poster; }
        }
    }
}
