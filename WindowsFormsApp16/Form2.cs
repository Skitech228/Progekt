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
        #region Form
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            gunaAnimateWindow1.Start();
        }

        #endregion 

        #region Buttons
        //Pers
        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            string[] line = new string[9];
            using (var reader = new StreamReader("filesettings.txt"))
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.ShowDialog();
                line = reader.ReadToEnd().Split('\n').Select(l => l.Trim()).ToArray();
                line[0] = openFileDialog1.FileName;
            }
            File.WriteAllLines("filesettings.txt", line);
        }

        //Hards
        private void gunaGradientButton3_Click(object sender, EventArgs e)
        {
            if (gunaTextBox1.Text != "")
            {
                Arr ar = new Arr();
                string[] line = new string[9];
                using (var reader = new StreamReader("settings.txt"))
                {
                    line = reader.ReadToEnd().Split('\n').Select(l => l.Trim()).ToArray();
                    var values = int.Parse(line[0]);
                    values = int.Parse(gunaTextBox1.Text);
                    line[0] = values.ToString();
                }
                File.WriteAllLines("settings.txt", line.ToArray());
            }
        }

        //Time
        private void gunaGradientButton4_Click(object sender, EventArgs e)
        {
            if (gunaTextBox2.Text != "")
            {
                Arr ar = new Arr();
                string[] line = new string[9];
                using (var reader = new StreamReader("settings.txt"))
                {
                    line = reader.ReadToEnd().Split('\n').Select(l => l.Trim()).ToArray();
                    var values = int.Parse(line[1]);
                    values = int.Parse(gunaTextBox2.Text);
                    line[1] = values.ToString();
                }
                File.WriteAllLines("settings.txt", line.ToArray());
            }
        }

        //Level1
        private void gunaGradientButton9_Click(object sender, EventArgs e)
        {
            string[] line = new string[9];
            using (var reader = new StreamReader("filesettings.txt"))
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.ShowDialog();
                line = reader.ReadToEnd().Split('\n').Select(l => l.Trim()).ToArray();
                line[3] = openFileDialog1.FileName;
            }
            File.WriteAllLines("filesettings.txt", line);
            gunaGradientButton9.Visible = false;
            gunaGradientButton10.Visible = false;
            gunaGradientButton11.Visible = false;
        }

        //Level2
        private void gunaGradientButton10_Click(object sender, EventArgs e)
        {
            string[] line = new string[9];
            using (var reader = new StreamReader("filesettings.txt"))
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.ShowDialog();
                line = reader.ReadToEnd().Split('\n').Select(l => l.Trim()).ToArray();
                line[4] = openFileDialog1.FileName;
            }
            File.WriteAllLines("filesettings.txt", line);
            gunaGradientButton9.Visible = false;
            gunaGradientButton10.Visible = false;
            gunaGradientButton11.Visible = false;
        }

        //Level3
        private void gunaGradientButton11_Click(object sender, EventArgs e)
        {
            string[] line = new string[9];
            using (var reader = new StreamReader("filesettings.txt"))
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.ShowDialog();
                line = reader.ReadToEnd().Split('\n').Select(l => l.Trim()).ToArray();
                line[5] = openFileDialog1.FileName;
            }
            File.WriteAllLines("filesettings.txt", line);
            gunaGradientButton9.Visible = false;
            gunaGradientButton10.Visible = false;
            gunaGradientButton11.Visible = false;
        }

        //Karts
        private void gunaGradientButton5_Click(object sender, EventArgs e)
        {
            gunaGradientButton9.Visible = true;
            gunaGradientButton10.Visible = true;
            gunaGradientButton11.Visible = true;
            gunaGradientButton12.Visible = false;
            gunaGradientButton13.Visible = false;
        }

        //Bot
        private void gunaGradientButton2_Click(object sender, EventArgs e)
        {
            string[] line = new string[9];
            using (var reader = new StreamReader("filesettings.txt"))
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.ShowDialog();
                line = reader.ReadToEnd().Split('\n').Select(l => l.Trim()).ToArray();
                line[6] = openFileDialog1.FileName;
            }
            File.WriteAllLines("filesettings.txt", line);
        }

        //Settings
        private void gunaGradientButton8_Click(object sender, EventArgs e)
        {
            gunaGradientButton12.Visible = true;
            gunaGradientButton13.Visible = true;
            gunaGradientButton9.Visible = false;
            gunaGradientButton10.Visible = false;
            gunaGradientButton11.Visible = false;
        }
        //SettingTrue
        private void gunaGradientButton12_Click(object sender, EventArgs e)
        {
            string[] line = new string[9];
            using (var reader = new StreamReader("filesettings.txt"))
            {
                line = reader.ReadToEnd().Split('\n').Select(l => l.Trim()).ToArray();
                line[7] = "true";
            }
            File.WriteAllLines("filesettings.txt", line);
            gunaGradientButton12.Visible = false;
            gunaGradientButton13.Visible = false;
        }
        //Setting False
        private void gunaGradientButton13_Click(object sender, EventArgs e)
        {
            string[] line = new string[9];
            using (var reader = new StreamReader("filesettings.txt"))
            {
                line = reader.ReadToEnd().Split('\n').Select(l => l.Trim()).ToArray();
                line[7] = "false";
            }
            File.WriteAllLines("filesettings.txt", line);
            gunaGradientButton12.Visible = false;
            gunaGradientButton13.Visible = false;
        }

        //Bomb
        private void gunaGradientButton7_Click(object sender, EventArgs e)
        {

        }
        //BotTime
        private void gunaGradientButton6_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
