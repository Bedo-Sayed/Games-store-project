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

/// <summary>
/// This form displays all of the currently added games to the shopping cart.
/// In this form, the customer can remove a game from the shopping cart and can 
/// confirm the purchase.
/// </summary>

namespace ConsoleApp2
{
    public partial class ShoppingCartForm : Form
    {
        private List<PictureBox> gamesPic = new List<PictureBox>();
        Customer cus;
        float total = 0;

        public ShoppingCartForm(dynamic cusPass)
        {
            InitializeComponent();

            cus = cusPass;
            for (int i = 0; i < Globals.shoppingCart.games.Count; i++)
            {
                total += Globals.shoppingCart.games[i].Price;

                int posX = i % 5, posY = i / 5;
                game gm = Globals.shoppingCart.games[i];

                MemoryStream ms = new MemoryStream(gm.Poster);
                string name = string.Format("pic{0}", i);
                PictureBox pic = new PictureBox();
                pic.Name = name;
                pic.Image = Image.FromStream(ms);
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Dock = DockStyle.Fill;
                
                int rem = i;
                foreach (Control c in tableLayoutPanel.Controls)
                {
                    if (rem == 0)
                    {

                        TableLayoutPanel tmp = (TableLayoutPanel)(c);
                        tmp.Controls.Add(pic, 0, 0);
                        name = string.Format("btnRemove{0}", i);
                        Button btn = new Button();
                        btn.Name = name;
                        btn.BackColor = Color.Red;
                        btn.ForeColor = Color.White;
                        btn.Text = "Remove from cart";
                        btn.Font = new Font(btn.Font, FontStyle.Bold);
                        btn.FlatStyle = FlatStyle.Popup;
                        btn.FlatAppearance.BorderSize = 0;
                        btn.Click += new EventHandler(this.btn_Click);
                        btn.Dock = DockStyle.Fill;
                        tmp.Controls.Add(btn , 0 , 1);
                        break;
                    }
                    rem--;
                }
            }

            labelTotalPrice.Text = "Total = " + total.ToString() + " $";
            Globals.ModifySize(this);   
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int gameIdx = 0;
            for (int i = 0; i < btn.Name.Length; i++)
            {
                if (btn.Name[i] >= '0' && btn.Name[i] <= '9')
                {
                    gameIdx = gameIdx * 10 + btn.Name[i] - '0';
                }
            }

            Globals.shoppingCart.games.RemoveAt(gameIdx);
            ShoppingCartForm frm = new ShoppingCartForm(cus);
            this.Hide();
            frm.ShowDialog();
            this.Dispose(false);
        }

        private void ShoppingCartForm_Load(object sender, EventArgs e)
        {
        }

        private void ShoppingCartForm_Resize(object sender, EventArgs e)
        {
            Globals.wd = this.Width;
            Globals.ht = this.Height;
            Globals.posX = this.Location.X;
            Globals.posY = this.Location.Y;
        }

        private void ShoppingCartForm_Move(object sender, EventArgs e)
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

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (Globals.shoppingCart.games.Count == 0)
            {
                MessageBox.Show("Shopping Cart is empty!");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to buy these items?", "Confirm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
                return;

            if (cus.RemainingMoney < total)
            {
                dialogResult = MessageBox.Show("You don't have enough money" , "Sad" , MessageBoxButtons.OK);
                return;
            }

            cus.BuyGames(total);

            Globals.shoppingCart.games.Clear();
            ShoppingCartForm frm = new ShoppingCartForm(cus);
            this.Hide();
            frm.ShowDialog();
            this.Dispose(false);
        }

        private void ShoppingCartForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
