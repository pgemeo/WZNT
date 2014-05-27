using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Form1 : Form
    {
        protected string File1, File2;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double Similarity = Services.ImageParser.ParseSimilarity(File1, File2);
            MessageBox.Show(string.Format("Process By Similarity - Images have {0} of similarity", Similarity));
            Similarity = Services.ImageParser.ParsePixels(File1, File2);
            MessageBox.Show(string.Format("Process By Pixels - Images have {0} of similarity", Similarity));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Title = "Images";
            openFileDialog1.Filter = "All Images|*.jpg; *.bmp; *.png; *.gif; *.tif";
            DialogResult Result = openFileDialog1.ShowDialog();
            if (Result == DialogResult.OK)
            {
                File1 = openFileDialog1.FileName;
                Image Image = Services.ImageParser.ResizeImage(File1, 150, 150);
                pictureBox1.Image = Image;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Title = "Images";
            openFileDialog1.Filter = "All Images|*.jpg; *.bmp; *.png; *.gif; *.tif";
            DialogResult Result = openFileDialog1.ShowDialog();
            if (Result == DialogResult.OK)
            {
                File2 = openFileDialog1.FileName;
                Image Image = Services.ImageParser.ResizeImage(File2, 150, 150);
                pictureBox2.Image = Image;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Modules.Grundlagen.Werkzeugnummerntool Form = new Modules.Grundlagen.Werkzeugnummerntool();
            Form.Show();
        }
    }
}
