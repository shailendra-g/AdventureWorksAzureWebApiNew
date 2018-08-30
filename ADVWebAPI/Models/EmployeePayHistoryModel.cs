using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADVWebAPI.Models
{
    public class EmployeePayHistoryModel
    {
        public System.DateTime RateChangeDate { get; set; }
        public decimal Rate { get; set; }
        public byte PayFrequency { get; set; }
        public System.DateTime ModifiedDate { get; set; }
    }
}