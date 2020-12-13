using Guna.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp16
{
    public partial class Form4 : Form
    {
        #region Settings

        public string pers = new Arr().Pers();
        public string hard = @"C:\Users\Skitech\source\repos\Skitech228\Progekt\WindowsFormsApp16\bin\Debug\Pict\serce_plamya.png";
        public string fon = @"C:\Users\Skitech\source\repos\Skitech228\Progekt\WindowsFormsApp16\bin\Debug\Pict\YP\fon\Вода.png";
        public string bot = new Arr().Bot();
        public string bomb = new Arr().Bomb();
        public int BombSch;
        public string setting = new Arr().Setting();
        GunaPictureBox[,] a;
        GunaPictureBox[] hards;
        public int[,] mas;
        public int[] hardsmas;
        GunaPictureBox guna = new GunaPictureBox();
        Timer tm = null;
        public int BonusSch;
        public string BonusImage = new Arr().Bonus();
        int startValue = new Arr().Time();

        #endregion

        #region Form
        public Form4()
        {
            InitializeComponent();
            if (setting == "true")
            {
                gunaButton2.Visible = true;
                gunaComboBox1.Visible = true;
            }
            Arr ar = new Arr();
            pers = @ar.Pers();
            a = ar.pic(10, fon, pers);
            foreach (var item in a)
            {
                this.Controls.Add(item);
            }
            mas = ar.ReadArray(ar.pars(3));
            hardsmas = new int[ar.Hards("settings.txt")];
            hards = ar.hards(hardsmas.Length, hard);
            foreach (var item in hards)
            {
                this.Controls.Add(item);
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (mas[i, j] == 2)
                    {
                        guna = ar.picture(a[i, j].Location, @"C:\Users\Skitech\source\repos\Skitech228\Progekt\WindowsFormsApp16\bin\Debug\Pict\YP\prep\Tree.jpg");
                        this.Controls.Remove(a[i, j]);
                        a[i, j] = guna;
                        this.Controls.Add(a[i, j]);
                    }
                }
            }
            tm = new Timer();
            tm.Tick += new EventHandler(tm_Tick);
            tm.Interval = 1000;
            tm.Start();
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void UpdateForm()
        {
            setting = new Arr().Setting();
            if (setting == "true")
            {
                gunaButton2.Visible = true;
                gunaComboBox1.Visible = true;
            }
            else
            {
                gunaButton2.Visible = false;
                gunaComboBox1.Visible = false;
            }
            startValue = new Arr().Time();
            foreach (var item in a)
            {
                this.Controls.Remove(item);
            }
            Arr ar = new Arr();
            pers = @ar.Pers();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    this.Controls.Remove(a[i, j]);
                }
            }
            a = ar.pic(10, fon, pers);
            foreach (var item in a)
            {
                this.Controls.Add(item);
            }
            mas = ar.ReadArray(ar.pars(3));
            hardsmas = new int[ar.Hards("settings.txt")];
            hards = ar.hards(hardsmas.Length, hard);
            foreach (var item in hards)
            {
                this.Controls.Add(item);
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (mas[i, j] == 2)
                    {
                        guna = ar.picture(a[i, j].Location, @"C:\Users\Skitech\source\repos\Skitech228\Progekt\WindowsFormsApp16\bin\Debug\Pict\YP\prep\Tree.jpg");
                        this.Controls.Remove(a[i, j]);
                        a[i, j] = guna;
                        this.Controls.Add(a[i, j]);
                    }
                }
            }
        }
        public void UpdateHards()
        {
            Arr ar = new Arr();
            foreach (var item in hards)
            {
                this.Controls.Remove(item);
            }
            hardsmas = new int[ar.Hards("settings.txt")];
            hards = ar.hards(hardsmas.Length, hard);
            foreach (var item in hards)
            {
                this.Controls.Add(item);
            }
        }

        #endregion

        #region Time
        private string Int2StringTime(int time)
        {
            int hours = (time - (time % (60 * 60))) / (60 * 60);
            int minutes = (time - time % 60) / 60 - hours * 60;
            int seconds = time - hours * 60 * 60 - minutes * 60;
            return String.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
        }

        void tm_Tick(object sender, EventArgs e)
        {
            BombBoom();
            if (startValue != 0)
            {
                gunaLabel1.Text = Int2StringTime(startValue);
                startValue--;
            }
            else
            {
                (sender as Timer).Stop();
                (sender as Timer).Dispose();
                MessageBox.Show("Вы не успели");
                Application.Exit();
            }
        }

        private void BombBoom()
        {
            bool f = false;
            if (startValue % 5 == 0)
            {

                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (mas[i, j] == 4)
                        {
                            Arr ar = new Arr();
                            guna = ar.picture(a[i, j].Location, @"C:\Users\Skitech\source\repos\Skitech228\Progekt\WindowsFormsApp16\bin\Debug\Pict\YP\bomb\boom.png");
                            this.Controls.Remove(a[i, j]);
                            a[i, j] = guna;
                            this.Controls.Add(a[i, j]);
                            mas[i, j] = 0;
                            BombSch = 0;
                                if (mas[i, j + 1] == 1 || mas[i, j - 1] == 1 || mas[i + 1, j] == 1 || mas[i - 1, j] == 1)
                                {
                                    ar.Hardsoff();
                                    UpdateHards();
                                    f = true;
                                }
                        }
                        if (f) break;
                    }
                    if (f) break;
                }
            }
        }

        #endregion

        #region Keys

        private void gunaTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDown(e);
            BonusMethod();
            BombMethod();
        }
        private void BonusMethod()
        {
            BonusSch++;
            if (BonusSch == 5)
            {
                Random random = new Random();
                while (true)
                {
                    int i = random.Next(0, 9);
                    int j = random.Next(0, 9);
                    if (mas[i, j] == 0 && i != 9 && j != 9)
                    {
                        Arr ar = new Arr();
                        guna = ar.picture(a[i, j].Location, BonusImage);
                        this.Controls.Remove(a[i, j]);
                        a[i, j] = guna;
                        this.Controls.Add(a[i, j]);
                        mas[i, j] = 3;
                        break;
                    }
                }
            }
        }

        private void BombMethod()
        {
            BombSch++;
            if (BombSch == 5)
            {
                Random random = new Random();
                while (true)
                {
                    int i = random.Next(1, 8);
                    int j = random.Next(1, 8);
                    if (mas[i, j] == 0)
                    {
                        Arr ar = new Arr();
                        guna = ar.picture(a[i, j].Location, bomb);
                        this.Controls.Remove(a[i, j]);
                        a[i, j] = guna;
                        this.Controls.Add(a[i, j]);
                        mas[i, j] = 4;
                        break;
                    }
                }
            }
        }

        private void gunaComboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDown(e);
            BonusMethod();
            BombMethod();
        }

        private void KeyDown(KeyEventArgs e)
        {
            bool f = false;
            Arr ar = new Arr();
            int j = 0;
            if (e.KeyData == Keys.Down)
                for (int i = 0; i < 10; i++)
                {
                    for (j = 0; j < 10; j++)
                    {
                        if (mas[i, j] == 1 && i != 9)
                        {
                            if (mas[i + 1, j] == 4)
                                BombSch = 0;
                                if (mas[i+1, j] == 3)
                            {
                                ar.Hardses();
                                UpdateHards();
                                BonusSch = 0;
                            }
                            if (mas[i + 1, j] != 2)
                            {
                                mas[i, j] = 0;
                                mas[i + 1, j] = 1;
                                guna = ar.Defolt(a[i, j].Location, fon);
                                this.Controls.Remove(a[i, j]);
                                a[i, j] = guna;
                                this.Controls.Add(a[i, j]);
                                guna = ar.Defolt(a[i + 1, j].Location, pers);
                                this.Controls.Remove(a[i + 1, j]);
                                a[i + 1, j] = guna;
                                this.Controls.Add(a[i + 1, j]);
                                f = true;
                            }
                        }
                    }
                    if (f)
                        break;
                }
            if (e.KeyData == Keys.Right)
                for (int i = 0; i < 10; i++)
                {
                    for (j = 0; j < 10; j++)
                    {
                        if (mas[i, j] == 1 && j != 9)
                        {
                            if (mas[i , j+1] == 4)
                                BombSch = 0;
                            if (mas[i, j+1] == 3)
                            {
                                ar.Hardses();
                                UpdateHards();
                                BonusSch = 0;
                            }
                            if (mas[i, j + 1] != 2)
                            {
                                mas[i, j] = 0;
                                mas[i, j + 1] = 1;
                                guna = ar.Defolt(a[i, j].Location, fon);
                                this.Controls.Remove(a[i, j]);
                                a[i, j] = guna;
                                this.Controls.Add(a[i, j]);
                                guna = ar.Defolt(a[i, j + 1].Location, pers);
                                this.Controls.Remove(a[i, j + 1]);
                                a[i, j + 1] = guna;
                                this.Controls.Add(a[i, j + 1]);
                                f = true;
                            }
                        }
                        if (f)
                            break;
                    }
                    if (f)
                        break;
                }
            if (e.KeyData == Keys.Left)
                for (int i = 0; i < 10; i++)
                {
                    for (j = 0; j < 10; j++)
                    {
                        if (mas[i, j] == 1 && j != 0)
                        {
                            if (mas[i , j - 1] == 4)
                                BombSch = 0;
                            if (mas[i, j-1] == 3)
                            {
                                ar.Hardses();
                                UpdateHards();
                                BonusSch = 0;
                            }
                            if (mas[i, j - 1] != 2)
                            {
                                mas[i, j] = 0;
                                mas[i, j - 1] = 1;
                                guna = ar.Defolt(a[i, j].Location, fon);
                                this.Controls.Remove(a[i, j]);
                                a[i, j] = guna;
                                this.Controls.Add(a[i, j]);
                                guna = ar.Defolt(a[i, j - 1].Location, pers);
                                this.Controls.Remove(a[i, j - 1]);
                                a[i, j - 1] = guna;
                                this.Controls.Add(a[i, j - 1]);
                                f = true;
                            }
                        }
                        if (f)
                            break;
                    }
                    if (f)
                        break;
                }
            if (e.KeyData == Keys.Up)
                for (int i = 0; i < 10; i++)
                {
                    for (j = 0; j < 10; j++)
                    {
                        if (mas[i, j] == 1 && i != 0)
                        {
                            if (mas[i - 1, j] == 4)
                                BombSch = 0;
                            if (mas[i-1, j] == 3)
                            {
                                ar.Hardses();
                                UpdateHards();
                                BonusSch = 0;
                            }
                            if (mas[i - 1, j] != 2)
                            {
                                mas[i, j] = 0;
                                mas[i - 1, j] = 1;
                                guna = ar.Defolt(a[i, j].Location, fon);
                                this.Controls.Remove(a[i, j]);
                                a[i, j] = guna;
                                this.Controls.Add(a[i, j]);
                                guna = ar.Defolt(a[i - 1, j].Location, pers);
                                this.Controls.Remove(a[i - 1, j]);
                                a[i - 1, j] = guna;
                                this.Controls.Add(a[i - 1, j]);
                                f = true;
                            }
                        }
                        if (f)
                            break;
                    }
                    if (f)
                        break;
                }
            if (mas[9, 9] == 1)
            {
                MessageBox.Show("Вы победили");
                Application.Exit();
            }
        }

        #endregion

        #region Buttons

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.gunaAnimateWindow1.AnimationType = Guna.UI.WinForms.GunaAnimateWindow.AnimateWindowType.AW_CENTER;
            f.Show();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            UpdateHards();
            UpdateForm();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            if (gunaComboBox1.Text == "1")
            {
                Form1 f = new Form1();
                f.Show();
                this.Hide();
            }
            if (gunaComboBox1.Text == "2")
            {
                Form3 f = new Form3();
                f.Show();
                this.Hide();
            }
        }

        #endregion
    }
}
