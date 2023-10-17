using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstagramHelper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap newImage = new Bitmap(@"C:\Users\pasi-\Pictures\ich\IMG-20170803-WA0008.JPG");

            newImage.Save(@"C:\Users\pasi-\Desktop\test.jpg");
        }
    }
}
