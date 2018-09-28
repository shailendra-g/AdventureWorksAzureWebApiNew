using System;
using ADVWebAPI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ADVDataModel;

namespace ADVDataModel.Test
{
    
    [TestClass]
    public class ADVIntegrationTest
    {
        private DepartmentRequestVM GetDepartmentRequestVM()
        {
            return new DepartmentRequestVM() { departmentid = 2 };
        }

        [TestMethod]
        public void GetDepartmentByIdTest()
        {
            var deptVM = GetDepartmentRequestVM();
            var controller = new DepartmentsController();

            var result = controller.GetDepartment(deptVM);
            Assert.IsNotNull(result);
        }

       
    }
}
