using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;

namespace Project_JobPortal_0507.Job_Recruiter_Module
{
    public partial class JobRecruiterREgistrationForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["abc"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindstate();
                ddlcity.Items.Insert(0, new ListItem("--SELECT--", "0"));
            }
        }

        public void clear()
        {
            txtname.Text = "";
            txtemail.Text = "";
            txtpassword.Text = "";
            txtmobile.Text = "";
            txtcomments.Text = "";
            txtaddress.Text = "";
            txthr.Text = "";
            txtwebsite.Text = "";
            ddlcity.SelectedIndex = 0;
            ddlstate.SelectedIndex = 0;


        }

        public void bindstate()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblJobSeekerState", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            ddlstate.DataSource = dt;
            ddlstate.DataValueField = "JobSeekerStateid";
            ddlstate.DataTextField = "JobSeekerStatename";
            ddlstate.DataBind();
            ddlstate.Items.Insert(0, new ListItem("--SELECT--", "0"));
        }

        public void bindcity()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblJobSeekerCity where JobSeekerStateid='" + ddlstate.SelectedValue + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            ddlcity.DataSource = dt;
            ddlcity.DataValueField = "JobSeekerCityid";
            ddlcity.DataTextField = "JobSeekerCityname";
            ddlcity.DataBind();
            ddlcity.Items.Insert(0, new ListItem("--SELECT--", "0"));
        }

        protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindcity();
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            string ImageName = Path.GetFileName(fuimg.PostedFile.FileName);
            fuimg.SaveAs(Server.MapPath("JobRecruiterImage" + "\\" + ImageName));

            

            con.Open();
            SqlCommand cmd = new SqlCommand("recruit", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "recruitinsert");
            cmd.Parameters.AddWithValue("@JobRecruiterEmail", txtemail.Text);
            cmd.Parameters.AddWithValue("@JobRecruiterName", txtname.Text);
            cmd.Parameters.AddWithValue("@JobRecruiterPassword", txtpassword.Text);
            cmd.Parameters.AddWithValue("@JobRecruiterHR", txthr.Text);
            cmd.Parameters.AddWithValue("@JobRecruiterState", ddlstate.SelectedValue);
            cmd.Parameters.AddWithValue("@JobRecruiterCity", ddlcity.SelectedValue);
            cmd.Parameters.AddWithValue("@JobRecruiterAddress", txtaddress.Text);
            cmd.Parameters.AddWithValue("@JobRecruiterWebsite", txtwebsite.Text);
            cmd.Parameters.AddWithValue("@JobRecruiterMobile", txtmobile.Text);
            cmd.Parameters.AddWithValue("@JobRecruiterImage", ImageName);
            cmd.Parameters.AddWithValue("@JobRecruiterComments", txtcomments.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            clear();
        }
    }
}