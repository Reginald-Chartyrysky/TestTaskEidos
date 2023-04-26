using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestTaskForEidos.Model;
namespace TestTaskForEidos.ViewModels.EmployeeVMs
{
    class EmployeeRedactorVM: ViewModelBase
    {
        ObservableCollection<Department> _departments;
        public ObservableCollection<Department> Departments { get { return _departments; } set { _departments = value; OnPropertyChanged(); } }

        Department _currentDepartment;
        public Department CurrentDepartment { get { return _currentDepartment; } set { _currentDepartment = value; OnPropertyChanged(); ChangeDepartment(); } }


     
        void ChangeDepartment()
        {
            if (CurrentDepartment == null)
            {
                return;
            }
            if(CurrentDepartment.Name == Employee.DepartmentName)
            {
                return;
            }

            
                foreach(var department in _departments)
                {
                    try
                    {
                        department.Employees.Remove(Employee);
                    }
                    catch
                    {
                        continue;
                    }
                }
                Employee.DepartmentName = CurrentDepartment.Name;
                CurrentDepartment.Employees.Add(Employee);
                
            
        }

        Employee _employee;
        public Employee Employee { get { return _employee; } set { _employee = value; OnPropertyChanged(); } }
        public EmployeeRedactorVM(ObservableCollection<Department> departments, Employee employee)
        {
            Employee = employee;
            Departments= departments;

            foreach (Department department in Departments)
            {
               if(department.Employees.Contains(Employee))
               {
                    CurrentDepartment= department;
               }
            }
        }
    }
}
