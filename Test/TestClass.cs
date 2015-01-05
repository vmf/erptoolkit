/*
 * TestClass.cs - This file is part of ERPToolkit
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
using System.Windows.Forms;
using ERPToolkit.App.Class;
using ERPToolkit.Class;
using ERPToolkit.WinForm;

namespace ERPToolkit.Test
{
    internal static class TestClass
    {
        [STAThread]
        public static void Main()
        {
            // Enable visual for WinForms
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Call methods for testing

            #region WinForm

            //TestProgressForm();
            //TestProgressForm2();

            #endregion

            #region Class

            #region SysEnvironment

            //TestUserName();

            #endregion

            #region ScriptRefactor

            //TestAddSummary();

            //TestChangeBlock();

            //TestDefineScriptCase();            

            #endregion

            #region SysIo

            #endregion

            #region Xml

            //TestGetListFromXml();

            #endregion

            #region General

            //TestReplaceInText();

            #endregion

            #endregion

            #region App.Class

            //TestExtractResource();

            #endregion

            #region LastTest

            TestChangeBlock();

            #endregion
        }

        #region WinForm

        #region ProgressForm

        private static void TestProgressForm()
        {
            var values = GetBasicValues();

            var progress = new ProgressForm();
            progress.Values = values;

            progress.Show();
            progress.MainMaximum = 5;
            progress.SubMaximum = 3000;
            progress.MainMinimum = 0;
            progress.SubMinimum = 0;
            progress.Title = "mytitle";
            progress.MainMessage = "main";

            for (var i = 1; i <= progress.MainMaximum; i++)
            {
                // Sub 1
                progress.SubValue = 1;
                for (var j = 1; j <= progress.SubMaximum; j++)
                {
                    progress.IncrementSub();
                    progress.SubMessage = "Sub-Process A...";
                }

                progress.IncrementMain();
                progress.MainMessage = "Main Process...";

                // Sub 2
                progress.SubValue = 1;
                for (var j = 1; j <= progress.SubMaximum; j++)
                {
                    progress.IncrementSub();
                    progress.SubMessage = "Sub-Process B...";
                }

                // Sub 3
                progress.SubValue = 1;
                for (var j = 1; j <= progress.SubMaximum; j++)
                {
                    progress.IncrementSub();
                    progress.SubMessage = "Sub-Process C...";
                }
            }
        }

        #endregion

        #endregion

        #region App.Class

        #region Resource

        private static void TestExtractResource()
        {
            var oRes = new Resource();
            oRes.Values = GetBasicValues();

            oRes.ExtractResource(@"C:\files\FontReg_x86-32.exe", @"ERPToolkit.Resources.FontReg.FontReg_x86-32.exe");
        }

        #endregion

        #endregion

        #region Values

        private static StoreValues GetBasicValues()
        {
            var values = new StoreValues();
            values.Language = "en-US";
            values.ResourceManager = "ERPToolkit.Resources.Lang.res_en_us";

            //values.Language = "pt-BR";
            //values.ResourceManager = "ERPToolkit.Resources.Lang.res_pt_br";

            /*values.WindowSize[0] = 1;
            values.WindowSize[1] = 1;
            values.WindowLocation[0] = 1;
            values.WindowLocation[1] = 1;*/

            return values;
        }

        #endregion

        #region Class

        #region SysIo

        private static void TestIsValidFile()
        {
            var test = new SysIo();
            Console.WriteLine(test.IsValidFile(@"C:\files\installer.xml", @"xml").ToString());
            Console.ReadLine();
        }

        #endregion

        #region SysEnvironment

        public static void TestUserName()
        {
            var sysEnv = new SysEnvironment();
            sysEnv.Values = GetBasicValues();
        }

        #endregion

        #region SysRegistry

        public static void TestCreateLocalIntranet()
        {
        }

        #endregion

        #region ScriptRefactor

        private static void TestAddSummary()
        {
            var oSr = new ScriptRefactor();
            oSr.Values = GetBasicValues();

            oSr.AddSummary(@"C:\files\from_script.vbs",
                @"C:\files\to_script.vbs",
                @"<example></example>;" +
                @"<os>145636</os>;" +
                @"<developer></developer>;" +
                @"<email></email>;" +
                @"<created></created>;" +
                @"<updated></updated>;" +
                @"<dependeces></dependeces>;");
        }

        private static void TestChangeBlock()
        {
            var oSr = new ScriptRefactor();
            oSr.Values = GetBasicValues();

            oSr.ChangeBlock(@"C:\files\from_script.vbs",
                @"C:\files\to_script.vbs",
                @"Test",
                "private sub Test2() " + Environment.NewLine +
                "    dim a" + Environment.NewLine +
                "end function");
        }

        private static void TestDefineScriptCase()
        {
            var oSr = new ScriptRefactor();
            oSr.Values = GetBasicValues();

            oSr.DefineScriptCase(@"c:\files\from_script.vbs", @"c:\files\to_script.vbs");
        }

        private static void TestRemoveWhiteSpaceEnd()
        {
        }

        #endregion

        #region Xml

        private static void TestGetListFromXml()
        {
            var xml = new Xml();
            var list =
                xml.GetListFromXml(
                    @"C:\Users\Vinicius M. Freitas\Source\Workspaces\ERPToolkit\ERPToolkit\Resources\Keyword\Language\vbscript.xml",
                    "keyword-name");

            foreach (var item in list)
                Console.WriteLine(item);
        }

        #endregion

        #region General

        private static void TestReplaceInText()
        {
            var oGeneral = new General();
            oGeneral.Values = GetBasicValues();

            MessageBox.Show(oGeneral.Replace("function", "Function", "Funtion", false));
        }

        #endregion

        #endregion
    }
}