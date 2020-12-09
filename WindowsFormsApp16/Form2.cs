using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp16
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            gunaAnimateWindow1.Start();
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            string[] line = new string[9];
            using (var reader = new StreamReader(@"D:\filesettings.txt"))
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.ShowDialog();
                line = reader.ReadToEnd().Split('\n').Select(l => l.Trim()).ToArray();
                line[0] = openFileDialog1.FileName;
            }
            File.WriteAllLines(@"D:\filesettings.txt", line);
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void gunaGradientButton3_Click(object sender, EventArgs e)
        {
            if (gunaTextBox1.Text != "")
            {
                Arr ar = new Arr();
                string[] line = new string[9];
                using (var reader = new StreamReader(@"D:\settings.txt"))
                {
                    line = reader.ReadToEnd().Split('\n').Select(l => l.Trim()).ToArray();
                    var values = int.Parse(line[0]);
                    values = int.Parse(gunaTextBox1.Text);
                    line[0] = values.ToString();
                }
                File.WriteAllLines(@"D:\settings.txt", line.ToArray());
            }
        }

        private void gunaGradientButton4_Click(object sender, EventArgs e)
        {
            if (gunaTextBox2.Text != "")
            {
                Arr ar = new Arr();
                string[] line = new string[9];
                using (var reader = new StreamReader(@"D:\settings.txt"))
                {
                    line = reader.ReadToEnd().Split('\n').Select(l => l.Trim()).ToArray();
                    var values = int.Parse(line[1]);
                    values = int.Parse(gunaTextBox2.Text);
                    line[1] = values.ToString();
                }
                File.WriteAllLines(@"D:\settings.txt", line.ToArray());
            }
        }

        private void gunaGradientButton9_Click(object sender, EventArgs e)
        {
            string[] line = new string[9];
            using (var reader = new StreamReader(@"D:\filesettings.txt"))
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.ShowDialog();
                line = reader.ReadToEnd().Split('\n').Select(l => l.Trim()).ToArray();
                line[3] = openFileDialog1.FileName;
            }
            File.WriteAllLines(@"D:\filesettings.txt", line);
            gunaGradientButton9.Visible = false;
            gunaGradientButton10.Visible = false;
            gunaGradientButton11.Visible = false;
        }

        private void gunaGradientButton10_Click(object sender, EventArgs e)
        {
            string[] line = new string[9];
            using (var reader = new StreamReader(@"D:\filesettings.txt"))
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.ShowDialog();
                line = reader.ReadToEnd().Split('\n').Select(l => l.Trim()).ToArray();
                line[4] = openFileDialog1.FileName;
            }
            File.WriteAllLines(@"D:\filesettings.txt", line);
            gunaGradientButton9.Visible = false;
            gunaGradientButton10.Visible = false;
            gunaGradientButton11.Visible = false;
        }

        private void gunaGradientButton11_Click(object sender, EventArgs e)
        {
            string[] line = new string[9];
            using (var reader = new StreamReader(@"D:\filesettings.txt"))
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.ShowDialog();
                line = reader.ReadToEnd().Split('\n').Select(l => l.Trim()).ToArray();
                line[5] = openFileDialog1.FileName;
            }
            File.WriteAllLines(@"D:\filesettings.txt", line);
            gunaGradientButton9.Visible = false;
            gunaGradientButton10.Visible = false;
            gunaGradientButton11.Visible = false;
        }

        private void gunaGradientButton5_Click(object sender, EventArgs e)
        {
            gunaGradientButton9.Visible = true;
            gunaGradientButton10.Visible = true;
            gunaGradientButton11.Visible = true;
            gunaGradientButton12.Visible = false;
            gunaGradientButton13.Visible = false;
        }

        private void gunaGradientButton2_Click(object sender, EventArgs e)
        {
            string[] line = new string[9];
            using (var reader = new StreamReader(@"D:\filesettings.txt"))
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.ShowDialog();
                line = reader.ReadToEnd().Split('\n').Select(l => l.Trim()).ToArray();
                line[6] = openFileDialog1.FileName;
            }
            File.WriteAllLines(@"D:\filesettings.txt", line);
        }

        private void gunaGradientButton8_Click(object sender, EventArgs e)
        {
            gunaGradientButton12.Visible = true;
            gunaGradientButton13.Visible = true;
            gunaGradientButton9.Visible = false;
            gunaGradientButton10.Visible = false;
            gunaGradientButton11.Visible = false;
        }
        private void gunaGradientButton12_Click(object sender, EventArgs e)
        {
            string[] line = new string[9];
            using (var reader = new StreamReader(@"D:\filesettings.txt"))
            {
                line = reader.ReadToEnd().Split('\n').Select(l => l.Trim()).ToArray();
                line[7] = "true";
            }
            File.WriteAllLines(@"D:\filesettings.txt", line);
            gunaGradientButton12.Visible = false;
            gunaGradientButton13.Visible = false;
        }
        private void gunaGradientButton13_Click(object sender, EventArgs e)
        {
            string[] line = new string[9];
            using (var reader = new StreamReader(@"D:\filesettings.txt"))
            {
                line = reader.ReadToEnd().Split('\n').Select(l => l.Trim()).ToArray();
                line[7] = "false";
            }
            File.WriteAllLines(@"D:\filesettings.txt", line);
            gunaGradientButton12.Visible = false;
            gunaGradientButton13.Visible = false;
        }
    }
}
