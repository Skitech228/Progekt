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
            Form1 f = new Form1();
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog();
            string filename=file.FileName;
            f.pers=filename;
            f.Close();
            Form4 f2 = new Form4();
            filename = file.FileName;
            f2.pers = filename;
            Form3 f3 = new Form3();
            filename = file.FileName;
            f3.pers = filename;
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}
