/*
 * Uac.cs - This file is part of ERPToolkit
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
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using ERPToolkit.App.Class;

namespace ERPToolkit.Class
{
    // This is for COM Interop.
    [Guid("4af5b21c-cc04-4beb-ae3f-def3e0000016")]
    [ComVisible(true)]
    public class Uac
    {
        /* Values: The ERPToolkit's way to pass values through classes */
        public StoreValues Values { get; set; }

        #region Modify

        /// <summary>
        ///     Modify UAC Level based on the parameters given
        /// </summary>
        /// <param name="enableLua">("1" TO DECAY) ("1" FOR RAISE)</param>
        /// <param name="consentPromptBehaviorAdmin">("0" TO DECAY) ("5" FOR RAISE)</param>
        /// <param name="consentPromptBehaviorUser">("0" TO DECAY) ("3" FOR RAISE)</param>
        /// <param name="promptOnSecureDesktop">("0" TO DECAY) ("1" FOR RAISE)</param>
        public void Modify(int enableLua, int consentPromptBehaviorAdmin, int consentPromptBehaviorUser,
            int promptOnSecureDesktop)
        {
            try
            {
                var process = new System.Diagnostics.Process();
                var startInfo = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments =
                        @" /C reg.exe ADD HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System /v EnableLUA /t REG_DWORD /d " +
                        enableLua + " /f & " +
                        @"reg.exe ADD HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System /v ConsentPromptBehaviorAdmin /t REG_DWORD /d " +
                        consentPromptBehaviorAdmin + " /f & " +
                        @"reg.exe ADD HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System /v ConsentPromptBehaviorUser /t REG_DWORD /d " +
                        consentPromptBehaviorUser + " /f & " +
                        @"reg.exe ADD HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System /v PromptOnSecureDesktop /t REG_DWORD /d " +
                        promptOnSecureDesktop + " /f",
                    Verb = "runas"
                };
                process.StartInfo = startInfo;
                process.Start();
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