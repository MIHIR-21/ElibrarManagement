using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace ElibrarManagement
{
    public partial class userprofile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Only load data if it's not a postback to avoid rebinding during postbacks
            if (!IsPostBack)
            {
                getUserBookDetail();

                if (!Page.IsPostBack)
                {
                    getUserPersonalDetails();
                }
            }
        }

        // Connection string retrieval
        private string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        }

        // Get details of books issued to the user
        void getUserBookDetail()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(getConnectionString()))
                {
                    con.Open();

                    // Fetching book_issue_tb1 data for the user based on Session["username"]
                    SqlCommand cmd = new SqlCommand("SELECT * FROM book_issue_tb1 WHERE member_id = @member_id", con);
                    cmd.Parameters.AddWithValue("@member_id", Session["username"]);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // If data exists, bind to GridView
                    if (dt.Rows.Count > 0)
                    {
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    else
                    {
                        // Show a message if no records are found
                        Response.Write("<script>alert('No issued books found for this user.')</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        void updateUserPersonalDetails()
        {
            string password = "";
            if (TextBox10.Text.Trim() == "")
            {
                password = TextBox9.Text.Trim();
            }
            else
            {
                password = TextBox10.Text.Trim();
            }

            try
            {
                using (SqlConnection con = new SqlConnection(getConnectionString()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE member_master_tb1 SET full_name=@full_name, dob=@dob, contact_no=@contact_no, email=@email, state=@state, city=@city, pincode=@pincode, full_address=@full_address, member_id=@member_id, password=@password, account_status=@account_status WHERE member_id=@member_id ", con);
                    cmd.Parameters.AddWithValue("@member_id", Session["username"]);

                    cmd.Parameters.AddWithValue("@full_name", TextBox1.Text.ToString());
                    cmd.Parameters.AddWithValue("@dob", TextBox2.Text.ToString());
                    cmd.Parameters.AddWithValue("@contact_no", TextBox3.Text.ToString());
                    cmd.Parameters.AddWithValue("@email", TextBox4.Text.ToString());
                    cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@city", TextBox5.Text.ToString());
                    cmd.Parameters.AddWithValue("@pincode", TextBox6.Text.ToString());
                    cmd.Parameters.AddWithValue("@full_address", TextBox7.Text.ToString());
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@account_status", "pending");

                    int result = cmd.ExecuteNonQuery();
                    con.Close();

                    if (result > 0)
                    {
                        Response.Write("<script>alert('Your Details Updated Successfully..')</script>");
                        getUserPersonalDetails();
                        getUserBookDetail();
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid Entry')</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }

        }

        void getUserPersonalDetails()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(getConnectionString()))
                {
                    con.Open();

                    // Fetching book_issue_tb1 data for the user based on Session["username"]
                    SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tb1 WHERE member_id = @member_id", con);
                    cmd.Parameters.AddWithValue("@member_id", Session["username"]);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    TextBox1.Text = dt.Rows[0]["full_name"].ToString();
                    TextBox2.Text = dt.Rows[0]["dob"].ToString();
                    TextBox3.Text = dt.Rows[0]["contact_no"].ToString();
                    TextBox4.Text = dt.Rows[0]["email"].ToString();
                    DropDownList1.SelectedValue = dt.Rows[0]["state"].ToString().Trim();
                    TextBox5.Text = dt.Rows[0]["city"].ToString();
                    TextBox6.Text = dt.Rows[0]["pincode"].ToString();
                    TextBox7.Text = dt.Rows[0]["full_address"].ToString();
                    TextBox8.Text = dt.Rows[0]["member_id"].ToString();
                    TextBox9.Text = dt.Rows[0]["password"].ToString();

                    Label1.Text = dt.Rows[0]["account_status"].ToString().Trim();

                    if (dt.Rows[0]["account_status"].ToString().Trim() == "active")
                    {
                        Label1.Attributes.Add("class", "badge badge-pill badge-success");
                    }
                    else if (dt.Rows[0]["account_status"].ToString().Trim() == "pending")
                    {
                        Label1.Attributes.Add("class", "badge badge-pill badge-warning");
                    }
                    else if (dt.Rows[0]["account_status"].ToString().Trim() == "deactive")
                    {
                        Label1.Attributes.Add("class", "badge badge-pill badge-danger");
                    }
                    else
                    {
                        Label1.Attributes.Add("class", "badge badge-pill badge-secondary");

                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        // Placeholder for update button event
        protected void Button1_Click(object sender, EventArgs e)
        {
            updateUserPersonalDetails();
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
