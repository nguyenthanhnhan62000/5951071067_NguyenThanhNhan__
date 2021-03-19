using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace _5951071067_NguyenThanhNhan.Models
{
   
    public class db
    {
        SqlConnection con = new SqlConnection("data source = desktop - uoo9lg0; initial catalog = democrud; integrated security = true ");

        public DataSet Empget(Employee emp, out String msg)
        {
            DataSet ds = new DataSet();
            msg = "";
            try
            {
                SqlCommand com = new SqlCommand("Sp_Employee,con");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Sr_no", emp.Sr_no);
                com.Parameters.AddWithValue("@Emp_name", emp.Emp_name);
                com.Parameters.AddWithValue("@City", emp.City);
                com.Parameters.AddWithValue("@Country", emp.Contry);
                com.Parameters.AddWithValue("@Department", emp.Department);
                com.Parameters.AddWithValue("@flag", emp.Flag);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "Ok";
                return ds;

            }
            catch (Exception ex)
            {

                msg = ex.Message;
                return ds;
            }
            


            
        }
        public String Empdml(Employee emp,out String msg)
        {
            msg = "";

            try
            {
                SqlCommand com = new SqlCommand("Sp_Employee,con");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Sr_no", emp.Sr_no);
                com.Parameters.AddWithValue("@Emp_name", emp.Emp_name);
                com.Parameters.AddWithValue("@City", emp.City);
                com.Parameters.AddWithValue("@Country", emp.Contry);
                com.Parameters.AddWithValue("@Department", emp.Department);
                com.Parameters.AddWithValue("@flag", emp.Flag);
                SqlDataAdapter da = new SqlDataAdapter(com);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "Ok";
                return msg;
            }
            catch (Exception)
            {
                throw;
            }
           
        }
    
    }
}
