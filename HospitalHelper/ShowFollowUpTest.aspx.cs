using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalHelper
{
    public partial class ShowFollowUpTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //displayvalue();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView1.DataSourceID = "SqlDataSource2";
            GridView1.DataBind();
            displayvalue();
        }

        protected void displayvalue()
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (GridView1.Rows[i].Cells[3].Text.Trim() == "" && GridView1.Rows[i].Cells[4].Text.Trim() != "")
                    GridView1.Rows[i].Cells[3].Text = "<" + GridView1.Rows[i].Cells[4].Text.Trim();
                else if (GridView1.Rows[i].Cells[3].Text.Trim() != "" && GridView1.Rows[i].Cells[4].Text.Trim() == "")
                    GridView1.Rows[i].Cells[3].Text = ">" + GridView1.Rows[i].Cells[3].Text.Trim();
                else if (GridView1.Rows[i].Cells[3].Text.Trim() != "" && GridView1.Rows[i].Cells[4].Text.Trim() != "")
                    GridView1.Rows[i].Cells[3].Text += "～" + GridView1.Rows[i].Cells[4].Text.Trim();
               
            }
            GridView1.Columns[4].Visible = false;
        }
    }
}