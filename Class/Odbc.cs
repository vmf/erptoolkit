/*
 * Odbc.cs - This file is part of ERPToolkit
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
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using ERPToolkit.App.Class;
using Microsoft.Win32;

namespace ERPToolkit.Class
{
    // This is for COM Interop.
    [Guid("4af5b21c-cc04-4beb-ae3f-def3e0000006")]
    [ComVisible(true)]
    public class Odbc
    {
        /* Values: The ERPToolkit's way to pass values through classes */
        public StoreValues Values { get; set; }

        #region Create

        /// <summary>
        ///     Creates a DSN
        /// </summary>
        /// <param name="dsnName">DSN name</param>
        /// <param name="database">Database</param>
        /// <param name="description">Description</param>
        /// <param name="server">Server</param>
        public void CreateDsn(string dsnName, string database, string description, string server)
        {
            try
            {
                const string odbcPath = "SOFTWARE\\ODBC\\ODBC.INI\\";
                const string driverName = "SQL Server";

                // Lookup driver path from driver name         
                const string driverPath = "C:\\Windows\\System32\\sqlsrv32.dll";

                var datasourcesKey = Registry.CurrentUser.CreateSubKey(odbcPath + "ODBC Data Sources",
                    RegistryKeyPermissionCheck.ReadWriteSubTree);
                if (datasourcesKey == null)
                {
                    throw new Exception("ODBC Registry key does not exist");
                }
                datasourcesKey.SetValue(dsnName, driverName);
                // Create new key in odbc.ini with dsn name and add values
                var dsnKey = Registry.CurrentUser.CreateSubKey(odbcPath + dsnName,
                    RegistryKeyPermissionCheck.ReadWriteSubTree);
                if (dsnKey == null)
                {
                    throw new Exception("ODBC Registry key for DSN was not created");
                }

                dsnKey.SetValue("Database", database);
                dsnKey.SetValue("Description", description);
                dsnKey.SetValue("Driver", driverPath);
                dsnKey.SetValue("LastUser", "sa");
                dsnKey.SetValue("Server", server);
            }
            catch (Exception exception)
            {
                var initEx = new ExceptionHandler();
                initEx.Values = Values;
                initEx.Handle(exception, MethodBase.GetCurrentMethod(), true);
            }
        }

        #endregion

        #region Check

        /// <summary>
        ///     Checks if the DSN name is valid(Exists)
        /// </summary>
        /// <param name="dsnName">Dsn name</param>
        /// <returns>The truth</returns>
        public bool IsValidDsn(string dsnName)
        {
            try
            {
                var general = new General();
                var list = general.GetListFromString(
                    GetDsnList(new Constants().DefaultSeparator), new Constants().DefaultSeparator);

                foreach (var item in list)
                {
                    if (dsnName.Equals(item))
                        return true;
                }
            }
            catch (Exception exception)
            {
                var initEx = new ExceptionHandler();
                initEx.Values = Values;
                initEx.Handle(exception, MethodBase.GetCurrentMethod(), true);
            }
            return false;
        }

        #endregion

        #region Get

        /// <summary>
        ///     Gets a property of a DSN
        /// </summary>
        /// <param name="dsnName">DSN name</param>
        /// <param name="property">Property name that we want to get</param>
        /// <returns></returns>
        public string GetDsnProperty(string dsnName, string property)
        {
            try
            {
                var key = Registry.CurrentUser.OpenSubKey(Path.Combine(new Constants().OdbcPath, dsnName));
                if (key != null)
                {
                    var o = key.GetValue(property);
                    if (o != null)
                    {
                        //MessageBox.Show(o.ToString());
                        return o.ToString();
                    }
                }
            }
            catch (Exception exception)
            {
                var initEx = new ExceptionHandler();
                initEx.Values = Values;
                initEx.Handle(exception, MethodBase.GetCurrentMethod(), true);
            }

            return null;
        }

        /// <summary>
        ///     Gets all DSNs
        /// </summary>
        /// <param name="separator">Separator</param>
        /// <returns>List</returns>
        public string GetDsnList(string separator)
        {
            var myList = "";
            try
            {
                const string odbcPath = "SOFTWARE\\ODBC\\ODBC.INI\\ODBC Data Sources";

                var key = Registry.CurrentUser.OpenSubKey(odbcPath);

                if (key != null)
                {
                    foreach (var item in key.GetValueNames().ToList())
                    {
                        myList += item + separator;
                    }
                }
                return myList;
            }
            catch (Exception exception)
            {
                var initEx = new ExceptionHandler();
                initEx.Values = Values;
                initEx.Handle(exception, MethodBase.GetCurrentMethod(), true);
            }

            return null;
        }

        #endregion
    }
}