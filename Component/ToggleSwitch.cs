/*
 * ToggleSwitch.cs - This file is part of ERPToolkit
 * Copyright (C) 2015  Vinícius M. Freitas
 * This component was developed based on the solution:
 * http://www.codeproject.com/Questions/481959/WinFormsplusToggleplusSwitchplusControl
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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

/* data for a change event. the current implementation
 * guarantees OldValue and NewValue are always different,
 * but the change event is built this way so you could change
 * internal behavior if you wanted.
 */
public class CheckChangedEventArgs : EventArgs
{
    public bool OldValue { get; set; }
    public bool NewValue { get; set; }

    public CheckChangedEventArgs(bool oldValue, bool newValue)
    {
        NewValue = newValue;
        OldValue = oldValue;
    }
}

/* event handler */
public delegate void CheckChangedEventHandler(object sender, CheckChangedEventArgs e);

[DefaultEvent("CheckChanged")]
public sealed class ToggleSwitch : UserControl
{
    //internal variables and their defaults.
    private Color _colorToggleOn = Color.Snow;
    private Color _colorToggleOff = Color.Snow;
    private Color _colorButtonOn = Color.LightSteelBlue;
    private Color _colorButtonOff = Color.Snow;
    private string _textOn = "ON";
    private string _textOff = "OFF";
    private bool _checked;
    private bool _borderExtraThin = true;
    private bool _borderForButton = true;
    private int _buttonWidthPercentage = 50;

    /* public properties that will show in the designer */
    public Color ColorToggleOn { get { return _colorToggleOn; } set { _colorToggleOn = value; UpdateColors(); } }
    public Color ColorToggleOff { get { return _colorToggleOff; } set { _colorToggleOff = value; UpdateColors(); } }
    public Color ColorButtonOn { get { return _colorButtonOn; } set { _colorButtonOn = value; UpdateColors(); } }
    public Color ColorButtonOff { get { return _colorButtonOff; } set { _colorButtonOff = value; UpdateColors(); } }
    public string TextON { get { return _textOn; } set { _textOn = value; UpdateColors(); } }
    public string TextOFF { get { return _textOff; } set { _textOff = value; UpdateColors(); } }
    public bool BorderExtraThin { get { return _borderExtraThin; } set { _borderExtraThin = value; UpdateBorders(); UpdateColors(); Refresh(); } }
    public bool BorderForButton { get { return _borderForButton; } set { _borderForButton = value; UpdateBorders(); UpdateColors(); Refresh(); } }
    public int ButtonWidthPercentage { get { return _buttonWidthPercentage; } set { _buttonWidthPercentage = value; UpdateBorders(); UpdateColors(); Refresh(); } }

    public bool Checked
    {
        get { return _checked; }

        set
        {
            /* This is set up so change events don't even occur unless the value is really changing.
             * This behavior could be modified if for some reason you want a change event without
             * the value actually changing; which explains the CheckChangedEventArgs having a
             * old value and a new value, even though the current implementation guarantees
             * they are actually different.
             */
            if (Checked == value)
                return;

            _checked = value;
            UpdateColors();

            CheckChanged(this, new CheckChangedEventArgs(!Checked, Checked));
        }
    }

    /* we use a floating label control as the "button" and optional text */
    private readonly Label _label1;

    /* CheckChanged is the default event for this control, and the only custom one we need */
    [Category("Action")]
    [Description("Fires when the switch is toggled, just like a checkbox")]
    public event CheckChangedEventHandler CheckChanged;

    void _CheckChangedDoNothing(object sender, CheckChangedEventArgs e)
    {
    }

    public ToggleSwitch()
    {
        CheckChanged = _CheckChangedDoNothing;

        _label1 = new Label();
        _label1.ForeColor = ForeColor;
        _label1.Visible = true;
        _label1.TextAlign = ContentAlignment.MiddleCenter;
        _label1.BorderStyle = BorderStyle.FixedSingle;
        _label1.MouseDown += label1_MouseDown;

        Controls.Add(_label1);

        UpdateColors();
    }

    void label1_MouseDown(object sender, EventArgs e)
    {
        Clicked();
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        Clicked();
    }

    private void Clicked()
    {
        Checked = !Checked;
    }

    private void UpdateBorders()
    {
        if (BorderExtraThin)
        {
            BorderStyle = BorderStyle.None;
        }

        if (BorderForButton)
        {
            _label1.BorderStyle = BorderStyle.FixedSingle;
        }
    }

    private void UpdateColors()
    {
        if (Checked)
        {
            BackColor = ColorToggleOn;
            _label1.Dock = DockStyle.Right;
            _label1.Width = (ClientRectangle.Width * ButtonWidthPercentage) / 100;
            _label1.Text = TextON;
            _label1.BackColor = ColorButtonOn;

            /* not sure why but it seems to need a 1-px offset to look correct */
            _label1.Padding = new Padding(1, 0, 0, 0);


            Refresh();
        }
        else
        {
            BackColor = ColorToggleOff;
            _label1.Dock = DockStyle.Left;
            _label1.Width = (ClientRectangle.Width * ButtonWidthPercentage) / 100;
            _label1.Text = TextOFF;
            _label1.BackColor = ColorButtonOff;

            Refresh();
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        const int borderSize = 1;

        if (BorderExtraThin)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
                Color.Black, borderSize, ButtonBorderStyle.Inset,
                Color.Black, borderSize, ButtonBorderStyle.Inset,
                Color.Black, borderSize, ButtonBorderStyle.Inset,
                Color.Black, borderSize, ButtonBorderStyle.Inset);
        }
    }
}