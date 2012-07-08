using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalHelper
{
    public partial class NewFollowUpTest : System.Web.UI.Page
    {
        private int fid = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GridView1.DataSourceID = "SqlDataSource2";
            //GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DropDownList droptype = new DropDownList();
            droptype.ID = "droptype1";
            form1.Controls.Add(droptype);
            droptype.AutoPostBack = true;
            droptype.DataSourceID = "SqlDataSource1";
            droptype.DataValueField = "TYPE";
            droptype.DataTextField = "NAME";
            droptype.DataBind();
            //droptype.SelectedValue = "1";
            //droptype.SelectedIndexChanged += new EventHandler(DropDownList1_SelectedIndexChanged);

            GridView grid = new GridView();
            form1.Controls.Add(grid);
            string[] array = { "TYPE", "TID" };
            grid.DataKeyNames = array;
            
            SqlDataSource2.SelectCommand = "SELECT * FROM TESTITEM WHERE TYPE=@TYPE";
            //SqlDataSource2.SelectParameters.Add(new QueryStringParameter("@TYPE", droptype.SelectedValue));
            //string str = (SqlDataSource2.SelectParameters["@TYPE"] as QueryStringParameter).QueryStringField;
            SqlDataSource2.SelectParameters.Add(new ControlParameter("TYPE", "droptype1", "SelectedValue"));
            
            BoundField bid = new BoundField();
            bid.DataField = "TID";
            bid.HeaderText = "No.";
            grid.Columns.Add(bid);

            BoundField bname = new BoundField();
            bname.DataField = "NAME";
            bname.HeaderText = "项目";
            grid.Columns.Add(bname);

            BoundField bunit = new BoundField();
            bunit.DataField = "UNIT";
            bunit.HeaderText = "单位";
            grid.Columns.Add(bunit);

            grid.DataSourceID = "SqlDataSource2";
            grid.DataBind();
            //TemplateField tresult = new TemplateField();
            //tresult.HeaderText = "结果";
            //tresult.ItemTemplate = TextBox as ITemplate;

            //grid.Columns.Add(tresult);

            
           
        }
    }
}