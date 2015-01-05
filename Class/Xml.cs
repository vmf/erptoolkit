/*
 * Xml.cs - This file is part of ERPToolkit
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
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using ERPToolkit.App.Class;

namespace ERPToolkit.Class
{
    // This is for COM Interop.
    [Guid("4af5b21c-cc04-4beb-ae3f-def3e0000018")]
    [ComVisible(true)]
    public class Xml
    {
        /* Values: The ERPToolkit's way to pass values through classes */
        public StoreValues Values { get; set; }

        /// <summary>
        ///     Gets a generic List<string> from an xml file.
        /// </summary>
        /// <param name="xmlPath">Path to the xml file</param>
        /// <param name="node">The descendants that we're going to get</param>
        /// <returns></returns>
        public List<string> GetListFromXml(string xmlPath, string node)
        {
            try
            {
                var list = new List<string>();

                /* Loads the xml file */
                var doc = XDocument.Load(xmlPath);

                if (!string.IsNullOrEmpty(xmlPath))
                {
                    if (File.Exists(xmlPath))
                    {
                        /* For each value that we're getting,
                         * it's been added to the generic List<string>
                         */
                        foreach (var myNode in doc.Descendants(node))
                        {
                            list.Add(myNode.Value);
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
    }
}