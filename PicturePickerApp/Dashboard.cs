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


using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace PicturePickerApp
{

    public partial class Dashboard : Form
    {
        private bool pixelSelectionMode = false;
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
                else
                {//display success message if file was uploaded and file type is correct
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
                if (pictureBox1.Image != null)
                {
                    // Calculate the scaling factor based on the original image size and stretched size
                    float scaleX = (float)pictureBox1.Image.Width / pictureBox1.Width;
                    float scaleY = (float)pictureBox1.Image.Height / pictureBox1.Height;

                    // Calculate the position in the original image based on the click location in the stretched image
                    int originalX = (int)(e.X * scaleX);
                    int originalY = (int)(e.Y * scaleY);

                    // Make sure the calculated position is within the bounds of the original image
                    originalX = Math.Max(0, Math.Min(originalX, pictureBox1.Image.Width - 1));
                    originalY = Math.Max(0, Math.Min(originalY, pictureBox1.Image.Height - 1));

                    Bitmap bmp = new Bitmap(pictureBox1.Image);
                    Color pixelColor = bmp.GetPixel(originalX, originalY);

                    String htmlColor = System.Drawing.ColorTranslator.ToHtml(pixelColor);
                    textBox1.Text = "Pixel Color: " + htmlColor;
                    System.Windows.Forms.Clipboard.SetText(htmlColor);
                    if (!pixelSelectionMode)
                    {
                        // In color change mode, you can change the pixel color to a new color.
                        Color newColor = Color.Red; // You can set the new color of your choice.
                        bmp.SetPixel(originalX, originalY, newColor);
                        pictureBox1.Image = (Image)bmp;
                    }
}
                    
                    
                //bmp.Dispose();
            
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pixelSelectionMode = !pixelSelectionMode;
            if (!pixelSelectionMode)
            {
                button1.Text = "Select Pixel";
            }
            else
            {
                button1.Text = "Change Color";
            }

        }
    }
}
