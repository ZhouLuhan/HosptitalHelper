﻿using System;
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
    public partial class NewFollowUpTest : System.Web.UI.Page
    {
        private int fid = 1;
        DropDownList[] droptype = new DropDownList[100];
        GridView[] grid = new GridView[100];
        SqlDataSource[] source = new SqlDataSource[100];
        static int count = 0;

        protected override void OnInit(EventArgs e)
        {
            string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["HospitalData"].ConnectionString;
            for (int i = 0; i < count + 1 - 1; i++)
            {
                droptype[i] = new DropDownList();
                grid[i] = new GridView();

                form1.Controls.Add(droptype[i]);
                form1.Controls.Add(grid[i]);

                droptype[i].SelectedIndexChanged += new EventHandler(DropDownList1_SelectedIndexChanged);
                droptype[i].AutoPostBack = true;
                droptype[i].DataSourceID = "SqlDataSource1";
                droptype[i].DataValueField = "TYPE";
                droptype[i].DataTextField = "NAME";
                droptype[i].DataBind();
            }
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["HospitalData"].ConnectionString;
            for (int i = 0; i < count; ++i)
            {
                string[] array = { "TID" };
                grid[i].DataKeyNames = array;
                //SqlDataSource2.SelectCommand = "SELECT * FROM TESTITEM WHERE TYPE=" + Convert.ToInt32(droptype[i].SelectedValue);
                source[i] = new SqlDataSource(strcon, "SELECT * FROM TESTITEM WHERE TYPE=" + Convert.ToInt32(droptype[i].SelectedValue));

                grid[i].DataSource = source[i];
                //grid[i].DataBind();
                grid[i].AutoGenerateColumns = false;
                grid[i].Columns.Clear();

                BoundField bid = new BoundField();
                bid.DataField = "TID";
                bid.HeaderText = "No.";
                grid[i].Columns.Add(bid);

                BoundField bname = new BoundField();
                bname.DataField = "NAME";
                bname.HeaderText = "项目";
                grid[i].Columns.Add(bname);

                BoundField bunit = new BoundField();
                bunit.DataField = "UNIT";
                bunit.HeaderText = "单位";
                grid[i].Columns.Add(bunit);


                TemplateField bresult = new TemplateField();
                TextBoxTemplate template = new TextBoxTemplate();
                bresult.HeaderText = "结果";
                bresult.ItemTemplate = template;
                grid[i].Columns.Add(bresult);

                BoundField bmin = new BoundField();
                bmin.DataField = "MINVALUE";
                bmin.HeaderText = "参考值";
                grid[i].Columns.Add(bmin);

                BoundField bmax = new BoundField();
                bmax.DataField = "MAXVALUE";
                grid[i].Columns.Add(bmax);

                grid[i].Columns[5].Visible = true;
                grid[i].DataBind();
                displayvalue(grid[i]);
            }
        }

        protected void displayvalue(GridView GridView1)
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

        void Load_Complete(object sender, EventArgs e)
        {
            
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = (form1.Controls.IndexOf((DropDownList)sender) - 3) / 2 - 1;
            source[index].SelectCommand = "SELECT * FROM TESTITEM WHERE TYPE=" + Convert.ToInt32(droptype[index].SelectedValue);
            //grid[index].DataSource = source[index];
            grid[index].Columns[5].Visible = true;
            grid[index].DataBind();
            displayvalue(grid[index]);
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["HospitalData"].ConnectionString;
            SqlConnection conn = new SqlConnection(strcon);
            conn.Open();
            
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < grid[i].Rows.Count; j++)
                {
                    string tmpr = ((TextBox)(grid[i].Rows[j].Cells[3].Controls[0])).Text.Trim();
                    if ( tmpr!= "")
                    {
                        SqlCommand comm = new SqlCommand("INSERT INTO TESTRESULT VALUES(@FID,@TYPE,@TID,@RESULT)", conn);
                        comm.Parameters.Add("@FID", 1);
                        comm.Parameters.Add("@TYPE", droptype[i].SelectedValue);
                        comm.Parameters.Add("@TID", grid[i].Rows[j].Cells[0].Text);
                        comm.Parameters.Add("@RESULT", tmpr);
                        comm.ExecuteNonQuery();
                    }
                }              
            }
            Response.Redirect("Login.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["HospitalData"].ConnectionString;
            droptype[count] = new DropDownList();
            grid[count] = new GridView();

            form1.Controls.Add(droptype[count]);
            form1.Controls.Add(grid[count]);

            droptype[count].SelectedIndexChanged += new EventHandler(DropDownList1_SelectedIndexChanged);
            droptype[count].AutoPostBack = true;
            droptype[count].DataSourceID = "SqlDataSource1";
            droptype[count].DataValueField = "TYPE";
            droptype[count].DataTextField = "NAME";
            droptype[count].DataBind();

            string[] array = { "TID" };
            grid[count].DataKeyNames = array;
            //SqlDataSource2.SelectCommand = "SELECT * FROM TESTITEM WHERE TYPE=" + Convert.ToInt32(droptype[i].SelectedValue);
            source[count] = new SqlDataSource(strcon, "SELECT * FROM TESTITEM WHERE TYPE=" + Convert.ToInt32(droptype[count].SelectedValue));

            grid[count].DataSource = source[count];
            //grid[count].DataBind();
            grid[count].AutoGenerateColumns = false;
            grid[count].Columns.Clear();

            BoundField bid = new BoundField();
            bid.DataField = "TID";
            bid.HeaderText = "No.";
            grid[count].Columns.Add(bid);

            BoundField bname = new BoundField();
            bname.DataField = "NAME";
            bname.HeaderText = "项目";
            grid[count].Columns.Add(bname);

            BoundField bunit = new BoundField();
            bunit.DataField = "UNIT";
            bunit.HeaderText = "单位";
            grid[count].Columns.Add(bunit);

            TemplateField bresult = new TemplateField();
            TextBoxTemplate template = new TextBoxTemplate();
            bresult.HeaderText = "结果";
            bresult.ItemTemplate = template;
            grid[count].Columns.Add(bresult);

            BoundField bmin = new BoundField();
            bmin.DataField = "MINVALUE";
            bmin.HeaderText = "参考值";
            grid[count].Columns.Add(bmin);

            BoundField bmax = new BoundField();
            bmax.DataField = "MAXVALUE";
            grid[count].Columns.Add(bmax);

            grid[count].Columns[5].Visible = true;
            grid[count].DataBind();
            displayvalue(grid[count++]);
            //grid[count++].DataBind();
        }
    }
}