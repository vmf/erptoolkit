/*
 * ExceptionForm.cs - This file is part of ERPToolkit
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
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ERPToolkit.App.Class;
using ERPToolkit.Class;

namespace ERPToolkit.App.WinForm
{
    // This is for COM Interop.
    [Guid("4af5b21c-cc04-4beb-ae3f-def3e0000021")]
    [ComVisible(true)]
    public partial class ExceptionForm : Form
    {
        private ResourceManager _rm;

        public ExceptionForm()
        {
            InitializeComponent();
        }

        /* Values: The ERPToolkit's way to pass values through classes */
        public StoreValues Values { get; set; }

        #region Email

        private void emailButton_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(1);
        }

        #endregion

        #region Initialization

        private void ExceptionForm_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeLanguage();
                SetComponents();
            }
                // Do not use exceptionForm
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, exception.GetType().ToString(), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void SetComponents()
        {
            exceptionFromTextBox.Text = Values.ExceptionFrom;
            exceptionTypeTextBox.Text = Values.ExceptionType;
            exceptionMessageTextBox.Text = Values.ExceptionMessage;

            emailTextBox.Text = Values.FromAddress;
        }

        private void InitializeLanguage()
        {
            var ci = new CultureInfo(Values.Language);
            var a = Assembly.Load("ERPToolkit");
            _rm = new ResourceManager(Values.ResourceManager, a);

            Text = Values.ErpName + @" - " + ProductVersion;
            okButton.Text = _rm.GetString("ok", ci);
            emailButton.Text = _rm.GetString("email", ci);
            exceptionFromLabel.Text = _rm.GetString("exceptionFrom", ci) + @":";
            exceptionTypeLabel.Text = _rm.GetString("exceptionType", ci) + @":";
            exceptionMessageLabel.Text = _rm.GetString("exceptionMessage", ci) + @":";
            exceptionTabPage.Text = _rm.GetString("exception", ci);
            emailTabPage.Text = _rm.GetString("sendEmail", ci);
            infoTextBox.Text = _rm.GetString("sendEmailInfo", ci);
            sendToLabel.Text = _rm.GetString("sendTo", ci) + @":";
            aditionalInfoLabel.Text = _rm.GetString("aditionalInfo", ci) + @":";
            sendEmailButton.Text = _rm.GetString("send", ci);
        }

        #endregion

        #region Close

        private void okButton_Click(object sender, EventArgs e)
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

        #region Email

        private void sendEmailButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            backgroundWorker.RunWorkerAsync();

            //MessageBox.Show(_general.BuildExceptionMessage(_exceptionFrom, _exceptionType, _exceptionMessage, aditionalMessageTextBox.Text));
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var initEx = new ExceptionHandler();
            initEx.Values = Values;
            var email = new Email();
            email.FromAddress = Values.FromAddress;
            email.Password = Values.Password;
            email.FromDisplayName = Values.FromDisplayName;
            email.SendToAddress = Values.SendToAddress;
            email.SendToDisplayName = Values.SendToDisplayName;
            email.Subject = Values.Subject;
            email.Body = Values.Body;
            email.Host = Values.Host;
            email.Port = Values.Port;
            email.EnableSsl = Values.EnableSsl;
            email.UseDefaultCredentials = Values.UseDefaultCredentials;

            email.SendEmail();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Cursor = Cursors.Default;
            MessageBox.Show(_rm.GetString("emailSent"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        #endregion
    }
}