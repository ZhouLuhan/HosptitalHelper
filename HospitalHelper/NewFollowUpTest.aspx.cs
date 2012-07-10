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
    public partial class NewFollowUpTest : System.Web.UI.Page
    {
        private int fid = 1;
        DropDownList[] droptype = new DropDownList[100];
        GridView[] grid = new GridView[100];
        SqlDataSource[] source = new SqlDataSource[100];
        static int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["HospitalData"].ConnectionString;
            for (int i = 0; i < 100; i++)
            {
                droptype[i] = new DropDownList();
                grid[i] = new GridView();
                
                form1.Controls.Add(droptype[i]);
                form1.Controls.Add(grid[i]);

                if (!IsPostBack)
                {
                    droptype[i].Visible = false;
                    grid[i].Visible = false;
                }

                droptype[i].SelectedIndexChanged += new EventHandler(DropDownList1_SelectedIndexChanged);
                droptype[i].AutoPostBack = true;
                droptype[i].DataSourceID = "SqlDataSource1";
                droptype[i].DataValueField = "TYPE";
                droptype[i].DataTextField = "NAME";
                droptype[i].DataBind();

                string[] array = { "TID" };
                grid[i].DataKeyNames = array;
                //SqlDataSource2.SelectCommand = "SELECT * FROM TESTITEM WHERE TYPE=" + Convert.ToInt32(droptype[i].SelectedValue);
                source[i] = new SqlDataSource(strcon, "SELECT * FROM TESTITEM WHERE TYPE=" + Convert.ToInt32(droptype[i].SelectedValue));

                grid[i].DataSource = source[i];
                grid[i].DataBind();
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

                //BoundField bresult = new BoundField();
                //bresult.HeaderText = "结果";
                //bresult.ReadOnly = false;
                //grid[i].Columns.Add(bresult);
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            int index = (form1.Controls.IndexOf((DropDownList)sender) - 3) / 2 - 1;
            source[index].SelectCommand = "SELECT * FROM TESTITEM WHERE TYPE=" + Convert.ToInt32(droptype[index].SelectedValue);
            grid[index].DataSource = source[index];
            grid[index].DataBind();
            Response.Write(index);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            //droptype = new DropDownList();
            //form1.Controls.Add(droptype);
           
            
            //GridView grid = new GridView();
            //form1.Controls.Add(grid);

            droptype[count].Visible = true;
            grid[count++].Visible = true;
            
            //TemplateField tresult = new TemplateField();
            //tresult.HeaderText = "结果";
            //tresult.ItemTemplate = TextBox as ITemplate;

            //grid.Columns.Add(tresult);


            //Response.Redirect("NewFollowUpTest.aspx");
        }
    }
}