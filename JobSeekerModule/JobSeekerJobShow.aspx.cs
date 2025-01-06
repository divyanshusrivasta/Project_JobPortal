using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_JobPortal_0507.JobSeekerModule
{
    public partial class JobSeekerJobShow : System.Web.UI.Page
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

        public void BindJobPost()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_JobPost", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "JobPostShowonly");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            gvjobshow.DataSource = dt;
            gvjobshow.DataBind();
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

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_JobPost", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "JobPostJobProfile");
            cmd.Parameters.AddWithValue("@JobProfileId", ddljobprofile.SelectedValue);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            if (dt.Rows.Count > 0)
            {
                gvjobshow.DataSource = dt;
                gvjobshow.DataBind();
                lblmsg.Text = ""; // Clear any previous messages
            }
            else
            {
                gvjobshow.DataSource = null;
                gvjobshow.DataBind();
                lblmsg.Text = "NO RESULTS FOUND: No records match your search criteria. Please adjust your filters and try again. !!!";
            }

        }

        protected void gvjobshow_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName =="Apply")
            {
                Response.Redirect("JobSeekerSendMail.aspx");

            }
        }
    }
}