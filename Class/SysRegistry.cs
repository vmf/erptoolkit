/*
 * SysRegistry.cs - This file is part of ERPToolkit
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
using Microsoft.Win32;

namespace ERPToolkit.Class
{
    // This is for COM Interop.
    [Guid("4af5b21c-cc04-4beb-ae3f-def3e0000015")]
    [ComVisible(true)]
    public class SysRegistry
    {
        /* Values: The ERPToolkit's way to pass values through classes */
        public StoreValues Values { get; set; }

        #region Create

        /// <summary>
        ///     Creates a sub key to local intranet and sets its value
        /// </summary>
        /// <param name="rootPath">Root path like 'server' for example</param>
        public void CreateLocalIntranet(string rootPath)
        {
            try
            {
                var sysEnv = new SysEnvironment();
                sysEnv.Values = Values;

                // Creates a sub key in the CurrentUser and then set a new value
                var registryPath = Path.Combine(new Constants().LocalIntranetRegPath, rootPath);
                var key = Registry.CurrentUser.CreateSubKey(registryPath, RegistryKeyPermissionCheck.ReadWriteSubTree);
                if (key == null)
                {
                    throw new Exception("Registry does not exist");
                }
                key.SetValue(new Constants().LocalIntranetKeyName, 00000001);

                // Creates a sub key in the Users and then set a new value
                var regPath = Path.Combine(sysEnv.GetUserSid(Environment.UserName), new Constants().LocalIntranetRegPath);

                var key2 = Registry.Users.CreateSubKey(regPath, RegistryKeyPermissionCheck.ReadWriteSubTree);
                if (key2 == null)
                {
                    throw new Exception("Registry does not exist");
                }
                key2.SetValue(new Constants().LocalIntranetKeyName, 00000001);
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