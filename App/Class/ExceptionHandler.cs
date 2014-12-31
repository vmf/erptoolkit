/*
 * ExceptionHandler.cs - This file is part of ERPToolkit
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
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using ERPToolkit.App.WinForm;

namespace ERPToolkit.App.Class
{
    // This is for COM Interop.
    [Guid("4af5b21c-cc04-4beb-ae3f-def3e0000003")]
    [ComVisible(true)]
    public class ExceptionHandler
    {
        private Form _exceptionForm;
        private ResourceManager _rm;

        public ExceptionHandler()
        {
            try
            {
                InitializeLanguage();
            }
                // Do not use ExceptionForm
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /* Values: The ERPToolkit's way to pass values through classes */
        public StoreValues Values { get; set; }

        #region Initialization

        /// <summary>
        ///     Initializes language
        /// </summary>
        private void InitializeLanguage()
        {
            try
            {
                /* If language or resource was not informated then 
                 * 'English' will be the default language 
                 */
                if (string.IsNullOrEmpty(Values.Language) || string.IsNullOrEmpty(Values.ResourceManager))
                {
                    Values.Language = "en-US";
                    Values.ResourceManager = "ERPToolkit.Lang.res_en_us";
                }

                var a = Assembly.Load("ERPToolkit");
                _rm = new ResourceManager(Values.ResourceManager, a);
            }
                // Do not use ExceptionForm
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Handle

        public void Handle(Exception exception, MethodBase currentMethod, bool run)
        {
            try
            {
                if (currentMethod.DeclaringType != null)
                {
                    var exceptionFrom = GetExceptionFrom(currentMethod.Name,
                        OnlyClassName(currentMethod.DeclaringType.ToString()),
                        Application.ProductName,
                        Application.ProductVersion);

                    // LoadValues(exceptions)
                    Values.ExceptionFrom = exceptionFrom;
                    Values.ExceptionType = exception.GetType().ToString();
                    Values.ExceptionMessage = exception.Message;

                    var exceptionForm = new ExceptionForm();
                    exceptionForm.Values = Values;

                    if (run == false)
                    {
                        if (exceptionForm.InvokeRequired)
                        {
                            exceptionForm.BeginInvoke((MethodInvoker) exceptionForm.Show);
                        }
                        else
                        {
                            _exceptionForm = exceptionForm;
                            var appThread = new Thread(LaunchExceptionForm);
                            appThread.SetApartmentState(ApartmentState.STA);
                            appThread.Start();
                        }
                    }
                    else
                    {
                        Application.Run(exceptionForm);
                    }

                    // Gets the exception and saves to the Exceptions variable
                    Values.Exceptions += BuildExceptionMessage(Values.ExceptionFrom, Values.ExceptionType,
                        Values.ExceptionMessage, "Automated collection");
                }
            }

                // Do not use ExceptionForm
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Launch

        /// <summary>
        ///     Launches the exception form
        /// </summary>
        private void LaunchExceptionForm()
        {
            try
            {
                Application.Run(_exceptionForm);
            }
                // Do not use ExceptionForm
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Email

        public string BuildExceptionMessage(string exceptionFrom, string exceptionType, string exceptionMessage,
            string message)
        {
            var messageBody = "-------------------------------------------------------------------\n";
            messageBody += "ProductName: " + Application.ProductName + "; ProductVersion: " + Application.ProductVersion +
                           "\n";
            messageBody += "-------------------------------------------------------------------\n";
            messageBody += "Date Time: " + DateTime.Now + "\n\n";
            messageBody += "---------------------------\n";
            messageBody += "From \n";
            messageBody += "---------------------------\n";
            messageBody += "MachineName: " + Environment.MachineName + "\n";
            messageBody += "UserName: " + Environment.UserName + "\n";
            messageBody += "UserDomainName: " + Environment.UserDomainName + "\n";
            messageBody += "UserInteractive: " + Environment.UserInteractive + "\n";
            messageBody += "OSVersion: " + Environment.OSVersion + "\n";
            messageBody += "Version: " + Environment.Version + "\n";
            messageBody += "Is64BitOperatingSystem: " + Environment.Is64BitOperatingSystem + "\n";
            messageBody += "ProcessorCount: " + Environment.ProcessorCount + "\n";
            messageBody += "SystemPageSize: " + Environment.SystemPageSize + "\n";
            messageBody += "SystemDirectory: " + Environment.SystemDirectory + "\n";
            messageBody += "HasShutdownStarted: " + Environment.HasShutdownStarted + "\n";
            messageBody += "Is64BitProcess: " + Environment.Is64BitProcess + "\n";
            messageBody += "---------------------------\n\n";

            messageBody += "---------------------------\n";
            messageBody += Values.ErpName + "\n";
            messageBody += "---------------------------\n";
            messageBody += Values.ErpName + @" " + "Path: " + Values.ErpPath + "\n";
            messageBody += Values.ErpName + @" " + "Pack: " + Values.ErpPack + "\n";
            messageBody += "---------------------------\n\n";

            messageBody += "---------------------------\n";
            messageBody += "Exception \n";
            messageBody += "---------------------------\n";
            messageBody += @"Exception From: " + exceptionFrom + "\n";
            messageBody += @"Exception Type: " + exceptionType + "\n";
            messageBody += @"Exception Message: " + exceptionMessage + "\n";
            messageBody += "---------------------------\n\n";

            messageBody += "---------------------------\n";
            messageBody += "User/Internal message \n";
            messageBody += "---------------------------\n";
            messageBody += message + "\n";
            messageBody += "---------------------------\n\n";

            return messageBody;
        }

        #endregion

        #region Method

        /// <summary>
        ///     Constructs the 'exception from'
        /// </summary>
        /// <param name="strMethod">Method that exception occurred</param>
        /// <param name="strClass">Class that exception occurred</param>
        /// <param name="strProduct">Product name</param>
        /// <param name="strVersion">Product version</param>
        /// <returns>Constructed exception from</returns>
        public string GetExceptionFrom(string strMethod, string strClass, string strProduct, string strVersion)
        {
            try
            {
                return "Method:" + strMethod + ";" + "Class:" + strClass + ";" + "Product Name:" + strProduct + ";" +
                       "Product Version:" + strVersion;
            }
                // Do not use ExceptionForm
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        /// <summary>
        ///     Gets just the class name
        /// </summary>
        /// <param name="str"></param>
        /// <returns>Class name</returns>
        private string OnlyClassName(string str)
        {
            try
            {
                for (var i = str.Length - 1; i > 0; i--)
                {
                    if (str.Substring(i, 1).Equals("."))
                    {
                        i++;
                        return str.Substring(i, str.Length - i);
                    }
                }
            }

                //Cannot use ExceptionForm
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, exception.GetType().ToString(), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            return null;
        }

        #endregion
    }
}