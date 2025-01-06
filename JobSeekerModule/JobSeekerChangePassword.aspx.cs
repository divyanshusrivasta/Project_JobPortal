using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Threading;

namespace Project_JobPortal_0507.JobSeekerModule
{
    public partial class JobSeekerChangePassword : System.Web.UI.Page
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
                SqlCommand cmd = new SqlCommand("seek", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "changepassword");               
                cmd.Parameters.AddWithValue("@JobSeekerId", Session["jsid"]);
                cmd.Parameters.AddWithValue("@JobSeekerPassword", txtcurrentpassword.Text);
                cmd.Parameters.AddWithValue("@JobSeekerNewPassword", txtnewpassword.Text);
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