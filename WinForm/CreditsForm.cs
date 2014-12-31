/*
 * CreditsForm.cs - This file is part of ERPToolkit
 * Copyright (C) 2014  Vinícius M. Freitas
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
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ERPToolkit.App.Class;

namespace ERPToolkit.WinForm
{
    // This is for COM Interop.
    [Guid("4af5b21c-cc04-4beb-ae3f-def3e0000020")]
    [ComVisible(true)]
    public partial class CreditsForm : Form
    {
        private ResourceManager _rm;

        public CreditsForm()
        {
            InitializeComponent();
        }

        /* Values: The ERPToolkit's way to pass values through classes */
        public StoreValues Values { get; set; }

        #region Initialization

        private void CreditsForm_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeLanguage();
            }
            catch (Exception exception)
            {
                var initEx = new ExceptionHandler();
                initEx.Values = Values;
                initEx.Handle(exception, MethodBase.GetCurrentMethod(), true);
            }
        }

        /// <summary>
        ///     Initializes language
        /// </summary>
        private void InitializeLanguage()
        {
            var ci = new CultureInfo(Values.Language);
            var a = Assembly.Load("ERPToolkit");
            _rm = new ResourceManager(Values.ResourceManager, a);

            Text = _rm.GetString("credits", ci);
            writtenByTabPage.Text = _rm.GetString("writtenBy", ci);
            documentedByTabPage.Text = _rm.GetString("documentedBy", ci);
            artworkByTabPage.Text = _rm.GetString("artworkBy", ci);
            closeButton.Text = _rm.GetString("close", ci);

            writtenByTextBox.Text = _rm.GetString("writtenByValue", ci);
            documentedByTextBox.Text = _rm.GetString("documentedByValue", ci);
            artworkByTextBox.Text = _rm.GetString("artworkByValue", ci);
        }

        #endregion

        #region Close

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        ///     Closes the window with 'escape' key
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion
    }
}