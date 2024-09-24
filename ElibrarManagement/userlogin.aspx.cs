using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ElibrarManagement
{
    public partial class userlogin : System.Web.UI.Page
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
                    //Response.Write("<script>alert('heloo world')</script>");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * from member_master_tb1 WHERE member_id='"+ TextBox1.Text.ToString() +"' AND password='"+TextBox2.Text.ToString()+"'" , con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Response.Write("<script>alert('Login Successfull')</script>");
                            Session["username"] = dr.GetValue(8).ToString();
                            Session["fullname"] = dr.GetValue(0).ToString();
                            Session["role"] = "user";
                            Session["status"] = dr.GetValue(10).ToString();
                        }
                        Response.Redirect("homepage.aspx");
                    }
                    else
                    {
                           Response.Write("<script>alert('Invalid credentials');</script>");
                    }
                }
            }
            catch(Exception ex)
            {

                Response.Write("<script>alert('"+ex.Message+"')</script>");
            }
        }
    }
}