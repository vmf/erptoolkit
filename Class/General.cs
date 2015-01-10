/*
 * General.cs - This file is part of ERPToolkit
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
 * along with this program; if not, write to the Free Softwaretest
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using ERPToolkit.App.Class;

namespace ERPToolkit.Class
{
    // This is for COM Interop.
    [Guid("4af5b21c-cc04-4beb-ae3f-def3e0000005")]
    [ComVisible(true)]
    public class General
    {
        /* Values: The ERPToolkit's way to pass values through classes */
        public StoreValues Values { get; set; }

        #region Filter

        /// <summary>
        ///     Filter
        /// </summary>
        /// <param name="item">Item</param>
        /// <param name="filter">Filter</param>
        /// <param name="matchCase">Is it a match case search ?</param>
        /// <param name="matchWhole">Is it a math whole word only search ?</param>
        /// <returns>'true' - it was found. 'false' - it wasn't found</returns>
        public bool Filter(string item, string filter, bool matchCase, bool matchWhole)
        {
            try
            {
                // Match case = true
                // Math whole only word = true
                if (matchCase && matchWhole)
                {
                    if (item.Equals(filter))
                    {
                        return true;
                    }
                }
                // Match case = false
                // Math whole only word = true
                else if (!matchCase && matchWhole)
                {
                    if (item.ToLower().Equals(filter.ToLower()))
                    {
                        return true;
                    }
                }
                else
                {
                    for (var i = 0; i < item.Length; i++)
                    {
                        // Match case = false
                        // Math whole only word = false
                        if (!matchCase)
                        {
                            if (
                                filter.Where(
                                    (t, j) => item.Substring(i, 1).ToLower().Equals(filter.Substring(j, 1).ToLower()))
                                    .Any())
                            {
                                return true;
                            }
                        }

                        // Match case = true
                        // Math whole only word = false
                        else
                        {
                            if (filter.Where((t, j) => item.Substring(i, 1).Equals(filter.Substring(j, 1))).Any())
                            {
                                return true;
                            }
                        }
                    }
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

        #region Check

        /// <summary>
        ///     Checks if the string has the prefix
        /// </summary>
        /// <param name="str">String</param>
        /// <param name="prefix">Prefix</param>
        /// <returns>The truth</returns>
        public bool IsTherePrefix(string str, string prefix)
        {
            try
            {
                if (!string.IsNullOrEmpty(str) && !string.IsNullOrEmpty(prefix))
                {
                    // If str name length is higher than
                    // or equal to the prefix length
                    if (str.Length >= prefix.Length)
                    {
                        // Checks if the the str name has prefix
                        if (str.Substring(0, prefix.Length).ToUpper().Equals(prefix.ToUpper()))
                        {
                            return true;
                        }
                    }
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

        #region Combine

        /// <summary>
        ///     Combine 2 paths
        /// </summary>
        /// <param name="path1">Path 1</param>
        /// <param name="path2">Path 2</param>
        /// <returns>Combined path</returns>
        public string CombinePath(string path1, string path2)
        {
            try
            {
                return Path.Combine(path1, path2);
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

        #region Char

        /// <summary>
        ///     Gets a char in a corresponding string
        /// </summary>
        /// <param name="str">string that we want to get the char</param>
        /// <param name="ch">char</param>
        /// <returns>Char position in the string or -1</returns>
        public int GetCharPosition(string str, string ch)
        {
            try
            {
                if (!string.IsNullOrEmpty(str))
                {
                    for (var index = 0; index < str.Length; index++)
                    {
                        if (str.Substring(index, 1).Equals(ch))
                        {
                            return index + 1;
                        }
                    }
                }
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
        ///     Gets the number of a char while the substring contains the char
        /// </summary>
        /// <param name="str">String</param>
        /// <param name="ch">Char that we want to find</param>
        /// <param name="since">Optional. The start number of the index of the loop</param>
        /// <returns></returns>
        public int GetNumberWhileChar(string str, string ch, int since = 0)
        {
            try
            {
                var nWhileChar = 0;
                for (var index = since; index < str.Length; index++)
                {
                    if (str.Substring(index, 1).Equals(ch))
                        nWhileChar++;
                }
                return nWhileChar;
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

        #region Get

        /// <summary>
        ///     Gets the Root path
        /// </summary>
        /// <param name="path">Path that we will be used to get the root path</param>
        /// <returns>Root path</returns>
        public string GetRootPath(string path)
        {
            try
            {
                var j = 0;

                // It means that is a server
                if (path.Substring(0, 2).Equals(@"\\"))
                {
                    j = 2;
                }
                for (var i = j; i < path.Length; i++)
                {
                    if (path.Substring(i, 1).Equals(@"\"))
                    {
                        return path.Substring(0, i);
                    }
                    if (i == path.Length - 1)
                    {
                        return path;
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
        ///     Gets the mapped path from a local path
        /// </summary>
        /// <param name="localPath">The local path</param>
        /// <returns>Mapped path</returns>
        public string GetMappedPath(string localPath)
        {
            try
            {
                if (localPath != null)
                {
                    // Check if it's already a mapped path
                    if (localPath.Substring(0, 2).Equals(@"\\"))
                    {
                        return localPath;
                    }
                    for (var i = 0; i <= localPath.Length; i++)
                    {
                        if (localPath.Substring(i, 1).Equals(@"\"))
                        {
                            return @"\\" +
                                   Path.Combine(Environment.MachineName, localPath.Substring(i, localPath.Length - i));
                        }
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
        ///     Gets the working directory of a file
        /// </summary>
        /// <param name="path">Path to the file</param>
        /// <returns>Working directory</returns>
        public string GetWorkingDirectory(string path)
        {
            try
            {
                for (var i = path.Length - 1; i >= 0; i--)
                {
                    if (path.Substring(i, 1).Equals("\\"))
                    {
                        return path.Substring(0, i) + @"\";
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

        #endregion

        #region List

        /// <summary>
        ///     Gets a list from a string based in a separator(Cannot use with Interop)
        /// </summary>
        /// <param name="str">string</param>
        /// <param name="separator">separator</param>
        /// <returns>List</returns>
        public List<string> GetListFromString(string str, string separator)
        {
            var list = new List<string>();
            try
            {
                if (!string.IsNullOrEmpty(str))
                {
                    /* Check if the last character of the string has the separator in the end. If not,
                     * the separator will be inserted in the end of the string. We need this
                     * because the last tag is not considered if it hasn't the separator, thus,
                     * if it's not specified, will be included anyway.
                    */
                    str = str.Substring(str.Length - 1, 1).Equals(separator) ? str : str + separator;

                    var strItem = "";
                    for (var i = 0; i < str.Length; i++)
                    {
                        if (!str.Substring(i, 1).Equals(separator))
                            strItem += str.Substring(i, 1);
                        else
                        {
                            list.Add(strItem);
                            strItem = "";
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

        /// <summary>
        ///     Gets a string list from a generic list 'List<string>'
        /// </summary>
        /// <param name="list"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public string GetStringFromList(List<string> list, string separator)
        {
            try
            {
                var strReturn = "";
                foreach (var item in list)
                    strReturn += item + separator;
                return strReturn;
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

        #region Refactor

        /// <summary>
        ///     Returns a string without another string. It can be a prefix, sufix
        ///     os in the middle of the string
        /// </summary>
        /// <param name="str">string to be updated</param>
        /// <param name="without">string to be removed</param>
        /// <returns>string replaced(if 'without' found) | string untouched(if 'without' not found)</returns>
        public string GetWithoutString(string str, string without)
        {
            try
            {
                if (!string.IsNullOrEmpty(str) && !string.IsNullOrEmpty(without))
                {
                    int startIndex = 0, endIndex = 0;

                    /* Loops to get the string items */
                    for (var index = 0; index < str.Length; index++)
                    {
                        /* We must first test if the index is lower than
                         * or equal to the length of the string less(-)
                         * the length of the without before testing the substring
                         * because in one moment we will not have enough string to get.
                         * */
                        if (index <= (str.Length - without.Length))
                        {
                            if (str.ToLower().Substring(index, without.Length).Equals(without.ToLower()))
                            {
                                /* The startIndex will be the index(the begining position of 'without') */
                                startIndex = index;

                                /* The endIndex will be the index plus(+) the lenght
                                 * of without.
                                 */
                                endIndex = index + without.Length;

                                /* Breaks the loop because we found it */
                                break;
                            }
                        }
                    }

                    var mystring = "";

                    /*  If endIndex is different of 0 means that
                     * we found the string 'without' in the string 'str'.                     
                     */
                    if (endIndex != 0)
                    {
                        /* Loops to get the string items */
                        for (var index = 0; index < str.Length; index++)
                        {
                            /* Gets the items that are not between startIndex
                             * and endIndex('wihout' position)                             
                             */
                            if (index < startIndex || index >= endIndex)
                                mystring += str.Substring(index, 1);
                        }

                        /* returns the replaced string */
                        return mystring;
                    }
                    /* returns the string untouched */
                    return str;
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
        ///     Updates the file Extension
        /// </summary>
        /// <param name="filePath">File path</param>
        /// <param name="newFileExtension">New file extension</param>
        /// <returns>Returns file with the new extension</returns>
        public string UpdateFileExtension(string filePath, string newFileExtension)
        {
            try
            {
                // add a "." if it was not added in the parameter 'newFileExtension' in the method call
                newFileExtension = !newFileExtension.Substring(0, 1).Equals(".")
                    ? "." + newFileExtension
                    : newFileExtension;

                for (var i = filePath.Length; i >= 0; i--)
                {
                    if (filePath.Substring(i - 1, 1).Equals("."))
                        return filePath.Substring(0, i - 1) + newFileExtension;
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
        ///     Replaces a text
        /// </summary>
        /// <param name="str">Text</param>
        /// <param name="findWhat">What we want to find</param>
        /// <param name="replaceWith">What we want to replace(if we find)</param>
        /// <param name="matchCase">The text will be found using match case ?</param>
        /// <returns>Replaced text(if found)</returns>
        public string Replace(string str, string findWhat, string replaceWith, bool matchCase)
        {
            try
            {
                var strCummulative = "";

                if (!string.IsNullOrEmpty(str))
                {
                    for (var index = 0; index < str.Length; index++)
                    {
                        if (matchCase)
                        {
                            /* Check if it has enough length to compare. if so, it'll compare.
                             * if not it won't need to compare because if it hasn't enough length
                             * means that it's not the text because the left length
                             * is less than the length of the text we are looking for.
                             */
                            if (index <= (str.Length - findWhat.Length))
                            {
                                /* Check if it is the text we are looking for */
                                if (str.Substring(index, findWhat.Length).Equals(findWhat))
                                {
                                    /* It gets the new text and then increments the index
                                     * with the findWhat length because once find the findWhat
                                     * we won't need to compare anything. Then, it adds the current substring
                                     * (substring after the increment of the index) if there are more text.
                                     */
                                    strCummulative += replaceWith;
                                    index += findWhat.Length;

                                    /* Does not get the next substring if                                      
                                     * there is no text anymore 
                                     */
                                    if (index < str.Length)
                                        strCummulative += str.Substring(index, 1);
                                }
                                else
                                    strCummulative += str.Substring(index, 1);
                            }
                            else
                                strCummulative += str.Substring(index, 1);
                        }
                        else
                        {
                            /* Check if it has enough length to compare. if so, it'll compare.
                             * if not it won't need to compare because if it hasn't enough length
                             * means that it's not the text because the left length
                             * is less than the length of the text we are looking for.
                             */
                            if (index <= (str.Length - findWhat.Length))
                            {
                                /* Check if it is the text we are looking for */
                                if (str.ToLower().Substring(index, findWhat.Length).Equals(findWhat.ToLower()))
                                {
                                    /* It gets the new text and then increments the index
                                     * with the findWhat length because once find the findWhat
                                     * we won't need to compare anything. Then, it adds the current substring
                                     * (substring after the increment of the index) if there are more text.
                                     */
                                    strCummulative += replaceWith;
                                    index += findWhat.Length;

                                    /* Does not get the next substring if                                      
                                     * there is no text anymore 
                                     */
                                    if (index < str.Length)
                                        strCummulative += str.Substring(index, 1);
                                }
                                else
                                    strCummulative += str.Substring(index, 1);
                            }
                            else
                                strCummulative += str.Substring(index, 1);
                        }
                    }
                }
                return strCummulative;
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