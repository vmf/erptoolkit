/*
 * LicenseForm.Designer.cs - This file is part of ERPToolkit
 * Copyright (C) 2014  Vinícius M. Freitas
 * Copyright (C) 2015  Vinícius M. Freitas
 * 
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 */

using System.ComponentModel;
using System.Windows.Forms;

namespace ERPToolkit.WinForm
{
    partial class LicenseForm
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
            this.licenseTextBox = new System.Windows.Forms.TextBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.bottomSepPanel = new System.Windows.Forms.Panel();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // licenseTextBox
            // 
            this.licenseTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.licenseTextBox.Location = new System.Drawing.Point(8, 12);
            this.licenseTextBox.Multiline = true;
            this.licenseTextBox.Name = "licenseTextBox";
            this.licenseTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.licenseTextBox.Size = new System.Drawing.Size(298, 251);
            this.licenseTextBox.TabIndex = 0;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(219, 7);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(87, 23);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "closeButton";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // bottomSepPanel
            // 
            this.bottomSepPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bottomSepPanel.BackColor = System.Drawing.Color.Silver;
            this.bottomSepPanel.Location = new System.Drawing.Point(0, 269);
            this.bottomSepPanel.Name = "bottomSepPanel";
            this.bottomSepPanel.Size = new System.Drawing.Size(314, 1);
            this.bottomSepPanel.TabIndex = 24;
            // 
            // bottomPanel
            // 
            this.bottomPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bottomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bottomPanel.Controls.Add(this.closeButton);
            this.bottomPanel.Location = new System.Drawing.Point(0, 269);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(314, 37);
            this.bottomPanel.TabIndex = 23;
            // 
            // LicenseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 306);
            this.Controls.Add(this.bottomSepPanel);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.licenseTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LicenseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LicenseForm";
            this.Load += new System.EventHandler(this.LicenseForm_Load);
            this.bottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox licenseTextBox;
        private Button closeButton;
        private Panel bottomSepPanel;
        private Panel bottomPanel;
    }
}