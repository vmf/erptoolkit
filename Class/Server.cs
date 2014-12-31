/*
 * Server.cs - This file is part of ERPToolkit
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
using System.Data;
using System.Data.Sql;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ERPToolkit.App.Class;

namespace ERPToolkit.Class
{
    // This is for COM Interop.
    [Guid("4af5b21c-cc04-4beb-ae3f-def3e0000010")]
    [ComVisible(true)]
    public class Server
    {
        /* Values: The ERPToolkit's way to pass values through classes */
        public StoreValues Values { get; set; }

        #region ServerList

        /// <summary>
        ///     Gets Servers
        /// </summary>
        /// <param name="separator">The separator used to separate the items of the list</param>
        /// <returns>List</returns>
        public List<string> GetServerList(string separator)
        {
            var instance = SqlDataSourceEnumerator.Instance;
            var serverList = new List<string>();
            try
            {
                var dtInstancesList = instance.GetDataSources().Select("", "ServerName ASC").CopyToDataTable();

                for (var i = 0; i < dtInstancesList.Rows.Count; i++)
                {
                    if (string.IsNullOrEmpty(dtInstancesList.Rows[i]["InstanceName"].ToString()))
                    {
                        serverList.Add(dtInstancesList.Rows[i]["ServerName"].ToString());
                    }
                    else
                    {
                        serverList.Add(dtInstancesList.Rows[i]["ServerName"] + "\\" +
                                       dtInstancesList.Rows[i]["InstanceName"]);
                    }
                }

                return serverList;
                //MessageBox.Show(serverList[0]);
            }
                //Do not use ExceptionForm
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, exception.GetType().ToString(), MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            return null;
        }

        #endregion
    }
}