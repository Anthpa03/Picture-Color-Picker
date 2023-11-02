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
        private bool pixelChangeColor = false;
        int originalX;
        int originalY;
        public Dashboard()
        {
            InitializeComponent();
            ChangeColor.Enabled = false;
            saveButton.Enabled = false;
        }

        private void UploadButton1_Click(object sender, EventArgs e)
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
                    pictureBox1.MouseClick += new MouseEventHandler(PictureBox1_MouseClick);

                }
                fileExtension = Path.GetExtension(dialog.FileName);//stores file type

                //checks if file is of type .jpg
                if (!string.Equals(fileExtension, ".jpg", StringComparison.OrdinalIgnoreCase))
                {
                    //if file is not .jpg, display error message
                    pictureBox1.ImageLocation = null;
                    MessageBox.Show("Invalid file format. Please upload a JPG image.");
                    
                    return;
                }

                //checks if file exists
                if (!File.Exists(dialog.FileName))
                {
                    pictureBox1.ImageLocation = null;
                    //if file does not exist, display error message
                    MessageBox.Show("File not found.");
                    
                    return;

                }
                else
                {
                    //display success message if file was uploaded and file type is correct
                    //Then sets the ability to change the color to false (again if uploading another picture)
                    //and enables the ability to save the file
               
                    MessageBox.Show("File uploaded successfully.");
                    ChangeColor.Enabled = false;
                    saveButton.Enabled = true;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void PictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (pictureBox1.Image != null)
                {
                    ChangeColor.Enabled = true; // This enables the user's ability to manipulate the pixel's color
                    // Calculate the scaling factor based on the original image size and stretched size
                    float scaleX = (float)pictureBox1.Image.Width / pictureBox1.Width;
                    float scaleY = (float)pictureBox1.Image.Height / pictureBox1.Height;

                    // Calculate the position in the original image based on the click location in the stretched image
                    originalX = (int)(e.X * scaleX);
                    originalY = (int)(e.Y * scaleY);

                    // Make sure the calculated position is within the bounds of the original image
                    originalX = Math.Max(0, Math.Min(originalX, pictureBox1.Image.Width - 1));
                    originalY = Math.Max(0, Math.Min(originalY, pictureBox1.Image.Height - 1));

                    Bitmap bmp = new Bitmap(pictureBox1.Image);
                    Color pixelColor = bmp.GetPixel(originalX, originalY);

                    String htmlColor = System.Drawing.ColorTranslator.ToHtml(pixelColor);
                    textBox1.Text = "Pixel Color: " + htmlColor;
                    System.Windows.Forms.Clipboard.SetText(htmlColor);
                    pixelChangeColor = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void ChangeColor_Click(object sender, EventArgs e)
        {
            if(pixelChangeColor)
            { 
                Bitmap bmp = new Bitmap(pictureBox1.Image);
                ColorDialog colorDlg = new ColorDialog
                {
                    AllowFullOpen = true,
                    AnyColor = true,
                    SolidColorOnly = false
                };
                if (colorDlg.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = bmp;
                    bmp.SetPixel(originalX, originalY, colorDlg.Color);
                }
            }

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "JPEG Image|*.jpg";
            saveDialog.Title = "Save Image";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                string savePath = saveDialog.FileName;

                // Save the edited image to the specified location
                Bitmap bmp = new Bitmap(pictureBox1.Image);
                bmp.Save(savePath, System.Drawing.Imaging.ImageFormat.Jpeg);

                MessageBox.Show("Image saved successfully.");
            }
        }

        
    }
}