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

/// <summary>
/// This form displays some of the information of the user. Also the user can change some information
/// through this form.
/// </summary>

namespace ConsoleApp2
{
    public partial class UserProfile : Form
    {
        private dynamic user;

        public UserProfile(dynamic userPass)
        {
            InitializeComponent();

            user = userPass;
            Globals.ModifySize(this);

            textBoxEmail.Text = user.Email;
            textBoxFirstName.Text = user.FirstName;
            textBoxLastName.Text = user.LastName;
            textBoxBirthdate.Text = user.Birthdate.Date.ToShortDateString();
            textBoxEmail.ReadOnly = true;
            textBoxBirthdate.ReadOnly = true;
            textBoxBalance.ReadOnly = true;

            if (user.Type > 0)
                textBoxBalance.Text = user.RemainingMoney.ToString() + " $";
            else //admin
            { 
                textBoxBalance.Text = "0 $";
                btnMyBoughtGames.Visible = false; 
            }
        }

        private void UserProfile_Load(object sender, EventArgs e)
        {

        }

        private void UserProfile_Move(object sender, EventArgs e)
        {
            Globals.wd = this.Width;
            Globals.ht = this.Height;
            Globals.posX = this.Location.X;
            Globals.posY = this.Location.Y;
        }

        private void UserProfile_Resize(object sender, EventArgs e)
        {
            Globals.wd = this.Width;
            Globals.ht = this.Height;
            Globals.posX = this.Location.X;
            Globals.posY = this.Location.Y;
        }

        private void UserProfile_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose(false);
        }

        private void btnChangeFirstName_Click(object sender, EventArgs e)
        {
            user.FirstName = textBoxFirstName.Text;
            user.SaveChanges();
            MessageBox.Show("First name has been updated");
        }

        private void btnChangeLastName_Click(object sender, EventArgs e)
        {
            user.LastName = textBoxLastName.Text;
            user.SaveChanges();
            MessageBox.Show("Last name has been updated");
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

        private void btnSavePass_Click(object sender, EventArgs e)
        {
            if (user.Password != textBoxOldPass.Text)
                MessageBox.Show("Old Password is not correct");
            else if (!IsValidPassword(textBoxNewPass.Text))
                MessageBox.Show("The password must have at least one uppercase letter, one lowercase letter and one digit");
            else if (textBoxNewPass.Text != textBoxConfirmPass.Text)
                MessageBox.Show("Passwords are not identical");
            else
            {
                user.Password = textBoxNewPass.Text;
                user.SaveChanges();
                MessageBox.Show("Password has been updated successfully");
                textBoxOldPass.Text = "";
                textBoxNewPass.Text = "";
                textBoxConfirmPass.Text = "";
            }
        }

        private void btnMyBoughtGames_Click(object sender, EventArgs e)
        {
            user.ViewGames();

            BoughtGames frm = new BoughtGames(user);
            this.Hide();
            frm.ShowDialog();
            Globals.ModifySize(this);
            this.Show();
        }
    }
}
