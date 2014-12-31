/*
 * ProgressForm.cs - This file is part of ERPToolkit
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
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ERPToolkit.App.Class;

namespace ERPToolkit.WinForm
{
    // This is for COM Interop.
    [Guid("4af5b21c-cc04-4beb-ae3f-def3e0000024")]
    [ComVisible(true)]
    public partial class ProgressForm : Form
    {
        private ResourceManager _rm;

        public ProgressForm()
        {
            InitializeComponent();
        }

        /* Values: The ERPToolkit's way to pass Values through classes */
        public StoreValues Values { get; set; }

        #region Percentage

        /// <summary>
        ///     Gets the percentage of the progress
        /// </summary>
        /// <param name="value">Current value</param>
        /// <param name="maximum">Maximum number of the progressbar</param>
        /// <returns></returns>
        private double GetPercentage(int value, int maximum)
        {
            var percent = (Convert.ToDouble(value)/Convert.ToDouble(maximum))*100;
            return Convert.ToDouble(string.Format("{0:0.00}", percent));
        }

        #endregion

        #region Close

        private void cancelButton_Click(object sender, EventArgs e)
        {
            var message = MessageBox.Show(_rm.GetString("wantToCancel"), _rm.GetString("warning"),
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message != DialogResult.Yes) return;
            Close();
        }

        #endregion

        #region Initialization

        private void ProgressForm_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeLanguage();
                SetComponents();
            }
            catch (Exception exception)
            {
                var initEx = new ExceptionHandler();
                initEx.Values = Values;
                initEx.Handle(exception, MethodBase.GetCurrentMethod(), true);
            }
        }

        private void InitializeLanguage()
        {
            var ci = new CultureInfo(Values.Language);
            var a = Assembly.Load("ERPToolkit");
            _rm = new ResourceManager(Values.ResourceManager, a);

            Text = Values.ErpName + @" - " + ProductVersion;
            cancelButton.Text = _rm.GetString("cancel", ci);
        }

        private void SetComponents()
        {
            mainPercLabel.Text = @"0.00%";
            subPercLabel.Text = @"0.00%";
        }

        #endregion

        #region GettersSetters

        public int MainMaximum
        {
            get { return mainProgressBar.Maximum; }
            set { mainProgressBar.Maximum = value; }
        }

        public int MainMinimum
        {
            get { return mainProgressBar.Minimum; }
            set { mainProgressBar.Minimum = value; }
        }

        public int SubMaximum
        {
            get { return subProgressBar.Maximum; }
            set { subProgressBar.Maximum = value; }
        }

        public int SubMinimum
        {
            get { return subProgressBar.Minimum; }
            set { subProgressBar.Minimum = value; }
        }

        public string MainMessage
        {
            get { return mainLabel.Text; }
            set { mainLabel.Text = value; }
        }

        public string SubMessage
        {
            get { return subLabel.Text; }
            set { subLabel.Text = value; }
        }

        public int MainValue
        {
            get { return mainProgressBar.Value; }
            set { mainProgressBar.Value = value; }
        }

        public int SubValue
        {
            get { return subProgressBar.Value; }
            set { subProgressBar.Value = value; }
        }

        public string Title
        {
            get { return Text; }
            set { Text = value; }
        }

        #endregion

        #region Increment

        public void IncrementMain()
        {
            try
            {
                //Increment 1 = (100 / Maximum)
                mainProgressBar.Increment(1);

                subProgressBar.Value = mainProgressBar.Value == mainProgressBar.Maximum
                    ? 100
                    : subProgressBar.Minimum;

                /* Updates the percentage label */
                mainPercLabel.Text = GetPercentage(mainProgressBar.Value, mainProgressBar.Maximum) + "%";

                Update();
            }
            catch (Exception exception)
            {
                var initEx = new ExceptionHandler();
                initEx.Values = Values;
                initEx.Handle(exception, MethodBase.GetCurrentMethod(), true);
            }
        }

        public void IncrementSub()
        {
            try
            {
                //Increment 1 = (100 / Maximum)
                subProgressBar.Increment(1);

                /* Updates the percentage label */
                subPercLabel.Text = GetPercentage(subProgressBar.Value, subProgressBar.Maximum) + "%";

                Update();
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