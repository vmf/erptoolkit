/*
 * ScriptRefactor.cs - This file is part of ERPToolkit
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
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using ERPToolkit.App.Class;

namespace ERPToolkit.Class
{
    // This is for COM Interop.
    [Guid("4af5b21c-cc04-4beb-ae3f-def3e0000008")]
    [ComVisible(true)]
    public class ScriptRefactor
    {
        private string _cumulativestring;
        /* Values: The ERPToolkit's way to pass values through classes */
        public StoreValues Values { get; set; }

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
                     * the separator will be inserted in the end of the string. This is needed
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

        #region Block

        /// <summary>
        ///     Checks if it starts with an identifier and
        ///     if it is a function or sub
        /// </summary>
        /// <param name="str">Line of the text</param>
        /// <returns>'true' - It's a block | 'false' - it's not a block</returns>
        private bool IsBlock(string str)
        {
            try
            {
                const int Space = 1;

                /* Check if the string(line) has enough length, if so,
                 * we can start comparing
                 */
                if (str.Length >= new Constants().MyPrivate.Length)
                {
                    // Check for the 'private' keyword
                    if (str.Substring(0, new Constants().MyPrivate.Length).ToLower().Equals(new Constants().MyPrivate))
                    {
                        /*
                         * FIXME: We are adding 1 'Constants().MyPrivate.Length + 1' because
                         * it simulates the space after the keyword. For example:
                         * 'private function'('private' + 1 space + 'funciton') or 
                         * 'private variable'('private' + 1 space + 'variable'). 
                         * But the statement can contain more than one space between 
                         * keywords, thus, would be nice to have a method to
                         * identify the number of spaces between keywords.
                         */

                        /* Checks whether enough characters left, if so
                         * we can start comparing the next keyword
                         */
                        if (str.Length >= new Constants().MyPrivate.Length + Space + new Constants().MyFunction.Length)
                        {
                            // Check for the 'function' keyword
                            if (
                                str.Substring(new Constants().MyPrivate.Length + Space,
                                    new Constants().MyFunction.Length)
                                    .ToLower()
                                    .Equals(new Constants().MyFunction))
                                return true;
                        }

                        /* Checks whether enough characters left, if so
                         * we can start comparing the next keyword
                         */
                        if (str.Length >= new Constants().MyPrivate.Length + Space + new Constants().MySub.Length)
                        {
                            // Check for the 'sub' keyword
                            if (
                                str.Substring(new Constants().MyPrivate.Length + Space, new Constants().MySub.Length)
                                    .ToLower()
                                    .Equals(new Constants().MySub))
                                return true;
                        }
                        return false;
                    }
                }

                /* Check if the string(line) has enough length, if so,
                 * we can start comparing
                 */
                if (str.Length >= new Constants().MyPublic.Length)
                {
                    // Check for the 'public' keyword
                    if (str.Substring(0, new Constants().MyPublic.Length).ToLower().Equals(new Constants().MyPublic))
                    {
                        /* Checks whether enough characters left, if so
                         * we can start comparing the next keyword
                         */
                        if (str.Length >= new Constants().MyPublic.Length + Space + new Constants().MyFunction.Length)
                        {
                            // Check for the 'function' keyword
                            if (
                                str.Substring(new Constants().MyPublic.Length + Space, new Constants().MyFunction.Length)
                                    .ToLower()
                                    .Equals(new Constants().MyFunction))
                                return true;
                        }

                        /* Checks whether enough characters left, if so
                         * we can start comparing the next keyword
                         */
                        if (str.Length >= new Constants().MyPublic.Length + Space + new Constants().MySub.Length)
                        {
                            // Check for the 'sub' keyword
                            if (
                                str.Substring(new Constants().MyPublic.Length + Space, new Constants().MySub.Length)
                                    .ToLower()
                                    .Equals(new Constants().MySub))
                                return true;
                        }
                        return false;
                    }
                }

                /* Check if the string(line) has enough length, if so,
                 * we can start comparing
                 */
                if (str.Length >= new Constants().MySub.Length)
                {
                    // Check for the 'sub' keyword
                    if (str.Substring(0, new Constants().MySub.Length).ToLower().Equals(new Constants().MySub))
                        return true;
                }

                /* Check if the string(line) has enough length, if so,
                 * we can start comparing
                 */
                if (str.Length >= new Constants().MyFunction.Length)
                {
                    // Check for the 'function' keyword
                    if (str.Substring(0, new Constants().MyFunction.Length).ToLower().Equals(new Constants().MyFunction))
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

        #endregion

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
                    rParameter = general.GetWithoutString(rParameter, new Constants().MyByVal);
                    rParameter = general.GetWithoutString(rParameter, new Constants().MyByRef);

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
    }
}