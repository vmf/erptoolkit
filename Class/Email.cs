/*
 * SendEmail.cs - This file is part of ERPToolkit
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
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ERPToolkit.App.Class;

namespace ERPToolkit.Class
{
    // This is for COM Interop.
    [Guid("4af5b21c-cc04-4beb-ae3f-def3e0000009")]
    [ComVisible(true)]
    public class Email
    {
        /* Values: The ERPToolkit's way to pass values through classes */
        public StoreValues Values { get; set; }

        #region Send

        public string FromAddress { get; set; }
        public string Password { get; set; }
        public string FromDisplayName { get; set; }
        public string SendToAddress { get; set; }
        public string SendToDisplayName { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
        public bool UseDefaultCredentials { get; set; }

        /// <summary>
        ///     Sends an e-mail
        /// </summary>
        public void SendEmail()
        {
            try
            {
                var fromAddress = new MailAddress(FromAddress, FromDisplayName);
                var toAddress = new MailAddress(SendToAddress, SendToDisplayName);

                var smtp = new SmtpClient
                {
                    Host = Host,
                    Port = Port,
                    EnableSsl = EnableSsl,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = UseDefaultCredentials,
                    Credentials = new NetworkCredential(fromAddress.Address, Password)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = Subject,
                    Body = Body
                })
                {
                    smtp.Send(message);
                }
            }
                // Do not use exception form
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, exception.GetType().ToString(), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}