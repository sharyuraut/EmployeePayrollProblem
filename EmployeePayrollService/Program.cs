using System;

namespace EmployeePayrollService
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("SQL!");

            EmployeeRepo repo = new EmployeeRepo();
            EmployeeSalaryModel employeeSalaryPayroll = new EmployeeSalaryModel();
            EmployeePayroll employeePayroll = new EmployeePayroll();

            employeePayroll.EmployeeName = "Johnny";
            employeePayroll.BasicPay = 200900;
            employeePayroll.StartDate = DateTime.Now;
            employeePayroll.Gender = "M";
            employeePayroll.PhoneNumber = "7677173446";
            employeePayroll.Address = "Bangur Rd";
            employeePayroll.Department = "HR";
            employeePayroll.Deductions = 1050;
            employeePayroll.TaxablePay = 17000;
            employeePayroll.Tax = 1800;
            employeePayroll.NetPay = 18000;

            //repo.AddEmployee(employeePayroll);

            Console.WriteLine("-------------");

            //repo.GetAllEmployee();

            employeeSalaryPayroll.EmployeeId = 3;
            employeeSalaryPayroll.payroll_id = 1;
            employeeSalaryPayroll.department = "Finance";
            employeeSalaryPayroll.basic_pay = 2345678;
            employeeSalaryPayroll.name = "UpdatedName";
            employeeSalaryPayroll.start_Date = "01-01-20";

            repo.UpdateEmployee(employeeSalaryPayroll);
        }
    }
}
