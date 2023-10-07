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

using System;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace PicturePickerApp
{
   
    public partial class Dashboard : Form
    {
        
        public Dashboard()
        {
            InitializeComponent();
           
        }

        private void uploadButton1_Click(object sender, EventArgs e)
        {   
            OpenFileDialog dialog = new OpenFileDialog();
            
                dialog.Filter = "jpg files (*.jpg)|";
            string fileExtension = Path.GetExtension(dialog.FileName);

            try
            {

                // Open file with jpg filter
                
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //c# display image in picture box 
                    pictureBox1.ImageLocation = dialog.FileName;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    //c# image file path 
                    uploadText.Text = dialog.FileName;

                    // Attach MouseClick event handler
                    pictureBox1.MouseClick += new MouseEventHandler(pictureBox1_MouseClick);
                    
                }
                fileExtension = Path.GetExtension(dialog.FileName);//stores file type

                //checks if file is of type .jpg
                if (!string.Equals(fileExtension, ".jpg", StringComparison.OrdinalIgnoreCase))
                {
                    //if file is not .jpg, display error message
                    pictureBox1.ImageLocation = null;
                    label1.Text = "Invalid file format. Please upload a JPG image.";

                    return;
                }
    
                //checks if file exists
                if (!File.Exists(dialog.FileName))
                {
                    pictureBox1.ImageLocation = null;
                    //if file does not exist, display error message
                    label1.Text = "File not found.";
                    return;

                }
                else {//display success message if file was uploaded and file type is correct
                    label1.Text = "File uploaded successfully.";
                }
            }
            
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);   
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                Bitmap bmp = new Bitmap(pictureBox1.Image);

                int x = e.X;
                int y = e.Y;

                Color pixelColor = bmp.GetPixel(x, y);

                // htmlColor translates the RGB values from pixelColor to hex
                String htmlColor = System.Drawing.ColorTranslator.ToHtml(pixelColor);
                textBox1.Text = "Pixel Color: " + htmlColor;
                System.Windows.Forms.Clipboard.SetText(htmlColor);
                bmp.Dispose();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

       
    }
}
