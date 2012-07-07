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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DropDownList droptype = new DropDownList();
            droptype.DataSourceID = "SqlDataSource1";
            droptype.DataValueField = "TYPE";
            droptype.DataTextField = "NAME";

            GridView grid = new GridView();
            grid.DataSourceID = "SqlDataSource2";
            string[] array = {"FID","TYPE","TID"};
            grid.DataKeyNames = array;

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

            BoundField bresult = new BoundField();
            bresult.DataField = "RESULT";
            bresult.HeaderText = "结果";
            grid.Columns.Add(bresult);

            form1.Controls.Add(droptype);
            form1.Controls.Add(grid);
        }
    }
}