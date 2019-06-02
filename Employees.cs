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
        public string Title { get; set; }

                              //<> these are generics
        public async static Task<ICollection<Employees>>GetEmployees()
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
                    Title = parts[1]
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
            var employeeData = $"{employee.Name}, {employee.Title}";
            FileHelper.WriteTextFileAsync(TEXT_FILE_NAME, employeeData);
        }
    }
}