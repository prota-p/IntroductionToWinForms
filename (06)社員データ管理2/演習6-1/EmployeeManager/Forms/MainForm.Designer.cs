﻿namespace EmployeeManager.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            loadCsvButton = new Button();
            employeeDataGridView = new DataGridView();
            searchBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)employeeDataGridView).BeginInit();
            SuspendLayout();
            // 
            // loadCsvButton
            // 
            loadCsvButton.Location = new Point(14, 12);
            loadCsvButton.Name = "loadCsvButton";
            loadCsvButton.Size = new Size(140, 27);
            loadCsvButton.TabIndex = 3;
            loadCsvButton.Text = "CSVファイル読込";
            loadCsvButton.UseVisualStyleBackColor = true;
            loadCsvButton.Click += loadCsvButton_Click;
            // 
            // employeeDataGridView
            // 
            employeeDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            employeeDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            employeeDataGridView.Location = new Point(12, 57);
            employeeDataGridView.Name = "employeeDataGridView";
            employeeDataGridView.ReadOnly = true;
            employeeDataGridView.Size = new Size(574, 250);
            employeeDataGridView.TabIndex = 4;
            // 
            // searchBox
            // 
            searchBox.Location = new Point(160, 15);
            searchBox.Name = "searchBox";
            searchBox.Size = new Size(100, 23);
            searchBox.TabIndex = 5;
            searchBox.TextChanged += searchBox_TextChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 319);
            Controls.Add(searchBox);
            Controls.Add(employeeDataGridView);
            Controls.Add(loadCsvButton);
            Name = "MainForm";
            Text = "社員情報管理";
            ((System.ComponentModel.ISupportInitialize)employeeDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Button loadCsvButton;
        private DataGridView employeeDataGridView;
        private TextBox searchBox;
    }
}