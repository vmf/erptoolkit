/*
 * SysEnvironment.cs - This file is part of ERPToolkit
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
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using ERPToolkit.App.Class;

namespace ERPToolkit.Class
{
    // This is for COM Interop.
    [Guid("4af5b21c-cc04-4beb-ae3f-def3e0000013")]
    [ComVisible(true)]
    public class SysEnvironment
    {
        /* Values: The ERPToolkit's way to pass values through classes */
        public StoreValues Values { get; set; }

        #region Environment

        /// <summary>
        ///     Gets the user SID
        /// </summary>
        /// <param name="userName">User name</param>
        /// <returns>User SID</returns>
        public string GetUserSid(string userName)
        {
            try
            {
                var f = new NTAccount(userName);
                var s = (SecurityIdentifier) f.Translate(typeof (SecurityIdentifier));
                return s.ToString();
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
        ///     Gets the current user name
        /// </summary>
        /// <returns>User name</returns>
        public string UserName()
        {
            return Environment.UserName;
        }

        /// <summary>
        ///     Gets the current directory
        /// </summary>
        /// <returns>Directory</returns>
        public string CurrentDirectory()
        {
            return Environment.CurrentDirectory;
        }

        /// <summary>
        ///     If shutdown has started
        /// </summary>
        /// <returns>The truth</returns>
        public bool HasShutdownStarted()
        {
            return Environment.HasShutdownStarted;
        }

        /// <summary>
        ///     Is it a 64-bit OS ?
        /// </summary>
        /// <returns>The truth</returns>
        public bool Is64BitOperatingSystem()
        {
            return Environment.Is64BitOperatingSystem;
        }

        /// <summary>
        ///     Is it a 64-bit process ?
        /// </summary>
        /// <returns>The truth</returns>
        public bool Is64BitProcess()
        {
            return Environment.Is64BitProcess;
        }

        /// <summary>
        ///     Gets the Machine Name
        /// </summary>
        /// <returns>Machine Name</returns>
        public string MachineName()
        {
            return Environment.MachineName;
        }

        /// <summary>
        ///     Gets the OS Version
        /// </summary>
        /// <returns>OSVersion</returns>
        public string OsVersion()
        {
            return Environment.OSVersion.ToString();
        }

        /// <summary>
        ///     Gets the number of processors on the current machine
        /// </summary>
        /// <returns></returns>
        public int ProcessorCount()
        {
            return Environment.ProcessorCount;
        }

        /// <summary>
        ///     Gets the fully qualified path of the system directory
        /// </summary>
        /// <returns>System Directory</returns>
        public string SystemDirectory()
        {
            return Environment.SystemDirectory;
        }

        /// <summary>
        ///     Gets the amount of memory for an operation system's page file
        /// </summary>
        /// <returns>System Page Size</returns>
        public int SystemPageSize()
        {
            return Environment.SystemPageSize;
        }

        /// <summary>
        ///     Gets the number of milliseconds elapsed since the system started
        /// </summary>
        /// <returns>Tick Count</returns>
        public int TickCount()
        {
            return Environment.TickCount;
        }

        /// <summary>
        ///     Gets the network domain name associated with the current user
        /// </summary>
        /// <returns>User Domain Name</returns>
        public string UserDomainName()
        {
            return Environment.UserDomainName;
        }

        /// <summary>
        ///     Gets a value indicating whether the current process is running in user interactive mode
        /// </summary>
        /// <returns>The truth</returns>
        public bool UserInteractive()
        {
            return Environment.UserInteractive;
        }

        /// <summary>
        ///     Gets the version of the common language runtime
        /// </summary>
        /// <returns>Version</returns>
        public string Version()
        {
            return Environment.Version.ToString();
        }

        /// <summary>
        ///     Gets the amount of the physical memory mapped to the process context
        /// </summary>
        /// <returns>Working set</returns>
        public long WorkingSet()
        {
            return Environment.WorkingSet;
        }

        #endregion
    }
}