using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ElibrarManagement
{
    public partial class adminbookissuing : System.Web.UI.Page
    {

        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(getConnectionString());
        }


        private string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        }

        // Issued Book
        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        // GO button
        protected void Button1_Click(object sender, EventArgs e)
        {
            getNames();
        }

        // return Book
        protected void Button3_Click(object sender, EventArgs e)
        {

        }


        // user defined functions
        void getNames()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(getConnectionString()))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT full_name FROM member_master_tb1 WHERE member_id='" + TextBox1.Text.Trim() + "'", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count >= 1)
                    {
                        TextBox3.Text = dt.Rows[0]["member_name"].ToString();
                    }
                    else
                    {
                        Response.Write("<script>alert('Wrong Book id')</script>");

                    }


                    SqlCommand cmd1 = new SqlCommand("SELECT book_name FROM book_master_tb1 WHERE book_id='" + TextBox2.Text.Trim() + "'", con);
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                    DataTable dt1 = new DataTable();
                    da.Fill(dt1);

                    if (dt1.Rows.Count >= 1)
                    {
                        TextBox4.Text = dt1.Rows[0]["book_name"].ToString();
                    }
                    else
                    {
                        Response.Write("<script>alert('Wrong Book id')</script>");

                    }

                    Response.Write("<script>alert('Name is SELECTED..')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
    }
}