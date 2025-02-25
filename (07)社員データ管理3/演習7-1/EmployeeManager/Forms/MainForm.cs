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
                dialog.Filter = "CSV�t�@�C��|*.csv";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _employees = _csvService.ReadCsv(dialog.FileName);
                        employeeDataGridView.DataSource = _employees;
                        ShowSuccessMessage("CSV�t�@�C����ǂݍ��݂܂����B");
                    }
                    catch (Exception ex)
                    {
                        ShowErrorMessage("�G���[���������܂���", ex);
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
                dialog.Filter = "CSV�t�@�C��|*.csv";
                dialog.Title = "CSV�t�@�C����ۑ�";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _csvService.WriteCsv(dialog.FileName, filteredList);
                        ShowSuccessMessage("CSV�t�@�C����ۑ����܂����B");
                    }
                    catch (Exception ex)
                    {
                        ShowErrorMessage("�ۑ����ɃG���[���������܂���", ex);
                    }
                }
            }
        }

        private bool ValidateDataExists()
        {
            if (_employees.Count == 0)
            {
                MessageBox.Show("�ۑ�����f�[�^������܂���B", "�x��",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void ShowSuccessMessage(string message)
        {
            MessageBox.Show(message, "����",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowErrorMessage(string message, Exception ex)
        {
            MessageBox.Show($"{message}�F{ex.Message}", "�G���[",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}