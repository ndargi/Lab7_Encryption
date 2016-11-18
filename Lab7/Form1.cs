using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7
{
    public partial class Form1 : Form
    {
        private Bitmap openimage;
        public Form1()
        {
            InitializeComponent();
            Size mysize = new Size(Get_File_Button.Width,Get_File_Button.Height);
            Bitmap openimage = new Bitmap(@"..\..\OpenPH.bmp");
            Bitmap newimage = new Bitmap(openimage, new Size(Get_File_Button.Width, Get_File_Button.Height));
            Get_File_Button.Image = newimage;
        }


    }
}
