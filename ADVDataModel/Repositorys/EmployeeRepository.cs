using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADVDataModel.Repositorys
{
    public class EmployeeRepository
    {
        public IQueryable<Employee> GetAllEmployees()
        {
            ADV2017Entities adv2017Entities = new ADV2017Entities();
            return adv2017Entities.Employees;
        }

        public IQueryable<Employee> GetAllEmployees(int id)
        {
            ADV2017Entities adv2017Entities = new ADV2017Entities();
            return adv2017Entities.Employees.Where(e => e.BusinessEntityID == id).Select(e => e);
        }

    }
}
