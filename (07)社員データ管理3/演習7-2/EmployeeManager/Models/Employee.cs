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
    }
}