using EmployeeManager.Models;
using EmployeeManager.Services;

namespace EmployeeManager.Forms
{
    public partial class MainForm : Form
    {
        private readonly CsvService _csvService;
        private List<Employee> _employees = new List<Employee>();

        public MainForm()
        {
            InitializeComponent();
            _csvService = new CsvService();

        }
        private void searchCondition_Changed(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void loadCsvButton_Click(object sender, EventArgs e)
        {
            LoadCsvFile();
        }

        private void saveCsvButton_Click(object sender, EventArgs e)
        {
            SaveCsvFile();
        }

        private void ApplyFilter()
        {
            string searchText = searchBox.Text.ToLower().Trim();

            DateTime fromDate = fromDatePicker.Value.Date;
            DateTime toDate = toDatePicker.Value.Date;

            var filteredList = _employees.Where(emp =>
                 (emp.Name.ToLower().Contains(searchText) ||
                 emp.Department.ToLower().Contains(searchText))
                &&
                (emp.JoinDate.Date >= fromDate &&
                emp.JoinDate.Date <= toDate)
            ).ToList();

            employeeDataGridView.DataSource = filteredList;
        }

        private void LoadCsvFile()
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "CSVファイル|*.csv";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _employees = _csvService.ReadCsv(dialog.FileName);
                        employeeDataGridView.DataSource = _employees;
                        ShowSuccessMessage("CSVファイルを読み込みました。");
                    }
                    catch (Exception ex)
                    {
                        ShowErrorMessage("エラーが発生しました", ex);
                    }
                }
            }
        }

        private void SaveCsvFile()
        {
            if (!ValidateDataExists()) return;

            var filteredList = employeeDataGridView.DataSource as List<Employee>;
            if (filteredList == null) return;

            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "CSVファイル|*.csv";
                dialog.Title = "CSVファイルを保存";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _csvService.WriteCsv(dialog.FileName, filteredList);
                        ShowSuccessMessage("CSVファイルを保存しました。");
                    }
                    catch (Exception ex)
                    {
                        ShowErrorMessage("保存中にエラーが発生しました", ex);
                    }
                }
            }
        }

        private bool ValidateDataExists()
        {
            if (_employees.Count == 0)
            {
                MessageBox.Show("保存するデータがありません。", "警告",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void ShowSuccessMessage(string message)
        {
            MessageBox.Show(message, "成功",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowErrorMessage(string message, Exception ex)
        {
            MessageBox.Show($"{message}：{ex.Message}", "エラー",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}