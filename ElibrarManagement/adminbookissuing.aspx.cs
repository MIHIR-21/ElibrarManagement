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

        }

        // return Book
        protected void Button3_Click(object sender, EventArgs e)
        {

        }
    }
}