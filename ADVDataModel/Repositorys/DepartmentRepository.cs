using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADVDataModel.Repositorys
{
    public class DepartmentRepository
    {
        public IQueryable<Department> GetAllDepartments()
        {
            ADV2017Entities adv2017Entities = new ADV2017Entities();
            return adv2017Entities.Departments;
        }

        public IQueryable<Department> GetAllDepartments(int id)
        {
            ADV2017Entities adv2017Entities = new ADV2017Entities();
            return adv2017Entities.Departments.Where(e => e.DepartmentID == id).Select(e => e);
        }
    }
}

