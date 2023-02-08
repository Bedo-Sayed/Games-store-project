using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Globalization;

/// <summary>
/// The first form in the system, in which the user can login/sign up.
/// </summary>

namespace ConsoleApp2
{
    public partial class LoginForm : Form
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost; database=games_store; UID=root; Password=1111; SslMode=none");

        //public object MessageBox { get; private set; }

        public LoginForm()
        {
            InitializeComponent();

            if (Globals.wd == 0 && Globals.ht == 0)
            {
                Globals.wd = this.Width;
                Globals.ht = this.Height;
                Globals.posX = this.Location.X;
                Globals.posY = this.Location.Y;
            }
            Globals.ModifySize(this);
        }


        private void LoginForm_Load(object sender, EventArgs e)
        {
            Globals.LoadGames();
            country.DropDownStyle = ComboBoxStyle.DropDownList;
            var list = CultureInfo.GetCultures(CultureTypes.SpecificCultures).
            Select(p => new RegionInfo(p.Name).EnglishName).
            Distinct().OrderBy(s => s).ToList();
            country.DataSource = list;
            signIn.Visible = false;

            if (Globals.ht > 0 || Globals.wd > 0)
                Globals.ModifySize(this);
        }

        private void signIn_Click(object sender, EventArgs e)
        {
            try
            {
                //string query = "SELECT * FROM `games_store`.`user` WHERE (email =  '" + "bedo6478@gmail.com" + "' and password = '" + "123aA" + "');";
                string query = "SELECT * FROM `games_store`.`user` WHERE (email =  '" + email.Text + "' and password = '" + password.Text + "');";
                MySqlCommand command = new MySqlCommand(query, connection);

                MySqlDataReader reader;
                connection.Open();
                reader = command.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    count++;
                }
                if (count == 0)
                    MessageBox.Show("Password or email is not correct");
                else
                {
                    MessageBox.Show("Welcome");
                    if ((int)reader["type"] == 0) //admin
                    {
                        Admin adm = new Admin(reader);
                        Home frm = new Home(adm);
                        this.Hide();
                        this.Dispose(false);
                        frm.ShowDialog();
                    }
                    else //customer
                    {
                        Customer cus = new Customer(reader);
                        Home frm = new Home(cus);
                        this.Hide();
                        this.Dispose(false);
                        frm.ShowDialog();
                    }
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
            connection.Close();
        }

        private void signUp_Click(object sender, EventArgs e)
        {
            if (!IsValidEmail(email.Text))
                MessageBox.Show("The email is not valid");
            else if (!IsValidPassword(password.Text))
                MessageBox.Show("The password must have at least one uppercase letter, one lowercase letter and one digit");
            else if (!PasswordConfirmation(password.Text, checkPassword.Text))
                MessageBox.Show("Passwords are not identical");
            else
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM user WHERE email = '" + email.Text + "'";

                    MySqlCommand command = new MySqlCommand(query , connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        MessageBox.Show("The email has already been used");
                        connection.Close();
                        return;
                    }
                    if (firstName.Text == "" || lastName.Text == "" || country.Text == "" || address.Text == "")
                    {
                        MessageBox.Show("All fields must be filled");
                        connection.Close();
                        return;
                    }
                    reader.Close();

                    Int64 curID = 1;
                    query = "SELECT COUNT(*) FROM user";
                    string type = "1";
                    if (checkBoxAdmin.Checked) //admin
                        type = "0";

                    command = new MySqlCommand(query, connection);
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        curID = (Int64)reader[0] + 1;
                    }
                    reader.Close();

                    query = "INSERT INTO user (id,email,password,first_name,last_name,birthdate,type,country,address,remaining_money)" +
                        " VALUES(@id ,@email , @password , @first_name , @last_name , @birthdate , @type , @country , @address , @remaining_money)";

                    DateTime theDate = birthday.Value.Date;

                    command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", curID.ToString());
                    command.Parameters.AddWithValue("@email", this.email.Text);
                    command.Parameters.AddWithValue("@password", this.password.Text);
                    command.Parameters.AddWithValue("@first_name", this.firstName.Text);
                    command.Parameters.AddWithValue("@last_name", this.lastName.Text);
                    command.Parameters.AddWithValue("@birthdate", theDate);
                    command.Parameters.AddWithValue("@type", type);
                    command.Parameters.AddWithValue("@country", this.country.Text);
                    command.Parameters.AddWithValue("@address", address.Text);
                    command.Parameters.AddWithValue("@remaining_money", "2500");

                    reader = command.ExecuteReader();
                    connection.Close();

                    MessageBox.Show("You have been registered successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            connection.Close();
        }

        public static List<string> GetCountryList()
        {
            List<string> cultureList = new List<string>();

            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            foreach (CultureInfo culture in cultures)
            {
                RegionInfo region = new RegionInfo(culture.LCID);

                if (!(cultureList.Contains(region.EnglishName)))
                {
                    cultureList.Add(region.EnglishName);
                }
            }
            return cultureList;
        }

        private void country_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void firstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {
        }

        private void password_Click(object sender, EventArgs e)
        {

        }

        private void checkPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkPassword_Click(object sender, EventArgs e)
        {

        }

        private void seePassword_CheckedChanged(object sender, EventArgs e)
        {
            if (password.PasswordChar == '*')
                password.PasswordChar = '\0';
            else
                password.PasswordChar = '*';
        }

        private void seePassword_CheckStateChanged(object sender, EventArgs e)
        {
            if (password.PasswordChar == '*')
                password.PasswordChar = '\0';
            else
                password.PasswordChar = '*';
        }

        private void seeCheckPassword_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkPassword.PasswordChar == '*')
                checkPassword.PasswordChar = '\0';
            else
                checkPassword.PasswordChar = '*';
        }

        private void seePassword_CheckedChanged_1(object sender, EventArgs e)
        {
            if (password.PasswordChar == '*')
                password.PasswordChar = '\0';
            else
                password.PasswordChar = '*';
        }


        private void seeCheckPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPassword.PasswordChar == '*')
                checkPassword.PasswordChar = '\0';
            else
                checkPassword.PasswordChar = '*';
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void password_TextAlignChanged(object sender, EventArgs e)
        {

        }

        public bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        public bool IsValidPassword(string password)
        {
            bool hasUpper = false, hasLower = false, hasNumber = false;
            for (int i = 0; i < password.Length; i++)
            {
                if (Char.IsUpper(password[i]))
                    hasUpper = true;
                if (Char.IsLower(password[i]))
                    hasLower = true;
                if (Char.IsNumber(password[i]))
                    hasNumber = true;
            }
            return hasUpper && hasLower && hasNumber;
        }

        public string PasswordStrength(string password)
        {
            if (password.Length <= 11)
                return "Weak";
            else if (password.Length <= 16)
                return "Medium";
            return "Strong";
        }

        public bool PasswordConfirmation(string essintialPassword, string confirmationPassword)
        {
            if (essintialPassword.Length != confirmationPassword.Length)
                return false;
            for (int i = 0; i < essintialPassword.Length; i++)
            {
                if (essintialPassword[i] != confirmationPassword[i])
                    return false;
            }
            return true;
        }

        private void signInOption_Click(object sender, EventArgs e)
        {
            signUp.Visible = false;
            checkBoxAdmin.Visible = false;
            signIn.Visible = true;
            firstName.Visible = false;
            firstNameLabel.Visible = false;
            lastName.Visible = false;
            lastNameLabel.Visible = false;
            checkPassword.Visible = false;
            checkPasswordLabel.Visible = false;
            seeCheckPassword.Visible = false;
            birthday.Visible = false;
            birthdayLabel.Visible = false;
            country.Visible = false;
            countryLabel.Visible = false;
            address.Visible = false;
            addressLabel.Visible = false;
            email.Text = "";
            password.Text = "";
            seePassword.Checked = false;
            seeCheckPassword.Checked = false;
        }

        private void signUpOption_Click(object sender, EventArgs e)
        {
            signIn.Visible = false;
            signUp.Visible = true;
            checkBoxAdmin.Visible = true;
            firstName.Visible = true;
            firstNameLabel.Visible = true;
            lastName.Visible = true;
            lastNameLabel.Visible = true;
            checkPassword.Visible = true;
            checkPasswordLabel.Visible = true;
            seeCheckPassword.Visible = true;
            birthday.Visible = true;
            birthdayLabel.Visible = true;
            country.Visible = true;
            countryLabel.Visible = true;
            address.Visible = true;
            addressLabel.Visible = true;
            email.Text = "";
            password.Text = "";
            seePassword.Checked = false;
            seeCheckPassword.Checked = false;
        }

        private void signUpOption_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void signUpOption_ControlRemoved(object sender, ControlEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_Resize(object sender, EventArgs e)
        {
            Globals.wd = this.Width;
            Globals.ht = this.Height;
            Globals.posX = this.Location.X;
            Globals.posY = this.Location.Y;
        }

        private void LoginForm_Move(object sender, EventArgs e)
        {
            Globals.wd = this.Width;
            Globals.ht = this.Height;
            Globals.posX = this.Location.X;
            Globals.posY = this.Location.Y;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
