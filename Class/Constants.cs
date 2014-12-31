/*
 * Constants.cs - This file is part of ERPToolkit
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

using System.Runtime.InteropServices;

namespace ERPToolkit.Class
{
    // This is for COM Interop.
    [Guid("4af5b21c-cc04-4beb-ae3f-def3e0000001")]
    [ComVisible(true)]
    public class Constants
    {
        #region List

        public readonly string DefaultSeparator = ";";

        #endregion

        #region Patterns

        public readonly string FontPattern = "*.ttf";

        #endregion

        #region ScriptRefactor

        public readonly string MyPrivate = "private";
        public readonly string MyPublic = "public";
        public readonly string MyFunction = "function";
        public readonly string MySub = "sub";
        public readonly string MyByVal = "byval";
        public readonly string MyByRef = "byref";

        #endregion

        #region Filters

        public readonly string MsiFilter = @"Applications (*.msi)|*.msi";

        public readonly string ExeFilter = @"Applications (*.exe)|*.exe";

        public readonly string XmlFilter = @"XML Files (*.xml)|*.xml";

        #endregion

        #region Environment

        // Packages' path
        public readonly string TempPath = @"C:\temp";
        public readonly string LogExtension = @".log";

        // Reg path
        public readonly string Regsrv32Path = "C:\\Windows\\System32\\regsvr32.exe";
        public readonly string Regasm = "C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\RegAsm.exe";

        public readonly string LocalIntranetRegPath =
            "Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings\\ZoneMap\\Domains\\";

        public readonly string OdbcPath = "SOFTWARE\\ODBC\\ODBC.INI";

        // Key name
        public readonly string LocalIntranetKeyName = "file";

        #endregion
    }
}