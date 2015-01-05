/*
 * CreditsForm.Designer.cs - This file is part of ERPToolkit
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
    partial class CreditsForm
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
            this.creditsTabControl = new System.Windows.Forms.TabControl();
            this.writtenByTabPage = new System.Windows.Forms.TabPage();
            this.writtenByTextBox = new System.Windows.Forms.TextBox();
            this.documentedByTabPage = new System.Windows.Forms.TabPage();
            this.documentedByTextBox = new System.Windows.Forms.TextBox();
            this.artworkByTabPage = new System.Windows.Forms.TabPage();
            this.artworkByTextBox = new System.Windows.Forms.TextBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.bottomSepPanel = new System.Windows.Forms.Panel();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.creditsTabControl.SuspendLayout();
            this.writtenByTabPage.SuspendLayout();
            this.documentedByTabPage.SuspendLayout();
            this.artworkByTabPage.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // creditsTabControl
            // 
            this.creditsTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.creditsTabControl.Controls.Add(this.writtenByTabPage);
            this.creditsTabControl.Controls.Add(this.documentedByTabPage);
            this.creditsTabControl.Controls.Add(this.artworkByTabPage);
            this.creditsTabControl.Location = new System.Drawing.Point(8, 12);
            this.creditsTabControl.Name = "creditsTabControl";
            this.creditsTabControl.SelectedIndex = 0;
            this.creditsTabControl.Size = new System.Drawing.Size(298, 251);
            this.creditsTabControl.TabIndex = 0;
            // 
            // writtenByTabPage
            // 
            this.writtenByTabPage.Controls.Add(this.writtenByTextBox);
            this.writtenByTabPage.Location = new System.Drawing.Point(4, 22);
            this.writtenByTabPage.Name = "writtenByTabPage";
            this.writtenByTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.writtenByTabPage.Size = new System.Drawing.Size(290, 225);
            this.writtenByTabPage.TabIndex = 0;
            this.writtenByTabPage.Text = "writtenByTabPage";
            this.writtenByTabPage.UseVisualStyleBackColor = true;
            // 
            // writtenByTextBox
            // 
            this.writtenByTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.writtenByTextBox.Location = new System.Drawing.Point(-1, -1);
            this.writtenByTextBox.Multiline = true;
            this.writtenByTextBox.Name = "writtenByTextBox";
            this.writtenByTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.writtenByTextBox.Size = new System.Drawing.Size(291, 228);
            this.writtenByTextBox.TabIndex = 0;
            // 
            // documentedByTabPage
            // 
            this.documentedByTabPage.Controls.Add(this.documentedByTextBox);
            this.documentedByTabPage.Location = new System.Drawing.Point(4, 22);
            this.documentedByTabPage.Name = "documentedByTabPage";
            this.documentedByTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.documentedByTabPage.Size = new System.Drawing.Size(290, 225);
            this.documentedByTabPage.TabIndex = 1;
            this.documentedByTabPage.Text = "documentedByTabPage";
            this.documentedByTabPage.UseVisualStyleBackColor = true;
            // 
            // documentedByTextBox
            // 
            this.documentedByTextBox.Location = new System.Drawing.Point(-1, -1);
            this.documentedByTextBox.Multiline = true;
            this.documentedByTextBox.Name = "documentedByTextBox";
            this.documentedByTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.documentedByTextBox.Size = new System.Drawing.Size(291, 228);
            this.documentedByTextBox.TabIndex = 3;
            // 
            // artworkByTabPage
            // 
            this.artworkByTabPage.Controls.Add(this.artworkByTextBox);
            this.artworkByTabPage.Location = new System.Drawing.Point(4, 22);
            this.artworkByTabPage.Name = "artworkByTabPage";
            this.artworkByTabPage.Size = new System.Drawing.Size(290, 225);
            this.artworkByTabPage.TabIndex = 2;
            this.artworkByTabPage.Text = "artworkByTabPage";
            this.artworkByTabPage.UseVisualStyleBackColor = true;
            // 
            // artworkByTextBox
            // 
            this.artworkByTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.artworkByTextBox.Location = new System.Drawing.Point(-1, -1);
            this.artworkByTextBox.Multiline = true;
            this.artworkByTextBox.Name = "artworkByTextBox";
            this.artworkByTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.artworkByTextBox.Size = new System.Drawing.Size(291, 228);
            this.artworkByTextBox.TabIndex = 2;
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
            this.bottomSepPanel.TabIndex = 22;
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
            this.bottomPanel.TabIndex = 21;
            // 
            // CreditsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 306);
            this.Controls.Add(this.bottomSepPanel);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.creditsTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "CreditsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreditsForm";
            this.Load += new System.EventHandler(this.CreditsForm_Load);
            this.creditsTabControl.ResumeLayout(false);
            this.writtenByTabPage.ResumeLayout(false);
            this.writtenByTabPage.PerformLayout();
            this.documentedByTabPage.ResumeLayout(false);
            this.documentedByTabPage.PerformLayout();
            this.artworkByTabPage.ResumeLayout(false);
            this.artworkByTabPage.PerformLayout();
            this.bottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl creditsTabControl;
        private TabPage writtenByTabPage;
        private TabPage documentedByTabPage;
        private Button closeButton;
        private TextBox writtenByTextBox;
        private TabPage artworkByTabPage;
        private TextBox artworkByTextBox;
        private TextBox documentedByTextBox;
        private Panel bottomSepPanel;
        private Panel bottomPanel;
    }
}