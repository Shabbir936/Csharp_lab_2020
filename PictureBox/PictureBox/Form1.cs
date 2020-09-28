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

namespace PictureBox
{

    public partial class PictureBox : Form
    {
        public PictureBox()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            //closing the form
            this.Close();

        }

        private void backgroundButton_Click(object sender, EventArgs e)
        {
            //changing the background from the users selection from 
            //color dialog box
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                pictureBox1.BackColor = colorDialog1.Color;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            //clearing the picture
            pictureBox1.Image = null;


        }

        private void showButton_Click(object sender, EventArgs e)
        {
            //show open file dialog and load the puctire selected by user once they click ok.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
            }
        }

        private void stretchCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (stretchCheckbox.Checked)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void nextButton_Click(object sender, EventArgs e)
        {

            var myImageArray = Directory.GetFiles(Path.GetDirectoryName(openFileDialog1.FileName), "*.jpg");
            Array.Sort(myImageArray);
            int currentIndex = Array.IndexOf(myImageArray,openFileDialog1.FileName) + 1;
            pictureBox1.Load(myImageArray[currentIndex]);
            openFileDialog1.FileName = myImageArray[currentIndex];
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            var myImageArray = Directory.GetFiles(Path.GetDirectoryName(openFileDialog1.FileName), "*.jpg");
            Array.Sort(myImageArray);
            int currentIndex = Array.IndexOf(myImageArray, openFileDialog1.FileName) - 1;
            pictureBox1.Load(myImageArray[currentIndex]);
            openFileDialog1.FileName = myImageArray[currentIndex];
        }
    }
}
