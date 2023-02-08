using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

/// <summary>
/// A class which implements the common methods between forms and holds the global data 
/// that might be used in more than one form.
/// </summary>

namespace ConsoleApp2
{
    public abstract class Globals
    {
        public static int state = 0;
        public static int wd = 0, ht = 0;
        public static int posX, posY;
        public static ShoppingCart shoppingCart = new ShoppingCart();
        public static List<game> games = new List<game>();
        public static List<game> boughtGames = new List<game>();
        public static List<game> activeGames = new List<game>();
        public static Dictionary<string, List<game>> gameByCategory = new Dictionary<string, List<game>> ();

        public static void LoadGames()
        {
            MySqlConnection con = new MySqlConnection("Server=localhost; database=games_store; UID=root; Password=1111; SslMode=none");
            con.Open();

            string str = "select * from game";
            MySqlDataAdapter adp = new MySqlDataAdapter(str, con);

            DataTable dt = new DataTable();
            adp.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                game gm = new game();
                gm.ID = (int)dt.Rows[i]["id"];
                gm.Name = dt.Rows[i]["name"].ToString();
                gm.Category = dt.Rows[i]["category"].ToString();
                gm.Price = (float)dt.Rows[i]["price"];
                gm.Rating = (float)dt.Rows[i]["rating"];
                gm.Description = dt.Rows[i]["description"].ToString();
                gm.Poster = (byte[])dt.Rows[i]["poster"];

                if (gameByCategory.ContainsKey(gm.Category))
                    gameByCategory[gm.Category].Add(gm);
                else
                {
                    gameByCategory.Add(gm.Category, new List<game>());
                    gameByCategory[gm.Category].Add(gm);
                }

                games.Add(gm);
            }

            activeGames = games;
            con.Close();
        } //When the program runs, this should be called

        public static void ModifySize(Form frm)
        {
            int tmpX = posX, tmpY = posY;
            frm.Size = new Size(wd, ht);

            frm.Location = new Point(tmpX, tmpY);
            posX = tmpX; posY = tmpY;
        }
    }
}
