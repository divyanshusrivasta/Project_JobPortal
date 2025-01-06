using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Project_JobPortal_0507.Admin_Module
{
    public partial class ManageJobSeeker : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["abc"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindJobSeeker();
                bindjobprofile();
            }
        }

        public void bindjobprofile()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblJobSeekerJobProfile", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            ddljobprofile.DataSource = dt;
            ddljobprofile.DataValueField = "JobSeekerJobProfileid";
            ddljobprofile.DataTextField = "JobSeekerJobProfilename";
            ddljobprofile.DataBind();
            ddljobprofile.Items.Insert(0, new ListItem("--SELECT--", "0"));
        }

        public void BindJobSeeker()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("seek", con);
            cmd.CommandType=CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "seekdisplay");
            SqlDataAdapter  sda=new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            gvjobseeker.DataSource = dt;
            gvjobseeker.DataBind();
        }

        protected void gvjobseeker_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "block")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("seek", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "JobSeekerblock");
                cmd.Parameters.AddWithValue("@JobSeekerId", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                BindJobSeeker();
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("seek", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "seekdisplayByJobProfileAndJobSeekename");
            cmd.Parameters.AddWithValue("@JobSeekerName", txtjobseekername.Text);
            cmd.Parameters.AddWithValue("@JobSeekerJobProfile", ddljobprofile.SelectedValue);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {
                gvjobseeker.DataSource = dt;
                gvjobseeker.DataBind();
                lblmsg.Text = ""; // Clear any previous messages
            }
            else
            {
                gvjobseeker.DataSource = null;
                gvjobseeker.DataBind();
                lblmsg.Text = "NO RESULTS FOUND: No records match your search criteria. Please adjust your filters and try again.  !!!";
            }
        }
    }
}