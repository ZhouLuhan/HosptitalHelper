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
    public class TextBoxTemplate : ITemplate
    {
        public TextBoxTemplate() { }

        public void InstantiateIn(System.Web.UI.Control container)
        {
            TextBox textbox = new TextBox();
            container.Controls.Add(textbox);
        }
    }
}