using GCUK_Task.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;

namespace GCUK_Task.Controllers
{
    public class EmployeeController : ApiController
    {
        GAUK_Task_DBEntities db =new GAUK_Task_DBEntities() ;
        [HttpGet]
        public IQueryable GetAllEmployees()
        {
            return db.Employees ;
        }
        // PUT api/Employee/5
        public IHttpActionResult EditEmployee(int id, Employee employee)
        {

            if (id != employee.ID)
            {
                return BadRequest();
            }
            
            db.Entry(employee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Employee
        [ResponseType(typeof(Employee))]
        public IHttpActionResult InsertEmployee(Employee employee)
        {

            db.Employees.Add(employee);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employee.ID }, employee);
        }
        

        // DELETE api/Employee/5
        [ResponseType(typeof(Employee))]
        public IHttpActionResult DeleteEmployee(int id)
        {
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            db.Employees.Remove(employee);
            db.SaveChanges();

            return Ok(employee);
        }
        private bool EmployeeExists(int id)
        {
            return db.Employees.Count(e => e.ID == id) > 0;
        }


    }
}
