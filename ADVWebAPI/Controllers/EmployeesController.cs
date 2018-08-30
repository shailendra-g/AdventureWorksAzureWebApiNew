using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ADVDataModel;
using ADVWebAPI.Models;

namespace ADVWebAPI.Controllers
{
    public class EmployeesController : ApiController
    {
        private ADV2017Entities db = new ADV2017Entities();

        ModelFactory _modelFactory;

        public EmployeesController()
        {
            _modelFactory = new ModelFactory();
        }

        // GET: api/Employees/5
        public IHttpActionResult GetEmployee(int id)
        {
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(_modelFactory.Create(employee));
        }

        // GET: api/Employees
        public IEnumerable<EmployeeModel> GetEmployees()
        {
            //return db.Employees;
            EmployeeRepository er = new EmployeeRepository();
            return er.GetAllEmployees().ToList().Select(e => _modelFactory.Create(e));
        }


        //Get: api/Employees/GetEmployeesByMaritalStatus/m
        //[Route("api/employees/get/mStatus")]
        //[Route("api/employees/GetEmployeesByMaritalStatus")]
        public IEnumerable<EmployeeModel> GetEmployeesByMaritalStatus(string mStatus)
        {
            //return db.Employees;
            EmployeeRepository er = new EmployeeRepository();

            if (!string.IsNullOrEmpty(mStatus))
            {
                return er.GetAllEmployees().Where(e => e.MaritalStatus.ToLower() == mStatus.ToLower()).ToList().Select(e => _modelFactory.Create(e));
            }
            else
            {
                return er.GetAllEmployees().ToList().Select(e => _modelFactory.Create(e));
            }
            
        }

        //Get: api/Employees/GetEmployeesByGender/male
        //[Route("api/employees/GetEmployeesByGender")]
        public IEnumerable<EmployeeModel> GetEmployeesByGender(string gender)
        {
            //return db.Employees;
            EmployeeRepository er = new EmployeeRepository();

            switch (gender.ToLower())
            {
                case "all":
                    return er.GetAllEmployees().ToList().Select(e => _modelFactory.Create(e));
                case "male":
                    return er.GetAllEmployees().Where(e => e.Gender == "M").ToList().Select(e => _modelFactory.Create(e));
                case "female":
                    return er.GetAllEmployees().Where(e => e.Gender == "F").ToList().Select(e => _modelFactory.Create(e));
                default: return er.GetAllEmployees().ToList().Select(e => _modelFactory.Create(e));
            }
        }

        //Get: api/Employees/GetEmployeesByGender/male
        //[Route("api/employees/GetEmployeesByGender")]
        public IEnumerable<EmployeeModel> GetEmployeesByOrgLevel(int? orgLevel)
        {
            //return db.Employees;
            EmployeeRepository er = new EmployeeRepository();

            if (orgLevel != null)
            {               
                return er.GetAllEmployees().Where(e => e.OrganizationLevel == orgLevel).ToList().Select(e => _modelFactory.Create(e));
            }
            else
            {
                return er.GetAllEmployees().ToList().Select(e => _modelFactory.Create(e));
            }
        }


        // PUT: api/Employees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployee(int id, Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.BusinessEntityID)
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

        // POST: api/Employees
        [ResponseType(typeof(Employee))]
        public IHttpActionResult PostEmployee([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Employees.Add(employee);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EmployeeExists(employee.BusinessEntityID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = employee.BusinessEntityID }, employee);
        }

        // DELETE: api/Employees/5
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeExists(int id)
        {
            return db.Employees.Count(e => e.BusinessEntityID == id) > 0;
        }
    }
}