using EmployeeManager.Services;

namespace EmployeeManager.Forms
{
    public partial class MainForm : Form
    {
        private readonly CsvService _csvService;

        public MainForm()
        {
            InitializeComponent();
            _csvService = new CsvService();

        }

        private void loadCsvButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "CSVファイル|*.csv";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var employees = _csvService.ReadCsv(dialog.FileName);
                        employeeDataGridView.DataSource = employees;
                        MessageBox.Show("CSVファイルを読み込みました。", "成功",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"エラーが発生しました：{ex.Message}", "エラー",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}