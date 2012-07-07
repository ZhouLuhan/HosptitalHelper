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

        protected void inserted_navigate(object sender, SqlDataSourceStatusEventArgs e)
        {

            Response.Redirect("PhysicalExamItem.aspx");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView1.DataSourceID = "SqlDataSource2";
            GridView1.DataBind();
        }

    }
}