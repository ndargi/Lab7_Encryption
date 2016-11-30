using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Size mysize = new Size(Get_File_Button.Width,Get_File_Button.Height);
            Bitmap openimage = new Bitmap(@"..\..\OpenPH.bmp");
            Bitmap newimage = new Bitmap(openimage, new Size(Get_File_Button.Width, Get_File_Button.Height));
            Get_File_Button.Image = newimage;
        }

        private void Encrypt_Button_MouseClick(object sender, MouseEventArgs e)
        {
            string inName = FilenameBox.Text;
            string outName = inName + ".des";
            
            FileStream fin;
            FileStream fout;
            try
            {
                fin = new FileStream(inName, FileMode.Open, FileAccess.Read);
                fout = new FileStream(outName, FileMode.OpenOrCreate, FileAccess.Write);
            }
            catch
            {
                MessageBox.Show("Could not open source or destination File.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (File.Exists(outName))
            {
                DialogResult dialog = MessageBox.Show("Output File Exists. Overwrite?", "File Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {

                }
                else if (dialog == DialogResult.No)
                {
                    return;
                }

            }
            fout.SetLength(0);
            byte[] bin = new byte[100]; //This is intermediate storage for the encryption.
            long rdlen = 0;              //This is the total number of bytes written.
            long totlen = fin.Length;    //This is the total length of the input file.
            int len;
            string key = KeyBox.Text;
            if (key.Length == 0)
            {
                MessageBox.Show("Please Enter a Key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // byte[] mykey = new byte[8] { 0X30, 0X30, 0X30, 0X30, 0X30, 0X30, 0X30, 0X30};
            byte[] mykey = new byte[8];
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine(Convert.ToChar(mykey[i]));
            }
            DES des = new DESCryptoServiceProvider();
            if (key.Length > 8)
            {
                string firsteight = key.Substring(0, 8);
                byte[] totalstring = Encoding.ASCII.GetBytes(key);
                mykey = Encoding.ASCII.GetBytes(firsteight);
                for (int i = 0; i < key.Length - 8; i++)
                {
                    mykey[i] = Convert.ToByte(mykey[i] + totalstring[i + 8]); 
                }
            }
            else//This needs to be figured out for keys that are less than 8 characters
            {
     
               
                char[] tempkey = key.ToCharArray();
                byte b;
                for (int i = 0; i < tempkey.Length; i++)
                {
                    b = (byte)tempkey[i];
                    mykey[i % (mykey.Length)] += (byte)b;
                }
                for (int i = 0; i < 8; i++)
                {
                    Console.WriteLine(Convert.ToChar(mykey[i]));
                }
            }

            CryptoStream encStream = new CryptoStream(fout, des.CreateEncryptor(mykey, mykey), CryptoStreamMode.Write);
            while (rdlen < totlen)
            {
                len = fin.Read(bin, 0, 100);
                encStream.Write(bin, 0, len);
                rdlen = rdlen + len;
            }
            encStream.Close();
            fout.Close();
            fin.Close();
        }

        private void Decrypt_Button_MouseClick(object sender, MouseEventArgs e)
        {
            string inName = FilenameBox.Text;
            string outName = inName.Remove(inName.Length - 4);
            if (Path.GetExtension(inName) != ".des")
            {
                Console.WriteLine(Path.GetExtension(inName));
                MessageBox.Show("Not a .des File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (File.Exists(outName))
            {
                DialogResult dialog = MessageBox.Show("Output File Exists. Overwrite?", "File Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    
                }
                else if (dialog == DialogResult.No)
                {
                    return;
                }

            }

            Console.WriteLine(outName);
            FileStream fin = new FileStream(inName, FileMode.Open, FileAccess.Read);
            FileStream fout = new FileStream(outName, FileMode.OpenOrCreate, FileAccess.Write);
            fout.SetLength(0);
            byte[] bin = new byte[100]; //This is intermediate storage for the encryption.
            long rdlen = 0;              //This is the total number of bytes written.
            long totlen = fin.Length;    //This is the total length of the input file.
            int len;
            string key = KeyBox.Text;
            //byte[] mykey = new byte[8] { 0X30, 0X30, 0X30, 0X30, 0X30, 0X30, 0X30, 0X30 };
            byte[] mykey = new byte[8];
            DES des = new DESCryptoServiceProvider();
            if (key.Length > 8)
            {
                string firsteight = key.Substring(0, 8);
                byte[] totalstring = Encoding.ASCII.GetBytes(key);
                mykey = Encoding.ASCII.GetBytes(firsteight);
                for (int i = 0; i < key.Length - 8; i++)
                {


                    mykey[i] = Convert.ToByte(mykey[i] + totalstring[i + 8]);
                }
            }
            else//This needs to be figured out for keys that are less than 8 characters
            {
                char[] tempkey = key.ToCharArray();
                byte b;
                for (int i = 0; i < tempkey.Length; i++)
                {
                    b = (byte)tempkey[i];
                    mykey[i % (mykey.Length)] += (byte)b;
                }
            }

            CryptoStream encStream = new CryptoStream(fout, des.CreateDecryptor(mykey, mykey), CryptoStreamMode.Write);
            while (rdlen < totlen)
            {
                len = fin.Read(bin, 0, 100);
                encStream.Write(bin, 0, len);
                rdlen = rdlen + len;
            }
            try
            {
                encStream.Close();
                fout.Close();
                fin.Close();
            }
            catch
            {
                
                MessageBox.Show("Bad Key or File", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                fout.Dispose();
                fin.Dispose();
                File.Delete(outName);
            }
        }

        private void Get_File_Button_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                FilenameBox.Text = openFileDialog1.FileName;
            }
        }
    }
}
