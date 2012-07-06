using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace HospitalHelper
{
    public partial class PasswordChange : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Bconfirm_Click(object sender, EventArgs e)
        {
            string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["HospitalData"].ConnectionString;
            SqlConnection conn = new SqlConnection(strcon);
            conn.Open();
            SqlCommand comm = new SqlCommand("UPDATE OPERATOR SET PSW=@PSW WHERE HID=@HID", conn);
            comm.Parameters.Add("@PSW", Tnpsw.Text);
            comm.Parameters.Add("@HID", Session["HID"].ToString());
            comm.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("FindPatient.aspx");
        }
    }
}