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
    public partial class AdminHome : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["abc"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAdmin();
            }
        }

        public void BindAdmin()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_Admin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "adminshow");
            cmd.Parameters.AddWithValue("@AdminId", Session["aid"]);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            gvadmin.DataSource = dt;
            gvadmin.DataBind();
        }
    }
}