/*
 * MethodInformation.cs - This file is part of ERPToolkit
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
using System.Reflection;
using System.Runtime.InteropServices;

namespace ERPToolkit.App.Class
{
    // This is for COM Interop.
    [Guid("4af5b21c-cc04-4beb-ae3f-def3e0000028")]
    [ComVisible(true)]
    public class MethodInformation
    {
        /* Values: The ERPToolkit's way to pass values through classes */
        public StoreValues Values { get; set; }

        #region GetNumber

        /// <summary>
        ///     Gets the number of public methods in the type specified
        /// </summary>
        /// <param name="myType"></param>
        /// <returns></returns>
        public int GetNumberOfPublicMethods(Type myType)
        {
            try
            {
                // Get the public methods.
                var myArrayMethodInfo =
                    myType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                return myArrayMethodInfo.Length;
            }
            catch (Exception exception)
            {
                var initEx = new ExceptionHandler();
                initEx.Values = Values;
                initEx.Handle(exception, MethodBase.GetCurrentMethod(), true);
            }
            return -1;
        }

        /// <summary>
        ///     Gets the number of non public methods in the type specified
        /// </summary>
        /// <param name="myType"></param>
        /// <returns></returns>
        public int GetNumberOfNonPublicMethods(Type myType)
        {
            try
            {
                // Get the nonpublic methods.
                var myArrayMethodInfo =
                    myType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                return myArrayMethodInfo.Length;
            }
            catch (Exception exception)
            {
                var initEx = new ExceptionHandler();
                initEx.Values = Values;
                initEx.Handle(exception, MethodBase.GetCurrentMethod(), true);
            }
            return -1;
        }

        #endregion

        #region GetMethodInfo

        /// <summary>
        ///     Gets all methods from a MethodInfo array
        /// </summary>
        /// <param name="myArrayMethodInfo"></param>
        /// <returns></returns>
        public List<string> GetMethodInfo(MethodInfo[] myArrayMethodInfo)
        {
            try
            {
                var list = new List<string>();

                // Gets information of all methods. 
                for (var i = 0; i < myArrayMethodInfo.Length; i++)
                {
                    var myMethodInfo = myArrayMethodInfo[i];
                    list.Add(myMethodInfo.Name);
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

        /// <summary>
        ///     Gets the list of all public methods in the type specified
        /// </summary>
        /// <param name="myType"></param>
        /// <returns></returns>
        public List<string> GetPublicMethodInfoList(Type myType)
        {
            try
            {
                // Get the nonpublic methods.
                var myArrayMethodInfo =
                    myType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

                // Display information for all methods.            
                return GetMethodInfo(myArrayMethodInfo);
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
        ///     Gets the list of all non public methods in the type specified
        /// </summary>
        /// <param name="myType"></param>
        /// <returns></returns>
        public List<string> GetNonPublicMethodInfoList(Type myType)
        {
            try
            {
                // Get the nonpublic methods.
                var myArrayMethodInfo =
                    myType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);

                // Display information for all methods.            
                return GetMethodInfo(myArrayMethodInfo);
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