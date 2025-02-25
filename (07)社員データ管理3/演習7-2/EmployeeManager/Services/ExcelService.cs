using ClosedXML.Excel;
using EmployeeManager.Models;
namespace EmployeeManager.Services
{
    public class ExcelService
    {
        public void ExportToExcel(string filePath, List<Employee> employees)
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("社員リスト");

            // ヘッダーの設定
            SetupHeaders(worksheet);

            // データの書き込み
            WriteEmployeeData(worksheet, employees);

            // ワークシートの書式設定
            FormatWorksheet(worksheet);

            // ファイルの保存
            workbook.SaveAs(filePath);
        }

        private static void SetupHeaders(IXLWorksheet worksheet)
        {
            // 定数の定義
            const int HEADER_ROW = 1;

            var headers = new[] { "社員番号", "氏名", "部署", "入社日" };

            for (int headerIndex = 0; headerIndex < headers.Length; headerIndex++)
            {
                int columnIndex = headerIndex + 1;
                var headerCell = worksheet.Cell(HEADER_ROW, columnIndex);
                headerCell.Value = headers[headerIndex];
                headerCell.Style.Font.Bold = true;
                headerCell.Style.Fill.BackgroundColor = XLColor.LightGray;
                headerCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            }
        }

        private static void WriteEmployeeData(IXLWorksheet worksheet, List<Employee> employees)
        {
            // 定数の定義
            const int HEADER_ROW = 1;
            const int DATA_START_ROW = HEADER_ROW + 1;
            const int ID_COLUMN = 1;
            const int NAME_COLUMN = 2;
            const int DEPARTMENT_COLUMN = 3;
            const int JOIN_DATE_COLUMN = 4;

            for (int employeeIndex = 0; employeeIndex < employees.Count; employeeIndex++)
            {
                int currentRow = DATA_START_ROW + employeeIndex;
                var employee = employees[employeeIndex];

                // 各列にデータを設定
                worksheet.Cell(currentRow, ID_COLUMN).Value = employee.Id;
                worksheet.Cell(currentRow, NAME_COLUMN).Value = employee.Name;
                worksheet.Cell(currentRow, DEPARTMENT_COLUMN).Value = employee.Department;

                // 日付の書式設定
                var joinDateCell = worksheet.Cell(currentRow, JOIN_DATE_COLUMN);
                joinDateCell.Value = employee.JoinDate;
                joinDateCell.Style.DateFormat.Format = "yyyy/MM/dd";
            }
        }

        private static void FormatWorksheet(IXLWorksheet worksheet)
        {
            // データ範囲の罫線を設定
            var usedDataRange = worksheet.RangeUsed();
            if (usedDataRange != null)
            {
                usedDataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                usedDataRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
            }
        }
    }
}