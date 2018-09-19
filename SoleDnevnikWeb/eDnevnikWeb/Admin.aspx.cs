using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eDnevnikDLL;

namespace eDnevnikWeb
{
    public partial class eDnevnik : System.Web.UI.Page
    {
        //SqlConnection sqlCon = new SqlConnection("server=.;integrated security=true;database=eDnevnik");
        
            
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //if (Session["Korisnik"] == null)
            //{
            //    Response.Redirect("Login.aspx");
            //}
            //else
            //{
                
            //    DataTable Dt;

                
            //    Dt = eDnevnikDLL.VezaSBazom.PrikazProfesora();
                              
            //    gvProfesori.DataSource = Dt;
            //    gvProfesori.DataBind();
            //}
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            
        }
        public void Clear()
        {
            hfProfesorID.Value = "";
            txtImeProfesora.Text = txtEmail.Text = txtKontaktTelefon.Text = txtLoginSifra.Text = txtBrojOdeljenja.Text = txtGodinaSkolovanja.Text = txtSkolskaGodina.Text = "";
            lblSuccessMessage.Text = lblErrorMessage.Text = "";
            btnSave.Text = "Save";
            btnDelete.Enabled = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Profesor prof = new Profesor();
            prof.ImeProfesora = txtImeProfesora.Text;
            prof.Email = txtEmail.Text;
            prof.KontaktTelefon = txtKontaktTelefon.Text;
            prof.LoginSifra = txtLoginSifra.Text;
            prof.NazivPredmeta = ddPredmeti.Text;
            prof.BrojOdeljenja = Int32.Parse(txtBrojOdeljenja.Text);
            prof.GodinaSkolovanja = Int32.Parse(txtGodinaSkolovanja.Text);
            prof.SkolskaGodina = Int32.Parse(txtSkolskaGodina.Text);

            VezaSBazom.DodavanjeProfesora(prof);

            Clear();
        }

        protected void lnk_OnClick(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"server=.;integrated security=true;database=eDnevnik");
            int profesorID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("dbo.profesoriUPDATE", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@ProfesorID", profesorID);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            

            hfProfesorID.Value = profesorID.ToString();
            txtImeProfesora.Text = dtbl.Rows[0]["ImeProfesora"].ToString();
            txtEmail.Text = dtbl.Rows[0]["Email"].ToString();
            txtKontaktTelefon.Text = dtbl.Rows[0]["KontaktTelefon"].ToString();
            txtLoginSifra.Text = dtbl.Rows[0]["LoginSifra"].ToString();
            btnSave.Text = "Update";
            btnDelete.Enabled = true;
            
        }
    }
}