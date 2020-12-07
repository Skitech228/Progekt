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
        GunaPictureBox[] a = new GunaPictureBox[32];
        int[,] mas=new int[6,6];
        public Form1()
        {
            InitializeComponent();
            gunaAnimateWindow1.Start();
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    mas[i, j] = 0;
                }
            }
            mas[0,0]=1;
            int[,] mas2 = new int[6, 6];
            Arr arr = new Arr();
            mas2=arr.ReadArray("1.txt");
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (mas[i, j] == 0)
                        mas[i, j] = mas2[i, j];
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
        private void Initial()
        {
            a[0] = gunaPictureBox1; a[1] = gunaPictureBox2; a[2] = gunaPictureBox3; a[3] = gunaPictureBox4; a[4] = gunaPictureBox5; a[5] = gunaPictureBox6;
            a[6] = gunaPictureBox7; a[7] = gunaPictureBox8; a[8] = gunaPictureBox9; a[9] = gunaPictureBox10; a[10] = gunaPictureBox11; a[11] = gunaPictureBox12;
            a[12] = gunaPictureBox13; a[13] = gunaPictureBox14; a[32] = gunaPictureBox33; a[33] = gunaPictureBox34; a[34] = gunaPictureBox35; a[35] = gunaPictureBox36;
            a[14] = gunaPictureBox15; a[15] = gunaPictureBox16; a[16] = gunaPictureBox17; a[17] = gunaPictureBox18; a[18] = gunaPictureBox19; a[19] = gunaPictureBox20;
            a[20] = gunaPictureBox21; a[21] = gunaPictureBox22; a[22] = gunaPictureBox23; a[23] = gunaPictureBox24; a[24] = gunaPictureBox25; a[25] = gunaPictureBox26;
            a[26] = gunaPictureBox27; a[27] = gunaPictureBox28; a[28] = gunaPictureBox29; a[29] = gunaPictureBox30; a[30] = gunaPictureBox31; a[31] = gunaPictureBox32;
        }
        private void Apdate()
        {
            for (int i = 1; i < 7; i++)
            {
                for (int j = 1; j < 7; j++)
                {
                    if (mas[i - 1, j - 1] == 1)
                        a[i * j - 1].Image = Image.FromFile(@"parrot_PNG713.png");
                }
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {        

        }

        private void gunaTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            int u = 0, o = 0;
            //if (gunaPictureBox1.Top <= f.Top + 100 && gunaPictureBox1.Bottom <= f.Bottom + 100 && gunaPictureBox1.Right <= f.Right + 100 && gunaPictureBox1.Width <= f.Width + 100)
            //{

            if (e.KeyCode == Keys.Left)
            {
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (mas[i, j] == 1)
                            u = i; o = j;
                    }
                }
                if (o != 0)
                    if (mas[u, o - 1] == 0)
                    {
                        mas[u, o] = 0;
                        mas[u, o - 1] = 1;
                    }
            }
            if (e.KeyCode == Keys.D)
            {
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (mas[i, j] == 1)
                            u = i; o = j;
                    }
                }
                if (o != 5)
                    if (mas[u, o + 1] != 0)
                    {
                        mas[u, o] = 0;
                        mas[u, o + 1] = 1;
                    }
            }
            Apdate();
            // }
        }
    }
}
