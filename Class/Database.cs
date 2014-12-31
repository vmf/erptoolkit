/*
 * Database.cs - This file is part of ERPToolkit
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
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using System.Runtime.InteropServices;
using ERPToolkit.App.Class;

namespace ERPToolkit.Class
{
    // This is for COM Interop.
    [Guid("4af5b21c-cc04-4beb-ae3f-def3e0000002")]
    [ComVisible(true)]
    public class Database
    {
        /* Values: The ERPToolkit's way to pass values through classes */
        public StoreValues Values { get; set; }

        #region DatabaseList

        /// <summary>
        ///     Gets the databases of a determined server
        /// </summary>
        /// <param name="server">Server name</param>
        /// <param name="user">User name</param>
        /// <param name="password">Password</param>
        /// <param name="systemDatabase">If system databases will be included in the list</param>
        public List<string> GetDatabaseList(string server, string user, string password, bool systemDatabase)
        {
            try
            {
                var list = new List<string>();

                // Open connection to the database
                var constring = "server=" + server + ";uid=" + user + ";pwd=" +
                                password + "; database=master";

                using (var con = new SqlConnection(constring))
                {
                    con.Open();

                    // Set up a command with the given query and associate
                    // this with the current connection.
                    using (var cmd = new SqlCommand("SELECT name from sys.databases", con))
                    {
                        using (var dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                // Checks if it is a system database
                                var database = systemDatabase == false && IsSystemDatabase(dr[0].ToString())
                                    ? null
                                    : dr[0].ToString();

                                if (!string.IsNullOrEmpty(database))
                                    list.Add(dr[0].ToString());
                            }
                        }
                    }
                }
                return list;
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

        #region Check

        /// <summary>
        ///     Check if the database is a 'System Database'
        /// </summary>
        /// <param name="databaseName">Database name</param>
        /// <returns>The truth</returns>
        public bool IsSystemDatabase(string databaseName)
        {
            try
            {
                if (!databaseName.Equals("master") && !databaseName.Equals("tempdb") && !databaseName.Equals("model") &&
                    !databaseName.Equals("msdb") && !databaseName.Equals("ReportServer") &&
                    !databaseName.Equals("ReportServerTempDB"))
                {
                    return false;
                }
                return true;
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
    }
}