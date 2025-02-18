namespace EmployeeManager.Models
{
    public class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public DateTime JoinDate { get; set; }

        public Employee(string id, string name, string department, DateTime joinDate)
        {
            Id = id;
            Name = name;
            Department = department;
            JoinDate = joinDate;
        }

        // CSVの1行から社員インスタンスを作成
        public static Employee FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            return new Employee(
                values[0],
                values[1],
                values[2],
                DateTime.Parse(values[3])
            );
        }

    }
}