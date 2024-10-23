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
            if (checkIfBookExist() && checkIfMemberExist())
            {
                if (checkIfIssueEntryExist())
                {
                    Response.Write("<script>alert('this Member Already has this Book.')</script>");

                }
                else
                {
                    insertIssuedBook();
                }
            }
            else
            {
                Response.Write("<script>alert('Member id and Book id dose not Exists.')</script>");

            }
        }

        // GO button
        protected void Button1_Click(object sender, EventArgs e)
        {
            getNames();
        }

        // return Book
        protected void Button3_Click(object sender, EventArgs e)
        {
            returnBook();
        }


        // user defined functions


        bool checkIfBookExist()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tb1 WHERE book_id='" + TextBox2.Text.ToString() + "' AND current_stock > 0", con);
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
            catch
            {
                return false;
            }
        }


        bool checkIfMemberExist()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT full_name FROM member_master_tb1 WHERE member_id='" + TextBox1.Text.ToString() + "'", con);
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
            catch
            {
                return false;
            }
        }

        void insertIssuedBook()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(getConnectionString()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO book_issue_tb1 (member_id , member_name, book_id, book_name, issue_date, due_date) VALUES (@member_id , @member_name, @book_id, @book_name, @issue_date, @due_date) ", con);
                    cmd.Parameters.AddWithValue("@member_id", TextBox1.Text.ToString());
                    cmd.Parameters.AddWithValue("@book_id", TextBox2.Text.ToString());
                    cmd.Parameters.AddWithValue("@member_name", TextBox3.Text.ToString());
                    cmd.Parameters.AddWithValue("@book_name", TextBox4.Text.ToString());
                    cmd.Parameters.AddWithValue("@issue_date", TextBox5.Text.ToString());
                    cmd.Parameters.AddWithValue("@due_date", TextBox6.Text.ToString());

                    cmd.ExecuteNonQuery();


                    cmd = new SqlCommand("UPDATE book_master_tb1 SET current_stock = current_stock - 1 WHERE book_id ='"+ TextBox2.Text.ToString() + "'", con);
                    cmd.ExecuteNonQuery();

                    con.Close();
                    Response.Write("<script>alert('Book Issued..')</script>");
                    
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        void returnBook()
        {

            try
            {
                using (SqlConnection con = new SqlConnection(getConnectionString()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM book_issue_tb1 WHERE book_id='"+ TextBox2.Text.ToString() +"' AND member_id='"+ TextBox1.Text.ToString() +"'", con);
                    int result = cmd.ExecuteNonQuery();

                    if(result > 0)
                    {
                        cmd = new SqlCommand("UPDATE book_master_tb1 SET current_stock = current_stock+1 WHERE book_id='"+ TextBox2.Text.ToString() +"'", con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Response.Write("<script>alert('Book Returned Successfully')</script>");
                        GridView1.DataBind();

                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        bool checkIfIssueEntryExist()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM book_issue_tb1 WHERE member_id='" + TextBox1.Text.ToString() + "' AND book_id='"+ TextBox2.Text.ToString() +"'", con);
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
            catch
            {
                return false;
            }
        }

        void getNames()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(getConnectionString()))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT full_name FROM member_master_tb1 WHERE member_id='"+ TextBox1.Text.ToString() +"'", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if(dt.Rows.Count >= 1 )
                    {
                        TextBox3.Text = dt.Rows[0]["full_name"].ToString();
                    }
                    else
                    {
                            Response.Write("<script>alert('Wrong member id')</script>");
                    }

                    cmd = new SqlCommand("SELECT book_name FROM book_master_tb1 WHERE book_id='"+ TextBox2.Text.ToString() +"'", con);
                    da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);

                    if(dt.Rows.Count >= 1 )
                    {
                        TextBox4.Text = dt.Rows[0]["book_name"].ToString();
                    }
                    else
                    {
                           Response.Write("<script>alert('Wrong Book id')</script>");

                    }

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if(e.Row.RowType == DataControlRowType.DataRow)
                {
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;

                    if(today > dt)
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
    }
}