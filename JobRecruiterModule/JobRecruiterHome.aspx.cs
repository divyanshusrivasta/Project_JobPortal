using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Project_JobPortal_0507.Job_Recruiter_Module
{
    public partial class JobRecruiterHome : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["abc"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            BindJobRecruiter();
        }
        public void BindJobRecruiter()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("recruit", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "onerecruitdisplay");
            cmd.Parameters.AddWithValue("@jobrecruiterid", Session["jrid"]);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            gvjobrecruiter.DataSource = dt;
            gvjobrecruiter.DataBind();

        }
    }
}