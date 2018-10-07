namespace PayrollSummarizer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.dlgOpenCSV = new System.Windows.Forms.OpenFileDialog();
            this.btnLoadCSV = new System.Windows.Forms.Button();
            this.grdBySSN = new System.Windows.Forms.DataGridView();
            this.SSN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Wages = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllSITW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdByDate = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllSITW2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtOtterData = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdBySSN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdByDate)).BeginInit();
            this.SuspendLayout();
            // 
            // dlgOpenCSV
            // 
            this.dlgOpenCSV.DefaultExt = "csv";
            this.dlgOpenCSV.FileName = "Q(n)Export.csv";
            this.dlgOpenCSV.Filter = "CSV Files|*.csv|All Files|*.*";
            // 
            // btnLoadCSV
            // 
            this.btnLoadCSV.Location = new System.Drawing.Point(12, 12);
            this.btnLoadCSV.Name = "btnLoadCSV";
            this.btnLoadCSV.Size = new System.Drawing.Size(138, 23);
            this.btnLoadCSV.TabIndex = 0;
            this.btnLoadCSV.Text = "Load CSV File";
            this.btnLoadCSV.UseVisualStyleBackColor = true;
            this.btnLoadCSV.Click += new System.EventHandler(this.btnLoadCSV_Click);
            // 
            // grdBySSN
            // 
            this.grdBySSN.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdBySSN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdBySSN.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SSN,
            this.EmployeeName,
            this.Hours,
            this.Wages,
            this.AllSITW});
            this.grdBySSN.Location = new System.Drawing.Point(12, 41);
            this.grdBySSN.Name = "grdBySSN";
            this.grdBySSN.Size = new System.Drawing.Size(567, 578);
            this.grdBySSN.TabIndex = 1;
            // 
            // SSN
            // 
            this.SSN.HeaderText = "SSN";
            this.SSN.Name = "SSN";
            this.SSN.Width = 70;
            // 
            // EmployeeName
            // 
            this.EmployeeName.HeaderText = "Name";
            this.EmployeeName.Name = "EmployeeName";
            this.EmployeeName.Width = 200;
            // 
            // Hours
            // 
            this.Hours.HeaderText = "Hours";
            this.Hours.Name = "Hours";
            this.Hours.Width = 60;
            // 
            // Wages
            // 
            this.Wages.HeaderText = "Wages";
            this.Wages.Name = "Wages";
            // 
            // AllSITW
            // 
            this.AllSITW.HeaderText = "AllSITW";
            this.AllSITW.Name = "AllSITW";
            this.AllSITW.Width = 60;
            // 
            // grdByDate
            // 
            this.grdByDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdByDate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdByDate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.AllSITW2});
            this.grdByDate.Location = new System.Drawing.Point(585, 41);
            this.grdByDate.Name = "grdByDate";
            this.grdByDate.Size = new System.Drawing.Size(270, 578);
            this.grdByDate.TabIndex = 2;
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            // 
            // AllSITW2
            // 
            this.AllSITW2.HeaderText = "AllSITW";
            this.AllSITW2.Name = "AllSITW2";
            // 
            // txtOtterData
            // 
            this.txtOtterData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOtterData.Location = new System.Drawing.Point(861, 41);
            this.txtOtterData.Multiline = true;
            this.txtOtterData.Name = "txtOtterData";
            this.txtOtterData.Size = new System.Drawing.Size(250, 578);
            this.txtOtterData.TabIndex = 3;
            this.txtOtterData.Text = "Otter Data:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 631);
            this.Controls.Add(this.txtOtterData);
            this.Controls.Add(this.grdByDate);
            this.Controls.Add(this.grdBySSN);
            this.Controls.Add(this.btnLoadCSV);
            this.Name = "MainForm";
            this.Text = "Payroll Summarizer";
            ((System.ComponentModel.ISupportInitialize)(this.grdBySSN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdByDate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog dlgOpenCSV;
        private System.Windows.Forms.Button btnLoadCSV;
        private System.Windows.Forms.DataGridView grdBySSN;
        private System.Windows.Forms.DataGridViewTextBoxColumn SSN;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hours;
        private System.Windows.Forms.DataGridViewTextBoxColumn Wages;
        private System.Windows.Forms.DataGridViewTextBoxColumn AllSITW;
        private System.Windows.Forms.DataGridView grdByDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn AllSITW2;
        private System.Windows.Forms.TextBox txtOtterData;
    }
}

