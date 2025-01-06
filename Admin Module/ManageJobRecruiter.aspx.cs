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
    public partial class ManageJobRecruiter : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["abc"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindJobRecruiter();
            }

        }



        public void BindJobRecruiter()
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("recruit", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "recruitdisplay");
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            gvjobrecruiter.DataSource = dt;
            gvjobrecruiter.DataBind();
        }

        protected void gvjobrecruiter_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "block")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("recruit", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "JobRecruiterblock");
                cmd.Parameters.AddWithValue("@JobRecruiterId", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                BindJobRecruiter();
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("recruit", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "recruitdisplayByRecruiterName");
            cmd.Parameters.AddWithValue("@JobRecruiterName", txtjorecruitername.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {
                gvjobrecruiter.DataSource = dt;
                gvjobrecruiter.DataBind();
                lblmsg.Text = ""; // Clear any previous messages
            }
            else
            {
                gvjobrecruiter.DataSource = null;
                gvjobrecruiter.DataBind();
                lblmsg.Text = "NO RESULTS FOUND: No records match your search criteria. Please adjust your filters and try again. !!!";
            }
        }
    }
}