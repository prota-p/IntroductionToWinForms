using EmployeeManager.Models;
using EmployeeManager.Services;
using System.Windows.Forms;

namespace EmployeeManager.Forms
{
    public partial class MainForm : Form
    {
        private readonly CsvService _csvService;
        //��(a1)�ǂݍ��񂾎Ј����X�g��ێ����Ă������߂̃t�B�[���h
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
                        //��(a2)�ǂݍ��񂾎Ј����X�g���t�B�[���h�ŕێ����Ă���
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

        private void searchBox_TextChanged(object sender, EventArgs e)
        {//(b)�����{�b�N�X�ŕύX���������Ƃ��ɌĂяo�����
            ApplyFilter();
        }

        private void ApplyFilter()
        {

            // �����L�[���[�h�i�������E�O��̋󔒂̓g�����j
            string searchText = searchBox.Text.ToLower().Trim();

            //��(c)LINQ�ŁA�����L�[���[�h�������܂��͕����Ɋ܂܂�Ă��邩�`�F�b�N
            var filteredList = _employees.Where(emp =>
                emp.Name.ToLower().Contains(searchText) ||
                emp.Department.ToLower().Contains(searchText)
            ).ToList();

            //��(d)�f�[�^�\�[�X�Ƀt�B���^�����O�������X�g���Z�b�g
            employeeDataGridView.DataSource = filteredList;
        }
    }
}