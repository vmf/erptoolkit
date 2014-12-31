/*
 * Font.cs - This file is part of ERPToolkit
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
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using ERPToolkit.App.Class;

namespace ERPToolkit.Class
{
    // This is for COM Interop.
    [Guid("4af5b21c-cc04-4beb-ae3f-def3e0000004")]
    [ComVisible(true)]
    public class Font
    {
        /* Values: The ERPToolkit's way to pass values through classes */
        public StoreValues Values { get; set; }

        #region Install

        /// <summary>
        ///     Install all fonts from a directory
        /// </summary>
        /// <param name="path">Directory that contains the fonts</param>
        public void Install(string path)
        {
            var general = new General();
            var sysIo = new SysIo();
            var res = new Resource();
            sysIo.Values = Values;
            general.Values = Values;
            res.Values = Values;

            try
            {
                Directory.CreateDirectory(new Constants().TempPath);

                // Copy all fonts to the temp directory
                sysIo.CopyTo(path, new Constants().TempPath, new Constants().FontPattern);

                // Extract the embedded executable according to the bits of the process
                var resourceName = Environment.Is64BitProcess ? "FontReg_x86-64.exe" : "FontReg_x86-32.exe";

                // Export with the same resource name
                var exePath = Path.Combine(new Constants().TempPath, resourceName);

                var resource = "ERPToolkit.FontReg" + "." + resourceName;

                res.ExtractResource(exePath, resource);

                // Run the exe...
                var process = new System.Diagnostics.Process();
                var startInfo = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments = @" /C " + exePath + @" /copy",
                    WorkingDirectory = general.GetWorkingDirectory(exePath),
                    UseShellExecute = false,
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