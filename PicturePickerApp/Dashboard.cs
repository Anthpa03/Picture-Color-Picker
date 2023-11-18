//Authors: Isha Swamy, Anthony Parra, David Liendo, Tristan Hernandez

//Version: 1.1, 11/19/2023

// PicturePickerApp is a Windows Forms application that allows users to upload and view JPG images,
// select individual pixels, change the color of selected pixels, and save the edited images.
// The program provides a user interface with buttons for uploading, saving, toggling pixel selection,
// and changing pixel colors. It also displays information about the selected pixel's color.
// The application is designed to be an interactive tool for simple image manipulation.


using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace PicturePickerApp
{
    public partial class Dashboard : Form
    {
        // Initialize ariables to manage pixel color change and color selection mode
        private bool pixelChangeColor = false;//checks whether there is a pixel selected to be changed
        private bool colorSelectionMode = false;//checks whether user is in color selection mode or pixel color change mode
        List<Bitmap> imageStates = new List<Bitmap>(); // Maintain a list to store image states for undo/redo
        int currentStateIndex = -1; // Track the index of the current state

        //Stores the coordinates of the selected pixel
        int originalX;
        int originalY;

        // Load the eyedropper cursor from the file within the direcotry
        private string cursorFilePath = "./resources/cursor.cur";

        public Dashboard()
        {
            InitializeComponent();
            //Initialize the form
            TogglePixelSelection.Appearance = System.Windows.Forms.Appearance.Button;
            Text = "Dashboard";
            ChangeColor.Enabled = false;
            saveButton.Enabled = false;
            UndoButton.Enabled = false;
            RedoButton.Enabled = false;
            TogglePixelSelection.Enabled = false;
            TogglePixelSelection.Click += TogglePixelSelection_Click;
        }

        private void UploadButton1_Click(object sender, EventArgs e)
        {
            if (colorSelectionMode) // If the user has selected the upload button, then the color selection mode is disabled to retain consistency
            { 
                colorSelectionMode = false;
                Cursor = Cursors.Default; // This also applies to the cursor
            }
            ChangeColor.Enabled = false; // Disable color change ability since no pixel is selected
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "jpg files (*.jpg)|"
            };

            try
            {
                // Check if TogglePixelSelection is checked and uncheck it if true
                if (TogglePixelSelection.Checked)
                {
                    TogglePixelSelection.Checked = false;
                }
                // Open file with jpg filter
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string fileExtension = Path.GetExtension(dialog.FileName);

                    // Check if the selected file is not a .jpg
                    if (!string.Equals(fileExtension, ".jpg", StringComparison.OrdinalIgnoreCase))
                    {
                        // Display error message
                        MessageBox.Show("Invalid file format. Please upload a JPG image.");
                        return;
                    }

                    // Load the image
                    Image originalImage = Image.FromFile(dialog.FileName);

                    // Define the maximum dimensions for the displayed image
                    int maxWidth = 300;
                    int maxHeight = 300;

                    // Declare variables for the new width and height based on the original image's resolution
                    int newWidth, newHeight;

                    // Check if the original image is wider than it is tall
                    if (originalImage.Width >= originalImage.Height)//if image is landscape
                    {
                        newWidth = maxWidth;
                        newHeight = (int)((float)originalImage.Height * maxWidth / originalImage.Width);
                    }
                    else//if image is portrait
                    {
                        newHeight = maxHeight;
                        newWidth = (int)((float)originalImage.Width * maxHeight / originalImage.Height);
                    }

                    // Create a new Bitmap with the lower resolution image
                    Bitmap lowResImage = new Bitmap(originalImage, newWidth, newHeight);

                    // Set PictureBox1's SizeMode property to zoom so it fits the picture box instead of being smaller
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                    // Display the lower resolution image in PictureBox1
                    pictureBox1.Image = lowResImage;

                    // Display the original file path
                    uploadText.Text = dialog.FileName;

                    // Attach MouseClick event handler
                    pictureBox1.MouseClick += new MouseEventHandler(PictureBox1_MouseClick);

                    MessageBox.Show("File uploaded successfully.");// Display success message
                    AddCurrentStateToHistory(); // Save the initial state of the uploaded image

                    // Enable or disable buttons based on successful file upload
                    saveButton.Enabled = true; // Enable saving ability
                    TogglePixelSelection.Enabled = true; // Enable pixel selection
                    UndoButton.Enabled = true; // Enable undo ability
                    RedoButton.Enabled = true; // Enavke redo ability
                }
            }
            catch (Exception ex)
            {
                // Display error
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void PictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (pictureBox1.Image != null && colorSelectionMode)//Check if user is in color selection mode and image is selected
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

                    //Create a bitmap of the image and get the color of the selected pixel
                    Bitmap bmp = new Bitmap(pictureBox1.Image);
                    Color pixelColor = bmp.GetPixel(originalX, originalY);

                    //Translate color name to Html and display hexidecimal color value
                    String htmlColor = System.Drawing.ColorTranslator.ToHtml(pixelColor);
                    textBox1.Text = "Pixel Color: " + htmlColor;
                    System.Windows.Forms.Clipboard.SetText(htmlColor);//Copy hexcode to clipboard
                    pixelChangeColor = true;
                }
            }
            catch (Exception ex)//catch errors
            {
                //display error
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void ChangeColor_Click(object sender, EventArgs e)//When user clicks change color button
        {
            if(pixelChangeColor)//Verify pixel is selected
            { 
                Bitmap bmp = new Bitmap(pictureBox1.Image);//Create bitmap of image
                ColorDialog colorDlg = new ColorDialog//Create color dialog for user to pick a color
                {
                    AllowFullOpen = true,
                    AnyColor = true,
                    SolidColorOnly = false
                };
                if (colorDlg.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = bmp;
                    bmp.SetPixel(originalX, originalY, colorDlg.Color);//Change pixel color on the bitmap to selected color
                    AddCurrentStateToHistory(); // Save the state after changing pixel color
                }
            }

        }

        private void SaveButton_Click(object sender, EventArgs e)//when user clicks save button
        {
            // Create a SaveFileDialog to allow the user to choose the save location and file name
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "JPEG Image|*.jpg";// Set filter to show only JPEG files
            saveDialog.Title = "Save Image";

            // Check if the user selected a valid file path
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file path
                string savePath = saveDialog.FileName;

                // Save the state before saving the image
                AddCurrentStateToHistory();

                // Save the edited image to the specified location
                Bitmap bmp = new Bitmap(pictureBox1.Image);
                bmp.Save(savePath, System.Drawing.Imaging.ImageFormat.Jpeg);

                // Display a success message to the user
                MessageBox.Show("Image saved successfully.");
            }
        }

        private void TogglePixelSelection_Click(object sender, EventArgs e)
        {
            // Toggle color selection mode based on the state of the TogglePixelSelection checkbox
            if (TogglePixelSelection.Checked)
            {
                colorSelectionMode = true; // Enable color selection mode
                Cursor = new Cursor(cursorFilePath); // Change cursor to an eyedropper when pixel selection is toggled
            }
            else
            {
                colorSelectionMode = false; // Disable color selection mode
                Cursor = Cursors.Default; // Change cursor back to default when pixel selection is toggled off
                ChangeColor.Enabled = false; // Disable color change button when exiting pixel selection mode
            }
        }

        // Method to add the current state to the list
        private void AddCurrentStateToHistory()
        {
            Bitmap currentState = new Bitmap(pictureBox1.Image);

            // If the current state is not at the end of the history list,
            // remove the states ahead and add the current state
            if (currentStateIndex < imageStates.Count - 1)
            {
                imageStates.RemoveRange(currentStateIndex + 1, imageStates.Count - currentStateIndex - 1);
            }

            imageStates.Add(currentState);
            currentStateIndex = imageStates.Count - 1;
        }

        // Undo Button Click Event
        private void UndoButton_Click(object sender, EventArgs e)
        {
            if (currentStateIndex > 0)
            {
                currentStateIndex--;
                pictureBox1.Image = new Bitmap(imageStates[currentStateIndex]);
            }
        }

        // Redo Button Click Event
        private void RedoButton_Click(object sender, EventArgs e)
        {
            if (currentStateIndex < imageStates.Count - 1)
            {
                currentStateIndex++;
                pictureBox1.Image = new Bitmap(imageStates[currentStateIndex]);
            }
        }
    }
}