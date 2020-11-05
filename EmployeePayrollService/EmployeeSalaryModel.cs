using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayrollService
{
    public class EmployeeSalaryModel
    {
        public int EmployeeId { get; set; }
        public int payroll_id { get; set; }
        public string name { get; set; }
        public string department { get; set; }
        public int basic_pay { get; set; }
        public string start_Date { get; set; }
    }
}
