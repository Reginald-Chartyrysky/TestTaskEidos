using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskForEidos.Model
{
    public class Department: ISerializable
    {
        //название, список кабинетов, список сотрудников
        public string Name { get; set; }
        public ObservableCollection<string> Offices { get; set; }
        public ObservableCollection<Employee> Employees { get; set; }



        public string GetJsonString()
        {
            throw new NotImplementedException();
        }
    }
}
