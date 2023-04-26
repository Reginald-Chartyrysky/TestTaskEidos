using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TestTaskForEidos.ViewModels.ViewModelBase;
using System.Windows.Input;
using TestTaskForEidos.Model;
using System.Collections.ObjectModel;

namespace TestTaskForEidos.ViewModels.DepartmentVMs
{
    public class DepartmentAddVM: ViewModelBase
    {
        ObservableCollection<Department> _departments;
        public ObservableCollection<Department> Departments { get { return _departments; } set { _departments = value; OnPropertyChanged(); } }

        public ICommand SaveDepartmentCommand
        {
            get { return new RelayCommand(action => SaveDepartment(), canExecute => true); }
        }

        void SaveDepartment()
        {

           Department.Employees = new ObservableCollection<Employee>();
           Department.Offices = new ObservableCollection<string>();
           Departments.Add(Department);
        }

        Department _department;
        public Department Department { get { return _department; } set { _department = value; OnPropertyChanged(); } }
        public DepartmentAddVM(ObservableCollection<Department> departments)
        {
            Departments = departments;
            Department = new Department();
        }

    }
}
