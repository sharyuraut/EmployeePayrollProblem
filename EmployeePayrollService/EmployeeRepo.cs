using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayrollService
{
    class EmployeeRepo
    {
        public static string connectionString = @"Data Source='(LocalDB)\ABC';Initial Catalog=EmployeeDetails;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
    }
}
