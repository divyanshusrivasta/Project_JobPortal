using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Project_JobPortal_0507.JobRecruiterModule
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["abc"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnchange_Click(object sender, EventArgs e)
        {
            if (txtnewpassword.Text == txtconfirmpassword.Text)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("recruit", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "changepassword");
                cmd.Parameters.AddWithValue("@JobRecruiterId", Session["jrid"]);
                cmd.Parameters.AddWithValue("@JobRecruiterPassword", txtcurrentpassword.Text);
                cmd.Parameters.AddWithValue("@JobRecruiterNewPassword", txtnewpassword.Text);
                cmd.ExecuteNonQuery();
                con.Close();


                Response.Redirect("../LogOut.aspx");



            }
            else
            {
                lblmsg.Text = "New Password And Confirm Password should be Same";
            }
        }
    }
}