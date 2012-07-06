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
    public partial class OperatorManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Bcfirm_Click(object sender, EventArgs e)
        {
            string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["HospitalData"].ConnectionString;
            SqlConnection conn = new SqlConnection(strcon);
            conn.Open();

            SqlCommand comm = new SqlCommand("SELECT HID FROM OPERATOR WHERE HID=@HID", conn);
            comm.Parameters.Add("@HID", Taduser.Text.Trim());
            SqlDataReader reader = comm.ExecuteReader();

            if (reader.HasRows)
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "info", "alert('此用户名已存在!')", true);
            else
            {
                reader.Close();
                comm = new SqlCommand("INSERT INTO OPERATOR(HID,PSW,LIM) VALUES('" + Taduser.Text.Trim() + "','" + Tadpsw.Text.Trim() + "','false')", conn);
                comm.ExecuteNonQuery();
                GridView1.DataBind();
            }
            conn.Close();
        }

    }
}