using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using TestTaskForEidos.Model;
using Newtonsoft.Json;
namespace TestTaskForEidos.Data
{
    static class JsonManager
    {
        

        public static void JsonSave(ObservableCollection<Department> departments, string fileName)
        {
            DepartmentList listToSave = new DepartmentList(departments);
            var json = JsonConvert.SerializeObject(listToSave);
            string _fileName = fileName;
            File.WriteAllText(_fileName, json);
        }

        public static ObservableCollection<Department> JsonOpenDepartments( string fileName)
        {
            string jsonString = File.ReadAllText(fileName);
            DepartmentList results = JsonConvert.DeserializeObject<DepartmentList>(jsonString);
            return new ObservableCollection<Department>(results.List);
       
        }
    }

    class DepartmentList
    {
        
        public List<Department> List;
        public DepartmentList() 
        { 

        }

        public DepartmentList(ObservableCollection<Department>  departments)
        {
            List = new List<Department>( departments);
        }
        
    }
}
