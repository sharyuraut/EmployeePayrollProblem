using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeePayrollService;

namespace SalaryTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CampareEmployeePayrollObject_withDB()
        {
            EmployeeSalaryModel model = new EmployeeSalaryModel()
            {
                payroll_id = 23,
                basic_pay = 10021,
                start_Date = "october",
                EmployeeId = 1
            };
            EmployeeRepo repo = new EmployeeRepo();
            int actual = repo.UpdateEmployee(model);
            Assert.AreEqual(model.basic_pay, actual);
        }
    }
}
