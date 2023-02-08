using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Globalization;

/// <summary>
/// The form which display the whole data of a specific game.
/// </summary>

namespace ConsoleApp2
{
    public partial class GameData : Form
    {
        private game currentGame;
        private dynamic user;

        public GameData(dynamic userPass , game gm)
        {
            InitializeComponent();
            currentGame = gm;
            user = userPass;

            textBoxGameName.Text = gm.Name;
            textBoxCategory.Text = gm.Category;
            comboBoxCategory.Text = gm.Category;
            comboBoxCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRate.DropDownStyle = ComboBoxStyle.DropDownList;
            double rating = Math.Round(gm.Rating, 1);
            textBoxRating.Text = rating.ToString();
            textBoxDescription.Text = gm.Description;
            textBoxPrice.Text = gm.Price.ToString() + " $";

            MemoryStream ms = new MemoryStream(gm.Poster);
            pictureBox1.Image = Image.FromStream(ms);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //this.FormBorderStyle = FormBorderStyle.FixedDialog;
            
            if (user is Customer) //Not admin 
            {
                btnEdit.Visible = false;
                textBoxGameName.ReadOnly = true;
                textBoxCategory.ReadOnly = true;
                textBoxRating.ReadOnly = true;
                textBoxDescription.ReadOnly = true;
                textBoxPrice.ReadOnly = true;
                comboBoxCategory.Visible = false;
            }
            else //Admin
            {
                textBoxGameName.BorderStyle = BorderStyle.FixedSingle;
                textBoxCategory.BorderStyle = BorderStyle.FixedSingle;
                textBoxRating.BorderStyle = BorderStyle.FixedSingle;
                textBoxDescription.BorderStyle = BorderStyle.FixedSingle;
                textBoxPrice.BorderStyle = BorderStyle.FixedSingle;
                textBoxCategory.Visible = false;
                btnAddShoppingCart.Visible = false;
                comboBoxCategory.Visible = true;
                comboBoxRate.Visible = false;
                btnRate.Visible = false;
            }

            Globals.ModifySize(this);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            currentGame.Name = textBoxGameName.Text;
            currentGame.Category = comboBoxCategory.Text;
            currentGame.Rating = float.Parse(textBoxRating.Text, CultureInfo.InvariantCulture.NumberFormat);
            currentGame.Description = textBoxDescription.Text;

            string price = "";
            for (int i = 0; i < textBoxPrice.Text.Length; i++)
            {
                if (textBoxPrice.Text[i] == '$')
                    break;
                price += textBoxPrice.Text[i];
            }
            currentGame.Price = float.Parse(price, CultureInfo.InvariantCulture.NumberFormat);

            user.EditGame(currentGame);

            MessageBox.Show("Game has been edited successfully");
        }

        private void btnAddShoppingCart_Click(object sender, EventArgs e)
        {
            if (Globals.shoppingCart.games.Count == 15)
            {
                MessageBox.Show("You can't add more than 15 item in the shopping cart");
                return;
            }
            Globals.shoppingCart.addGame(currentGame);
        }

        private void GameData_Move(object sender, EventArgs e)
        {
            Globals.wd = this.Width;
            Globals.ht = this.Height;
            Globals.posX = this.Location.X;
            Globals.posY = this.Location.Y;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void GameData_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnRate_Click(object sender, EventArgs e)
        {
            string rate = comboBoxRate.Text;
            if (rate == "")
            {
                MessageBox.Show("You must choose a rate first !!");
                return;
            }
        
            user.RateGame(currentGame , rate);
            MessageBox.Show("Game has been rated successfully");
            textBoxRating.Text = currentGame.Rating.ToString();
        }

        private void GameData_Load(object sender, EventArgs e)
        {
        }

        private void GameData_Resize(object sender, EventArgs e)
        {
            Globals.wd = this.Width;
            Globals.ht = this.Height;
            Globals.posX = this.Location.X;
            Globals.posY = this.Location.Y;
        }
    }
}
