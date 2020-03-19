using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class EmployeeViewModel
    {
        public int ID { set; get; }
        public string EmpName { set; get; }
        public string Gender { set; get; }
        public decimal Salary { set; get; }
    }
}