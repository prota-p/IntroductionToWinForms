using EmployeeManager.Models;
using EmployeeManager.Services;
using System.Windows.Forms;

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

        private void loadCsvButton_Click(object sender, EventArgs e)
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
                        MessageBox.Show("CSV�t�@�C����ǂݍ��݂܂����B", "����",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"�G���[���������܂����F{ex.Message}", "�G���[",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void searchCondition_Changed(object sender, EventArgs e)
        {
            ApplyFilter();
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
    }
}