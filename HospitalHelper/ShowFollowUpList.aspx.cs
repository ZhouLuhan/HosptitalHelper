using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace HospitalHelper
{
    public partial class ShowFollowUpList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            if (TextBox2.Text.Trim() == "")
            {
                GridView1.DataSourceID = "SqlDataSource2";
                GridView1.DataBind();

                int i, k;
                for (i = 0; i < GridView1.Rows.Count; i++)
                {
                    if (!GridView1.Rows[i].Visible) continue;
                    for (k = i + 1; k < GridView1.Rows.Count; k++)
                    {
                        if (!GridView1.Rows[k].Visible) continue;

                        if (GridView1.Rows[i].Cells[0].Text == GridView1.Rows[k].Cells[0].Text)
                        {
                            GridView1.Rows[i].Cells[4].Text += "," + GridView1.Rows[k].Cells[4].Text;
                            GridView1.Rows[k].Visible = false;
                        }
                    }
                }
            }
            else
            {
                
                GridView1.DataSourceID = "SqlDataSource1";
                GridView1.DataBind();
            }

            for (int j = 0; j < GridView1.Rows.Count; j++)
            {
                if (GridView1.Rows[j].Cells[3].Text.Count() > 50)
                {
                    GridView1.Rows[j].Cells[3].Text = GridView1.Rows[j].Cells[3].Text.Remove(50);
                    GridView1.Rows[j].Cells[3].Text = GridView1.Rows[j].Cells[3].Text.Insert(50, "...");
                }
            }
        }
    }
}