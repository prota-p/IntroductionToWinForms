namespace EmployeeManager.Forms
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
            fromDatePicker = new DateTimePicker();
            toDatePicker = new DateTimePicker();
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
            employeeDataGridView.Location = new Point(12, 45);
            employeeDataGridView.Name = "employeeDataGridView";
            employeeDataGridView.ReadOnly = true;
            employeeDataGridView.Size = new Size(614, 364);
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
            // fromDatePicker
            // 
            fromDatePicker.Location = new Point(278, 16);
            fromDatePicker.Name = "fromDatePicker";
            fromDatePicker.Size = new Size(132, 23);
            fromDatePicker.TabIndex = 6;
            fromDatePicker.ValueChanged += fromDatePicker_ValueChanged;
            // 
            // toDatePicker
            // 
            toDatePicker.Location = new Point(427, 16);
            toDatePicker.Name = "toDatePicker";
            toDatePicker.Size = new Size(132, 23);
            toDatePicker.TabIndex = 7;
            toDatePicker.ValueChanged += toDatePicker_ValueChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 421);
            Controls.Add(toDatePicker);
            Controls.Add(fromDatePicker);
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
        private DateTimePicker fromDatePicker;
        private DateTimePicker toDatePicker;
    }
}