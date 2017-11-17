using System;
using System.Collections.Generic;

namespace LinqFunctions
{
    public class ModelEmployee
    {
        public string EmpployeeID { get; set;}
        public int Salary { get; set; }
        public string DepartmentID { get; set; }
        public DateTime DOJ { get; set; }

        public ModelEmployee(string id, int sal, string dm, DateTime doj)
        {
            this.EmpployeeID = id;
            this.Salary = sal;
            this.DepartmentID = dm;
            this.DOJ = doj;
        }
    }

    public class ModelDepartment
    {
        public string DepartmentID { get; set; }
        public string DepartmentName { get; set; }

        public ModelDepartment(string id, string name)
        {
            DepartmentID = id;
            DepartmentName = name;
        }
    }

    public static class EmployeeListBuider
    {
        public static List<ModelEmployee> Buil()
        {
            List<ModelEmployee> list = new List<ModelEmployee>();
            list.Add(new ModelEmployee("EMP1001", 3200, "D001",Convert.ToDateTime(" 10 / 2 / 2010 ")));
            list.Add(new ModelEmployee("EMP1002", 3500, "D001", Convert.ToDateTime("10 / 12 / 2013")));
            list.Add(new ModelEmployee("EMP1003", 3000, "D002", Convert.ToDateTime("10 / 11 / 2012")));
            list.Add(new ModelEmployee("EMP1004", 4500, "D002", Convert.ToDateTime("10 / 10 / 2011")));
            return (list);
        }

        public static List<ModelDepartment> DepartmentBuild()
        {
            List<ModelDepartment> list = new List<ModelDepartment>();
            list.Add(new ModelDepartment("D001", "HR"));
            list.Add(new ModelDepartment("D002", "Sales"));
         
            return (list);
        }
    }


}
