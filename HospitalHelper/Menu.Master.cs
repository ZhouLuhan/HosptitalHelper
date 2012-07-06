using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalHelper
{
    public partial class Menu : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            if (TreeView1.SelectedValue == "帐户管理")
            {
                if (Session["LIM"] == "true") Response.Redirect("OperatorManager.aspx");
                else Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "info", "alert('您无权访问!')", true);
            }
        }

        protected void Blogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}