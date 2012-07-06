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
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Blogin_Click(object sender, EventArgs e)
        {
            string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["HospitalData"].ConnectionString;
            SqlConnection conn = new SqlConnection(strcon);
            conn.Open();
            SqlCommand comm = new SqlCommand("select * from OPERATOR where HID=@user", conn);
            string psw = Tpsw.Text;
            comm.Parameters.Add("@user", Tuser.Text);

            comm.ExecuteNonQuery();
            SqlDataReader reader = comm.ExecuteReader();

            if (reader.HasRows)
            {
                Session["HID"] = Tuser.Text;
                
                reader.Read();
                if (reader.GetBoolean(2))
                    Session["LIM"] = "true";
                else Session["LIM"] = "false";

                if (reader.GetString(1) == psw) Response.Redirect("FindPatient.aspx");
                else Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "info", "alert('密码错误!')", true);
            }
            else Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "info", "alert('用户名错误!')", true);
            conn.Close();
        }
    }
}
