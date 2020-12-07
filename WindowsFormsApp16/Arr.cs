﻿using Guna.UI.WinForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp16
{
    class Arr
    {
        public int[,] ReadArray(string filename)
        {
            int[,] result = null;

            using (var reader = new StreamReader(filename))
            {
                var line = reader.ReadLine();
                var values = line.Split(' ').Select(int.Parse).ToArray();
                int n = values[0], m = values[1];
                while (true)
                if (n == 6 && m == 6 || n == 8 && m == 8 || n == 10 && m == 10)
                {
                    result = new int[n, m];

                    for (int i = 0; i < n; i++)
                    {
                        line = reader.ReadLine();
                        values = line.Split(' ').Select(int.Parse).ToArray();

                        for (int j = 0; j < m; j++)
                            result[i, j] = values[j];
                    }
                        break;
                }
                else
                    {
                        return result;
                    }
            }

            return result;
        }
        public GunaPictureBox[,] pic(int raz,string fon,string pers)
        {
            int x=0;
            int y = 34;
            GunaPictureBox[,] guna = new GunaPictureBox[raz,raz];
            for (int i = 0; i < raz; i++)
            {
                for (int j = 0; j < raz; j++)
                {
                    GunaPictureBox pic = new GunaPictureBox();
                    System.Drawing.Point sys = new System.Drawing.Point(x,y);
                    pic.Location = sys;
                    x+= 100;
                    System.Drawing.Size si = new System.Drawing.Size(100,100);
                    pic.Size=si;
                    System.Drawing.Image imag2 = System.Drawing.Image.FromFile(@fon);
                    pic.Image = imag2;                    
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    guna[i, j] = pic;
                    pic.Visible = true;
                }
                y += 100;
                x = 0;
            }
            System.Drawing.Image imag = System.Drawing.Image.FromFile(@pers);
            guna[0,0].Image = imag;
            imag = System.Drawing.Image.FromFile(@"D:\end.jpg");
            guna[raz-1,raz-1].Image=imag;
            return guna;
        }
        public GunaPictureBox Defolt(System.Drawing.Point sys)
        {
            GunaPictureBox pic = new GunaPictureBox();
            pic.Location = sys;
            System.Drawing.Size si = new System.Drawing.Size(100, 100);
            pic.Size = si;
            System.Drawing.Image imag2 = System.Drawing.Image.FromFile(@"D:\Вода.png");
            pic.Image = imag2;
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            pic.Visible = true;
            return pic;
        }
        public GunaPictureBox Defolt(System.Drawing.Point sys,string par)
        {
            GunaPictureBox pic = new GunaPictureBox();
            pic.Location = sys;
            System.Drawing.Size si = new System.Drawing.Size(100, 100);
            pic.Size = si;
            System.Drawing.Image imag2 = System.Drawing.Image.FromFile(par);
            pic.Image = imag2;
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            pic.Visible = true;
            return pic;
        }
        public GunaPictureBox picture(System.Drawing.Point sys,string pars)
        {
            GunaPictureBox pic = new GunaPictureBox();
            pic.Location = sys;
            System.Drawing.Size si = new System.Drawing.Size(100, 100);
            pic.Size = si;
            System.Drawing.Image imag = System.Drawing.Image.FromFile(pars);
            pic.Image = imag;                    
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            pic.Visible = true;
            return pic;
        }

    }
}
