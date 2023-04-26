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
    public class EmployeeAddVM:ViewModelBase
    {
        

        Department _currentDepartment;
        public Department CurrentDepartment { get { return _currentDepartment; } set { _currentDepartment = value; OnPropertyChanged(); } }

        public ICommand SaveEmployeeCommand
        {
            get { return new RelayCommand(action => SaveEmployee(), canExecute => true); }
        }

        void SaveEmployee()
        {
           
            CurrentDepartment.Employees.Add(Employee);
        }

        Employee _employee;
        public Employee Employee { get { return _employee; } set { _employee = value; OnPropertyChanged(); } }
        public EmployeeAddVM(Department department)
        {
            CurrentDepartment = department;
            Employee = new Employee(CurrentDepartment);
        }
    }
}
