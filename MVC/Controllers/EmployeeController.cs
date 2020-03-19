using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Net.Http.Headers;

namespace MVC.Controllers
{
    public class EmployeeController : Controller 
    {
        // GET: Employee
        public ActionResult Index()    
        {          
            IEnumerable<EmployeeViewModel> empList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Employee/GetAllEmployees").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<EmployeeViewModel>>().Result;
            return View(empList);
        }   
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new EmployeeViewModel());
            else
            {
               
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Employee/GetAllEmployees" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<EmployeeViewModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(EmployeeViewModel emp)
        {
            if (emp.ID == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Employee/InsertEmployee", emp).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Employee/EditEmployee/" + emp.ID, emp).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Employee/DeleteEmployee/" + id.ToString()).Result;
            if(response.ReasonPhrase =="Not Found")
            {
                TempData["SuccessMessage"] = "Deleting Error";

            }
            else
            { 
                TempData["SuccessMessage"] = "Deleted Successfully";
            }
            return RedirectToAction("Index");
        }
    }
}
