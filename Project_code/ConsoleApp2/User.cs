using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

/// <summary>
/// This class holds the essential information of the user(customer/admin).
/// </summary>

namespace ConsoleApp2
{
    public class User
    {
        private int id , type;
        private string email, password, firstName , lastName , country , address;
        private DateTime birthdate;

        public User(MySqlDataReader dr)
        {
            id = (int)dr["id"];
            type = (int)dr["type"];
            email = dr["email"].ToString();
            password = dr["password"].ToString();
            firstName = dr["first_name"].ToString();
            lastName = dr["last_name"].ToString();
            country = dr["country"].ToString();
            address = dr["address"].ToString();
            birthdate = (DateTime)dr["birthdate"];
        }

        public int ID
        {
            get { return id; }
        }

        public string Email
        {
            set { email = value; }
            get { return email; }
        }

        public string Password
        {
            set { password = value; }
            get { return password; }
        }

        public string FirstName
        {
            set { firstName = value; }
            get { return firstName; }
        }

        public string LastName
        {
            set { lastName = value; }
            get { return lastName; }
        }

        public string Country
        {
            set { Country = value; }
            get { return Country; }
        }

        public string Address
        {
            set { address = value; }
            get { return address; }
        }

        public DateTime Birthdate
        {
            set { birthdate = value; }
            get { return birthdate; }
        }

        public int Type
        {
            set { type = value; }
            get { return type; }
        }

        public void SaveChanges()
        {
            MySqlConnection con = new MySqlConnection("Server=localhost; database=games_store; UID=root; Password=1111; SslMode=none");
            con.Open();

            string query = "UPDATE user SET first_name = @first , last_name = @last , password = @password" +
                ", type = @type , country = @country , address = @address" +
                " WHERE id = " + id.ToString();

            MySqlCommand com = new MySqlCommand(query, con);

            com.Parameters.AddWithValue("@first", firstName);
            com.Parameters.AddWithValue("@last", lastName);
            com.Parameters.AddWithValue("@password", password);
            com.Parameters.AddWithValue("@type", type);
            com.Parameters.AddWithValue("@country", country);
            com.Parameters.AddWithValue("@address", address);

            com.ExecuteNonQuery();
        }
    }
}
