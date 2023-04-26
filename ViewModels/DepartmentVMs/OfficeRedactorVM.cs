using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TestTaskForEidos.ViewModels.ViewModelBase;
using System.Windows.Input;
using TestTaskForEidos.Model;

namespace TestTaskForEidos.ViewModels.DepartmentVMs
{
    public  class OfficeRedactorVM:ViewModelBase
    {
        Department _currentDepartment;
        public Department CurrentDepartment { get { return _currentDepartment; } set { _currentDepartment = value; OnPropertyChanged(); } }

        
        string _office;
        public string Office { get { return _office; } set { _office = value;  OnPropertyChanged(); ChangeOffice(); } }

        string _oldOffice;
        public string OldOffice { get { return _oldOffice; } set { _office = value; } }

        void ChangeOffice()
        {
            for(int i=0; i < CurrentDepartment.Offices.Count(); i++)
            {
                if (CurrentDepartment.Offices[i] == _oldOffice)
                {
                    CurrentDepartment.Offices[i] = Office;
                }
            }
          
        }
        public OfficeRedactorVM(Department department, string office)
        {
            CurrentDepartment = department;
            _oldOffice = office;
            Office= office;
        }
    }
}
