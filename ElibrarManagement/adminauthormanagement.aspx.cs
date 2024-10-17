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
    public partial class adminauthormanagement : System.Web.UI.Page
    {

        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(getConnectionString());
            GridView1.DataBind();

        }

        private string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        }

        // add button click
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkIfAuthorExists())
            {
                Response.Write("<script>alert('Author is already exist.')</script>");

            }
            else
            {
                addNewAuthor();
            }
        }

        // update button click
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkIfAuthorExists())
            {
                updateAuthor();
            }
            else
            {
                Response.Write("<script>alert('Author id is not exist.')</script>");
            }
        }

        // delete button click
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIfAuthorExists())
            {
                deleteAuthor();
            }
            else
            {
                Response.Write("<script>alert('Author id is not exist.')</script>");
            }
        }

        // go button click
        protected void Button1_Click(object sender, EventArgs e)
        {
            getAuthorById();
        }


        // user defined Methods

        void getAuthorById()
        {
            try
            {
                SqlConnection con = new SqlConnection(getConnectionString());
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM author_master_tb1 WHERE author_id='" + TextBox1.Text.ToString() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                Response.Write("<script>alert('Invalid Author Id')</script>");

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                
            }
        }

        void deleteAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(getConnectionString());
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM author_master_tb1 WHERE author_id='" + TextBox1.Text.ToString() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Author Deleted Successfully')</script>");
                clearForm();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        void updateAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(getConnectionString());
                con.Open();
                SqlCommand cmd = new SqlCommand($"UPDATE author_master_tb1 SET author_name=@author_name WHERE author_id='{TextBox1.Text.Trim()}'", con);

                cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.ToString());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Author Updated Successfully')</script>");
                clearForm();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        void addNewAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(getConnectionString());
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO author_master_tb1(author_id,author_name) values (@author_id,@author_name)", con);
                cmd.Parameters.AddWithValue("@author_id", TextBox1.Text.ToString());
                cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.ToString());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Author added Successfully')</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        bool checkIfAuthorExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(getConnectionString());
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM author_master_tb1 WHERE author_id='"+ TextBox1.Text.ToString() +"'" , con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('"+ ex.Message +"')</script>");
                return false;
            }
        }

        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }
    }
}