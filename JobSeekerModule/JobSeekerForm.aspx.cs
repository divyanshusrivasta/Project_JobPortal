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


namespace Project_JobPortal_0507.Job_Seeker_Module
{
    public partial class JobSeekerForm : System.Web.UI.Page
    {
        SqlConnection con=new SqlConnection(ConfigurationManager.ConnectionStrings["abc"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindjobprofile();
                bindqualification();
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
            txtdob.Text = "";
            rblexperiance.ClearSelection();
            rblgender.ClearSelection();
            ddlcity.SelectedIndex = 0;
            ddljobprofile.SelectedIndex = 0;
            ddlqualification.SelectedIndex = 0;
            ddlstate.SelectedIndex = 0;


        }
        public void bindjobprofile()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblJobSeekerJobProfile", con);
            SqlDataAdapter sda=new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            ddljobprofile.DataSource = dt;
            ddljobprofile.DataValueField = "JobSeekerJobProfileid";
            ddljobprofile.DataTextField = "JobSeekerJobProfilename";
            ddljobprofile.DataBind();
            ddljobprofile.Items.Insert(0, new ListItem("--SELECT--","0"));
        }

        public void bindqualification()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblJobSeekerQualification",con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            ddlqualification.DataSource = dt;
            ddlqualification.DataValueField = "JobSeekerQualificationid";
            ddlqualification.DataTextField = "JobSeekerQualificationname";
            ddlqualification.DataBind();
            ddlqualification.Items.Insert(0, new ListItem("--SELECT--", "0"));
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
            SqlCommand cmd = new SqlCommand("select * from tblJobSeekerCity where JobSeekerStateid='"+ddlstate.SelectedValue+"'",con);
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
            string ImageName=Path.GetFileName(fuimg.PostedFile.FileName);
            fuimg.SaveAs(Server.MapPath("JobSeekerImage" + "\\" + ImageName));

            string ResumeName = Path.GetFileName(furesume.PostedFile.FileName);
            furesume.SaveAs(Server.MapPath("JobSeekerResume" + "\\" + ResumeName));

            con.Open();
            SqlCommand cmd =new SqlCommand("seek",con);
            cmd.CommandType=CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "seekinsert");
            cmd.Parameters.AddWithValue("@JobSeekerName",txtname.Text);
            cmd.Parameters.AddWithValue("@JobSeekerEmail", txtemail.Text);
            cmd.Parameters.AddWithValue("@JobSeekerPassword", txtpassword.Text);
            cmd.Parameters.AddWithValue("@JobSeekerGender", rblgender.SelectedValue);
            cmd.Parameters.AddWithValue("@JobSeekerJobProfile",ddljobprofile.SelectedValue);
            cmd.Parameters.AddWithValue("@JobSeekerQualification",ddlqualification.SelectedValue);
            cmd.Parameters.AddWithValue("@JobSeekerState", ddlstate.SelectedValue);
            cmd.Parameters.AddWithValue("@JobSeekerCity", ddlcity.SelectedValue);
            cmd.Parameters.AddWithValue("@JobSeekerAddress", txtaddress.Text);
            cmd.Parameters.AddWithValue("@JobSeekerDob", txtdob.Text);
            cmd.Parameters.AddWithValue("@JobSeekerMobile", txtmobile.Text);
            cmd.Parameters.AddWithValue("@JobSeekerExperiance", rblexperiance.SelectedValue);
            cmd.Parameters.AddWithValue("@JobSeekerImage", ImageName);
            cmd.Parameters.AddWithValue("@JobSeekerResume", ResumeName);
            cmd.Parameters.AddWithValue("@JobSeekerComments", txtcomments.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            clear();


        }
    }
}