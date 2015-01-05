/*
 * ToolkitMenu.cs - This file is part of ERPToolkit
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

namespace ERPToolkit.Component
{
    partial class ToolkitMenu
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStyleCboBox = new System.Windows.Forms.ComboBox();
            this.allTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.languageTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.portugueseButton = new System.Windows.Forms.Button();
            this.englishButton = new System.Windows.Forms.Button();
            this.languageButton = new System.Windows.Forms.Button();
            this.helpTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.helpButton2 = new System.Windows.Forms.Button();
            this.helpButton = new System.Windows.Forms.Button();
            this.aboutButton = new System.Windows.Forms.Button();
            this.sizeTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.middleSizeButton = new System.Windows.Forms.Button();
            this.sizeButton = new System.Windows.Forms.Button();
            this.defaultSizeButton = new System.Windows.Forms.Button();
            this.maximizedSizeButton = new System.Windows.Forms.Button();
            this.menuPanel.SuspendLayout();
            this.allTableLayoutPanel.SuspendLayout();
            this.languageTableLayoutPanel.SuspendLayout();
            this.helpTableLayoutPanel.SuspendLayout();
            this.sizeTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuPanel
            // 
            this.menuPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.menuPanel.Controls.Add(this.panel1);
            this.menuPanel.Controls.Add(this.menuStyleCboBox);
            this.menuPanel.Controls.Add(this.allTableLayoutPanel);
            this.menuPanel.Location = new System.Drawing.Point(0, 0);
            this.menuPanel.Margin = new System.Windows.Forms.Padding(0);
            this.menuPanel.MinimumSize = new System.Drawing.Size(100, 315);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(120, 315);
            this.menuPanel.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Location = new System.Drawing.Point(119, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 315);
            this.panel1.TabIndex = 13;
            // 
            // menuStyleCboBox
            // 
            this.menuStyleCboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStyleCboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.menuStyleCboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.menuStyleCboBox.FormattingEnabled = true;
            this.menuStyleCboBox.Items.AddRange(new object[] {
            "Dark",
            "Light"});
            this.menuStyleCboBox.Location = new System.Drawing.Point(0, 294);
            this.menuStyleCboBox.Name = "menuStyleCboBox";
            this.menuStyleCboBox.Size = new System.Drawing.Size(120, 21);
            this.menuStyleCboBox.TabIndex = 10;
            this.menuStyleCboBox.SelectedIndexChanged += new System.EventHandler(this.menuStyleCboBox_SelectedIndexChanged);
            // 
            // allTableLayoutPanel
            // 
            this.allTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.allTableLayoutPanel.ColumnCount = 1;
            this.allTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.allTableLayoutPanel.Controls.Add(this.languageTableLayoutPanel, 0, 0);
            this.allTableLayoutPanel.Controls.Add(this.helpTableLayoutPanel, 0, 2);
            this.allTableLayoutPanel.Controls.Add(this.sizeTableLayoutPanel, 0, 1);
            this.allTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.allTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.allTableLayoutPanel.Name = "allTableLayoutPanel";
            this.allTableLayoutPanel.RowCount = 4;
            this.allTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.allTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.allTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.allTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.allTableLayoutPanel.Size = new System.Drawing.Size(120, 285);
            this.allTableLayoutPanel.TabIndex = 11;
            // 
            // languageTableLayoutPanel
            // 
            this.languageTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.languageTableLayoutPanel.ColumnCount = 1;
            this.languageTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.languageTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.languageTableLayoutPanel.Controls.Add(this.portugueseButton, 0, 2);
            this.languageTableLayoutPanel.Controls.Add(this.englishButton, 0, 1);
            this.languageTableLayoutPanel.Controls.Add(this.languageButton, 0, 0);
            this.languageTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.languageTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.languageTableLayoutPanel.Name = "languageTableLayoutPanel";
            this.languageTableLayoutPanel.RowCount = 3;
            this.languageTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.languageTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.languageTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.languageTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.languageTableLayoutPanel.Size = new System.Drawing.Size(120, 85);
            this.languageTableLayoutPanel.TabIndex = 9;
            // 
            // portugueseButton
            // 
            this.portugueseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.portugueseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.portugueseButton.ForeColor = System.Drawing.Color.DarkGray;
            this.portugueseButton.Image = global::ERPToolkit.Properties.Resources.pt_br_24;
            this.portugueseButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.portugueseButton.Location = new System.Drawing.Point(0, 60);
            this.portugueseButton.Margin = new System.Windows.Forms.Padding(0);
            this.portugueseButton.Name = "portugueseButton";
            this.portugueseButton.Size = new System.Drawing.Size(120, 25);
            this.portugueseButton.TabIndex = 2;
            this.portugueseButton.Text = "portugueseButton";
            this.portugueseButton.UseVisualStyleBackColor = true;
            this.portugueseButton.Click += new System.EventHandler(this.portugueseButton_Click);
            // 
            // englishButton
            // 
            this.englishButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.englishButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.englishButton.ForeColor = System.Drawing.Color.DarkGray;
            this.englishButton.Image = global::ERPToolkit.Properties.Resources.en_us_24;
            this.englishButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.englishButton.Location = new System.Drawing.Point(0, 35);
            this.englishButton.Margin = new System.Windows.Forms.Padding(0);
            this.englishButton.Name = "englishButton";
            this.englishButton.Size = new System.Drawing.Size(120, 25);
            this.englishButton.TabIndex = 1;
            this.englishButton.Text = "englishButton";
            this.englishButton.UseVisualStyleBackColor = true;
            this.englishButton.Click += new System.EventHandler(this.englishButton_Click);
            // 
            // languageButton
            // 
            this.languageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.languageButton.BackColor = System.Drawing.Color.DimGray;
            this.languageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.languageButton.ForeColor = System.Drawing.Color.DarkGray;
            this.languageButton.Location = new System.Drawing.Point(0, 0);
            this.languageButton.Margin = new System.Windows.Forms.Padding(0);
            this.languageButton.Name = "languageButton";
            this.languageButton.Size = new System.Drawing.Size(120, 35);
            this.languageButton.TabIndex = 0;
            this.languageButton.Text = "languageButton";
            this.languageButton.UseVisualStyleBackColor = false;
            this.languageButton.Click += new System.EventHandler(this.languageButton_Click);
            // 
            // helpTableLayoutPanel
            // 
            this.helpTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.helpTableLayoutPanel.ColumnCount = 1;
            this.helpTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.helpTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.helpTableLayoutPanel.Controls.Add(this.helpButton2, 0, 1);
            this.helpTableLayoutPanel.Controls.Add(this.helpButton, 0, 0);
            this.helpTableLayoutPanel.Controls.Add(this.aboutButton, 0, 2);
            this.helpTableLayoutPanel.Location = new System.Drawing.Point(0, 196);
            this.helpTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.helpTableLayoutPanel.Name = "helpTableLayoutPanel";
            this.helpTableLayoutPanel.RowCount = 3;
            this.helpTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.helpTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.helpTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.helpTableLayoutPanel.Size = new System.Drawing.Size(120, 89);
            this.helpTableLayoutPanel.TabIndex = 10;
            // 
            // helpButton2
            // 
            this.helpButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.helpButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpButton2.ForeColor = System.Drawing.Color.DarkGray;
            this.helpButton2.Location = new System.Drawing.Point(0, 35);
            this.helpButton2.Margin = new System.Windows.Forms.Padding(0);
            this.helpButton2.Name = "helpButton2";
            this.helpButton2.Size = new System.Drawing.Size(120, 25);
            this.helpButton2.TabIndex = 8;
            this.helpButton2.Text = "helpButton2";
            this.helpButton2.UseVisualStyleBackColor = true;
            this.helpButton2.Click += new System.EventHandler(this.helpButton2_Click);
            // 
            // helpButton
            // 
            this.helpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.helpButton.BackColor = System.Drawing.Color.DimGray;
            this.helpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpButton.ForeColor = System.Drawing.Color.DarkGray;
            this.helpButton.Location = new System.Drawing.Point(0, 0);
            this.helpButton.Margin = new System.Windows.Forms.Padding(0);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(120, 35);
            this.helpButton.TabIndex = 7;
            this.helpButton.Text = "helpButton";
            this.helpButton.UseVisualStyleBackColor = false;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // aboutButton
            // 
            this.aboutButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.aboutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aboutButton.ForeColor = System.Drawing.Color.DarkGray;
            this.aboutButton.Location = new System.Drawing.Point(0, 60);
            this.aboutButton.Margin = new System.Windows.Forms.Padding(0);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(120, 25);
            this.aboutButton.TabIndex = 9;
            this.aboutButton.Text = "aboutButton";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // sizeTableLayoutPanel
            // 
            this.sizeTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sizeTableLayoutPanel.ColumnCount = 1;
            this.sizeTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.sizeTableLayoutPanel.Controls.Add(this.middleSizeButton, 0, 2);
            this.sizeTableLayoutPanel.Controls.Add(this.sizeButton, 0, 0);
            this.sizeTableLayoutPanel.Controls.Add(this.defaultSizeButton, 0, 1);
            this.sizeTableLayoutPanel.Controls.Add(this.maximizedSizeButton, 0, 3);
            this.sizeTableLayoutPanel.Location = new System.Drawing.Point(0, 85);
            this.sizeTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.sizeTableLayoutPanel.Name = "sizeTableLayoutPanel";
            this.sizeTableLayoutPanel.RowCount = 4;
            this.sizeTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.sizeTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.sizeTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.sizeTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.sizeTableLayoutPanel.Size = new System.Drawing.Size(120, 111);
            this.sizeTableLayoutPanel.TabIndex = 8;
            // 
            // middleSizeButton
            // 
            this.middleSizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.middleSizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.middleSizeButton.ForeColor = System.Drawing.Color.DarkGray;
            this.middleSizeButton.Location = new System.Drawing.Point(0, 60);
            this.middleSizeButton.Margin = new System.Windows.Forms.Padding(0);
            this.middleSizeButton.Name = "middleSizeButton";
            this.middleSizeButton.Size = new System.Drawing.Size(120, 25);
            this.middleSizeButton.TabIndex = 5;
            this.middleSizeButton.Text = "middleSizeButton";
            this.middleSizeButton.UseVisualStyleBackColor = true;
            this.middleSizeButton.Click += new System.EventHandler(this.middleSizeButton_Click);
            // 
            // sizeButton
            // 
            this.sizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sizeButton.BackColor = System.Drawing.Color.DimGray;
            this.sizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sizeButton.ForeColor = System.Drawing.Color.DarkGray;
            this.sizeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.sizeButton.Location = new System.Drawing.Point(0, 0);
            this.sizeButton.Margin = new System.Windows.Forms.Padding(0);
            this.sizeButton.Name = "sizeButton";
            this.sizeButton.Size = new System.Drawing.Size(120, 35);
            this.sizeButton.TabIndex = 3;
            this.sizeButton.Text = "sizeButton";
            this.sizeButton.UseVisualStyleBackColor = false;
            this.sizeButton.Click += new System.EventHandler(this.sizeButton_Click);
            // 
            // defaultSizeButton
            // 
            this.defaultSizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.defaultSizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.defaultSizeButton.ForeColor = System.Drawing.Color.DarkGray;
            this.defaultSizeButton.Location = new System.Drawing.Point(0, 35);
            this.defaultSizeButton.Margin = new System.Windows.Forms.Padding(0);
            this.defaultSizeButton.Name = "defaultSizeButton";
            this.defaultSizeButton.Size = new System.Drawing.Size(120, 25);
            this.defaultSizeButton.TabIndex = 4;
            this.defaultSizeButton.Text = "defaultSizeButton";
            this.defaultSizeButton.UseVisualStyleBackColor = true;
            this.defaultSizeButton.Click += new System.EventHandler(this.defaultSizeButton_Click);
            // 
            // maximizedSizeButton
            // 
            this.maximizedSizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.maximizedSizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maximizedSizeButton.ForeColor = System.Drawing.Color.DarkGray;
            this.maximizedSizeButton.Location = new System.Drawing.Point(0, 85);
            this.maximizedSizeButton.Margin = new System.Windows.Forms.Padding(0);
            this.maximizedSizeButton.Name = "maximizedSizeButton";
            this.maximizedSizeButton.Size = new System.Drawing.Size(120, 26);
            this.maximizedSizeButton.TabIndex = 6;
            this.maximizedSizeButton.Text = "maximizedSizeButton";
            this.maximizedSizeButton.UseVisualStyleBackColor = true;
            this.maximizedSizeButton.Click += new System.EventHandler(this.maximizedSizeButton_Click);
            // 
            // ToolkitMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.menuPanel);
            this.Name = "ToolkitMenu";
            this.Size = new System.Drawing.Size(120, 315);
            this.menuPanel.ResumeLayout(false);
            this.allTableLayoutPanel.ResumeLayout(false);
            this.languageTableLayoutPanel.ResumeLayout(false);
            this.helpTableLayoutPanel.ResumeLayout(false);
            this.sizeTableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel menuPanel;
        private TableLayoutPanel allTableLayoutPanel;
        private TableLayoutPanel languageTableLayoutPanel;
        private Button portugueseButton;
        private Button languageButton;
        private TableLayoutPanel helpTableLayoutPanel;
        private Button helpButton2;
        private Button helpButton;
        private Button aboutButton;
        private TableLayoutPanel sizeTableLayoutPanel;
        private Button middleSizeButton;
        private Button sizeButton;
        private Button defaultSizeButton;
        private Button maximizedSizeButton;
        private ComboBox menuStyleCboBox;
        private Button englishButton;
        private Panel panel1;
    }
}
