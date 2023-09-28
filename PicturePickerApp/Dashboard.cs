using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PicturePickerApp
{
   
    public partial class Dashboard : Form
    {
        
        public Dashboard()
        {
            InitializeComponent();
        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void uploadButton1_Click(object sender, EventArgs e)
        {
            try
            {
                // Open file with jpg filter
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files (*.jpg)|";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //c# display image in picture box 
                    pictureBox1.ImageLocation = dialog.FileName;
                    //c# image file path 
                    uploadText.Text = dialog.FileName;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("oop");
            }
        }

    }
}
