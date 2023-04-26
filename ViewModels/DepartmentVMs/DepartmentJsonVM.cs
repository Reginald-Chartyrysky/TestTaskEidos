using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestTaskForEidos.Model;
using System.Text.Json;
using System.IO;
using TestTaskForEidos.Data;
using System.Windows.Forms;

namespace TestTaskForEidos.ViewModels.DepartmentVMs
{
    public class DepartmentJsonVM: ViewModelBase
    {

        ObservableCollection<Department> _departments;
        public ObservableCollection<Department> Departments { get { return _departments; } set { _departments = value; OnPropertyChanged(); } }


        string _toSaveFileName = "department.json";
        public string ToSaveFileName { get { return _toSaveFileName; } set { _toSaveFileName = value; OnPropertyChanged(); } }

        public ICommand SaveListCommand
        {
            get { return new RelayCommand(action => SaveList(), canExecute => true); }
        }
        void SaveList()
        {
            if (Departments == null)
            {
                return;
            }

            JsonManager.JsonSave(Departments, ToSaveFileName);
           

        }

        public ICommand LoadListCommand
        {
            get { return new RelayCommand(action => LoadList(), canExecute => true); }
        }
        void LoadList()
        {
            if (Departments == null)
            {
                return;
            }

            string _fileName;
            System.Windows.Forms.OpenFileDialog o = new System.Windows.Forms.OpenFileDialog();

            o.Filter = "Json(*.json) | *.json";
            o.Multiselect = false;

            if (o.ShowDialog() == DialogResult.OK || !string.IsNullOrEmpty( o.FileName))
            {
                _fileName = o.FileName;
            }
            else
            {
                return;
            }
            try
            {
                Departments.Clear();
                foreach (var department in JsonManager.JsonOpenDepartments(_fileName))
                {


                    Departments.Add(department);
                }
            }
            catch
            {
                Departments.Clear();
                MessageBox.Show("Проблема с открытием файла");
                return;
            }


        }

        public DepartmentJsonVM(ObservableCollection<Department> departments)
        {
           
            Departments = departments;

        }
    }

}

