using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BL
{
    class DepartmentBL
    {
        readonly string connectionString = ConfigurationManager.ConnectionStrings["EmployeeContext"].ConnectionString;

        public IEnumerable<Department> Departments
        {
            get
            {
                List<Department> departments = new List<Department>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllDepartments", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Department department = new Department();
                        department.ID = Convert.ToInt32(rdr["ID"]);
                        department.Name = rdr["Name"].ToString();

                        departments.Add(department);
                    }
                }

                return departments;
            }
        }
    }
}
