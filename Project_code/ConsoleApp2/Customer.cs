using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

/// <summary>
/// This is the customer class, it is a sub class of User class.
/// </summary>

namespace ConsoleApp2
{
    public class Customer : User
    {
        private float remainingMoney;
        private List<game> myGames;

        public Customer(MySqlDataReader dr) : base(dr)
        {
            remainingMoney = (float)(dr["remaining_money"]);
        }

        public float RemainingMoney
        {
            set { remainingMoney = value; }
            get { return remainingMoney; }
        }

        public List<game> MyGames
        {
            get { return myGames; }
        }

        public void BuyGames(float total) 
        {
            MySqlConnection con = new MySqlConnection("Server=localhost; database=games_store; UID=root; Password=1111; SslMode=none");
            con.Open();

            MySqlCommand com;
            string query;
            for (int i = 0; i < Globals.shoppingCart.games.Count; i++)
            {
                query = "SELECT * FROM user_game WHERE user_id = " + this.ID.ToString() +
                    " AND game_id = " + Globals.shoppingCart.games[i].ID.ToString();
                com = new MySqlCommand(query, con);

                MySqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    int tmp = (int)dr["count"] + 1;
                    query = "UPDATE user_game SET count = " + tmp.ToString() + " WHERE " +
                        "user_id = " + this.ID.ToString() + " AND game_id = " +
                         Globals.shoppingCart.games[i].ID.ToString();
                }
                else
                {
                    query = "INSERT INTO user_game VALUES(" + this.ID.ToString() + "," +
                         Globals.shoppingCart.games[i].ID.ToString() + ",1,0)";
                }

                dr.Close();
                com = new MySqlCommand(query, con);
                com.ExecuteNonQuery();
            }

            this.RemainingMoney -= total;
            query = "UPDATE user SET remaining_money = " + this.RemainingMoney.ToString() +
                " WHERE id = " + this.ID.ToString();
            com = new MySqlCommand(query, con);
            com.ExecuteNonQuery();
        }

        public void RateGame(game currentGame , string rate)
        {
            string query = "SELECT * from user_game where user_id = " + ID.ToString() +
                " AND game_id = " + currentGame.ID.ToString();

            MySqlConnection con = new MySqlConnection("Server=localhost; database=games_store; UID=root; Password=1111; SslMode=none");
            con.Open();

            MySqlCommand mq = new MySqlCommand(query, con);

            MySqlDataReader dr = mq.ExecuteReader();
            if (dr.Read())
            {
                dr.Close();
                query = "UPDATE user_game SET rating = " + rate + " WHERE user_id = " + ID.ToString() +
                    " AND game_id = " + currentGame.ID.ToString();
                mq = new MySqlCommand(query, con);
                mq.ExecuteNonQuery();
            }
            else
            {
                dr.Close();
                query = "INSERT INTO user_game VALUES (" + ID.ToString() + "," + currentGame.ID.ToString() +
                    ",0," + rate + ");";
                mq = new MySqlCommand(query, con);
                mq.ExecuteNonQuery();
            }

            query = "SELECT AVG(rating) FROM user_game WHERE game_id = " + currentGame.ID.ToString()
                + " AND rating > 0";
            mq = new MySqlCommand(query, con);
            dr = mq.ExecuteReader();
            dr.Read();

            currentGame.Rating = (float) ((double)dr[0]);

            query = "UPDATE game SET rating = " + currentGame.Rating.ToString() + " " +
                "WHERE id = " + currentGame.ID.ToString();

            dr.Close();
            mq = new MySqlCommand(query, con);
            mq.ExecuteNonQuery();

            con.Close();
        }

        public void ViewGames()
        {
            Globals.boughtGames.Clear();
            MySqlConnection con = new MySqlConnection("Server=localhost; database=games_store; UID=root; Password=1111; SslMode=none");
            con.Open();

            string str = "SELECT * FROM user_game WHERE user_id = " + this.ID.ToString();
            MySqlDataAdapter adp = new MySqlDataAdapter(str, con);

            DataTable dt = new DataTable();
            adp.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string query = "SELECT * FROM game WHERE id = " + dt.Rows[i]["game_id"].ToString();
                int cnt = (int)dt.Rows[i]["count"];

                MySqlCommand com = new MySqlCommand(query, con);
                MySqlDataReader dr = com.ExecuteReader();

                dr.Read();
                game gm = new game(dr);
                for (int j = 0; j < cnt; j++)
                {
                    Globals.boughtGames.Add(gm);
                }

                dr.Close();
            }
        }
    }
}
