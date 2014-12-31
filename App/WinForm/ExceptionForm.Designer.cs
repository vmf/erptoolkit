using System.ComponentModel;
using System.Windows.Forms;

namespace ERPToolkit.App.WinForm
{
    partial class ExceptionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExceptionForm));
            this.bottomSepPanel = new System.Windows.Forms.Panel();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.okButton = new System.Windows.Forms.Button();
            this.emailButton = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.exceptionTabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.exceptionFromLabel = new System.Windows.Forms.Label();
            this.exceptionTypeLabel = new System.Windows.Forms.Label();
            this.exceptionFromTextBox = new System.Windows.Forms.TextBox();
            this.exceptionTypeTextBox = new System.Windows.Forms.TextBox();
            this.exceptionMessageTextBox = new System.Windows.Forms.TextBox();
            this.exceptionMessageLabel = new System.Windows.Forms.Label();
            this.emailTabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.sendToLabel = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.infoTextBox = new System.Windows.Forms.TextBox();
            this.aditionalInfoTextBox = new System.Windows.Forms.TextBox();
            this.aditionalInfoLabel = new System.Windows.Forms.Label();
            this.sendEmailButton = new System.Windows.Forms.Button();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.bottomPanel.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.exceptionTabPage.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.emailTabPage.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bottomSepPanel
            // 
            this.bottomSepPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bottomSepPanel.BackColor = System.Drawing.Color.Silver;
            this.bottomSepPanel.Location = new System.Drawing.Point(0, 184);
            this.bottomSepPanel.Name = "bottomSepPanel";
            this.bottomSepPanel.Size = new System.Drawing.Size(384, 1);
            this.bottomSepPanel.TabIndex = 18;
            // 
            // bottomPanel
            // 
            this.bottomPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bottomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bottomPanel.Controls.Add(this.okButton);
            this.bottomPanel.Controls.Add(this.emailButton);
            this.bottomPanel.Location = new System.Drawing.Point(0, 184);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(384, 37);
            this.bottomPanel.TabIndex = 17;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(196, 7);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(87, 23);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "okButton";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // emailButton
            // 
            this.emailButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.emailButton.Location = new System.Drawing.Point(289, 7);
            this.emailButton.Name = "emailButton";
            this.emailButton.Size = new System.Drawing.Size(87, 23);
            this.emailButton.TabIndex = 4;
            this.emailButton.Text = "emailButton";
            this.emailButton.UseVisualStyleBackColor = true;
            this.emailButton.Click += new System.EventHandler(this.emailButton_Click);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.exceptionTabPage);
            this.tabControl.Controls.Add(this.emailTabPage);
            this.tabControl.Location = new System.Drawing.Point(-1, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(7);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(388, 188);
            this.tabControl.TabIndex = 19;
            // 
            // exceptionTabPage
            // 
            this.exceptionTabPage.Controls.Add(this.tableLayoutPanel1);
            this.exceptionTabPage.Controls.Add(this.exceptionMessageTextBox);
            this.exceptionTabPage.Controls.Add(this.exceptionMessageLabel);
            this.exceptionTabPage.Location = new System.Drawing.Point(4, 22);
            this.exceptionTabPage.Name = "exceptionTabPage";
            this.exceptionTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.exceptionTabPage.Size = new System.Drawing.Size(380, 162);
            this.exceptionTabPage.TabIndex = 0;
            this.exceptionTabPage.Text = "exceptionTabPage";
            this.exceptionTabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.exceptionFromLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.exceptionTypeLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.exceptionFromTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.exceptionTypeTextBox, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(370, 52);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // exceptionFromLabel
            // 
            this.exceptionFromLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.exceptionFromLabel.AutoSize = true;
            this.exceptionFromLabel.Location = new System.Drawing.Point(0, 6);
            this.exceptionFromLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.exceptionFromLabel.Name = "exceptionFromLabel";
            this.exceptionFromLabel.Size = new System.Drawing.Size(102, 13);
            this.exceptionFromLabel.TabIndex = 25;
            this.exceptionFromLabel.Text = "exceptionFromLabel";
            // 
            // exceptionTypeLabel
            // 
            this.exceptionTypeLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.exceptionTypeLabel.AutoSize = true;
            this.exceptionTypeLabel.Location = new System.Drawing.Point(0, 32);
            this.exceptionTypeLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.exceptionTypeLabel.Name = "exceptionTypeLabel";
            this.exceptionTypeLabel.Size = new System.Drawing.Size(103, 13);
            this.exceptionTypeLabel.TabIndex = 27;
            this.exceptionTypeLabel.Text = "exceptionTypeLabel";
            // 
            // exceptionFromTextBox
            // 
            this.exceptionFromTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.exceptionFromTextBox.BackColor = System.Drawing.Color.White;
            this.exceptionFromTextBox.Location = new System.Drawing.Point(109, 3);
            this.exceptionFromTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.exceptionFromTextBox.Name = "exceptionFromTextBox";
            this.exceptionFromTextBox.ReadOnly = true;
            this.exceptionFromTextBox.Size = new System.Drawing.Size(261, 20);
            this.exceptionFromTextBox.TabIndex = 26;
            // 
            // exceptionTypeTextBox
            // 
            this.exceptionTypeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.exceptionTypeTextBox.BackColor = System.Drawing.Color.White;
            this.exceptionTypeTextBox.Location = new System.Drawing.Point(109, 29);
            this.exceptionTypeTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.exceptionTypeTextBox.Name = "exceptionTypeTextBox";
            this.exceptionTypeTextBox.ReadOnly = true;
            this.exceptionTypeTextBox.Size = new System.Drawing.Size(261, 20);
            this.exceptionTypeTextBox.TabIndex = 28;
            // 
            // exceptionMessageTextBox
            // 
            this.exceptionMessageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.exceptionMessageTextBox.BackColor = System.Drawing.Color.White;
            this.exceptionMessageTextBox.Location = new System.Drawing.Point(6, 75);
            this.exceptionMessageTextBox.Margin = new System.Windows.Forms.Padding(7);
            this.exceptionMessageTextBox.Multiline = true;
            this.exceptionMessageTextBox.Name = "exceptionMessageTextBox";
            this.exceptionMessageTextBox.ReadOnly = true;
            this.exceptionMessageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.exceptionMessageTextBox.Size = new System.Drawing.Size(367, 79);
            this.exceptionMessageTextBox.TabIndex = 30;
            // 
            // exceptionMessageLabel
            // 
            this.exceptionMessageLabel.AutoSize = true;
            this.exceptionMessageLabel.Location = new System.Drawing.Point(3, 61);
            this.exceptionMessageLabel.Name = "exceptionMessageLabel";
            this.exceptionMessageLabel.Size = new System.Drawing.Size(122, 13);
            this.exceptionMessageLabel.TabIndex = 29;
            this.exceptionMessageLabel.Text = "exceptionMessageLabel";
            // 
            // emailTabPage
            // 
            this.emailTabPage.Controls.Add(this.tableLayoutPanel2);
            this.emailTabPage.Controls.Add(this.infoTextBox);
            this.emailTabPage.Controls.Add(this.aditionalInfoTextBox);
            this.emailTabPage.Controls.Add(this.aditionalInfoLabel);
            this.emailTabPage.Controls.Add(this.sendEmailButton);
            this.emailTabPage.Location = new System.Drawing.Point(4, 22);
            this.emailTabPage.Name = "emailTabPage";
            this.emailTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.emailTabPage.Size = new System.Drawing.Size(380, 162);
            this.emailTabPage.TabIndex = 1;
            this.emailTabPage.Text = "emailTabPage";
            this.emailTabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.sendToLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.emailTextBox, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 45);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(370, 26);
            this.tableLayoutPanel2.TabIndex = 25;
            // 
            // sendToLabel
            // 
            this.sendToLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.sendToLabel.AutoSize = true;
            this.sendToLabel.Location = new System.Drawing.Point(0, 6);
            this.sendToLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.sendToLabel.Name = "sendToLabel";
            this.sendToLabel.Size = new System.Drawing.Size(69, 13);
            this.sendToLabel.TabIndex = 24;
            this.sendToLabel.Text = "sendToLabel";
            // 
            // emailTextBox
            // 
            this.emailTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.emailTextBox.Location = new System.Drawing.Point(75, 3);
            this.emailTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.ReadOnly = true;
            this.emailTextBox.Size = new System.Drawing.Size(295, 20);
            this.emailTextBox.TabIndex = 5;
            // 
            // infoTextBox
            // 
            this.infoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.infoTextBox.BackColor = System.Drawing.Color.White;
            this.infoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.infoTextBox.Location = new System.Drawing.Point(6, 10);
            this.infoTextBox.Multiline = true;
            this.infoTextBox.Name = "infoTextBox";
            this.infoTextBox.ReadOnly = true;
            this.infoTextBox.Size = new System.Drawing.Size(367, 32);
            this.infoTextBox.TabIndex = 6;
            this.infoTextBox.Text = "infoTextBox";
            // 
            // aditionalInfoTextBox
            // 
            this.aditionalInfoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.aditionalInfoTextBox.Location = new System.Drawing.Point(6, 90);
            this.aditionalInfoTextBox.Multiline = true;
            this.aditionalInfoTextBox.Name = "aditionalInfoTextBox";
            this.aditionalInfoTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.aditionalInfoTextBox.Size = new System.Drawing.Size(367, 37);
            this.aditionalInfoTextBox.TabIndex = 2;
            // 
            // aditionalInfoLabel
            // 
            this.aditionalInfoLabel.AutoSize = true;
            this.aditionalInfoLabel.Location = new System.Drawing.Point(3, 74);
            this.aditionalInfoLabel.Name = "aditionalInfoLabel";
            this.aditionalInfoLabel.Size = new System.Drawing.Size(90, 13);
            this.aditionalInfoLabel.TabIndex = 20;
            this.aditionalInfoLabel.Text = "aditionalInfoLabel";
            // 
            // sendEmailButton
            // 
            this.sendEmailButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sendEmailButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.sendEmailButton.Location = new System.Drawing.Point(286, 133);
            this.sendEmailButton.Name = "sendEmailButton";
            this.sendEmailButton.Size = new System.Drawing.Size(87, 23);
            this.sendEmailButton.TabIndex = 1;
            this.sendEmailButton.Text = "sendEmailButton";
            this.sendEmailButton.UseVisualStyleBackColor = true;
            this.sendEmailButton.Click += new System.EventHandler(this.sendEmailButton_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // ExceptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 221);
            this.Controls.Add(this.bottomSepPanel);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExceptionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExceptionForm";
            this.Load += new System.EventHandler(this.ExceptionForm_Load);
            this.bottomPanel.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.exceptionTabPage.ResumeLayout(false);
            this.exceptionTabPage.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.emailTabPage.ResumeLayout(false);
            this.emailTabPage.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel bottomSepPanel;
        private Panel bottomPanel;
        private Button okButton;
        private Button emailButton;
        private TabControl tabControl;
        private TabPage exceptionTabPage;
        private TabPage emailTabPage;
        private TextBox exceptionMessageTextBox;
        private Label exceptionMessageLabel;
        private TextBox exceptionTypeTextBox;
        private Label exceptionTypeLabel;
        private TextBox exceptionFromTextBox;
        private Label exceptionFromLabel;
        private Button sendEmailButton;
        private TextBox aditionalInfoTextBox;
        private Label aditionalInfoLabel;
        private TextBox emailTextBox;
        private Label sendToLabel;
        private BackgroundWorker backgroundWorker;
        private TextBox infoTextBox;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
    }
}