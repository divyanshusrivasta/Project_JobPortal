using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Project_JobPortal_0507.Admin_Module
{
    public partial class AdminMangaeJob : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["abc"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindJobPost();
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
        public void BindJobPost()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_JobPost", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "JobPostShow");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            gvadminjobpost.DataSource = dt;
            gvadminjobpost.DataBind();
        }

        protected void gvadminjobpost_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "block")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_JobPost", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "JobPostblock");
                cmd.Parameters.AddWithValue("@JobPostId", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                BindJobPost();
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_JobPost", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "JobPostShowSearch");
            cmd.Parameters.AddWithValue("@JobRecruiterName", txtjorecruitername.Text);
            cmd.Parameters.AddWithValue("@JobProfileId", ddljobprofile.SelectedValue);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {
                gvadminjobpost.DataSource = dt;
                gvadminjobpost.DataBind();
                lblmsg.Text = ""; // Clear any previous messages
            }
            else
            {
                gvadminjobpost.DataSource = null;
                gvadminjobpost.DataBind();
                lblmsg.Text = "NO RESULTS FOUND: No records match your search criteria. Please adjust your filters and try again.  !!!";
            }
        }
    }
}