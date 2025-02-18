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
                dialog.Filter = "CSVファイル|*.csv";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _employees = _csvService.ReadCsv(dialog.FileName);
                        employeeDataGridView.DataSource = _employees;
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

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void fromDatePicker_ValueChanged(object sender, EventArgs e)
        {
            //★(a)日付範囲の始点が変更されたときにフィルタを適用する
            ApplyFilter();
        }

        private void toDatePicker_ValueChanged(object sender, EventArgs e)
        {
            //★(b)日付範囲の終点が変更されたときにフィルタを適用する
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            string searchText = searchBox.Text.ToLower().Trim();

            //★(c)日付フィルタ：開始日と終了日（DateTimePickerコントロールから取得）
            DateTime fromDate = fromDatePicker.Value.Date;
            DateTime toDate = toDatePicker.Value.Date;

            //★(d)LINQで複数条件を適用
            var filteredList = _employees.Where(emp =>
                // 検索キーワードが空の場合はこの条件を無視、入力がある場合は氏名または部署に部分一致
                 (emp.Name.ToLower().Contains(searchText) ||
                 emp.Department.ToLower().Contains(searchText))
                &&
                // 入社日が指定範囲内にあるかチェック
                (emp.JoinDate.Date >= fromDate &&
                emp.JoinDate.Date <= toDate)
            ).ToList();

            employeeDataGridView.DataSource = filteredList;
        }
    }
}