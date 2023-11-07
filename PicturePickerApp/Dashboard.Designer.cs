using System.Windows.Forms;

namespace PicturePickerApp
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void displayImage()
        {

        }



        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.uploadButton1 = new System.Windows.Forms.Button();
            this.uploadText = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.ChangeColor = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.TogglePixelSelection = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(375, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(912, 635);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseClick);
            // 
            // uploadButton1
            // 
            this.uploadButton1.Location = new System.Drawing.Point(1180, 674);
            this.uploadButton1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.uploadButton1.Name = "uploadButton1";
            this.uploadButton1.Size = new System.Drawing.Size(108, 43);
            this.uploadButton1.TabIndex = 1;
            this.uploadButton1.Text = "Upload";
            this.uploadButton1.UseVisualStyleBackColor = true;
            this.uploadButton1.Click += new System.EventHandler(this.UploadButton1_Click);
            // 
            // uploadText
            // 
            this.uploadText.Location = new System.Drawing.Point(490, 677);
            this.uploadText.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.uploadText.Name = "uploadText";
            this.uploadText.Size = new System.Drawing.Size(682, 26);
            this.uploadText.TabIndex = 2;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(375, 674);
            this.saveButton.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(108, 43);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(32, 32);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(306, 26);
            this.textBox1.TabIndex = 4;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 

            // 
            // ChangeColor
            // 
            this.ChangeColor.Location = new System.Drawing.Point(109, 86);
            this.ChangeColor.Name = "ChangeColor";
            this.ChangeColor.Size = new System.Drawing.Size(159, 34);
            this.ChangeColor.TabIndex = 7;
            this.ChangeColor.Text = "Change Color";
            this.ChangeColor.UseVisualStyleBackColor = true;
            this.ChangeColor.Click += new System.EventHandler(this.ChangeColor_Click);
            // 
            // TogglePixelSelection
            // 
            this.TogglePixelSelection.Appearance = System.Windows.Forms.Appearance.Button;
            this.TogglePixelSelection.AutoSize = true;
            this.TogglePixelSelection.Image = ((System.Drawing.Image)(resources.GetObject("TogglePixelSelection.Image")));
            this.TogglePixelSelection.Location = new System.Drawing.Point(25, 118);
            this.TogglePixelSelection.Name = "TogglePixelSelection";
            this.TogglePixelSelection.Size = new System.Drawing.Size(56, 56);
            this.TogglePixelSelection.TabIndex = 9;
            this.TogglePixelSelection.UseVisualStyleBackColor = true;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1671, 725);
            this.Controls.Add(this.ChangeColor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.uploadText);
            this.Controls.Add(this.uploadButton1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "Dashboard";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private Button uploadButton1;
        private TextBox uploadText;
        private Button saveButton;
        private TextBox textBox1;
        private ErrorProvider errorProvider1;
        private Label label1;
        private Button ChangeColor;
        private ColorDialog colorDialog1;
        private CheckBox TogglePixelSelection;
    }
}