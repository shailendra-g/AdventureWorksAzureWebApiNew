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
using ADVDataModel.Repositorys;
using ADVWebAPI.Models;

namespace ADVWebAPI.Controllers
{
    [RoutePrefix("api/Dept")]
    public class DepartmentsController : ApiController
    {
        private ADV2017Entities db = new ADV2017Entities();

        ModelFactory _modelFactory;

        public DepartmentsController()
        {
            _modelFactory = new ModelFactory();
        }

        // GET: api/Departments
        [HttpGet]
        [Route("GetDepartments")]
        public IEnumerable<DepartmentModel> GetDepartments()
        {
            DepartmentRepository dr = new DepartmentRepository();
            return dr.GetAllDepartments().ToList().Select(e => _modelFactory.Create(e)); ;
        }

        
        [HttpPost]
        [Route("GetDepartment")]
        public IHttpActionResult GetDepartment(DepartmentRequestVM deptId)
        {
            Department department = db.Departments.Find(deptId.departmentid);
            if (department == null)
            {
                return NotFound();
            }


            return Ok(_modelFactory.Create(department));
        }

        // PUT: api/Departments/5
        [HttpPost]
        [Route("PutDepartment")]
        public IHttpActionResult PutDepartment(Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(department).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(department.DepartmentID))
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

        // POST: api/Departments
        /// <summary>
        /// Post Department
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("PostDepartment")]
        public IHttpActionResult PostDepartment(Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Departments.Add(department);
            db.SaveChanges();
            //Need to check what this is
            return CreatedAtRoute("DefaultApi", new { id = department.DepartmentID }, department);
        }
        
        /// <summary>
        /// Delete Dept test
        /// </summary>
        /// <param name="dept"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("DeleteDepartment")]
        public IHttpActionResult DeleteDepartment(DepartmentRequestVM dept)
        {
            Department department = db.Departments.Find(dept.departmentid);
            if (department == null)
            {
                return NotFound();
            }

            db.Departments.Remove(department);
            db.SaveChanges();

            return Ok(department);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DepartmentExists(short id)
        {
            return db.Departments.Count(e => e.DepartmentID == id) > 0;
        }
    }

    public class DepartmentRequestVM
    {
        public short departmentid { get; set; }
    }
}