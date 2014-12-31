/*
 * Shortcut.cs - This file is part of ERPToolkit
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
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using ERPToolkit.App.Class;
using IWshRuntimeLibrary;

namespace ERPToolkit.Class
{
    // This is for COM Interop.
    [Guid("4af5b21c-cc04-4beb-ae3f-def3e0000011")]
    [ComVisible(true)]
    public class Shortcut
    {
        /* Values: The ERPToolkit's way to pass values through classes */
        public StoreValues Values { get; set; }

        #region Create

        /// <summary>
        ///     Creates shortcut
        /// </summary>
        /// <param name="shortcutName">Shortcut name</param>
        /// <param name="shortcutPath">Shortcut path</param>
        /// <param name="targetFileLocation">Target file location - path of the file that will launch when the shortcut is run</param>
        public void Create(string shortcutName, string shortcutPath, string targetFileLocation)
        {
            var general = new General();
            try
            {
                var shortcutLocation = Path.Combine(shortcutPath, shortcutName + ".lnk");
                var shell = new WshShell();
                var shortcut = (IWshShortcut) shell.CreateShortcut(shortcutLocation);

                shortcut.Description = shortcutName; // The description of the shortcut
                //shortcut.IconLocation = @"c:\myicon.ico";         // The icon of the shortcut
                shortcut.TargetPath = targetFileLocation;
                // The path of the file that will launch when the shortcut is run
                shortcut.WorkingDirectory = general.GetWorkingDirectory(targetFileLocation); // The path start in    
                shortcut.Save(); // Save the shortcut           
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