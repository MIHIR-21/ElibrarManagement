using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElibrarManagement
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"] == null)
                {
                    LinkButton1.Visible = true;  // user login link button
                    LinkButton2.Visible = true;  // signup link button

                    LinkButton3.Visible = false;  // logout link button
                    LinkButton7.Visible = false;    // hello user link button

                    LinkButton6.Visible = true;  // admin login link button
                    LinkButton8.Visible = false; // book invantory link button
                    LinkButton9.Visible = false; // book issuing link button
                    LinkButton10.Visible = false; // member management link button
                    LinkButton11.Visible = false; // author management link button
                    LinkButton12.Visible = false; // publisher management link button
                }
                else if (Session["role"] == "user")
                {
                    LinkButton1.Visible = false;  // user login link button
                    LinkButton2.Visible = false;  // signup link button

                    LinkButton3.Visible = true;  // logout link button
                    LinkButton7.Visible = true;    // hello user link button
                    LinkButton7.Text = "hello"+ " " +Session["username"].ToString();

                    LinkButton6.Visible = true;  // admin login link button
                    LinkButton8.Visible = false; // book invantory link button
                    LinkButton9.Visible = false; // book issuing link button
                    LinkButton10.Visible = false; // member management link button
                    LinkButton11.Visible = false; // author management link button
                    LinkButton12.Visible = false; // publisher management link button
                }
                else if(Session["role"] == "admin")
                {
                    LinkButton1.Visible = false;  // user login link button
                    LinkButton2.Visible = false;  // signup link button

                    LinkButton3.Visible = true;  // logout link button
                    LinkButton7.Visible = true;    // hello user link button
                    LinkButton7.Text = "hello Admin";
                    //LinkButton7.Text = "hello Admin"+ Session["username"].ToString();

                    LinkButton6.Visible = false;  // admin login link button
                    LinkButton8.Visible = true; // book invantory link button
                    LinkButton9.Visible = true; // book issuing link button
                    LinkButton10.Visible = true; // member management link button
                    LinkButton11.Visible = true; // author management link button
                    LinkButton12.Visible = true; // publisher management link button
                }
            }
            catch(Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}')</script>");
            }
        }

        protected void LinkButton1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }

        protected void LinkButton2_Click1(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminpublishermanagement.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminauthormanagement.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookissuing.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminmembermanagement.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookinvantory.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewbooks.aspx");
        }

        // Logout Button
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["usename"] = "";
            Session["fullname"] = "";
            Session["role"] = "";
            Session["status"] = "";

            LinkButton1.Visible = true;  // user login link button
            LinkButton2.Visible = true;  // signup link button

            LinkButton3.Visible = false;  // logout link button
            LinkButton7.Visible = false;    // hello user link button

            LinkButton6.Visible = true;  // admin login link button
            LinkButton8.Visible = false; // book invantory link button
            LinkButton9.Visible = false; // book issuing link button
            LinkButton10.Visible = false; // member management link button
            LinkButton11.Visible = false; // author management link button
            LinkButton12.Visible = false; // publisher management link button

            Response.Redirect("homepage.aspx");
        }

        // View Profile
        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("userprofile.aspx");

        }
    }
}