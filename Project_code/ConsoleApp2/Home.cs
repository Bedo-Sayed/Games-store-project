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

/// <summary>
/// The main home form, the first form that appear in the system after the login.
/// </summary>

namespace ConsoleApp2
{
    public partial class Home : Form
    {
        private dynamic user;
        private List<PictureBox> gamesPic = new List<PictureBox>();
        private List<Bitmap> imgCopy = new List<Bitmap>();
        private int idx;
        static int bucketIdx = 0;

        public Home(dynamic userPass)
        {
            InitializeComponent();

            user = userPass;
            if (user is Admin)
            {
                picBoxShoppingCart.Visible = false;
            }

            int gameCnt = 0;
            for(int i = bucketIdx*21; i < Math.Min(Globals.activeGames.Count , (bucketIdx+1)*21); i++)
            {
                game gm = Globals.activeGames[i];
                int rowIdx = gameCnt % 7, colIdx = gameCnt / 7;

                MemoryStream ms = new MemoryStream(gm.Poster);

                string name = string.Format("pic{0}", gameCnt);
                PictureBox pic = new PictureBox();
                pic.Name = name;
                Bitmap org = new Bitmap(ms , false);

                //pic.Image = Image.FromStream(ms);

                Bitmap bit = new Bitmap(org , 150 , 150);
                imgCopy.Add(new Bitmap(bit));

                for(int ii=0; ii<bit.Width; ii++)
                {
                    for(int j=0; j<bit.Height; j++)
                    {
                        Color c = bit.GetPixel(ii, j);
                        Color c2 = Color.FromArgb(200, c.R, c.G, c.B);
                        bit.SetPixel(ii, j, c2);
                    }
                }
            
                pic.Image = bit;

                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Dock = DockStyle.Fill;

                tableLayoutPanel.Controls.Add(pic , rowIdx , colIdx+1);
                gamesPic.Add(pic);

                idx = gameCnt;
                gamesPic[gameCnt].MouseEnter += new EventHandler(this.picBox_MouseEnter);
                gamesPic[gameCnt].MouseLeave += new EventHandler(this.picBox_MouseLeave);

                gamesPic[gameCnt].Click += new EventHandler(this.picBox_Click);
                gameCnt++;
            }

            if (user.Type > 0) //Not admin
            {
                btnAdd.Visible = false;
            }

            if (Globals.wd == 0 && Globals.ht == 0)
            {
                Globals.wd = this.Width;
                Globals.ht = this.Height;
                Globals.posX = this.Location.X;
                Globals.posY = this.Location.Y;
            }
            Globals.ModifySize(this);

            foreach(Control c in tableLayoutPanel1.Controls)
            {
                if (c is Label)
                {
                    if (c.Name == "labelCategory") continue;
                    Label tmp = (Label)c;
                    c.MouseEnter += new EventHandler(this.label_MouseEnter);
                    c.MouseLeave += new EventHandler(this.label_MouseLeave);
                    c.Click += new EventHandler(this.label_MouseClick);
                }
            }
            foreach (Control c in tableLayoutPanel2.Controls)
            {
                if (c is Label)
                {
                    Label tmp = (Label)c;
                    c.MouseEnter += new EventHandler(this.label_MouseEnter);
                    c.MouseLeave += new EventHandler(this.label_MouseLeave);
                    c.Click += new EventHandler(this.label_MouseClick);
                }
            }

            labelPage.Text = "Page " + (bucketIdx + 1).ToString();
        }

        private void Home_Load(object sender, EventArgs e)
        {
        }

        private void label_MouseClick(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            string cat = "";
            for (int i = 0; i < lbl.Text.Length; i++)
            {
                cat += lbl.Text[i];
            }

            if (cat == "All") Globals.activeGames = Globals.games;
            else Globals.activeGames = Globals.gameByCategory[cat];
            bucketIdx = 0;
            Home frm = new Home(user);
            this.Hide();
            frm.ShowDialog();
            this.Dispose(false);
        }

        private void label_MouseEnter(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            lbl.Font = new Font(lbl.Font, FontStyle.Bold);
            lbl.Cursor = Cursors.Hand;
        }

        private void label_MouseLeave(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            lbl.Cursor = Cursors.Arrow;
            lbl.Font = new Font(lbl.Font, FontStyle.Regular);
            this.Refresh();
        }

        private void picBox_MouseEnter(object sender , EventArgs e)
        {
            PictureBox pc = sender as PictureBox;
            //pc.BorderStyle = BorderStyle.Fixed3D;
            pc.Cursor = Cursors.Hand;

            int gameIdx = 0;
            for (int i = 0; i < pc.Name.Length; i++)
            {
                if (pc.Name[i] >= '0' && pc.Name[i] <= '9')
                {
                    gameIdx = gameIdx * 10 + pc.Name[i] - '0';
                }
            }

            for (int i=0; i<pc.Image.Width; i++)
            {
                for(int j=0; j<pc.Image.Height; j++)
                {
                    ((Bitmap)pc.Image).SetPixel(i , j , imgCopy[gameIdx].GetPixel(i, j));
                }
            }
            pc.Refresh();
        }

        private void picBox_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pc = sender as PictureBox;
            //pc.BorderStyle = BorderStyle.None;
            pc.Cursor = Cursors.Arrow;

            int gameIdx = 0;
            for (int i = 0; i < pc.Name.Length; i++)
            {
                if (pc.Name[i] >= '0' && pc.Name[i] <= '9')
                {
                    gameIdx = gameIdx * 10 + pc.Name[i] - '0';
                }
            }

            for (int i = 0; i < pc.Image.Width; i++)
            {
                for (int j = 0; j < pc.Image.Height; j++)
                {
                    Color c = imgCopy[gameIdx].GetPixel(i, j);
                    Color c2 = Color.FromArgb(200, c.R, c.G, c.B);
                    ((Bitmap)pc.Image).SetPixel(i, j, c2);
                }
            }
            pc.Refresh();
        }

        private void picBox_Click(object sender , EventArgs e)
        {
            PictureBox pc = sender as PictureBox;

            int gameIdx = 0;
            for (int i = 0; i < pc.Name.Length; i++)
            {
                if (pc.Name[i] >= '0' && pc.Name[i] <= '9')
                {
                    gameIdx = gameIdx * 10 + pc.Name[i] - '0';
                }
            }

            GameData gameDataForm = new GameData(user , Globals.activeGames[bucketIdx*21+gameIdx]);
            this.Hide();
            gameDataForm.ShowDialog();
            this.Show();
            Globals.ModifySize(this);
        }

        private void Home_Shown(object sender, EventArgs e)
        {
        }

        private void picBoxShoppingCart_Click(object sender, EventArgs e)
        {
            ShoppingCartForm shoppingForm = new ShoppingCartForm(user);
            this.Hide();
            shoppingForm.ShowDialog();
            this.Show();
            Globals.ModifySize(this);
        }

        private void picBoxShoppingCart_MouseEnter(object sender, EventArgs e)
        {
            picBoxShoppingCart.BackColor = Color.Red;
            picBoxShoppingCart.Cursor = Cursors.Hand;
        }

        private void picBoxShoppingCart_MouseLeave(object sender, EventArgs e)
        {
            picBoxShoppingCart.BackColor = this.BackColor;
            picBoxShoppingCart.Cursor = Cursors.Arrow;
        }

        private void Home_Resize(object sender, EventArgs e)
        {
            Globals.wd = this.Width;
            Globals.ht = this.Height;
            Globals.posX = this.Location.X;
            Globals.posY = this.Location.Y;
        }

        private void buttonPrv_Click(object sender, EventArgs e)
        {
            if (bucketIdx == 0) { }
            else
            {
                bucketIdx--;
                Home cusHome = new Home(user);
                cusHome.Show();
                this.Dispose(false);
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if ((bucketIdx + 1) * 21 >= Globals.activeGames.Count) { }
            else
            {
                bucketIdx++;
                Home cusHome = new Home(user);
                cusHome.Show();
                this.Dispose(false);
            }
        }

        private void Home_Move(object sender, EventArgs e)
        {
            Globals.wd = this.Width;
            Globals.ht = this.Height;
            Globals.posX = this.Location.X;
            Globals.posY = this.Location.Y;
        }

        private void picBoxLogOut_MouseEnter(object sender, EventArgs e)
        {
            picBoxLogOut.BackColor = Color.Red;
            picBoxLogOut.Cursor = Cursors.Hand;
        }

        private void picBoxLogOut_MouseLeave(object sender, EventArgs e)
        {
            picBoxLogOut.BackColor = this.BackColor;
            picBoxLogOut.Cursor = Cursors.Arrow;
        }

        private void picBoxLogOut_Click(object sender, EventArgs e)
        {
            bucketIdx = 0;
            this.Hide();
            LoginForm frm = new LoginForm();
            frm.ShowDialog();
            this.Dispose(false);
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddNewGame frm = new AddNewGame(user);
            this.Hide();
            frm.ShowDialog();
            this.Show();
            Globals.ModifySize(this);
        }

        private void Home_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void picBoxProfile_MouseEnter(object sender, EventArgs e)
        {
            picBoxProfile.BackColor = Color.Red;
            picBoxProfile.Cursor = Cursors.Hand;
        }

        private void picBoxProfile_MouseLeave(object sender, EventArgs e)
        {
            picBoxProfile.BackColor = this.BackColor;
            picBoxProfile.Cursor = Cursors.Arrow;
        }

        private void picBoxProfile_Click(object sender, EventArgs e)
        {
            UserProfile frm = new UserProfile(user);
            this.Hide();
            frm.ShowDialog();
            Globals.ModifySize(this);
            this.Show();
        }
    }
}
