﻿using System.Windows.Forms;

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

        private void displayImage() { 
            
        }



        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.uploadButton1 = new System.Windows.Forms.Button();
            this.uploadText = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(285, 26);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(811, 509);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // uploadButton1
            // 
            this.uploadButton1.Location = new System.Drawing.Point(1000, 540);
            this.uploadButton1.Name = "uploadButton1";
            this.uploadButton1.Size = new System.Drawing.Size(96, 27);
            this.uploadButton1.TabIndex = 1;
            this.uploadButton1.Text = "Upload";
            this.uploadButton1.UseVisualStyleBackColor = true;
            this.uploadButton1.Click += new System.EventHandler(this.uploadButton1_Click);
            // 
            // uploadText
            // 
            this.uploadText.Location = new System.Drawing.Point(597, 545);
            this.uploadText.Name = "uploadText";
            this.uploadText.Size = new System.Drawing.Size(397, 22);
            this.uploadText.TabIndex = 2;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 579);
            this.Controls.Add(this.uploadText);
            this.Controls.Add(this.uploadButton1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Dashboard";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private Button uploadButton1;
        private TextBox uploadText;
    }
}