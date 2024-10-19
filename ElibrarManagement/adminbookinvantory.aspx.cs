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

        static string globle_filepath;
        static int globle_actual_stock, globle_current_stock, globle_issued_books;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillAuthorPublisherValues();
            }
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
            getBookById();
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
            updateBookById();
        }


        // delete button click
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIfBookIdExists())
            {
                deleteBook();
                clearForm();
            }
            else
            {
                Response.Write("<script>alert('book id is not Exists..')</script>");

            }
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
                    DropDownList3.DataTextField = "author_name";
                    DropDownList3.DataBind();

                    cmd = new SqlCommand("SELECT publisher_name FROM publisher_master_tb1", con);
                    da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);

                    DropDownList2.DataSource = dt;
                    DropDownList2.DataValueField = "publisher_name";
                    DropDownList3.DataTextField = "publisher_name";
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
                    SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tb1 WHERE book_id='" + TextBox2.Text.ToString() + "'", con);
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


                string filepath = "~/book_invantory/books1";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("/book_invantory/" + filename));
                filepath = "~/book_invantory/" + filename;


                using (SqlConnection con = new SqlConnection(getConnectionString()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO book_master_tb1 (book_id,book_name,publisher_name,edition,book_cost,no_of_pages,book_discription,book_img_link,genre,actual_stock,current_stock,language,publish_date,author_name) values (@book_id,@book_name,@publisher_name,@edition,@book_cost,@no_of_pages,@book_discription,@book_img_link,@genre,@actual_stock,@current_stock,@language,@publish_date,@author_name)", con);

                    cmd.Parameters.AddWithValue("@book_id", TextBox2.Text.ToString());
                    cmd.Parameters.AddWithValue("@book_name", TextBox1.Text.ToString());
                    cmd.Parameters.AddWithValue("@edition", TextBox7.Text.ToString());
                    cmd.Parameters.AddWithValue("@book_cost", TextBox8.Text.ToString());
                    cmd.Parameters.AddWithValue("@no_of_pages", TextBox10.Text.ToString());
                    cmd.Parameters.AddWithValue("@book_discription", TextBox4.Text.ToString());
                    cmd.Parameters.AddWithValue("@actual_stock", TextBox5.Text.ToString());
                    cmd.Parameters.AddWithValue("@current_stock", TextBox5.Text.ToString());
                    cmd.Parameters.AddWithValue("@publish_date", TextBox3.Text.ToString());
                    cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
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

        void getBookById()
        {

            try
            {
                using (SqlConnection con = new SqlConnection(getConnectionString()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tb1 WHERE book_id='" + TextBox2.Text.ToString() + "'", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count >= 1)
                    {
                        TextBox1.Text = dt.Rows[0]["book_name"].ToString();
                        TextBox3.Text = dt.Rows[0]["publish_date"].ToString();
                        TextBox4.Text = dt.Rows[0]["book_discription"].ToString();
                        TextBox5.Text = dt.Rows[0]["actual_stock"].ToString().Trim();
                        TextBox6.Text = dt.Rows[0]["current_stock"].ToString().Trim();
                        TextBox7.Text = dt.Rows[0]["edition"].ToString();
                        TextBox8.Text = dt.Rows[0]["book_cost"].ToString().Trim();
                        TextBox10.Text = dt.Rows[0]["no_of_pages"].ToString().Trim();
                        TextBox9.Text = "" + (Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString().Trim()) - Convert.ToInt32(dt.Rows[0]["current_stock"].ToString().Trim()));

                        DropDownList1.SelectedValue = dt.Rows[0]["language"].ToString().Trim();
                        DropDownList2.SelectedValue = dt.Rows[0]["publisher_name"].ToString().Trim();
                        DropDownList3.SelectedValue = dt.Rows[0]["author_name"].ToString().Trim();

                        ListBox1.ClearSelection();
                        string[] genres = dt.Rows[0]["genre"].ToString().Trim().Split(',');
                        for(int i = 0; i < genres.Length; i++)
                        {
                            for (int j = 0; j < ListBox1.Items.Count; j++)
                            {
                                if (ListBox1.Items[j].ToString() == genres[i])
                                {
                                    ListBox1.Items[j].Selected = true;
                                }
                            }
                        }

                        globle_actual_stock = Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString().Trim());
                        globle_current_stock = Convert.ToInt32(dt.Rows[0]["current_stock"].ToString().Trim());
                        globle_issued_books = globle_actual_stock - globle_current_stock;
                        globle_filepath = dt.Rows[0]["book_img_link"].ToString();
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid Book Id')</script>");

                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }


        void updateBookById()
        {
            if (checkIfBookIdExists())
            {
                try
                {

                    int actual_stock = Convert.ToInt32(TextBox5.Text.Trim());
                    int current_stock = Convert.ToInt32(TextBox6.Text.Trim());

                    if (globle_actual_stock == actual_stock)
                    {

                    }
                    else
                    {
                        if (actual_stock < globle_issued_books)
                        {
                            Response.Write("<script>alert('Actual stock value can not be less than the issued books ')</script>");
                            return;
                        }
                        else
                        {
                            current_stock = actual_stock - globle_issued_books;
                            TextBox6.Text = "" + current_stock;
                        }
                    }

                    string genres = "";
                    foreach (int i in ListBox1.GetSelectedIndices())
                    {
                        genres = genres + ListBox1.Items[i] + ",";
                    }

                    genres = genres.Remove(genres.Length - 1);


                    string filepath = "~/book_invantory/books1";
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    if (filename == "" || filename == null)
                    {
                        filepath = globle_filepath;
                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("book_invantory/" + filename));
                        filepath = "~/book_invantory/" + filename;
                    }

                    SqlConnection con = new SqlConnection(getConnectionString());
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE book_master_tb1 SET book_name=@book_name,publisher_name=@publisher_name,edition=@edition,book_cost=@book_cost,no_of_pages=@no_of_pages,book_discription=@book_discription,book_img_link=@book_img_link,genre=@genre,actual_stock=@actual_stock,current_stock=@current_stock,language=@language,publish_date=@publish_date,author_name=@author_name  WHERE book_id='" + TextBox2.Text.ToString() + "'", con);

                    cmd.Parameters.AddWithValue("@book_name", TextBox1.Text.ToString());
                    cmd.Parameters.AddWithValue("@genre", genres);
                    cmd.Parameters.AddWithValue("@edition", TextBox7.Text.ToString());
                    cmd.Parameters.AddWithValue("@book_cost", TextBox8.Text.ToString());
                    cmd.Parameters.AddWithValue("@no_of_pages", TextBox10.Text.ToString());
                    cmd.Parameters.AddWithValue("@book_discription", TextBox4.Text.ToString());
                    cmd.Parameters.AddWithValue("@actual_stock", actual_stock.ToString());
                    cmd.Parameters.AddWithValue("@current_stock", current_stock.ToString());
                    cmd.Parameters.AddWithValue("@publish_date", TextBox3.Text.ToString());
                    cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@book_img_link", filepath);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert('Book Updated Successfully')</script>");

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid member Id')</script>");

            }
        }
        void deleteBook()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(getConnectionString()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM book_master_tb1 WHERE book_id='"+ TextBox2.Text.ToString() +"'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert('book is Deleted ..')</script>");

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");

            }
        }

        void clearForm()
        {
            TextBox2.Text = "";
        }
    }
}