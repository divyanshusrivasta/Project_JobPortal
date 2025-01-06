using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Linq;

namespace Project_JobPortal_0507.JobRecruiterModule
{
    public partial class JobRecruiterJobPost : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["abc"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                bindqualification();
                bindjobprofile();

            }
        }

        public void clear()
        {
            ddljobprofile.SelectedIndex = 0;
            rblgender.ClearSelection();
            rblworkmode.ClearSelection();
            cblqualification.ClearSelection();
            txtminexp.Text = "";
            txtmaxexp.Text = "";
            txtminsalary.Text = "";
            txtmaxsalary.Text = "";
            txtvacancy.Text = "";
            txtcomments.Text = "";
            

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
        public void bindqualification()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblJobSeekerQualification", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            cblqualification.DataSource = dt;
            cblqualification.DataValueField = "JobSeekerQualificationid";
            cblqualification.DataTextField = "JobSeekerQualificationname";
            cblqualification.DataBind();
        }
        protected void btnadd_Click(object sender, EventArgs e)
        {
            string kk = "";
            for(int i = 0; i < cblqualification.Items.Count; i++)
            {
                if (cblqualification.Items[i].Selected==true)
                {
                    kk += cblqualification.Items[i].Text + ",";
                }
            }
            kk = kk.TrimEnd(',');


            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_JobPost", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "JobPostInsert");
            cmd.Parameters.AddWithValue("@JobRecruiterId", Session["jrid"]);
            cmd.Parameters.AddWithValue("@JobPostJobProfile", ddljobprofile.SelectedValue);
            cmd.Parameters.AddWithValue("@JobPostMode", rblworkmode.SelectedValue);
            cmd.Parameters.AddWithValue("@JobPostGender", rblgender.SelectedValue);
            cmd.Parameters.AddWithValue("@JobPostMinExp", txtminexp.Text);
            cmd.Parameters.AddWithValue("@JobPostQaulification", kk);
            cmd.Parameters.AddWithValue("@JobPostMaxExp", txtmaxexp.Text);
            cmd.Parameters.AddWithValue("@JobPostMinSalary", txtminsalary.Text);
            cmd.Parameters.AddWithValue("@JobPostMaxSalary", txtmaxsalary.Text);
            cmd.Parameters.AddWithValue("@JobPostVacancy", txtvacancy.Text);
            cmd.Parameters.AddWithValue("@JobPostComments", txtcomments.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            clear();
        }
    }
}