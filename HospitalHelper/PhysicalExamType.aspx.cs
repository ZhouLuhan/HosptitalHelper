using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data.OleDb;

namespace HospitalHelper
{
    public partial class PhysicalExamType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)//添加类别
        {
            string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["HospitalData"].ConnectionString;
            SqlConnection conn = new SqlConnection(strcon);
            conn.Open();
            SqlCommand commcount = new SqlCommand("SELECT COUNT(*), MAX(TYPE) FROM TESTTYPE", conn);
            commcount.ExecuteNonQuery();
            SqlDataReader reader =  commcount.ExecuteReader();
            reader.Read();

            int count;
            if (reader.GetInt32(0) > 0)          
                count = reader.GetInt32(1);
            else count = 0;
            reader.Close();

            SqlCommand comm = new SqlCommand("INSERT INTO [TESTTYPE](TYPE,NAME) VALUES (@TYPE, @NAME)", conn);
            comm.Parameters.Add("@NAME", TextBox1.Text);
            comm.Parameters.Add("@TYPE", count + 1);

            comm.ExecuteNonQuery();

            conn.Close();
            Response.Redirect("PhysicalExamType.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)//删除类别
        {
            //string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["HospitalData"].ConnectionString;
            //SqlConnection conn = new SqlConnection(strcon);
            //conn.Open();
            //SqlCommand commdeleted = new SqlCommand("SELECT TYPE FROM DELETED", conn);
            //SqlDataReader reader = commdeleted.ExecuteReader();
            //reader.Read();
            //int type = reader.GetInt32(0);
            //reader.Close();

            //SqlCommand comm = new SqlCommand("DELETE FROM TESTITEM WHERE TYPE = @TYPE", conn);
            //comm.Parameters.Add("@TYPE", SqlDataSource1.delete;
            //comm.ExecuteNonQuery();
            //conn.Close();
        }
    }
}