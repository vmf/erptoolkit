using System.ComponentModel;
using System.Windows.Forms;

namespace ERPToolkit.WinForm
{
    partial class AboutForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.aboutPictureBox = new System.Windows.Forms.PictureBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.licenseButton = new System.Windows.Forms.Button();
            this.creditsButton = new System.Windows.Forms.Button();
            this.bottomSepPanel = new System.Windows.Forms.Panel();
            this.bottomPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.aboutPictureBox)).BeginInit();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // aboutPictureBox
            // 
            this.aboutPictureBox.Location = new System.Drawing.Point(0, 0);
            this.aboutPictureBox.Name = "aboutPictureBox";
            this.aboutPictureBox.Size = new System.Drawing.Size(384, 361);
            this.aboutPictureBox.TabIndex = 0;
            this.aboutPictureBox.TabStop = false;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(289, 7);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(87, 23);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "closeButton";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // licenseButton
            // 
            this.licenseButton.Location = new System.Drawing.Point(101, 7);
            this.licenseButton.Name = "licenseButton";
            this.licenseButton.Size = new System.Drawing.Size(87, 23);
            this.licenseButton.TabIndex = 2;
            this.licenseButton.Text = "licenseButton";
            this.licenseButton.UseVisualStyleBackColor = true;
            this.licenseButton.Click += new System.EventHandler(this.licenseButton_Click);
            // 
            // creditsButton
            // 
            this.creditsButton.Location = new System.Drawing.Point(8, 7);
            this.creditsButton.Name = "creditsButton";
            this.creditsButton.Size = new System.Drawing.Size(87, 23);
            this.creditsButton.TabIndex = 3;
            this.creditsButton.Text = "creditsButton";
            this.creditsButton.UseVisualStyleBackColor = true;
            this.creditsButton.Click += new System.EventHandler(this.creditsButton_Click);
            // 
            // bottomSepPanel
            // 
            this.bottomSepPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bottomSepPanel.BackColor = System.Drawing.Color.Silver;
            this.bottomSepPanel.Location = new System.Drawing.Point(0, 369);
            this.bottomSepPanel.Name = "bottomSepPanel";
            this.bottomSepPanel.Size = new System.Drawing.Size(384, 1);
            this.bottomSepPanel.TabIndex = 22;
            // 
            // bottomPanel
            // 
            this.bottomPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bottomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bottomPanel.Controls.Add(this.closeButton);
            this.bottomPanel.Controls.Add(this.creditsButton);
            this.bottomPanel.Controls.Add(this.licenseButton);
            this.bottomPanel.Location = new System.Drawing.Point(0, 369);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(384, 37);
            this.bottomPanel.TabIndex = 21;
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 406);
            this.Controls.Add(this.bottomSepPanel);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.aboutPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AboutForm";
            this.Load += new System.EventHandler(this.AboutForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.aboutPictureBox)).EndInit();
            this.bottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox aboutPictureBox;
        private Button closeButton;
        private Button licenseButton;
        private Button creditsButton;
        private Panel bottomSepPanel;
        private Panel bottomPanel;
    }
}