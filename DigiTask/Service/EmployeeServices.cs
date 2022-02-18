//EmployeeService class in self created Service folder is for all the functions used for CRUD operations that are callled in controller class.
using DigiTask.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DigiTask.Service
{
    public class EmployeeServices
    {
        //configurationManager is for accessing the database connections of configuration files.
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        
        public List<Employee> GetEmployee() //An EmployeeModel type List is created to list all the data available.
        {
            try
            {
                cmd = new SqlCommand("sp_select", con); //sp_select is Stored Procedure created in db.
                cmd.CommandType = CommandType.StoredProcedure;
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                List<Employee> list = new List<Employee>(); 
                foreach (DataRow dr in dt.Rows) 
                {
                    list.Add(new Employee
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        empName = dr["Name"].ToString(),
                        empAddress = dr["Eaddress"].ToString(),
                        empDepart = dr["Department"].ToString(),
                        empSalary = Convert.ToInt32(dr["Salary"])

                    });

                }
                return list;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool InsertEmployee(Employee employee) //boolean type InsertEmployee function is created.
        {
            try
            {
                cmd = new SqlCommand("sp_insert", con); //sp_insert is stored procedure created in db for inseert operation query
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", employee.empName); //for inserting,parameters should bepassed whose value is given from EmployeeModel
                cmd.Parameters.AddWithValue("@eaddress", employee.empAddress);
                cmd.Parameters.AddWithValue("@department", employee.empDepart);
                cmd.Parameters.AddWithValue("@salary", employee.empSalary);
                con.Open();
                int r = cmd.ExecuteNonQuery(); //sqlcommand return integer type so its values are stored in variable r.
                if (r > 0) //when there is atleast one value returned then it resturns true
                {
                    return true; 
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        public bool UpdateEmployee(Employee employee) //boolean type updateEmployee function is created.
   
        {
            try
            {
                cmd = new SqlCommand("sp_update", con); //sp_insert is stored procedure created in db for update operation query
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", employee.empName);
                cmd.Parameters.AddWithValue("@eaddress", employee.empAddress);
                cmd.Parameters.AddWithValue("@department", employee.empDepart);
                cmd.Parameters.AddWithValue("@salary", employee.empSalary);
                cmd.Parameters.AddWithValue("@id", employee.Id); 
                con.Open();
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        public int DeleteEmployee(int id)
        {
            try
            {
                cmd = new SqlCommand("sp_delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                return cmd.ExecuteNonQuery();
              

            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}