/*
 * UdlFile.cs - This file is part of ERPToolkit
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
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using ERPToolkit.App.Class;

namespace ERPToolkit.Class
{
    // This is for COM Interop.
    [Guid("4af5b21c-cc04-4beb-ae3f-def3e0000017")]
    [ComVisible(true)]
    public class UdlFile
    {
        /* Values: The ERPToolkit's way to pass values through classes */
        public StoreValues Values { get; set; }

        #region Create

        /// <summary>
        ///     Creates the .udl file for each dsn that'll be created
        /// </summary>
        /// <param name="fileName">File name(DSN name)</param>
        /// <param name="path">Path that .udl file will be created</param>
        /// <param name="datasource">Server</param>
        /// <param name="user">User</param>
        /// <param name="password">Password</param>
        /// <param name="database">Database</param>
        public void CreateUdlFile(string fileName, string path, string datasource, string user, string password,
            string database)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var filePath = Path.Combine(path, fileName) + ".udl";

            try
            {
                {
                    var fs = new FileStream(filePath, FileMode.OpenOrCreate);
                    fs.Close();
                }

                var dataConnection = "[oledb]" + Environment.NewLine +
                                     "; Everything after this line is an OLE DB initstring" + Environment.NewLine +
                                     "Provider=SQLOLEDB.1;Password=" + password +
                                     ";Persist Security Info=True;User ID=" + user +
                                     ";Initial Catalog=" + database + ";Data Source=" + datasource;

                File.WriteAllText(filePath, dataConnection, Encoding.Unicode);
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