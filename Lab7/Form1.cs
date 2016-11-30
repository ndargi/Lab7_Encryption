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

        private void Encrypt_Button_MouseClick(object sender, MouseEventArgs e)//Function used for encrypting the file
        {
            string inName = FilenameBox.Text;
            string outName = inName + ".des";
            
            FileStream fin;
            FileStream fout;
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
            string key = KeyBox.Text;
            if (key.Length == 0)
            {
                MessageBox.Show("Please Enter a Key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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
           
            fout.SetLength(0);
            byte[] bin = new byte[100]; 
            long rdlen = 0;              
            long totlen = fin.Length;   
            int len;
           
            byte[] mykey = new byte[8];
            DES des = new DESCryptoServiceProvider();
                char[] tempkey = key.ToCharArray();
                byte b;
            for (int i = 0; i < tempkey.Length; i++)
            {
                b = (byte)tempkey[i];
                mykey[i % (mykey.Length)] += (byte)b;
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

        private void Decrypt_Button_MouseClick(object sender, MouseEventArgs e)//Function used for decrypting the file
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
            byte[] bin = new byte[100]; 
            long rdlen = 0;              
            long totlen = fin.Length;    
            int len;
            string key = KeyBox.Text;
            byte[] mykey = new byte[8];
            DES des = new DESCryptoServiceProvider();
                char[] tempkey = key.ToCharArray();
                byte b;
                for (int i = 0; i < tempkey.Length; i++)
                {
                    b = (byte)tempkey[i];
                    mykey[i % (mykey.Length)] += (byte)b;
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
