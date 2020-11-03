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

        public void GetAllEmployee()
        {
            try
            {
                EmployeePayroll employeePayroll = new EmployeePayroll();
                using (this.connection)
                {
                    string query = @"SELECT * FROM employee_payroll;";

                    //define SqlCommand Object
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employeePayroll.EmployeeID = dr.GetInt32(0);
                            employeePayroll.EmployeeName = dr.GetString(1);
                            employeePayroll.BasicPay = (double)dr.GetDecimal(2);
                            employeePayroll.StartDate = dr.GetDateTime(3);
                            employeePayroll.Gender = dr.GetString(4);
                            employeePayroll.PhoneNumber = dr.GetString(5);
                            employeePayroll.Address = dr.GetString(6);
                            employeePayroll.Department = dr.GetString(7);
                            employeePayroll.Deductions = (double)dr.GetDecimal(8);
                            employeePayroll.TaxablePay = (double)dr.GetDecimal(9);
                            employeePayroll.Tax = (double)dr.GetDecimal(10);
                            employeePayroll.NetPay = (double)dr.GetDecimal(11);

                            //Display retrieved record - UC 2
                            Console.WriteLine("{0},{1},{2},{3},{4},{5}", employeePayroll.EmployeeID, employeePayroll.EmployeeName, employeePayroll.PhoneNumber, employeePayroll.Address, employeePayroll.Department, employeePayroll.Gender, employeePayroll.PhoneNumber);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found!");
                    }
                    dr.Close();
                    this.connection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
    }
}
