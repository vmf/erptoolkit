/*
 * SysIo.cs - This file is part of ERPToolkit
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
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using ERPToolkit.App.Class;

namespace ERPToolkit.Class
{
    // This is for COM Interop.
    [Guid("4af5b21c-cc04-4beb-ae3f-def3e0000014")]
    [ComVisible(true)]
    public class SysIo
    {
        /* Values: The ERPToolkit's way to pass values through classes */
        public StoreValues Values { get; set; }

        #region Write

        /// <summary>
        ///     Write a content to a text file
        /// </summary>
        /// <param name="filePath">Path to the file</param>
        /// <param name="content">Content</param>
        public void WriteToFile(string filePath, string content)
        {
            try
            {
                var writer = new StreamWriter(filePath, false, Encoding.GetEncoding("iso-8859-8"));
                writer.Write(content);
                writer.Close();
            }
            catch (Exception exception)
            {
                var initEx = new ExceptionHandler();
                initEx.Values = Values;
                initEx.Handle(exception, MethodBase.GetCurrentMethod(), true);
            }
        }

        #endregion

        #region Copy

        /// <summary>
        ///     Copy files to another directory
        /// </summary>
        /// <param name="sourceDir">Directory that contains the files</param>
        /// <param name="destDir">Directory of destination</param>
        /// <param name="pattern">File extension that we want to copy</param>
        public void CopyTo(string sourceDir, string destDir, string pattern)
        {
            try
            {
                foreach (var file in new DirectoryInfo(sourceDir).GetFiles(pattern))
                {
                    file.CopyTo(Path.Combine(destDir, file.Name), true);
                }
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
        ///     Used to validate the file existence and extension
        /// </summary>
        /// <param name="path">Path to the file</param>
        /// <param name="extension">File extension</param>
        /// <returns>The truth</returns>
        public bool IsValidFile(string path, string extension)
        {
            try
            {
                return File.Exists(path) && !string.IsNullOrEmpty(extension)
                       && path.Substring(path.Length - extension.Length, extension.Length).Equals(extension);
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

        #region Refactor

        /// <summary>
        ///     Replaces(Refactor)
        /// </summary>
        /// <param name="filePath">Path to the file</param>
        /// <param name="findWhat">Text to find</param>
        /// <param name="replaceWith">Text to replace if found</param>
        public void ReplaceText(string filePath, string findWhat, string replaceWith)
        {
            try
            {
                var reader = new StreamReader(filePath);
                var content = reader.ReadToEnd();
                reader.Close();

                content = content.Replace(findWhat, replaceWith);

                var writer = new StreamWriter(filePath);
                writer.Write(content);
                writer.Close();
            }
            catch (Exception exception)
            {
                var initEx = new ExceptionHandler();
                initEx.Values = Values;
                initEx.Handle(exception, MethodBase.GetCurrentMethod(), true);
            }
        }

        #endregion

        #region Delete

        /// <summary>
        ///     Delete the subdirectories, files and the directory itself
        /// </summary>
        /// <param name="directoryPath">Path to the directory</param>
        public void DeleteDirectory(string directoryPath)
        {
            try
            {
                if (Directory.Exists(directoryPath))
                {
                    var directoryInfo = new DirectoryInfo(directoryPath);

                    // Files
                    foreach (var file in directoryInfo.GetFiles())
                    {
                        file.Delete();
                    }

                    // Directories
                    foreach (var dir in directoryInfo.GetDirectories())
                    {
                        dir.Delete(true);
                    }

                    // Directory
                    Directory.Delete(directoryPath);
                }
            }
            catch (Exception exception)
            {
                var initEx = new ExceptionHandler();
                initEx.Values = Values;
                initEx.Handle(exception, MethodBase.GetCurrentMethod(), true);
            }
        }

        #endregion

        #region Choose

        /// <summary>
        ///     Used to choose a file and gets its path
        /// </summary>
        /// <param name="strCurrentPath">Will be returned if user cancels the dialog</param>
        /// <param name="strFilter">Filter(kind of file)</param>
        /// <param name="initialDir">Initial Directory(Can be ommited)</param>
        /// <returns>file path if selected or the current path if dialog be canceled</returns>
        public string ChooseFile(string strCurrentPath, string strFilter, string initialDir)
        {
            try
            {
                var ofd = new OpenFileDialog();
                ofd.Filter = strFilter;
                if (!string.IsNullOrEmpty(initialDir))
                    ofd.InitialDirectory = initialDir;

                return ofd.ShowDialog() == DialogResult.OK ? ofd.FileName : strCurrentPath;
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
        ///     Opens the dialog to choose a folder and return its path
        /// </summary>
        /// <param name="strCurrentPath">The current data field</param>
        /// <returns>Returns the current data field if the dialog be canceled</returns>
        public string ChoosePath(string strCurrentPath)
        {
            try
            {
                var fbd = new FolderBrowserDialog();

                return fbd.ShowDialog() == DialogResult.OK ? fbd.SelectedPath : strCurrentPath;
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
        ///     Opens a dialog to choose where to save the file
        /// </summary>
        /// <param name="strCurrentPath">Current path</param>
        /// <param name="strFilter">Kind of file(Filter)</param>
        /// <param name="initialDir">Initial directory</param>
        /// <returns>Selected path or the current path</returns>
        public string SaveFile(string strCurrentPath, string strFilter, string initialDir)
        {
            try
            {
                var sfd = new SaveFileDialog();
                sfd.Filter = strFilter;

                if (!string.IsNullOrEmpty(initialDir))
                    sfd.InitialDirectory = initialDir;

                return sfd.ShowDialog() == DialogResult.OK ? sfd.FileName : strCurrentPath;
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

        #region Get

        /// <summary>
        ///     Gets a text(content) of a text file
        /// </summary>
        /// <param name="filePath">Path to the file</param>
        /// <returns>Content of the file</returns>
        public string GetFileText(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    var reader = new StreamReader(filePath);

                    var content = reader.ReadToEnd();

                    return content;
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
        ///     Gets the product name of some package
        /// </summary>
        /// <param name="filePath">Path to the file</param>
        /// <returns>Product name</returns>
        public string GetProductName(string filePath)
        {
            try
            {
                if (!File.Exists(filePath)) return null;
                var myFileVersionInfo = FileVersionInfo.GetVersionInfo(filePath);

                // Get product version from file             
                return myFileVersionInfo.ProductName;
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
        ///     Gets the file name of some file
        /// </summary>
        /// <param name="filePath">Path to the file</param>
        /// <returns>File name</returns>
        public string GetFileName(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    return new FileInfo(filePath).Name;
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
        ///     Gets the legal trademarks
        /// </summary>
        /// <param name="filePath">File path</param>
        public string GetLegalTrademarks(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    // Get version info from the file
                    var myFileVersionInfo = FileVersionInfo.GetVersionInfo(filePath);

                    // Get legal trademarks from the file
                    return myFileVersionInfo.LegalTrademarks;
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
    }
}