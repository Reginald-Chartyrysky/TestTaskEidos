using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskForEidos.Model
{
    public class Employee: ISerializable
    {
        //Имя, фамилия, должность, зарплата, отдел, должность

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Role { get; set; }
        public string DepartmentName { get; set; }
        public string Salary { get; set; }


        public Employee() { }
        public Employee(Department department) 
        {
            DepartmentName = department.Name;
        }

        public Employee(string departmentName)
        {
            DepartmentName = departmentName;
        }
        public string GetJsonString()
        {
            throw new NotImplementedException();
        }
    }
}
