using ADVDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADVWebAPI.Models
{
    public class ModelFactory
    {
        public EmployeeModel Create(Employee employee)
        {
            return new EmployeeModel()
            {
                BusinessEntityID = employee.BusinessEntityID,
                NationalIDNumber = employee.NationalIDNumber,
                LoginID = employee.LoginID,
                JobTitle = employee.JobTitle,
                BirthDate = employee.BirthDate,
                MaritalStatus = employee.MaritalStatus,
                Gender = employee.Gender,
                HireDate = employee.HireDate,
                SalariedFlag = employee.SalariedFlag,
                VacationHours = employee.VacationHours,
                SickLeaveHours = employee.SickLeaveHours,
                CurrentFlag = employee.CurrentFlag,
                ModifiedDate = employee.ModifiedDate,
                EmployeeDepartmentHistory = employee.EmployeeDepartmentHistories.Select(ed => Create(ed)),
                EmployeePayHistory = employee.EmployeePayHistories.Select(ep => Create(ep))
            };
        }

        public EmployeeDepartmentHistoryModel Create(EmployeeDepartmentHistory edh)
        {
            return new EmployeeDepartmentHistoryModel()
            {
                DepartmentID = edh.DepartmentID,
                ShiftID = edh.ShiftID,
                StartDate = edh.StartDate,
                EndDate = edh.EndDate
            };
        }

        public EmployeePayHistoryModel Create(EmployeePayHistory eph)
        {
            return new EmployeePayHistoryModel()
            {
                 Rate = eph.Rate,
                 ModifiedDate = eph.ModifiedDate,
                 PayFrequency = eph.PayFrequency,
                 RateChangeDate = eph.RateChangeDate
            };
        }

        public DepartmentModel Create(Department dep)
        {
            return new DepartmentModel()
            {
                DepartmentID = dep.DepartmentID,
                GroupName = dep.GroupName,
                Name = dep.Name,
                ModifiedDate = dep.ModifiedDate
            };
        }
    }
}