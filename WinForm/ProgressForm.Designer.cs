/*
 * ProgressForm.Designer.cs - This file is part of ERPToolkit
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
    partial class ProgressForm
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
            this.mainProgressBar = new System.Windows.Forms.ProgressBar();
            this.cancelButton = new System.Windows.Forms.Button();
            this.subProgressBar = new System.Windows.Forms.ProgressBar();
            this.mainLabel = new System.Windows.Forms.Label();
            this.subLabel = new System.Windows.Forms.Label();
            this.bottomSepPanel = new System.Windows.Forms.Panel();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.mainPercLabel = new System.Windows.Forms.Label();
            this.subPercLabel = new System.Windows.Forms.Label();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainProgressBar
            // 
            this.mainProgressBar.Location = new System.Drawing.Point(9, 23);
            this.mainProgressBar.Margin = new System.Windows.Forms.Padding(0);
            this.mainProgressBar.Name = "mainProgressBar";
            this.mainProgressBar.Size = new System.Drawing.Size(520, 23);
            this.mainProgressBar.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(495, 7);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(87, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // subProgressBar
            // 
            this.subProgressBar.Location = new System.Drawing.Point(9, 70);
            this.subProgressBar.Margin = new System.Windows.Forms.Padding(0);
            this.subProgressBar.Name = "subProgressBar";
            this.subProgressBar.Size = new System.Drawing.Size(520, 23);
            this.subProgressBar.TabIndex = 2;
            // 
            // mainLabel
            // 
            this.mainLabel.AutoSize = true;
            this.mainLabel.Location = new System.Drawing.Point(8, 7);
            this.mainLabel.Name = "mainLabel";
            this.mainLabel.Size = new System.Drawing.Size(55, 13);
            this.mainLabel.TabIndex = 3;
            this.mainLabel.Text = "mainLabel";
            // 
            // subLabel
            // 
            this.subLabel.AutoSize = true;
            this.subLabel.Location = new System.Drawing.Point(8, 55);
            this.subLabel.Name = "subLabel";
            this.subLabel.Size = new System.Drawing.Size(55, 13);
            this.subLabel.TabIndex = 4;
            this.subLabel.Text = "mainLabel";
            // 
            // bottomSepPanel
            // 
            this.bottomSepPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bottomSepPanel.BackColor = System.Drawing.Color.Silver;
            this.bottomSepPanel.Location = new System.Drawing.Point(0, 102);
            this.bottomSepPanel.Name = "bottomSepPanel";
            this.bottomSepPanel.Size = new System.Drawing.Size(590, 1);
            this.bottomSepPanel.TabIndex = 20;
            // 
            // bottomPanel
            // 
            this.bottomPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bottomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bottomPanel.Controls.Add(this.cancelButton);
            this.bottomPanel.Location = new System.Drawing.Point(0, 102);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(590, 37);
            this.bottomPanel.TabIndex = 19;
            // 
            // mainPercLabel
            // 
            this.mainPercLabel.AutoSize = true;
            this.mainPercLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainPercLabel.Location = new System.Drawing.Point(532, 30);
            this.mainPercLabel.Name = "mainPercLabel";
            this.mainPercLabel.Size = new System.Drawing.Size(23, 16);
            this.mainPercLabel.TabIndex = 21;
            this.mainPercLabel.Text = "p1";            
            // 
            // subPercLabel
            // 
            this.subPercLabel.AutoSize = true;
            this.subPercLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subPercLabel.Location = new System.Drawing.Point(532, 77);
            this.subPercLabel.Name = "subPercLabel";
            this.subPercLabel.Size = new System.Drawing.Size(23, 16);
            this.subPercLabel.TabIndex = 22;
            this.subPercLabel.Text = "p2";
            // 
            // ProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 139);
            this.Controls.Add(this.subPercLabel);
            this.Controls.Add(this.mainPercLabel);
            this.Controls.Add(this.bottomSepPanel);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.subLabel);
            this.Controls.Add(this.mainLabel);
            this.Controls.Add(this.subProgressBar);
            this.Controls.Add(this.mainProgressBar);
            this.MaximizeBox = false;
            this.Name = "ProgressForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProgressForm";
            this.Load += new System.EventHandler(this.ProgressForm_Load);
            this.bottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ProgressBar mainProgressBar;
        private Button cancelButton;
        private ProgressBar subProgressBar;
        private Label mainLabel;
        private Label subLabel;
        private Panel bottomSepPanel;
        private Panel bottomPanel;
        private Label mainPercLabel;
        private Label subPercLabel;
    }
}

