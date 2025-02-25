using System.Text;
using EmployeeManager.Models;

namespace EmployeeManager.Services
{
    public class CsvService
    {
        public List<Employee> ReadCsv(string filePath)
        {
            var lines = File.ReadAllLines(filePath, Encoding.UTF8);
            return lines.Skip(1) // ヘッダー行をスキップ
                       .Select(ParseCsvLine)
                       .ToList();
        }

        private Employee ParseCsvLine(string line)
        {
            var values = line.Split(',');
            return new Employee(
                values[0],
                values[1],
                values[2],
                DateTime.Parse(values[3])
            );
        }

        public void WriteCsv(string filePath, List<Employee> employees)
        {
            var lines = employees.Select(ToCsvLine);
            File.WriteAllLines(filePath, lines, Encoding.UTF8);
        }

        private string ToCsvLine(Employee employee)
        {
            return $"{employee.Id},{employee.Name},{employee.Department},{employee.JoinDate:yyyy/MM/dd}";
        }
    }
}