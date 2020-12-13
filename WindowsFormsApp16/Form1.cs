using Guna.UI.WinForms;
using MathNet.Numerics.LinearAlgebra;
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
    public partial class Form1 : Form
    {
        #region Settings
        public string pers = new Arr().Pers();
        public string hard = @"C:\Users\Skitech\source\repos\Skitech228\Progekt\WindowsFormsApp16\bin\Debug\Pict\serce_plamya.png";
        public string fon = @"C:\Users\Skitech\source\repos\Skitech228\Progekt\WindowsFormsApp16\bin\Debug\Pict\YP\fon\Вода.png";
        public string bot = new Arr().Bot();
        public string setting = new Arr().Setting();
        GunaPictureBox[,] a;
        GunaPictureBox[] hards;
        public int[,] mas;
        public int[] hardsmas;
        GunaPictureBox guna = new GunaPictureBox();
        #endregion

        #region Fors
        public Form1()
        {
            InitializeComponent();
            gunaAnimateWindow1.Start();
            if (setting == "true")
            {
                gunaButton2.Visible = true;
                gunaComboBox1.Visible = true;
            }
            Arr ar = new Arr();
            pers = @ar.Pers();
            a = ar.pic(6,fon,pers);
            foreach (var item in a)
            {
                this.Controls.Add(item);
            }
            mas = ar.ReadArray(ar.pars(1));
            hardsmas = new int[ar.Hards("settings.txt")];
            hards = ar.hards(hardsmas.Length, hard);
            foreach (var item in hards)
            {
                this.Controls.Add(item);
            }
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (mas[i, j] == 2)
                    {
                        guna=ar.picture(a[i,j].Location, @"C:\Users\Skitech\source\repos\Skitech228\Progekt\WindowsFormsApp16\bin\Debug\Pict\YP\prep\gratis-png-arbol-de-navidad-ano-nuevo-arbol-dibujo-pino-arbol-de-navidad.png");
                        this.Controls.Remove(a[i,j]);
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
            foreach (var item in a)
            {
                this.Controls.Remove(item);
            }
            Arr ar = new Arr();
            pers = @ar.Pers();
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    this.Controls.Remove(a[i, j]);
                }
            }
            a = ar.pic(6, fon, pers);
            foreach (var item in a)
            {
                this.Controls.Add(item);
            }
            mas = ar.ReadArray(ar.pars(1));
            hardsmas = new int[ar.Hards("settings.txt")];
            hards = ar.hards(hardsmas.Length, hard);
            foreach (var item in hards)
            {
                this.Controls.Add(item);
            }
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (mas[i, j] == 2)
                    {
                        guna = ar.picture(a[i, j].Location, @"C:\Users\Skitech\source\repos\Skitech228\Progekt\WindowsFormsApp16\bin\Debug\Pict\YP\prep\gratis-png-arbol-de-navidad-ano-nuevo-arbol-dibujo-pino-arbol-de-navidad.png");
                        this.Controls.Remove(a[i, j]);
                        a[i, j] = guna;
                        this.Controls.Add(a[i, j]);
                    }
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

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
            if (gunaComboBox1.Text == "2")
            {
                Form3 f = new Form3();
                f.Show();
                this.Hide();
            }
            if (gunaComboBox1.Text == "3")
            {
                Form4 f = new Form4();
                f.Show();
                this.Hide();
            }
        }

        #endregion

        #region Keys
        private void gunaTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            KeysDown(e);
        }

        private void KeysDown(KeyEventArgs e)
        {
            bool f = false;
            Arr ar = new Arr();
            int j = 0;
            if (e.KeyData == Keys.Down)
                for (int i = 0; i < 6; i++)
                {
                    for (j = 0; j < 6; j++)
                    {
                        if (mas[i, j] == 1 && i != 5)
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
                for (int i = 0; i < 6; i++)
                {
                    for (j = 0; j < 6; j++)
                    {
                        if (mas[i, j] == 1 && j != 5)
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
                for (int i = 0; i < 6; i++)
                {
                    for (j = 0; j < 6; j++)
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
                for (int i = 0; i < 6; i++)
                {
                    for (j = 0; j < 6; j++)
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
            if (mas[5, 5] == 1)
            {
                MessageBox.Show("Вы смогли");
                Form3 form = new Form3();
                //form.gunaAnimateWindow1.AnimationType = Guna.UI.WinForms.GunaAnimateWindow.AnimateWindowType.AW_CENTER;
                form.Show();
                this.Hide();
            }
        }
        private void gunaComboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            KeysDown(e);
        }
        #endregion Keys
    }
}
