using EmployeeManager.Models;
using EmployeeManager.Services;
using System.Windows.Forms;

namespace EmployeeManager.Forms
{
    public partial class MainForm : Form
    {
        private readonly CsvService _csvService;
        //★(a1)読み込んだ社員リストを保持しておくためのフィールド
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
                        //★(a2)読み込んだ社員リストをフィールドで保持しておく
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
        {//(b)検索ボックスで変更があったときに呼び出される
            ApplyFilter();
        }

        private void ApplyFilter()
        {

            // 検索キーワード（小文字・前後の空白はトリム）
            string searchText = searchBox.Text.ToLower().Trim();

            //★(c)LINQで、検索キーワードが氏名または部署に含まれているかチェック
            var filteredList = _employees.Where(emp =>
                emp.Name.ToLower().Contains(searchText) ||
                emp.Department.ToLower().Contains(searchText)
            ).ToList();

            //★(d)データソースにフィルタリングしたリストをセット
            employeeDataGridView.DataSource = filteredList;
        }
    }
}