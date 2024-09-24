using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElibrarManagement
{
    public partial class adminlogin : System.Web.UI.Page
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM admin_login_tb1 WHERE username='" + TextBox1.Text.ToString() + "' AND password='" + TextBox2.Text.ToString() + "'", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Response.Write("<script>alert('Successfull Login');</script>");
                            Session["usename"] = dr.GetValue(0).ToString();
                            Session["fullname"] = dr.GetValue(2).ToString();
                            Session["role"] = "admin";
                            //Session["status"] = dr.GetValue(10).ToString();
                        }
                        Response.Redirect("homepage.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid credentials');</script>");

                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('" + ex.Message + "')</script>");

            }
             
        }
    }
}