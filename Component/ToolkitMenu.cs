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

using System;
using System.Drawing;
using System.Windows.Forms;

namespace ERPToolkit.Component
{
    public partial class ToolkitMenu : UserControl
    {
        public ToolkitMenu()
        {
            InitializeComponent();
            InitializeLanguage();
            SetMenuStyle();
        }

        // Components text
        public string LanguageText { get; set; }
        public string EnglishText { get; set; }
        public string PortugueseText { get; set; }
        public string SizeText { get; set; }
        public string DefaultSizeText { get; set; }
        public string MiddleSizeText { get; set; }
        public string MaximizedText { get; set; }
        public string HelpText { get; set; }
        public string AboutText { get; set; }
        public string MenuStyle { get; set; }
        public bool LanguageExpanded { get; set; }
        public bool SizeExpanded { get; set; }
        public bool HelpExpanded { get; set; }
        // Components events that'll be called
        public event EventHandler EnglishButtonClicked;
        public event EventHandler PortugueseButtonClicked;
        public event EventHandler DefaultSizeButtonClicked;
        public event EventHandler MiddleSizeButtonClicked;
        public event EventHandler MaximizedSizeButtonClicked;
        public event EventHandler HelpButton2Clicked;
        public event EventHandler AboutButtonClicked;

        #region Initialization

        public void InitializeLanguage()
        {
            languageButton.Text = LanguageText;
            englishButton.Text = EnglishText;
            portugueseButton.Text = PortugueseText;
            sizeButton.Text = SizeText;
            defaultSizeButton.Text = DefaultSizeText;
            middleSizeButton.Text = MiddleSizeText;
            maximizedSizeButton.Text = MaximizedText;
            helpButton.Text = HelpText;
            helpButton2.Text = HelpText;
            aboutButton.Text = AboutText;
        }

        #endregion

        #region Language

        private void languageButton_Click(object sender, EventArgs e)
        {
            if (languageTableLayoutPanel.Height != languageButton.Height)
                LanguageExpanded = false;
            else
                LanguageExpanded = true;

            SetLanguageExpanded();
        }

        public void SetLanguageExpanded()
        {
            languageTableLayoutPanel.Height = LanguageExpanded ? 85 : languageButton.Height;
        }

        #endregion

        #region Size

        private void sizeButton_Click(object sender, EventArgs e)
        {
            if (sizeTableLayoutPanel.Height != sizeButton.Height)
                SizeExpanded = false;
            else
                SizeExpanded = true;

            SetSizeExpanded();
        }

        public void SetSizeExpanded()
        {
            sizeTableLayoutPanel.Height = SizeExpanded ? 111 : sizeButton.Height;
        }

        #endregion

        #region Help

        private void helpButton_Click(object sender, EventArgs e)
        {
            if (helpTableLayoutPanel.Height != helpButton.Height)
                HelpExpanded = false;
            else
                HelpExpanded = true;

            SetHelpExpanded();
        }

        public void SetHelpExpanded()
        {
            helpTableLayoutPanel.Height = HelpExpanded ? 85 : helpButton.Height;
        }

        #endregion

        #region MenuStyle

        public void SetMenuStyle()
        {
            if (string.IsNullOrEmpty(MenuStyle))
            {
                MenuStyle = "Dark";
            }

            menuStyleCboBox.Text = MenuStyle;

            if (MenuStyle.Equals("Dark"))
            {
                menuPanel.BackColor = Color.FromArgb(64, 64, 64);

                languageButton.BackColor = Color.DimGray;
                languageButton.ForeColor = Color.DarkGray;
                englishButton.ForeColor = Color.DarkGray;
                portugueseButton.ForeColor = Color.DarkGray;

                sizeButton.BackColor = Color.DimGray;
                sizeButton.ForeColor = Color.DarkGray;
                defaultSizeButton.ForeColor = Color.DarkGray;
                middleSizeButton.ForeColor = Color.DarkGray;
                maximizedSizeButton.ForeColor = Color.DarkGray;

                helpButton.BackColor = Color.DimGray;
                helpButton.ForeColor = Color.DarkGray;
                helpButton2.ForeColor = Color.DarkGray;
                aboutButton.ForeColor = Color.DarkGray;
            }
            else if (MenuStyle.Equals("Light"))
            {
                menuPanel.BackColor = Color.Transparent;

                languageButton.BackColor = Color.FromArgb(224, 224, 224);
                languageButton.ForeColor = Color.DimGray;
                englishButton.ForeColor = Color.DimGray;
                portugueseButton.ForeColor = Color.DimGray;

                sizeButton.BackColor = Color.FromArgb(224, 224, 224);
                sizeButton.ForeColor = Color.DimGray;
                defaultSizeButton.ForeColor = Color.DimGray;
                middleSizeButton.ForeColor = Color.DimGray;
                maximizedSizeButton.ForeColor = Color.DimGray;

                helpButton.BackColor = Color.FromArgb(224, 224, 224);
                helpButton.ForeColor = Color.DimGray;
                helpButton2.ForeColor = Color.DimGray;
                aboutButton.ForeColor = Color.DimGray;
            }
        }

        private void menuStyleCboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MenuStyle = menuStyleCboBox.Text;
            SetMenuStyle();
        }

        #endregion

        #region Click

        private void englishButton_Click(object sender, EventArgs e)
        {
            EnglishButtonClicked(this, e);
        }

        private void portugueseButton_Click(object sender, EventArgs e)
        {
            PortugueseButtonClicked(this, e);
        }

        private void defaultSizeButton_Click(object sender, EventArgs e)
        {
            DefaultSizeButtonClicked(this, e);
        }

        private void middleSizeButton_Click(object sender, EventArgs e)
        {
            MiddleSizeButtonClicked(this, e);
        }

        private void maximizedSizeButton_Click(object sender, EventArgs e)
        {
            MaximizedSizeButtonClicked(this, e);
        }

        private void helpButton2_Click(object sender, EventArgs e)
        {
            HelpButton2Clicked(this, e);
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            AboutButtonClicked(this, e);
        }

        #endregion
    }
}