using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using TestTaskForEidos.Data;
using TestTaskForEidos.Model;
using TestTaskForEidos.ViewModels.DepartmentVMs;
using TestTaskForEidos.ViewModels.EmployeeVMs;
using TestTaskForEidos.Views.DepartmentManagement;
using TestTaskForEidos.Views.EmployeeManagement;

namespace TestTaskForEidos.ViewModels
{
    public class MainViewModel:ViewModelBase
    {
        private ObservableCollection<Department> _departmentList; 
        #region Selection
        public ObservableCollection<Department> DepartmentList { get { return _departmentList; } set { _departmentList = value; OnPropertyChanged(); } }

        private Department _selectedDepartment;

        public Department SelectedDepartment { get { return _selectedDepartment; } set { _selectedDepartment = value; OnPropertyChanged(); } } 

    
        private Employee _selectedEmployee;
        public Employee SelectedEmployee { get { return _selectedEmployee; } set { _selectedEmployee = value; OnPropertyChanged(); SelectedItem = _selectedEmployee; } }

        private string _selectedOffice;
        public string SelectedOffice { get { return _selectedOffice; } 
            set { _selectedOffice = value; OnPropertyChanged(); SelectedItem = _selectedOffice; OnPropertyChanged(); SelectedItem = _selectedOffice; } }

        private object SelectedItem;
        #endregion

        #region Commands
        public ICommand AddDepartmentCommand
        {
            get { return new RelayCommand(action => ShowAddDepartment(), canExecute => true); }
        }
        void ShowAddDepartment()
        {
            AddDepartment addDepartment = new AddDepartment();
            DepartmentAddVM departmentAddVM = new DepartmentAddVM(DepartmentList);
            addDepartment.DataContext = departmentAddVM;
            addDepartment.Show();
        }

        public ICommand AddEmployeeCommand
        {
            get { return new RelayCommand(action => ShowAddEmployee(), canExecute => true); }
        }
        void ShowAddEmployee()
        {
            AddEmployee addEmployee = new AddEmployee();
            EmployeeAddVM employeeAddVM = new EmployeeAddVM(SelectedDepartment);
            addEmployee.DataContext = employeeAddVM;
            addEmployee.Show();
        }

        public ICommand AddOfficeCommand
        {
            get { return new RelayCommand(action => AddOffice(), canExecute => true); }
        }
        void AddOffice()
        {
            SelectedDepartment.Offices.Add("0");
        }

        public ICommand EdditEmployeeCommand
        {
            get { return new RelayCommand(action => ShowEdditEmployee(), canExecute => true); }
        }
        void ShowEdditEmployee()
        {
            if (SelectedEmployee == null) 
            {
                return;
            }
            EmployeeRedactor redactEmployee = new EmployeeRedactor();
            EmployeeRedactorVM redactorVM = new EmployeeRedactorVM(DepartmentList, SelectedEmployee);
            redactEmployee.DataContext = redactorVM;
            redactEmployee.Show();
        }

        public ICommand EdditOfficeCommand
        {
            get { return new RelayCommand(action => ShowEdditOffice(), canExecute => true); }
        }
        void ShowEdditOffice()
        {
            if(SelectedOffice == null)
            {
                return;
            }
            OfficeRedactor ofr = new OfficeRedactor();
            OfficeRedactorVM ofrvm = new OfficeRedactorVM(SelectedDepartment, SelectedOffice);
            ofr.DataContext = ofrvm;
            ofr.Show();
        }


        public ICommand OpenJsonCommand
        {
            get { return new RelayCommand(action => OpenJson(), canExecute => true); }
        }
        void OpenJson()
        {
            DepartmentJson dj = new DepartmentJson();
            DepartmentJsonVM djvm = new DepartmentJsonVM(DepartmentList);
            dj.DataContext = djvm;
            dj.Show();
        }


        public ICommand DeleteCommand
        {
            get { return new RelayCommand(action => DeleteItem(), canExecute => true); }
        }
        void DeleteItem()
        {
            if (SelectedItem == null)
            {
                return;
            }
            
            if (SelectedItem is Employee toDeleteEmployee) 
            { 
                SelectedDepartment.Employees.Remove(toDeleteEmployee);
                SelectedEmployee = null;
                
            }

            if (SelectedItem is string toDeleteOffice)
            {
                SelectedDepartment.Offices.Remove(toDeleteOffice);
                SelectedOffice = null;

            }
           
        }

        #endregion
        public MainViewModel()
        {
            try
            {
                _departmentList = JsonManager.JsonOpenDepartments("departments.json");
            }
            catch
            {
                _departmentList = new ObservableCollection<Department>()
                    {
                    new Department()
            {
                Name= "Default",
                Employees = new ObservableCollection<Employee>(),
                Offices = new ObservableCollection<string>()

            }
                     };

            }
            _selectedDepartment = _departmentList[0];
        }
    }
}
