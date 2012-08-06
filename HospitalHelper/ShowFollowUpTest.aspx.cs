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
    public partial class ShowFollowUpTest : System.Web.UI.Page
    {
        SqlDataSource source, sourcet;
        DropDownList droptype;
        protected void Page_Load(object sender, EventArgs e)
        {         
            string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["HospitalData"].ConnectionString;
            sourcet = new SqlDataSource(strcon, "SELECT * FROM TESTTYPE");
            //droptype = new DropDownList();
            //form1.Controls.Add(droptype);
            //droptype.AutoPostBack = true;
            //droptype.DataSource = sourcet;
            //droptype.DataTextField = "NAME";
            //droptype.DataValueField = "TYPE";
            //droptype.SelectedIndexChanged += new EventHandler(DropDownList1_SelectedIndexChanged);      
            //droptype.DataBind();
            if (!IsPostBack)
            {
                DropDownList1.DataSource = sourcet;
                DropDownList1.DataTextField = "NAME";
                DropDownList1.DataValueField = "TYPE";
                DropDownList1.AutoPostBack = true;
                DropDownList1.SelectedIndexChanged += new EventHandler(DropDownList1_SelectedIndexChanged);
                DropDownList1.DataBind();
            }

            source = new SqlDataSource(strcon, "SELECT * FROM [TESTITEM],[TESTRESULT] WHERE TESTITEM.TID=TESTRESULT.TID AND TESTITEM.TYPE=TESTRESULT.TYPE AND TESTITEM.TYPE =" + DropDownList1.SelectedValue);
            GridView1.Columns[5].Visible = true;
            GridView1.DataSource = source;
            GridView1.DataBind();
            displayvalue();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["HospitalData"].ConnectionString;
            source = new SqlDataSource(strcon, "SELECT * FROM [TESTITEM],[TESTRESULT] WHERE TESTITEM.TID=TESTRESULT.TID AND TESTITEM.TYPE=TESTRESULT.TYPE AND TESTITEM.TYPE =" + DropDownList1.SelectedValue);
            GridView1.Columns[5].Visible = true;
            GridView1.DataSource = source;
            GridView1.DataBind();
            displayvalue();
        }

        protected void displayvalue()
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                Response.Write(GridView1.Rows[i].Cells[4].Text);
                Response.Write(GridView1.Rows[i].Cells[5].Text);
                if (GridView1.Rows[i].Cells[4].Text.Trim() == "" && GridView1.Rows[i].Cells[5].Text.Trim() != "")
                    GridView1.Rows[i].Cells[4].Text = "<" + GridView1.Rows[i].Cells[5].Text.Trim();
                else if (GridView1.Rows[i].Cells[4].Text.Trim() != "" && GridView1.Rows[i].Cells[5].Text.Trim() == "")
                    GridView1.Rows[i].Cells[4].Text = ">" + GridView1.Rows[i].Cells[5].Text.Trim();
                else if (GridView1.Rows[i].Cells[4].Text.Trim() != "" && GridView1.Rows[i].Cells[5].Text.Trim() != "")
                    GridView1.Rows[i].Cells[4].Text += "～" + GridView1.Rows[i].Cells[5].Text.Trim();
               
            }
            GridView1.Columns[5].Visible = false;
        }
    }
}