/*
 * Process.cs - This file is part of ERPToolkit
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
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using ERPToolkit.App.Class;

namespace ERPToolkit.Class
{
    // This is for COM Interop.
    [Guid("4af5b21c-cc04-4beb-ae3f-def3e0000007")]
    [ComVisible(true)]
    public class Process
    {
        /* Values: The ERPToolkit's way to pass values through classes */
        public StoreValues Values { get; set; }

        #region Launch

        /// <summary>
        ///     Launch Msi packages
        /// </summary>
        /// <param name="packagePath">Package path that'll be called to execution</param>
        /// <param name="logPath">Log file path</param>
        /// <param name="command">Command(parameter that'll be passed to msiexec)</param>
        public void LaunchMsiPackage(string packagePath, string logPath, string command)
        {
            try
            {
                var process = new System.Diagnostics.Process();
                var startInfo = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments = " /C msiexec /" + command + " \"" + packagePath + "\"" + " /qn /LV+ \"" + logPath + "\"",
                    Verb = "runas"
                };
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();
                process.Close();
            }

            catch (Exception exception)
            {
                var initEx = new ExceptionHandler();
                initEx.Values = Values;
                initEx.Handle(exception, MethodBase.GetCurrentMethod(), true);
            }
        }

        #endregion
    }
}