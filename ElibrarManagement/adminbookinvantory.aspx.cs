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
            if (checkIfBookIdExists())
            {
                Response.Write("<script>alert('book id already Exists..')</script>");
            }
            else
            {
                addNewBook();
            }
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

        bool checkIfBookIdExists()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(getConnectionString()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tb1 WHERE book_id='" + TextBox2.Text.ToString() + "' OR book_name='"+ TextBox1.Text.ToString() +"'", con);
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
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                return false;
            }

        }

        void addNewBook()
        {
            try
            {
                string genres = "";
                foreach (int i in ListBox1.GetSelectedIndices())
                {
                    genres = genres + ListBox1.Items[i] + ",";
                }

                genres = genres.Remove(genres.Length - 1);


                string filepath = "~/book_invantory/";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("/book_invantory/" + filename));
                filepath = "~/book_invantory/" + filename;


                using (SqlConnection con = new SqlConnection(getConnectionString()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO book_master_tb1 (book_id,book_name,publisher_name,edition,book_cost,no_of_pages,book_discription,book_img_link,genre,actual_stock,current_stock,author_name) values (@book_id,@book_name,@publisher_name,@edition,@book_cost,@no_of_pages,@book_discription,@book_img_link,@genre,@actual_stock,@current_stock,@author_name)", con);

                    cmd.Parameters.AddWithValue("@book_id", TextBox2.Text.ToString());
                    cmd.Parameters.AddWithValue("@book_name", TextBox1.Text.ToString());
                    cmd.Parameters.AddWithValue("@edition", TextBox7.Text.ToString());
                    cmd.Parameters.AddWithValue("@book_cost", TextBox8.Text.ToString());
                    cmd.Parameters.AddWithValue("@no_of_pages", TextBox10.Text.ToString());
                    cmd.Parameters.AddWithValue("@book_discription", TextBox4.Text.ToString());
                    cmd.Parameters.AddWithValue("@actual_stock", TextBox5.Text.ToString());
                    cmd.Parameters.AddWithValue("@current_stock", TextBox5.Text.ToString());
                    cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@book_img_link", filepath);
                    cmd.Parameters.AddWithValue("@genre", genres);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert('book is added ..')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");

            }
        }
    }
}