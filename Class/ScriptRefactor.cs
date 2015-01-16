/*
 * ScriptRefactor.cs - This file is part of ERPToolkit
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
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Mime;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using ERPToolkit.App.Class;

namespace ERPToolkit.Class
{
    // This is for COM Interop.
    [Guid("4af5b21c-cc04-4beb-ae3f-def3e0000008")]
    [ComVisible(true)]
    public class ScriptRefactor
    {
        private string _cumulativestring;
        /* The list of keywords that'll be read from the xml file */
        private List<string> _listOfKeywords = new List<string>();
        /* Values: The ERPToolkit's way to pass values through classes */
        public StoreValues Values { get; set; }

        private CultureInfo _ci;
        private ResourceManager _rm;

        #region AddSummary

        /// <summary>
        ///     Adds summaries to a corresponding vbscript
        /// </summary>
        /// <param name="fromFilePath">Path to the file</param>
        /// <param name="toFilePath">Path to the file</param>
        /// <param name="tags">Tags</param>
        public void AddSummary(string fromFilePath, string toFilePath, string tags)
        {
            try
            {
                if (File.Exists(fromFilePath))
                {
                    var content = "";

                    /* Check if the last tag has the separator in the end. If not,
                     * the separator will be inserted in the end of the string. We need this
                     * because the last tag is not considered if it hasn't the separator, thus,
                     * if the user does not specify, will be included anyway
                    */
                    tags = !string.IsNullOrEmpty(tags) &&
                           !tags.Substring(tags.Length - 1, 1).Equals(new Constants().DefaultSeparator)
                        ? tags + ";"
                        : tags;

                    var reader = new StreamReader(fromFilePath, Encoding.GetEncoding("iso-8859-8"));
                    var sysIo = new SysIo {Values = Values};

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (!string.IsNullOrEmpty(line))
                        {
                            /*
                             * Check if it's a block. It means that the line found
                             * is a function or sub.
                             */
                            if (IsBlock(line))
                            {
                                /* Gets the parameters */
                                var parameters = GetParameters(line, reader);

                                /* Checks if there are parameters, if not, 
                                 * the line cannot break(NewLine)
                                 */
                                if (!string.IsNullOrEmpty(parameters))
                                    content += GetSummary(parameters) + Environment.NewLine;
                                else
                                    content += GetSummary(parameters);

                                /* Gets information TAGs */
                                content += GetTags(tags) + Environment.NewLine;

                                /* Gets the line and the cumulative string
                                 * if it has.
                                 */
                                content += line + Environment.NewLine + _cumulativestring;

                                /* Cleans the commulative string because 
                                 * we might have other functions 
                                 * or subs where their parameters are declared in
                                 * more than one line
                                 */
                                _cumulativestring = "";
                            }
                            else
                                content += line + Environment.NewLine;
                        }
                        else
                            content += line + Environment.NewLine;
                    }

                    /* Closes the object */
                    reader.Close();

                    /* Updates or creates a new file containing 
                     * the summaries(if the conditions were satisfied)
                     */
                    sysIo.WriteToFile(toFilePath, content);
                }
            }
            catch (Exception exception)
            {
                var initEx = new ExceptionHandler();
                initEx.Values = Values;
                initEx.Handle(exception, MethodBase.GetCurrentMethod(), true);
            }
        }

        #region Parameter

        /// <summary>
        ///     Gets the summary
        /// </summary>
        /// <param name="line">Line of the text</param>
        /// <param name="reader">StreamReader object</param>
        /// <returns>Summary</returns>
        private string GetParameters(string line, StreamReader reader)
        {
            try
            {
                if (!string.IsNullOrEmpty(line))
                {
                    var general = new General();
                    general.Values = Values;

                    string currentPrm = "", parameters = "";
                    var startIndex = general.GetCharPosition(line, "(");

                    if (startIndex != -1)
                    {
                        for (var index = startIndex; index < line.Length; index++)
                        {
                            /* If this substring is ',' means that we have
                             * a parameter to get and that we have other
                             * parameters
                             */
                            if (line.Substring(index, 1).Equals(@","))
                            {
                                parameters += GetParameter(currentPrm) + Environment.NewLine;

                                /* Cleans the current parameter to get the next parameter */
                                currentPrm = "";
                            }

                            /* If this substring is ')' means that we are
                             * in the end of the parameters, thus, we can
                             * read the parameter and then break the loop.
                             */
                            else if (line.Substring(index, 1).Equals(@")"))
                            {
                                parameters += GetParameter(currentPrm);
                                break;
                            }
                            else if (line.Substring(index, 1).Equals(@"_"))
                            {
                                /* Checks if we are in the end of line
                                 * if so, we know that we have more parameters
                                 * in the next line, if not, the parameter name
                                 * contains underline('_')
                                 */
                                if (index + 1 == line.Trim().Length)
                                {
                                    /* Reads the next line that contains more parameters */
                                    line = reader.ReadLine();

                                    /* Saves this line to a comulative variable because
                                     * the StreamReader object will consume the next line and
                                     * we'll need it again.
                                     */
                                    _cumulativestring += line + Environment.NewLine;

                                    /* Reset the indexes because it's a new line */
                                    // ReSharper disable once RedundantAssignment
                                    startIndex = 0;
                                    index = 0;
                                }
                                // ReSharper disable once PossibleNullReferenceException
                                currentPrm += line.Substring(index, 1);
                            }
                            else
                                currentPrm += line.Substring(index, 1);
                        }
                        return parameters;
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
        ///     Loads the parameter structure
        /// </summary>
        /// <param name="parameter">Parameter</param>
        /// <returns>Loaded(Formated prm)</returns>
        private string GetParameter(string parameter)
        {
            try
            {
                var general = new General();

                if (!string.IsNullOrEmpty(parameter))
                {
                    /* Removes the keyword from parameter */
                    var rParameter = parameter;
                    rParameter = general.GetWithoutString(rParameter, new Constants().ByValKeyword.ToLower());
                    rParameter = general.GetWithoutString(rParameter, new Constants().ByRefKeyword.ToLower());

                    /* Removes white spaces */
                    rParameter = rParameter.Trim();

                    /* returns the parameter */
                    return "''' <param name=" + "\"" +
                           rParameter + "\"" +
                           "></param>";
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
        ///     Loads the summary
        /// </summary>
        /// <param name="parameters">Parameters</param>
        /// <returns>Summary</returns>
        private string GetSummary(string parameters)
        {
            try
            {
                return
                    "''' <summary> " + Environment.NewLine +
                    "'''" + Environment.NewLine +
                    "''' </summary> " + Environment.NewLine +
                    parameters;
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

        #region Tags

        private string GetTags(string tags)
        {
            try
            {
                if (!string.IsNullOrEmpty(tags))
                {
                    var general = new General();
                    var tagValues = "";

                    var list = general.GetListFromString(tags, new Constants().DefaultSeparator);
                    foreach (var item in list)
                    {
                        tagValues += "\r\n" + "'" + new string(' ', 4) + item;
                        Console.WriteLine(item);
                    }

                    return
                        "'<info>" +
                        tagValues + Environment.NewLine +
                        "'</info>";
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

        #endregion

        #region RemoveWhiteSpaceEnd

        /// <summary>
        ///     Removes the white spaces of a text file
        /// </summary>
        /// <param name="fromFilePath">Path to the file</param>
        /// <param name="toFilePath">Path to the file</param>
        public void RemoveWhiteSpaceEnd(string fromFilePath, string toFilePath)
        {
            try
            {
                if (File.Exists(fromFilePath))
                {
                    var content = "";

                    var reader = new StreamReader(fromFilePath, Encoding.GetEncoding("iso-8859-8"));
                    var sysIo = new SysIo {Values = Values};

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (!string.IsNullOrEmpty(line))
                        {
                            /* Gets the line without the white spaces in the end*/
                            content += GetRemovedWhiteSpaceEnd(line) + Environment.NewLine;
                        }
                        else
                            content += Environment.NewLine;
                    }

                    reader.Close();

                    sysIo.WriteToFile(toFilePath, content);
                }
            }
            catch (Exception exception)
            {
                var initEx = new ExceptionHandler();
                initEx.Values = Values;
                initEx.Handle(exception, MethodBase.GetCurrentMethod(), true);
            }
        }

        #region GetRemovedWhiteSpaceEnd

        /// <summary>
        ///     Gets the line without the white spaces in the end
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private string GetRemovedWhiteSpaceEnd(string line)
        {
            try
            {
                return line.TrimEnd();
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

        #endregion

        #region Block

        /// <summary>
        ///     Checks if it starts with an identifier and
        ///     if it is a function or sub
        /// </summary>
        /// <param name="line">Line of the text</param>
        /// <returns>'true' - It's a block | 'false' - it's not a block</returns>
        private bool IsBlock(string line)
        {
            try
            {
                int space;

                /* Check if the string(line) has enough length, if so,
                 * we can start comparing
                 */
                if (line.Length >= new Constants().PrivateKeyword.Length)
                {
                    // Check for the 'private' keyword
                    if (
                        line.Substring(0, new Constants().PrivateKeyword.Length)
                            .ToLower()
                            .Equals(new Constants().PrivateKeyword.ToLower()))
                    {
                        /* Gets the white space between the keyword of access and the keyword of the block.
                         * Generally, the space between the keywords is '1', but it can be more than one, thus,
                         * we must get the number of white spaces before comparing.
                         */
                        space = GetSpaceToBlockType(line, new Constants().PrivateKeyword.ToLower());

                        /* Checks whether enough characters left, if so
                         * we can start comparing the next keyword
                         */
                        if (line.Length >=
                            new Constants().PrivateKeyword.Length + space + new Constants().FunctionKeyword.Length)
                        {
                            // Check for the 'function' keyword
                            if (
                                line.Substring(new Constants().PrivateKeyword.Length + space,
                                    new Constants().FunctionKeyword.Length)
                                    .ToLower()
                                    .Equals(new Constants().FunctionKeyword.ToLower()))
                                return true;
                        }

                        /* Checks whether enough characters left, if so
                         * we can start comparing the next keyword
                         */
                        if (line.Length >=
                            new Constants().PrivateKeyword.Length + space + new Constants().SubKeyword.Length)
                        {
                            // Check for the 'sub' keyword
                            if (
                                line.Substring(new Constants().PrivateKeyword.Length + space,
                                    new Constants().SubKeyword.Length)
                                    .ToLower()
                                    .Equals(new Constants().SubKeyword.ToLower()))
                                return true;
                        }
                        return false;
                    }
                }

                /* Check if the string(line) has enough length, if so,
                 * we can start comparing
                 */
                if (line.Length >= new Constants().PublicKeyword.Length)
                {
                    // Check for the 'public' keyword
                    if (
                        line.Substring(0, new Constants().PublicKeyword.Length)
                            .ToLower()
                            .Equals(new Constants().PublicKeyword.ToLower()))
                    {
                        /* Gets the white space between the keyword of access and the keyword of the block.
                         * Generally, the space between the keywords is '1', but it can be more than one, thus,
                         * we must get the number of white spaces before comparing.
                         */
                        space = GetSpaceToBlockType(line, new Constants().PublicKeyword.ToLower());

                        /* Checks whether enough characters left, if so
                         * we can start comparing the next keyword
                         */
                        if (line.Length >=
                            new Constants().PublicKeyword.Length + space + new Constants().FunctionKeyword.Length)
                        {
                            // Check for the 'function' keyword
                            if (
                                line.Substring(new Constants().PublicKeyword.Length + space,
                                    new Constants().FunctionKeyword.Length)
                                    .ToLower()
                                    .Equals(new Constants().FunctionKeyword.ToLower()))
                                return true;
                        }

                        /* Checks whether enough characters left, if so
                         * we can start comparing the next keyword
                         */
                        if (line.Length >=
                            new Constants().PublicKeyword.Length + space + new Constants().SubKeyword.Length)
                        {
                            // Check for the 'sub' keyword
                            if (
                                line.Substring(new Constants().PublicKeyword.Length + space,
                                    new Constants().SubKeyword.Length)
                                    .ToLower()
                                    .Equals(new Constants().SubKeyword.ToLower()))
                                return true;
                        }
                        return false;
                    }
                }

                /* Check if the string(line) has enough length, if so,
                 * we can start comparing
                 */
                if (line.Length >= new Constants().SubKeyword.Length)
                {
                    // Check for the 'sub' keyword
                    if (
                        line.Substring(0, new Constants().SubKeyword.Length)
                            .ToLower()
                            .Equals(new Constants().SubKeyword.ToLower()))
                        return true;
                }

                /* Check if the string(line) has enough length, if so,
                 * we can start comparing
                 */
                if (line.Length >= new Constants().FunctionKeyword.Length)
                {
                    // Check for the 'function' keyword
                    if (
                        line.Substring(0, new Constants().FunctionKeyword.Length)
                            .ToLower()
                            .Equals(new Constants().FunctionKeyword.ToLower()))
                        return true;
                }
                return false;
            }
            catch (Exception exception)
            {
                var initEx = new ExceptionHandler();
                initEx.Values = Values;
                initEx.Handle(exception, MethodBase.GetCurrentMethod(), true);
            }
            return false;
        }

        /// <summary>
        ///     Gets the white space between the keyword of access and the keyword of the block
        /// </summary>
        /// <param name="line">Line of the text</param>
        /// <param name="blockAccess">Block Access ('public' or 'private')</param>
        /// <returns></returns>
        private int GetSpaceToBlockType(string line, string blockAccess)
        {
            try
            {
                var oGeneral = new General();
                var index = 0;

                /* Remove the blockAccess from the line, so 
                 * we can start counting the number of white spaces
                 */
                var myLine = oGeneral.GetWithoutString(line, blockAccess.ToLower());

                /* Counting the number of white spaces */
                while (myLine.Substring(index, 1).Equals(@" "))
                    index++;
                return index;
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

        #region ChangeBlock

        #region ChangeBlock

        /// <summary>
        ///     Changes a block('sub' or 'function') of a vbscript
        /// </summary>
        /// <param name="fromFilePath">Path to the file</param>
        /// <param name="toFilePath">Path to the file</param>
        /// <param name="oldBlockName">Name of the old block(block that'll be replaced)</param>
        /// <param name="newBlock">Entire new block('sub' or 'function')</param>
        public void ChangeBlock(string fromFilePath, string toFilePath, string oldBlockName, string newBlock)
        {
            try
            {
                if (File.Exists(fromFilePath))
                {
                    var content = "";

                    var reader = new StreamReader(fromFilePath, Encoding.GetEncoding("iso-8859-8"));
                    var sysIo = new SysIo {Values = Values};

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (!string.IsNullOrEmpty(line))
                        {
                            if (IsBlock(line))
                            {
                                /* Checks if the block that we must find to replace 
                                 * is equal to the block that was found in this line
                                 */
                                if (oldBlockName.ToLower().Trim().Equals(GetBlockName(line).ToLower().Trim()))
                                {
                                    /* Reads the lines while it is the old block. Thus,
                                     * when have finished the reading, we just update the
                                     * the text part that wasn't added yet.
                                     */
                                    ReadWhileBlock(reader);

                                    /* Gets the new block */
                                    content += newBlock + Environment.NewLine;
                                }
                                else
                                    content += line + Environment.NewLine;
                            }
                            else
                                content += line + Environment.NewLine;
                        }
                        else
                            content += line + Environment.NewLine;
                    }

                    reader.Close();

                    sysIo.WriteToFile(toFilePath, content);
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

        #region BlockName

        /// <summary>
        ///     Gets the block name('function' name or 'sub' name)
        /// </summary>
        /// <param name="line">Line of the text file</param>
        /// <returns>Block name</returns>
        private string GetBlockName(string line)
        {
            try
            {
                var oGeneral = new General();
                var myLine = line.ToLower();

                /* Removes all the access and type keywords from the line, thus, we can
                 * get the block name easier.
                 */
                myLine = oGeneral.GetWithoutString(myLine, new Constants().PrivateKeyword.ToLower());
                myLine = oGeneral.GetWithoutString(myLine, new Constants().PublicKeyword.ToLower());
                myLine = oGeneral.GetWithoutString(myLine, new Constants().FunctionKeyword.ToLower());
                myLine = oGeneral.GetWithoutString(myLine, new Constants().SubKeyword.ToLower());

                /* Gets the '(' index of the line position because 
                 * once found it we have the end of the block name('function', 'sub').             
                 */
                return myLine.Substring(0, oGeneral.GetCharPosition(myLine, @"(") - 1).TrimStart();
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

        #region ReadWhileBlock

        /// <summary>
        ///     Reads the block of the script while the spacified block
        ///     wasn't finished.
        /// </summary>
        /// <param name="reader">StreamReader object</param>
        private void ReadWhileBlock(StreamReader reader)
        {
            try
            {
                const int space = 1;

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                    {
                        /* Check if it starts with the 'end' keyword */
                        if (line.ToLower()
                            .Substring(0, new Constants().EndKeyword.Length)
                            .Equals(new Constants().EndKeyword.ToLower()))
                        {
                            /* Checks if it has enough length to compare */
                            if (line.Length >=
                                new Constants().EndKeyword.Length + space + new Constants().FunctionKeyword.Length)
                            {
                                /* Check if it is a end of a function */
                                if (line.ToLower()
                                    .Substring(new Constants().EndKeyword.Length + space,
                                        new Constants().FunctionKeyword.Length)
                                    .Equals(new Constants().FunctionKeyword.ToLower()))
                                {
                                    break;
                                }
                            }

                            /* Checks if it has enough length to compare */
                            if (line.Length >=
                                new Constants().EndKeyword.Length + space + new Constants().SubKeyword.Length)
                            {
                                /* Check if it is a end of a sub */
                                if (line.ToLower()
                                    .Substring(new Constants().EndKeyword.Length + space,
                                        new Constants().SubKeyword.Length)
                                    .Equals(new Constants().SubKeyword.ToLower()))
                                {
                                    break;
                                }
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
        }

        #endregion

        #endregion

        #region DefineScriptCase

        /// <summary>
        ///     Defines the script case(case of the keywords)
        /// </summary>
        /// <param name="fromFilePath"></param>
        /// <param name="toFilePath"></param>
        /// <param name="keywordCase">
        ///     Optional. The case that will be defined for the keywords.
        ///     "D" - Default,
        ///     "L" - Lower Case,
        ///     "U" - Upper Case
        /// </param>
        public void DefineScriptCase(string fromFilePath, string toFilePath, string keywordCase = "D")
        {
            try
            {
                if (File.Exists(fromFilePath))
                {
                    var content = "";
                    var reader = new StreamReader(fromFilePath, Encoding.GetEncoding("iso-8859-8"));
                    var sysIo = new SysIo {Values = Values};

                    /* While it's not in the end of file */
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (!string.IsNullOrEmpty(line))
                        {
                            /* It gets the refactored line. It'll basically replace
                             * all the keywords of the line with the keywords of the
                             * xml(if found) and more important:
                             * it'll replace with the case defined in 'keywordCase'.
                             * If the method return null means that something goes wrong,
                             * thus, the loop in lines will break.
                             */
                            var newContent = DefineKeywordsCase(line, keywordCase);
                            if (!string.IsNullOrEmpty(newContent))
                                content += newContent + Environment.NewLine;
                            else
                                break;
                        }
                        else
                            content += Environment.NewLine;
                    }

                    reader.Close();

                    sysIo.WriteToFile(toFilePath, content);
                }
            }
            catch (Exception exception)
            {
                var initEx = new ExceptionHandler();
                initEx.Values = Values;
                initEx.Handle(exception, MethodBase.GetCurrentMethod(), true);
            }
        }

        private string DefineKeywordsCase(string line, string keywordCase)
        {
            try
            {
                var myLine = line;

                /* Does not read the keywords again once read it */
                if (_listOfKeywords.Count == 0)
                {
                    _listOfKeywords = new Xml().GetListFromXml(
                        ERPToolkit.Properties.Resources.vbscript,
                        @"keyword-name");
                }

                var oGeneral = new General();
                foreach (var item in _listOfKeywords)
                {
                    /* In the next section it'll define what case to use
                     * for the keywords of the line.
                     */

                    /* Default Case */
                    if (keywordCase.Trim().ToUpper().Equals("D"))
                    {
                        myLine = oGeneral.Replace(myLine, item, item, false, true);
                    }

                    /* Lower Case */
                    else if (keywordCase.Trim().ToUpper().Equals("L"))
                    {
                        myLine = oGeneral.Replace(myLine, item, item.ToLower(), false, true);
                    }

                    /* Upper Case */
                    else if (keywordCase.Trim().ToUpper().Equals("U"))
                    {
                        myLine = oGeneral.Replace(myLine, item, item.ToUpper(), false, true);
                    }

                    /* Unknown parameter */
                    else
                    {
                        MessageBox.Show(_rm.GetString("unknownParameter", _ci) + @": " + keywordCase, _rm.GetString("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        /* Returning null the main method will known 
                         * that something goes wrong and will break the loop 
                         */
                        return null;                        
                    }
                }

                return myLine;
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

        #region InitializeLanguage

        /// <summary>
        ///     Initializes language
        /// </summary>
        public void InitializeLanguage()
        {
            /* If the language wasn't specified, English will be the default language */
            if (string.IsNullOrEmpty(Values.Language) || string.IsNullOrEmpty(Values.ResourceManager))
            {
                Values.Language = "en-US";
                Values.ResourceManager = "ERPToolkit.Resources.Lang.res_en_us";
            }
            _ci = new CultureInfo(Values.Language);
            var a = Assembly.Load("ERPToolkit");
            _rm = new ResourceManager(Values.ResourceManager, a);
        }

        #endregion
    }
}