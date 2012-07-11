using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data.Sql;
using System.Data.SqlClient;

namespace HospitalHelper
{
    public partial class ShowFollowUpProspect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["FID"] != null)
            {
                string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["HospitalData"].ConnectionString;
                SqlConnection conn = new SqlConnection(strcon);
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT PNAME, FDATE, FDESCRIPTION, FDOCTOR FROM PATIENT,FOLLOWUP WHERE FID=@FID AND PATIENT.PID=FOLLOWUP.PID", conn);
                comm.Parameters.Add("@FID", Request.QueryString["FID"]);
                comm.ExecuteNonQuery();
                SqlDataReader reader = comm.ExecuteReader();
                display(reader);
                conn.Close();
            }
        }

        protected void display(SqlDataReader reader)
        {
            reader.Read();
            Lname.Text = reader.GetString(0);
            Ldate.Text = reader.GetDateTime(1).ToString();
            Tdes.Text = reader.GetString(2);
            Ldoc.Text = reader.GetString(3);
            reader.Close();
        }
    }
}