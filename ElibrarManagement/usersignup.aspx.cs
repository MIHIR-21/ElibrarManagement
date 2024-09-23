using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElibrarManagement
{
    public partial class usersignup : System.Web.UI.Page
    {
        SqlConnection con;

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(GetConnectionString());
        }

        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        }
        protected void Button1_Click(object sender, EventArgs e, SqlConnection con)
        {
           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {

                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into member_master_tb1(full_name,dob,contact_no,email,state,city,pincode,full_address,member_id,password,account_status) values(@full_name,@dob,@contact_no,@email,@state,@city,@pincode,@full_address,@member_id,@password,@account_status)", con);
                    cmd.Parameters.AddWithValue("@full_name", TextBox1.Text.ToString());
                    cmd.Parameters.AddWithValue("@dob", TextBox2.Text.ToString());
                    cmd.Parameters.AddWithValue("@contact_no", TextBox3.Text.ToString());
                    cmd.Parameters.AddWithValue("@email", TextBox4.Text.ToString());
                    cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@city", TextBox5.Text.ToString());
                    cmd.Parameters.AddWithValue("@pincode", TextBox6.Text.ToString());
                    cmd.Parameters.AddWithValue("@full_address", TextBox7.Text.ToString());
                    cmd.Parameters.AddWithValue("@member_id", TextBox8.Text.ToString());
                    cmd.Parameters.AddWithValue("@password", TextBox9.Text.Trim());
                    cmd.Parameters.AddWithValue("@account_status", "pending");

                    cmd.ExecuteNonQuery();
                    
                    Response.Write("<script>alert('Sign Up Successful. Go to User Login to Login ');</script>");
                }
            }
            catch(Exception ex) 
            {
                Response.Write("<script>alert('"+ ex.Message +"')</script>");

            }
            finally
            {
                if(con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
    }
}