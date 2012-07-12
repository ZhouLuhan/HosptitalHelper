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
    public partial class ShowDataSet : System.Web.UI.Page
    {
        DropDownList[] droptype = new DropDownList[100];
        DropDownList[] dropitem = new DropDownList[100];
        SqlDataSource[] source = new SqlDataSource[100];
        static int count;
        static int submit = 0;

        protected override void OnInit(EventArgs e)
        {
            string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["HospitalData"].ConnectionString;

            for (int i = 0; i < count; i++)
            {
                droptype[i] = new DropDownList();
                dropitem[i] = new DropDownList();
                form1.Controls.Add(droptype[i]);
                form1.Controls.Add(dropitem[i]);

                droptype[i].AutoPostBack = true;
                droptype[i].DataSourceID = "SqlDataSource1";
                droptype[i].DataTextField = "NAME";
                droptype[i].DataValueField = "TYPE";
                droptype[i].SelectedIndexChanged += new EventHandler(DropDownList1_SelectedIndexChanged);
                droptype[i].DataBind();

                source[i] = new SqlDataSource(strcon, "SELECT * FROM TESTITEM WHERE TYPE=" + droptype[i].SelectedValue);
                dropitem[i].AutoPostBack = true;
                dropitem[i].DataSource = source[i];
                dropitem[i].DataTextField = "NAME";
                dropitem[i].DataValueField = "TID";
                dropitem[i].SelectedIndexChanged += new EventHandler(DropDownList2_SelectedIndexChanged);
                dropitem[i].DataBind();
            }      
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { count = 0; submit = 0; }
            if (submit > 0)
            {
                GridView grid = new GridView();
                form1.Controls.Add(grid);
                submit = form1.Controls.IndexOf(grid);
            }
        }

        protected void Badd_Click(object sender, EventArgs e)
        {
            //if (form1.Controls.Count % 2 != 0) form1.Controls.RemoveAt(form1.Controls.Count - 1);
            string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["HospitalData"].ConnectionString;

            if (submit > 0) { form1.Controls.RemoveAt(submit); submit = 0; }

            droptype[count] = new DropDownList();
            dropitem[count] = new DropDownList();
            form1.Controls.Add(droptype[count]);
            form1.Controls.Add(dropitem[count]);

            droptype[count].AutoPostBack = true;
            droptype[count].DataSourceID = "SqlDataSource1";
            droptype[count].DataTextField = "NAME";
            droptype[count].DataValueField = "TYPE";
            droptype[count].SelectedIndexChanged += new EventHandler(DropDownList1_SelectedIndexChanged);
            
            droptype[count].DataBind();

            
            source[count] = new SqlDataSource(strcon, "SELECT * FROM TESTITEM WHERE TYPE=" + droptype[count].SelectedValue);
            dropitem[count].AutoPostBack = true;
            dropitem[count].DataSource = source[count];
            dropitem[count].DataTextField = "NAME";
            dropitem[count].DataValueField = "TID";
            dropitem[count].SelectedIndexChanged += new EventHandler(DropDownList2_SelectedIndexChanged);
            
            dropitem[count].DataBind();
            count++;
            
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (form1.Controls.Count % 2 != 0) form1.Controls.RemoveAt(form1.Controls.Count - 1);
            if (submit > 0) { form1.Controls.RemoveAt(submit); submit = 0; }

            int index = (form1.Controls.IndexOf((DropDownList)sender) - 14) / 2;
            source[index].SelectCommand = "SELECT * FROM TESTITEM WHERE TYPE=" + droptype[index].SelectedValue;
            dropitem[index].DataSource = source[index];
            dropitem[index].DataBind();
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (submit > 0) { form1.Controls.RemoveAt(submit); submit = 0; }
        }

        protected void Bsubmit_Click(object sender, EventArgs e)
        {
            if (submit > 0) { form1.Controls.RemoveAt(submit); submit = 0; }

            int month = 0 - Convert.ToInt32(Tmonth.Text);
            GridView grid = new GridView();
            form1.Controls.Add(grid);
            submit = form1.Controls.IndexOf(grid);

            string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["HospitalData"].ConnectionString;
            SqlConnection conn = new SqlConnection(strcon);
            conn.Open();
            SqlCommand comm = new SqlCommand("SELECT FDATE,RESULT,TYPE,TID FROM FOLLOWUP,TESTRESULT WHERE FOLLOWUP.FID=TESTRESULT.FID AND FDATE>@FDATE ORDER BY FDATE ASC", conn);
            comm.Parameters.Add("@FDATE", System.DateTime.Now.AddMonths(month));
            comm.ExecuteNonQuery();
            SqlDataReader reader = comm.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("时间"));
            for (int i = 0; i < count; i++)
                dt.Columns.Add(new DataColumn(dropitem[i].SelectedItem.Text));

            int j = -1; DateTime tmp = System.DateTime.Now.AddDays(1);

            DataRow[] rows = new DataRow[100];
            for (int i = 0; i < 100; i++)
                rows[i] = dt.NewRow();

            while (reader.Read())
            {
                if (reader.GetDateTime(0) != tmp)
                {
                    dt.Rows.Add(rows[++j]);
                    rows[j]["时间"] = reader.GetDateTime(0);
                    tmp = reader.GetDateTime(0);
                }
                for (int i = 0; i < count; i++)
                    if (reader.GetInt32(2) == Convert.ToInt32(droptype[i].SelectedValue) && reader.GetInt32(3) == Convert.ToInt32(dropitem[i].SelectedValue))
                    {
                        rows[j][dropitem[i].SelectedItem.Text] = reader.GetString(1);
                        break;
                    }
            }

            reader.Close();
            conn.Close();

            grid.DataSource = dt;
            grid.DataBind();


        }

    }
}