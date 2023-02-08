using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

/// <summary>
/// Admin class, this class is a sub class of User class, it holds no attributes more 
/// than customer class.
/// </summary>

namespace ConsoleApp2
{
    public class Admin : User
    {
        public Admin(MySqlDataReader dr) : base(dr)
        {

        }

        public void AddGame(game gm)
        {
            MySqlConnection con = new MySqlConnection("Server=localhost; database=games_store; UID=root; Password=1111; SslMode=none");
            con.Open();

            string query = "SELECT COUNT(*) FROM game";
            MySqlCommand com = new MySqlCommand(query, con);

            Int64 curID = 1;
            MySqlDataReader reader = com.ExecuteReader();
            if (reader.Read())
            {
                curID = (Int64)reader[0] + 1;
            }
            reader.Close();

            query = "INSERT INTO game (id , name , category , price , rating , description,  poster)" +
                " VALUES(@id , @name, @category, @price, @rating, @description, @poster)";

            gm.ID = (int)curID;
            com = new MySqlCommand(query, con);
            com.Parameters.AddWithValue("@id", gm.ID);
            com.Parameters.AddWithValue("@name", gm.Name);
            com.Parameters.AddWithValue("@category", gm.Category);
            com.Parameters.AddWithValue("@price", gm.Price);
            com.Parameters.AddWithValue("@rating", gm.Rating);
            com.Parameters.AddWithValue("@description", gm.Description);
            com.Parameters.AddWithValue("@poster", gm.Poster);
            com.ExecuteNonQuery();

            Globals.games.Add(gm);
            if (Globals.gameByCategory.ContainsKey(gm.Category))
                Globals.gameByCategory[gm.Category].Add(gm);
            else
            {
                Globals.gameByCategory.Add(gm.Category, new List<game>());
                Globals.gameByCategory[gm.Category].Add(gm);
            }
        }

        public void EditGame(game currentGame)
        {
            string query = "UPDATE game SET name=@name, category=@category, " +
               "rating =@rating , description =@description , price =@price " +
               "WHERE id =@id";

            MySqlConnection con = new MySqlConnection("Server=localhost; database=games_store; UID=root; Password=1111; SslMode=none");
            con.Open();

            MySqlCommand mq = new MySqlCommand(query, con);
            mq.Parameters.AddWithValue("@name", currentGame.Name);
            mq.Parameters.AddWithValue("@category", currentGame.Category);
            mq.Parameters.AddWithValue("@rating", currentGame.Rating);
            mq.Parameters.AddWithValue("@description", currentGame.Description);
            mq.Parameters.AddWithValue("@price", currentGame.Price);
            mq.Parameters.AddWithValue("@id", currentGame.ID);

            mq.ExecuteNonQuery();
            con.Close();
        }
    }
}
