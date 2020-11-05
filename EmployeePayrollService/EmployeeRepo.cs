using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayrollService
{
    public class EmployeeRepo
    {
        public static string connectionString = @"Data Source='(LocalDB)\ABC';Initial Catalog=EmployeeDetails;Integrated Security=True";
        //private string connectionString;
        private readonly SqlConnection connection = new SqlConnection(connectionString);
        //SqlConnection connection = new SqlConnection(connectionString);

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

        public bool AddEmployee(EmployeePayroll payroll)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("AddNewEmployee", this.connection);
                    command.CommandType = CommandType.StoredProcedure;


                    command.Parameters.AddWithValue("@Name", payroll.EmployeeName);
                    command.Parameters.AddWithValue("@basic_pay", payroll.BasicPay);
                    command.Parameters.AddWithValue("@start_Date", payroll.StartDate);
                    command.Parameters.AddWithValue("@gender", payroll.Gender);
                    command.Parameters.AddWithValue("@phone_no", payroll.PhoneNumber);
                    command.Parameters.AddWithValue("@address", payroll.Address);
                    command.Parameters.AddWithValue("@department", payroll.Department);
                    command.Parameters.AddWithValue("@deductions", payroll.Deductions);
                    command.Parameters.AddWithValue("@taxable_pay", payroll.TaxablePay);
                    command.Parameters.AddWithValue("@income_tax", payroll.Tax);
                    command.Parameters.AddWithValue("@net_pay", payroll.NetPay);


                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    connection.Close();

                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public int UpdateEmployee(EmployeeSalaryModel model)
        {
            int salary = 0;
            try
            {
                using (connection)
                {
                    SqlConnection connection = new SqlConnection(connectionString);
                    EmployeeSalaryModel displayModel = new EmployeeSalaryModel();

                    SqlCommand command = new SqlCommand("UpdateEmployeePayroll", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@payroll_id", model.payroll_id);
                    command.Parameters.AddWithValue("@basic_pay", model.payroll_id);
                    command.Parameters.AddWithValue("@start_Date", model.start_Date);
                    command.Parameters.AddWithValue("@id", model.EmployeeId);
                    command.Parameters.AddWithValue("@department", model.department);
                    command.Parameters.AddWithValue("@name", model.name);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            displayModel.EmployeeId = reader.GetInt32(0);
                            displayModel.payroll_id = reader.GetInt32(1);
                            displayModel.basic_pay = reader.GetInt32(2);
                            displayModel.start_Date = reader.GetString(3);
                            displayModel.name = reader.GetString(4);
                            displayModel.department = reader.GetString(5);
                            salary = displayModel.payroll_id;
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data found!");
                    }
                    reader.Close();
                    return salary;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                connection.Close();
                return 0;
            }
            finally
            {
                connection.Close();
            }
        }


    }
}
