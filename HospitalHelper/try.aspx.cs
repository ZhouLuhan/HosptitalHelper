using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalHelper
{
    public partial class _try : System.Web.UI.Page
    {
        TextBox textbox1, textbox2, textbox3;
        DropDownList drop;
        static int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            textbox1 = new TextBox();
            textbox2 = new TextBox();
            textbox3 = new TextBox();
            d1.Controls.Add(textbox1);
            if (count > 0) d1.Controls.Add(textbox3);
            d2.Controls.Add(textbox2);
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            int i;
            if (count == 0) d1.Controls.Add(textbox3);
            count++;
        }
    }
}