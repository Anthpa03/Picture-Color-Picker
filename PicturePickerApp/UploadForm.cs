using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PicturePickerApp
{
    public partial class uploadForm : Form
    {
        public uploadForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //adds in file upload functionality
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files (*.jpg)|";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    pictureBox1.ImageLocation= dialog.FileName;

                }
            }
            catch (Exception)
            {
                Console.WriteLine("Test");
              
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}