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
/// This form shows all the bought games of the current customer.
/// </summary>

namespace ConsoleApp2
{
    public partial class BoughtGames : Form
    {
        private dynamic user;
        private List<PictureBox> gamesPic = new List<PictureBox>();
        private List<Bitmap> imgCopy = new List<Bitmap>();
        private int idx;
        static int bucketIdx = 0;

        public BoughtGames(dynamic userPass)
        {
            InitializeComponent();

            user = userPass;

            int gameCnt = 0;
            for (int i = bucketIdx * 21; i < Math.Min(Globals.boughtGames.Count, (bucketIdx + 1) * 21); i++)
            {
                game gm = Globals.boughtGames[i];
                int rowIdx = gameCnt % 7, colIdx = gameCnt / 7;

                MemoryStream ms = new MemoryStream(gm.Poster);

                string name = string.Format("pic{0}", gameCnt);
                PictureBox pic = new PictureBox();
                pic.Name = name;

                Bitmap org = new Bitmap(ms, false);

                Bitmap bit = new Bitmap(org, 150, 150);
                imgCopy.Add(new Bitmap(bit));

                for (int ii = 0; ii < bit.Width; ii++)
                {
                    for (int j = 0; j < bit.Height; j++)
                    {
                        Color c = bit.GetPixel(ii, j);
                        Color c2 = Color.FromArgb(200, c.R, c.G, c.B);
                        bit.SetPixel(ii, j, c2);
                    }
                }

                pic.Image = bit;

                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Dock = DockStyle.Fill;

                tableLayoutPanel.Controls.Add(pic, rowIdx, colIdx + 1);
                gamesPic.Add(pic);

                idx = gameCnt;
                gamesPic[gameCnt].MouseEnter += new EventHandler(this.picBox_MouseEnter);
                gamesPic[gameCnt].MouseLeave += new EventHandler(this.picBox_MouseLeave);

                gamesPic[gameCnt].Click += new EventHandler(this.picBox_Click);
                gameCnt++;
            }

            Globals.ModifySize(this);
            labelPage.Text = "Page " + (bucketIdx + 1).ToString();
        }

        private void BoughtGames_Load(object sender, EventArgs e)
        {
        }

        private void picBox_MouseEnter(object sender, EventArgs e)
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

            for (int i = 0; i < pc.Image.Width; i++)
            {
                for (int j = 0; j < pc.Image.Height; j++)
                {
                    ((Bitmap)pc.Image).SetPixel(i, j, imgCopy[gameIdx].GetPixel(i, j));
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

        private void picBox_Click(object sender, EventArgs e)
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

            GameData gameDataForm = new GameData(user, Globals.boughtGames[bucketIdx * 21 + gameIdx]);
            this.Hide();
            gameDataForm.ShowDialog();
            this.Show();
            Globals.ModifySize(this);
        }

        private void buttonPrv_Click(object sender, EventArgs e)
        {
            if (bucketIdx == 0) { }
            else
            {
                bucketIdx--;
                BoughtGames cusHome = new BoughtGames(user);
                cusHome.Show();
                this.Dispose(false);
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if ((bucketIdx + 1) * 21 >= Globals.boughtGames.Count) { }
            else
            {
                bucketIdx++;
                BoughtGames cusHome = new BoughtGames(user);
                cusHome.Show();
                this.Dispose(false);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BoughtGames_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void BoughtGames_Resize(object sender, EventArgs e)
        {
            Globals.wd = this.Width;
            Globals.ht = this.Height;
            Globals.posX = this.Location.X;
            Globals.posY = this.Location.Y;
        }

        private void BoughtGames_Move(object sender, EventArgs e)
        {
            Globals.wd = this.Width;
            Globals.ht = this.Height;
            Globals.posX = this.Location.X;
            Globals.posY = this.Location.Y;
        }
    }
}
