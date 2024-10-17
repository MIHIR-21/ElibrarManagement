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
    public partial class adminmembermanagement : System.Web.UI.Page
    {

        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
            con = new SqlConnection(getConnectionString());
        }

        private string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        }

        // go button
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            if (checkIfMemberIdExists())
            {
                getMemberById();
            }
            else
            {
                Response.Write("<script>alert('Member is not Exists..')</script>");

            }
        }

        // Pause button
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            updateActiveStatusById("pending");
        }

        // Active button
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            updateActiveStatusById("active");
        }

        // deactiv button
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            updateActiveStatusById("deactive");
        }

        // delete 
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (TextBox2.Text.ToString().Equals(""))
            {
                Response.Write("<script>alert('Member ID cannot be blank')</script>");

            }
            else
            {
                if (checkIfMemberIdExists())
                {


                    Response.Write("<script>alert('are your sure ?')</script>");
                    try
                    {
                        using (SqlConnection con = new SqlConnection(getConnectionString()))
                        {
                            con.Open();
                            SqlCommand cmd = new SqlCommand("DELETE FROM member_master_tb1 WHERE member_id='" + TextBox2.Text.ToString() + "'", con);
                            cmd.ExecuteNonQuery();
                            GridView1.DataBind();
                            clearForm();
                            Response.Write("<script>alert('user deleted successfully..')</script>");

                        }
                    }
                    catch (Exception ex)
                    {

                        Response.Write("<script>alert('" + ex.Message + "')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Member is not Exists..')</script>");

                }
            }

        }


        // user defined methods

        void getMemberById()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(getConnectionString()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tb1 WHERE member_id='" + TextBox2.Text.ToString() + "'", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            TextBox1.Text = dr.GetValue(0).ToString();
                            TextBox3.Text = dr.GetValue(10).ToString();
                            TextBox5.Text = dr.GetValue(1).ToString();
                            TextBox9.Text = dr.GetValue(2).ToString();
                            TextBox6.Text = dr.GetValue(3).ToString();
                            TextBox7.Text = dr.GetValue(4).ToString();
                            TextBox8.Text = dr.GetValue(5).ToString();
                            TextBox10.Text = dr.GetValue(6).ToString();
                            TextBox4.Text = dr.GetValue(7).ToString();


                        }

                    }

                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('" + ex.Message + "')</script>");

            }
        }

        void updateActiveStatusById(string status)
        {
            if (TextBox2.Text.ToString().Equals(""))
            {
                Response.Write("<script>alert('Member ID cannot be blank')</script>");

            }
            else
            {
                if (checkIfMemberIdExists())
                {


                    try
                    {
                        using (SqlConnection con = new SqlConnection(getConnectionString()))
                        {
                            con.Open();
                            SqlCommand cmd = new SqlCommand("UPDATE member_master_tb1 SET account_status='" + status + "' WHERE member_id='" + TextBox2.Text.ToString() + "'", con);
                            cmd.ExecuteNonQuery();
                            con.Close();

                            GridView1.DataBind();
                            Response.Write("<script>alert('member status updated..')</script>");

                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write($"<script>alert('" + ex.Message + "')</script>");

                    }
                }
                else
                {
                    Response.Write("<script>alert('Member is not Exists.')</script>");

                }
            }
        }

        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox5.Text = "";
            TextBox9.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox10.Text = "";
            TextBox4.Text = "";
        }

        bool checkIfMemberIdExists()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(getConnectionString()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tb1 WHERE member_id='"+ TextBox2.Text.ToString() +"'", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if(dt.Rows.Count >= 1)
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
                Response.Write("<script>alert('"+ ex.Message +"')</script>");
                return false;
            }
            
        }

    }
}