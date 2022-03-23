using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arbetsprov.Models
{
    public class EmployeeResponse
    {
        public string status { get; set; }
        public Employee data { get; set; }
        public string message { get; set; }
    }
}
