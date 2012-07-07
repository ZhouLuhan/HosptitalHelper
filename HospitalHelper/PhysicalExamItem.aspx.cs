using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.Sql;

namespace HospitalHelper
{
    public partial class PhysicalExamItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)//添加Item
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["HospitalHelper"].ConnectionString;
            SqlConnection conn = new SqlConnection(strcon);
            SqlCommand comm = new SqlCommand("SELECT * FROM TESTITEM WHERE TYPE = @TYPE", conn);
            comm.Parameters.Add("@TYPE", DropDownList1.SelectedValue);
            conn.Open();

            SqlDataAdapter sd = new SqlDataAdapter(comm);
            System.Data.DataSet ds = new System.Data.DataSet();
            sd.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            conn.Close();
        }

    }
}