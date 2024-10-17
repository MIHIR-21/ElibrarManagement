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
    public partial class adminpublishermanagement : System.Web.UI.Page
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

        // go button click
        protected void Button1_Click(object sender, EventArgs e)
        {
            getPublisherById();
        }

        // add button click
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkIfPublisherExists())
            {
                Response.Write("<script>alert('publisher ID is already exists')</script>");

            }
            else
            {
                addNewPublisher();

            }
        }

        // Update button click
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkIfPublisherExists())
            {
                updatePublisher();
            }
            else
            {
                Response.Write("<script>alert('Publisher id is not exist.')</script>");
            }
        }

        // Delete button click
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIfPublisherExists())
            {
                deletePublisher();
            }
            else
            {
                Response.Write("<script>alert('Publiher id is not exist.')</script>");

            }
        }



        // user defined Methods 

        bool checkIfPublisherExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(getConnectionString());
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM publisher_master_tb1 WHERE publisher_id='" + TextBox1.Text.ToString() + "'", con);
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
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                return false;
            }
        }

        void addNewPublisher()
        {
            try
            {
                using(SqlConnection con = new SqlConnection(getConnectionString()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO publisher_master_tb1 (publisher_id,publisher_name) values (@publisher_id,@publisher_name) ", con);

                    cmd.Parameters.AddWithValue("@publisher_id",TextBox1.Text.ToString());
                    cmd.Parameters.AddWithValue("@publisher_name",TextBox2.Text.ToString());

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('publisher added successfully')</script>");
                    clearForm();
                    GridView1.DataBind();

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        void updatePublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(getConnectionString());
                con.Open();
                SqlCommand cmd = new SqlCommand($"UPDATE publisher_master_tb1 SET publisher_name=@publisher_name WHERE publisher_id='{TextBox1.Text.Trim()}'", con);

                cmd.Parameters.AddWithValue("@publisher_name", TextBox2.Text.ToString());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Publisher Updated Successfully')</script>");
                clearForm();
                GridView1.DataBind();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        void deletePublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(getConnectionString());
                con.Open();
                Response.Write("<script>alert('are your sure ?')</script>");


                SqlCommand cmd = new SqlCommand("DELETE FROM publisher_master_tb1 WHERE publisher_id='"+ TextBox1.Text.ToString() +"'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Publisher Deleted Successfully')</script>");
                clearForm();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }


        void getPublisherById()
        {
            try
            {
                SqlConnection con = new SqlConnection(getConnectionString());
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM publisher_master_tb1 WHERE publisher_id='" + TextBox1.Text.ToString() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Publisher Id')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");

            }
        }
        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }
    }
}