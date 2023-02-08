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
using System.Globalization;

/// <summary>
/// The form in which the admin can fill the data of a new game and add it.
/// </summary>

namespace ConsoleApp2
{
    public partial class AddNewGame : Form
    {
        private Admin admin;
        public AddNewGame(Admin adminPass)
        {
            InitializeComponent();
            admin = adminPass;
            Globals.ModifySize(this);
        }

        private void btnLoadPoster_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.ImageLocation = open.FileName;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose(false);
        }

        private void AddNewGame_Move(object sender, EventArgs e)
        {
            Globals.wd = this.Width;
            Globals.ht = this.Height;
            Globals.posX = this.Location.X;
            Globals.posY = this.Location.Y;
        }

        private void AddNewGame_Resize(object sender, EventArgs e)
        {
            Globals.wd = this.Width;
            Globals.ht = this.Height;
            Globals.posX = this.Location.X;
            Globals.posY = this.Location.Y;
        }

        private void AddNewGame_Load(object sender, EventArgs e)
        {
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (pictureBox1==null || pictureBox1.Image == null || textBoxGameName.Text.Length == 0
                || comboBoxCategory.Text.Length == 0 || textBoxDescription.Text.Length == 0 
                || textBoxRating.Text.Length == 0 || textBoxPrice.Text.Length == 0)
            {
                MessageBox.Show("All fields must be filled!");
                return;
            }

            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);

            byte[] img = ms.ToArray();

            game gm = new game();
            gm.Name = textBoxGameName.Text;
            gm.Category = comboBoxCategory.Text;
            gm.Rating = float.Parse(textBoxRating.Text, CultureInfo.InvariantCulture.NumberFormat);
            gm.Description = textBoxDescription.Text;
            gm.Poster = img;
            gm.Price = float.Parse(textBoxPrice.Text, CultureInfo.InstalledUICulture.NumberFormat);
            admin.AddGame(gm);

            MessageBox.Show("The game has been added successfully");
        }

        private void AddNewGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
