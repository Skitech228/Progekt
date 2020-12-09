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
        public string pers = new Arr().Pers();
        public string fon = @"D:\Вода.png";
        public string hard = @"D:\serce_plamya.png";
        public string bot = new Arr().Bot();
        public string setting = new Arr().Setting();
        GunaPictureBox[,] a;
        GunaPictureBox[] hards;
        public int[,] mas;
        public int[] hardsmas;
        GunaPictureBox guna = new GunaPictureBox();
        public Form4()
        {
            InitializeComponent();
            Arr ar = new Arr();
            pers = @ar.Pers();
            a = ar.pic(10, fon, pers);
            foreach (var item in a)
            {
                this.Controls.Add(item);
            }
            mas = ar.ReadArray(ar.pars(3));
            hardsmas = new int[ar.Hards(@"D:\settings.txt")];
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
                        guna = ar.picture(a[i, j].Location, @"D:\4.jpg");
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

        Timer tm = null;
        int startValue = new Arr().Time();

        private string Int2StringTime(int time)
        {
            int hours = (time - (time % (60 * 60))) / (60 * 60);
            int minutes = (time - time % 60) / 60 - hours * 60;
            int seconds = time - hours * 60 * 60 - minutes * 60;
            return String.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
        }

        void tm_Tick(object sender, EventArgs e)
        {
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

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {

        }

        private void gunaTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaTextBox1_KeyDown(object sender, KeyEventArgs e)
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
                    if (f)
                        break;
                }
            if (e.KeyData == Keys.Right)
                for (int i = 0; i < 10; i++)
                {
                    for (j = 0; j < 10; j++)
                    {
                        if (mas[i, j] == 1 && j != 9)
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
    }
}
