/*
 * StoreValues.cs - This file is part of ERPToolkit
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

using System.Runtime.InteropServices;

namespace ERPToolkit.App.Class
{
    // This is for COM Interop.
    [Guid("4af5b21c-cc04-4beb-ae3f-def3e0000012")]
    [ComVisible(true)]
    public class StoreValues
    {
        #region Exception

        public string ExceptionFrom { get; set; }
        public string ExceptionType { get; set; }
        public string ExceptionMessage { get; set; }
        public string Exceptions { get; set; }

        #endregion

        #region Email

        public string FromAddress { get; set; }
        public string Password { get; set; }
        public string FromDisplayName { get; set; }
        public string SendToAddress { get; set; }
        public string SendToDisplayName { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
        public bool UseDefaultCredentials { get; set; }

        #endregion

        #region Language

        public string Language { get; set; }
        public string ResourceManager { get; set; }

        #endregion

        #region ERP

        public string ErpPath { get; set; }
        public string ErpPack { get; set; }
        public string ErpName { get; set; }

        #endregion

        #region Window

        public int WindowSizeX { get; set; }
        public int WindowSizeY { get; set; }

        public int WindowLocationX { get; set; }
        public int WindowLocationY { get; set; }

        #endregion
    }
}