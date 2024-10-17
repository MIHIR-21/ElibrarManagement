using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;

namespace ElibrarManagement
{
    public partial class adminbookinvantory : System.Web.UI.Page
    {

        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            fillAuthorPublisherValues();
            GridView1.DataBind();
            con = new SqlConnection(getConnectionString());
        }

        private string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        }

        // Go button click
        protected void LinkButton4_Click(object sender, EventArgs e)
        {

        }

        // add button click
        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        // update button click
        protected void Button3_Click(object sender, EventArgs e)
        {

        }


        // delete button click
        protected void Button4_Click(object sender, EventArgs e)
        {

        }


        // user defined functions

        void fillAuthorPublisherValues()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(getConnectionString()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT author_name FROM author_master_tb1", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    DropDownList3.DataSource = dt;
                    DropDownList3.DataValueField = "author_name";
                    DropDownList3.DataBind();

                    cmd = new SqlCommand("SELECT publisher_name FROM publisher_master_tb1", con);
                    da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);

                    DropDownList2.DataSource = dt;
                    DropDownList2.DataValueField = "publisher_name";
                    DropDownList2.DataBind();
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('"+ ex.Message +"')</script>");
            }
        }
    }
}