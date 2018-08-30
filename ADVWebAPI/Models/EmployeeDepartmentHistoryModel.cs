using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADVWebAPI.Models
{
    public class EmployeeDepartmentHistoryModel
    {
        public short DepartmentID { get; set; }
        public byte ShiftID { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
    }
}