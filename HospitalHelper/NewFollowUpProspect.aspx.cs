using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data.OleDb;

namespace HospitalHelper
{
    public partial class NewFollowUpProspect : System.Web.UI.Page
    {
        private int pid = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void bNext_Click(object sender, EventArgs e)
        {
            string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["HospitalData"].ConnectionString;
            SqlConnection conn = new SqlConnection(strcon);
            conn.Open();
            SqlCommand comm = new SqlCommand("SELECT MAX(FID) FROM FOLLOWUP", conn);
            comm.ExecuteNonQuery();
            SqlDataReader reader = comm.ExecuteReader();

            int fid;
            if (reader.Read() && !reader.IsDBNull(0)) fid = reader.GetInt32(0)+1;
            else fid = 1;
            reader.Close();

            comm = new SqlCommand("INSERT INTO [FOLLOWUP](FID, FDATE, FDESCRIPTION, FDOCTOR, PID) VALUES (@FID, @FDATE, @FDESCRIPTION, @FDOCTOR, @PID)", conn);
            PickData(comm, fid);
            comm.ExecuteNonQuery();

            string tag = string.Empty;
            int tagid = 0;
            for (int i = 0; i < tTag.Text.Length; ++i)
                if (i < tTag.Text.Length-1 && tTag.Text[i] != ',' && tTag.Text[i] != '，') 
                    if (tag != string.Empty || tTag.Text[i] != ' ') tag = tag + tTag.Text[i];
                else
                {
                    if (i == tTag.Text.Length - 1 && tTag.Text[i] != ',' && tTag.Text[i] != '，') 
                        if (tag != string.Empty || tTag.Text[i] != ' ') tag = tag + tTag.Text[i];
                    if (tag == string.Empty) continue;
                    comm = new SqlCommand("SELECT MAX(TAGID) FROM TAG", conn);
                    comm.ExecuteNonQuery();
                    reader = comm.ExecuteReader();
                    if (reader.Read() && !reader.IsDBNull(0)) tagid = reader.GetInt32(0) + 1;
                    else tagid = 0;
                    reader.Close();
                    comm = new SqlCommand("INSERT INTO [TAG](TAGID, FID, DESCRIPTION) VALUES (@TAGID, @FID, @DESCRIPTION)", conn);
                    PickTagData(comm, tagid, fid, tag);
                    comm.ExecuteNonQuery();
                    tag = string.Empty;
                }

            conn.Close();
            Response.Redirect("NewFollowUpTest.aspx");
        }

        private void PickTagData(SqlCommand comm, int tagid, int fid, string tag)
        {
            comm.Parameters.Add("@TAGID", tagid);
            comm.Parameters.Add("@FID", fid);
            comm.Parameters.Add("@DESCRIPTION", tag);
        }

        private void PickData(SqlCommand comm, int fid)
        {
            comm.Parameters.Add("@FID", fid);
            comm.Parameters.Add("@FDATE", tTime.Text);
            comm.Parameters.Add("@FDESCRIPTION", tDescription.Text);
            comm.Parameters.Add("@FDOCTOR", tDoctor.Text);
            comm.Parameters.Add("@PID", pid.ToString());
        }
    }
}