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
            saveCsvButton = new Button();
            ((System.ComponentModel.ISupportInitialize)employeeDataGridView).BeginInit();
            SuspendLayout();
            // 
            // loadCsvButton
            // 
            loadCsvButton.Location = new Point(14, 12);
            loadCsvButton.Name = "loadCsvButton";
            loadCsvButton.Size = new Size(120, 27);
            loadCsvButton.TabIndex = 3;
            loadCsvButton.Text = "CSVファイル読込";
            loadCsvButton.UseVisualStyleBackColor = true;
            loadCsvButton.Click += loadCsvButton_Click;
            // 
            // employeeDataGridView
            // 
            employeeDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            employeeDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            employeeDataGridView.Location = new Point(12, 82);
            employeeDataGridView.Name = "employeeDataGridView";
            employeeDataGridView.ReadOnly = true;
            employeeDataGridView.RowHeadersWidth = 62;
            employeeDataGridView.Size = new Size(562, 288);
            employeeDataGridView.TabIndex = 4;
            // 
            // searchBox
            // 
            searchBox.Location = new Point(14, 53);
            searchBox.Name = "searchBox";
            searchBox.Size = new Size(100, 23);
            searchBox.TabIndex = 5;
            searchBox.TextChanged += searchCondition_Changed;
            // 
            // fromDatePicker
            // 
            fromDatePicker.Location = new Point(120, 53);
            fromDatePicker.Name = "fromDatePicker";
            fromDatePicker.Size = new Size(132, 23);
            fromDatePicker.TabIndex = 6;
            fromDatePicker.ValueChanged += searchCondition_Changed;
            // 
            // toDatePicker
            // 
            toDatePicker.Location = new Point(258, 53);
            toDatePicker.Name = "toDatePicker";
            toDatePicker.Size = new Size(132, 23);
            toDatePicker.TabIndex = 7;
            toDatePicker.ValueChanged += searchCondition_Changed;
            // 
            // saveCsvButton
            // 
            saveCsvButton.Location = new Point(140, 12);
            saveCsvButton.Name = "saveCsvButton";
            saveCsvButton.Size = new Size(123, 27);
            saveCsvButton.TabIndex = 8;
            saveCsvButton.Text = "CSVファイル保存";
            saveCsvButton.UseVisualStyleBackColor = true;
            saveCsvButton.Click += saveCsvButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(588, 382);
            Controls.Add(saveCsvButton);
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
        private Button saveCsvButton;
    }
}