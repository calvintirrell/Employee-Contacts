using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    public class Employees
    {
        private const string TEXT_FILE_NAME = "Employee.txt";
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Title { get; set; }
        public string EmployeeNum { get; set; }
        public string Salary { get; set; }
        public string Tenure { get; set; }
        public string Supervisor { get; set; }
        public string Department { get; set; }

        //<> these are generics
        public async static Task<ICollection<Employees>>GetEmployeesAsync()
        {
            //List is a wrapper around an array to be a dynamic array
            var employees = new List<Employees>();
            var content = await FileHelper.ReadTextFileAsync(TEXT_FILE_NAME);
            var lines = content.Split(new char[] { '\r', '\n' });
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }
                var parts = line.Split(',');
                var employee = new Employees
                {
                    Name = parts[0],
                    Address = parts[1],
                    Phone = parts[2],
                    Title = parts[3],
                    EmployeeNum = parts[4],
                    Salary = parts[5],
                    Tenure = parts[6],
                    Supervisor = parts[7],
                    Department = parts[8]
                };
                employees.Add(employee);
            }
            return employees;

            // Object Initialization
            //return new Employees
            //{
            //    Name = "C T",
            //    Title = "CEO"
            //};
        }

        public static void WriteEmployee(Employees employee)
        {
            var employeeData = $"{employee.Name}, {employee.Address}, {employee.Phone}, {employee.Title}, {employee.EmployeeNum}, {employee.Salary}, {employee.Tenure}, {employee.Supervisor}, {employee.Department}";
            FileHelper.WriteTextFileAsync(TEXT_FILE_NAME, employeeData);
        }
    }
}