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
        public string pers = @"D:\1.png";
        public string fon = @"D:\Вода.png";
        GunaPictureBox[,] a;
        int[,] mas;
        GunaPictureBox guna = new GunaPictureBox();
        public void Update()
        {
            Arr ar = new Arr();
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (mas[i, j] == 1)
                        ar.picture(a[i,j].Location,pers);
                    if (mas[i, j] == 0)
                        ar.picture(a[i, j].Location, fon);
                }
            }
        }
        public Form1()
        {
            InitializeComponent();
            gunaAnimateWindow1.Start();
            Arr ar = new Arr();
            a = ar.pic(6,fon,pers);
            foreach (var item in a)
            {
                this.Controls.Add(item);
            }
            mas = ar.ReadArray(@"D:\2.txt");
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (mas[i, j] == 2)
                    {
                        guna=ar.picture(a[i,j].Location, @"D:\4.jpg");
                        this.Controls.Remove(a[i,j]);
                        a[i, j] = guna;
                        this.Controls.Add(a[i, j]);
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Click(object sender, EventArgs e)
        {
            gunaAnimateWindow1.Start();
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.gunaAnimateWindow1.AnimationType = Guna.UI.WinForms.GunaAnimateWindow.AnimateWindowType.AW_CENTER;
            f.Show();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {        

        }

        private void gunaTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            bool f = false;
            Arr ar = new Arr();
            int j = 0;
            if (e.KeyData==Keys.Down)
                for (int i = 0; i < 6; i++)
                {
                    for (j = 0; j < 6; j++)
                    {
                        if(mas[i,j]==1 && i!=5)
                            if(mas[i+1,j]!=2)
                            {
                                mas[i, j] = 0;
                                mas[i + 1, j] = 1;
                                guna=ar.Defolt(a[i, j].Location, fon);
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
                            if (mas[i,j+1] != 2)
                            {
                                mas[i, j] = 0;
                                mas[i, j+1] = 1;
                                guna = ar.Defolt(a[i, j].Location, fon);
                                this.Controls.Remove(a[i, j]);
                                a[i, j] = guna;
                                this.Controls.Add(a[i, j]);
                                guna = ar.Defolt(a[i, j+1].Location, pers);
                                this.Controls.Remove(a[i, j+1]);
                                a[i, j+1] = guna;
                                this.Controls.Add(a[i, j+1]);
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
                                guna = ar.Defolt(a[i-1, j].Location, pers);
                                this.Controls.Remove(a[i-1, j]);
                                a[i-1, j] = guna;
                                this.Controls.Add(a[i-1, j]);
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
    }
}
