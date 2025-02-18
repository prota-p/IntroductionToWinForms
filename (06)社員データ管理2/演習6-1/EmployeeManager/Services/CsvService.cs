using System.Text;
using EmployeeManager.Models;

namespace EmployeeManager.Services
{
    public class CsvService
    {
        public List<Employee> ReadCsv(string filePath)
        {
            var employees = new List<Employee>();

            using (var reader = new StreamReader(filePath, true))
            {
                // ヘッダーをスキップ
                reader.ReadLine();

                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        employees.Add(Employee.FromCsv(line));
                    }
                }
            }

            return employees;
        }
    }
}