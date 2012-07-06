using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data.Sql;
using System.Data.SqlClient;

namespace HospitalHelper
{
    public partial class NewPatient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Tpid.Attributes.Add("onkeypress", "if(event.keyCode==13){document.all.Button1.Click();return false;}"); 


            if (Request.QueryString["PID"] != null)
            {
                string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["HospitalData"].ConnectionString;
                SqlConnection conn = new SqlConnection(strcon);
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT * FROM PATIENT WHERE PID=@PID", conn);
                comm.Parameters.Add("@PID", Request.QueryString["PID"]);
                comm.ExecuteNonQuery();
                SqlDataReader reader = comm.ExecuteReader();
                reader.Read();
                DisplayPatient(reader);
                conn.Close();
            }
        }

        protected void Bsave_Click(object sender, EventArgs e)
        {
            string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["HospitalData"].ConnectionString;
            SqlConnection conn = new SqlConnection(strcon);
            conn.Open();
            SqlCommand comm = new SqlCommand("SELECT PID FROM PATIENT WHERE PID=@PID", conn);
            comm.Parameters.Add("@PID", Tpid.Text);
            comm.ExecuteNonQuery();
            SqlDataReader reader = comm.ExecuteReader();


            if (reader.HasRows)//update
            {
                reader.Close();
                comm = new SqlCommand("UPDATE [PATIENT] SET [PNAME] = @PNAME, [PMARRIAGE] = @PMARRIAGE, [PFOLK] = @PFOLK, [PNATION] = @PNATION, [PBIRTHDAY] = @PBIRTHDAY, [PSEX] = @PSEX, [PRELIGE] = @PRELIGE, [PDEGREE] = @PDEGREE, [PEDUCATION] = @PEDUCATION, [PBIRTHCITY] = @PBIRTHCITY, [PBIRTHDISTRICT] = @PBIRTHDISTRICT, [PNATIVECITY] = @PNATIVECITY, [PNATIVEDISTRICT] = @PNATIVEDISTRICT, [PPROPERTY] = @PPROPERTY, [PFEETYPE] = @PFEETYPE, [PCARDNUM] = @PCARDNUM, [PJOB] = @PJOB, [PWORKUNIT] = @PWORKUNIT, [PWORKPLACE] = @PWORKPLACE, [PWORKTEL] = @PWORKTEL, [PWORKPOST] = @PWORKPOST, [PRESIDENCEPLACE] = @PRESIDENCEPLACE, [PHOMETEL] = @PHOMETEL, [PHOMECITY] = @PHOMECITY, [PHOMEDISTRICT] = @PHOMEDISTRICT, [PHOMEPLACE] = @PHOMEPLACE, [PCONNAME] = @PCONNAME, [PCONRELATION] = @PCONRELATION, [PCONPLACE] = @PCONPLACE, [PCONTEL] = @PCONTEL, [PCONPOST] = @PCONPOST, [PCONWORKUNIT] = @PCONWORKUNIT, [PCONHISTORYPEO] = @PCONHISTORYPEO, [PCOMMENT] = @PCOMMENT, [PHOMEPOST] = @PHOMEPOST WHERE [PID] = @PID", conn);
            }
            else //insert
            {
                reader.Close();
                comm = new SqlCommand("INSERT INTO [PATIENT] ([PID], [PNAME], [PMARRIAGE], [PFOLK], [PNATION], [PBIRTHDAY],[PSEX], [PRELIGE], [PDEGREE], [PEDUCATION], [PBIRTHCITY], [PBIRTHDISTRICT], [PNATIVECITY], [PNATIVEDISTRICT], [PPROPERTY], [PFEETYPE], [PCARDNUM], [PJOB], [PWORKUNIT], [PWORKPLACE], [PWORKTEL], [PWORKPOST], [PRESIDENCEPLACE], [PHOMETEL], [PHOMECITY], [PHOMEDISTRICT], [PHOMEPLACE], [PCONNAME], [PCONRELATION], [PCONPLACE], [PCONTEL], [PCONPOST], [PCONWORKUNIT], [PCONHISTORYPEO], [PCOMMENT], [PHOMEPOST]) VALUES (@PID, @PNAME, @PMARRIAGE, @PFOLK, @PNATION, @PBIRTHDAY, @PSEX, @PRELIGE, @PDEGREE, @PEDUCATION, @PBIRTHCITY, @PBIRTHDISTRICT, @PNATIVECITY, @PNATIVEDISTRICT, @PPROPERTY, @PFEETYPE, @PCARDNUM, @PJOB, @PWORKUNIT, @PWORKPLACE, @PWORKTEL, @PWORKPOST, @PRESIDENCEPLACE, @PHOMETEL, @PHOMECITY, @PHOMEDISTRICT, @PHOMEPLACE, @PCONNAME, @PCONRELATION, @PCONPLACE, @PCONTEL, @PCONPOST, @PCONWORKUNIT, @PCONHISTORYPEO, @PCOMMENT, @PHOMEPOST)", conn);               
            }
            PickPatient(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("FindPatient.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           // Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "info", "alert('yeah!')", true);
            string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["HospitalData"].ConnectionString;
            SqlConnection conn = new SqlConnection(strcon);
            conn.Open();

            SqlCommand comm = new SqlCommand("SELECT * FROM PATIENT WHERE PID=@PID", conn);
            comm.Parameters.Add("@PID", Tpid.Text.Trim());
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                DisplayPatient(reader);
            }
            conn.Close();
        }

        private void DisplayPatient(SqlDataReader reader)
        {
            if (!reader.IsDBNull(1)) Tpname.Text = reader.GetString(1);
            if (!reader.IsDBNull(2)) Tpmarriage.Text = reader.GetString(2);
            if (!reader.IsDBNull(3)) Tpfolk.Text = reader.GetString(3);
            if (!reader.IsDBNull(4)) Tpnation.Text = reader.GetString(4);
            if (!reader.IsDBNull(5))
            {
                DateTime time = reader.GetSqlDateTime(5).Value;
                Tpbirthday.Text = time.ToShortDateString();
                Tpbirthtime.Text = time.ToShortTimeString();
                Tpold.Text = (DateTime.Now.Year - time.Year - ((DateTime.Now.Month < time.Month || (DateTime.Now.Month == time.Month && DateTime.Now.Day < time.Day)) ? 1 : 0)).ToString();
            }
            if (!reader.IsDBNull(6)) Tsex.Text = reader.GetString(6);
            if (!reader.IsDBNull(7)) Tprelige.Text = reader.GetString(7);
            if (!reader.IsDBNull(8)) Tpdgree.Text = reader.GetString(8);
            if (!reader.IsDBNull(9)) Tpeducation.Text = reader.GetString(9);
            if (!reader.IsDBNull(10)) Tpbirthcity.Text = reader.GetString(10);
            if (!reader.IsDBNull(11)) Tpbirthdistrict.Text = reader.GetString(11);
            if (!reader.IsDBNull(12)) Tpnativecity.Text = reader.GetString(12);
            if (!reader.IsDBNull(13)) Tpnativedistrict.Text = reader.GetString(13);
            if (!reader.IsDBNull(14)) Tpproperty.Text = reader.GetString(14);
            if (!reader.IsDBNull(15)) Tpfeetype.Text = reader.GetString(15);
            if (!reader.IsDBNull(16)) Tpcardnum.Text = reader.GetString(16);
            if (!reader.IsDBNull(17)) Tpjob.Text = reader.GetString(17);
            if (!reader.IsDBNull(18)) Tpworkunit.Text = reader.GetString(18);
            if (!reader.IsDBNull(19)) Tpworkplace.Text = reader.GetString(19);
            if (!reader.IsDBNull(20)) Tpworktel.Text = reader.GetString(20);
            if (!reader.IsDBNull(21)) Tpworkpost.Text = reader.GetString(21);
            if (!reader.IsDBNull(22)) Tpresidenceplace.Text = reader.GetString(22);
            if (!reader.IsDBNull(23)) Tphometel.Text = reader.GetString(23);
            if (!reader.IsDBNull(24)) Tphomecity.Text = reader.GetString(24);
            if (!reader.IsDBNull(25)) Tphomedistrict.Text = reader.GetString(25);
            if (!reader.IsDBNull(26)) Tphomeplace.Text = reader.GetString(26);
            if (!reader.IsDBNull(27)) Tpconname.Text = reader.GetString(27);
            if (!reader.IsDBNull(28)) Tpconrelation.Text = reader.GetString(28);
            if (!reader.IsDBNull(29)) Tpconplace.Text = reader.GetString(29);
            if (!reader.IsDBNull(30)) Tpcontel.Text = reader.GetString(30);
            if (!reader.IsDBNull(31)) Tpconpost.Text = reader.GetString(31);
            if (!reader.IsDBNull(32)) Tpconworkunit.Text = reader.GetString(32);
            if (!reader.IsDBNull(33)) Tphistorypeo.Text = reader.GetString(33);
            if (!reader.IsDBNull(34)) Tpcomment.Text = reader.GetString(34);
            if (!reader.IsDBNull(35)) Tphomepost.Text = reader.GetString(35);
            Tpid.Text = reader.GetString(0);
        }

        private void PickPatient(SqlCommand comm)
        {
            comm.Parameters.Add("@PID", Tpid.Text);
            comm.Parameters.Add("@PNAME", Tpname.Text);
            comm.Parameters.Add("@PMARRIAGE", Tpmarriage.Text);
            comm.Parameters.Add("@PFOLK", Tpfolk.Text);
            comm.Parameters.Add("@PNATION", Tpnation.Text);
            comm.Parameters.Add("@PBIRTHDAY", Tpbirthday.Text + " " + Tpbirthtime.Text);
            comm.Parameters.Add("@PSEX", Tsex.Text);
            comm.Parameters.Add("@PRELIGE", Tprelige.Text);
            comm.Parameters.Add("@PDEGREE", Tpdgree.Text);
            comm.Parameters.Add("@PEDUCATION", Tpeducation.Text);
            comm.Parameters.Add("@PBIRTHCITY", Tpbirthcity.Text);
            comm.Parameters.Add("@PBIRTHDISTRICT", Tpbirthdistrict.Text);
            comm.Parameters.Add("@PNATIVECITY", Tpnativecity.Text);
            comm.Parameters.Add("@PNATIVEDISTRICT", Tpnativedistrict.Text);
            comm.Parameters.Add("@PPROPERTY", Tpproperty.Text);
            comm.Parameters.Add("@PFEETYPE", Tpfeetype.Text);
            comm.Parameters.Add("@PCARDNUM", Tpcardnum.Text);
            comm.Parameters.Add("@PJOB", Tpjob.Text);
            comm.Parameters.Add("@PWORKUNIT", Tpworkunit.Text);
            comm.Parameters.Add("@PWORKPLACE", Tpworkplace.Text);
            comm.Parameters.Add("@PWORKTEL", Tpworktel.Text);
            comm.Parameters.Add("@PWORKPOST", Tpworkpost.Text);
            comm.Parameters.Add("@PRESIDENCEPLACE", Tpresidenceplace.Text);
            comm.Parameters.Add("@PHOMETEL", Tphometel.Text);
            comm.Parameters.Add("@PHOMECITY", Tphomecity.Text);
            comm.Parameters.Add("@PHOMEDISTRICT", Tphomedistrict.Text);
            comm.Parameters.Add("PHOMEPLACE", Tphomeplace.Text);
            comm.Parameters.Add("@PCONNAME", Tpconname.Text);
            comm.Parameters.Add("@PCONRELATION", Tpconrelation.Text);
            comm.Parameters.Add("@PCONPLACE", Tpconplace.Text);
            comm.Parameters.Add("@PCONTEL", Tpcontel.Text);
            comm.Parameters.Add("@PCONPOST", Tpconpost.Text);
            comm.Parameters.Add("@PCONWORKUNIT", Tpconworkunit.Text);
            comm.Parameters.Add("@PCONHISTORYPEO", Tphistorypeo.Text);
            comm.Parameters.Add("@PCOMMENT", Tpcomment.Text);
            comm.Parameters.Add("@PHOMEPOST", Tphomepost.Text);
        }
    }
}