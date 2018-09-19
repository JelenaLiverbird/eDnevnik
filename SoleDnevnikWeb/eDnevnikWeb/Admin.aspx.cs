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
            if (!IsPostBack)
            {
                btnDelete.Enabled = false;
            }
            
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            hfProfesorID.Value = "";
            txtImeProfesora.Text = txtEmail.Text = txtKontaktTelefon.Text = txtLoginSifra.Text = txtBrojOdeljenja.Text = txtGodinaSkolovanja.Text = txtNazivPredmeta.Text = txtSkolskaGodina.Text = "";
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
            prof.NazivPredmeta = txtNazivPredmeta.Text;
            prof.BrojOdeljenja = Int32.Parse(txtBrojOdeljenja.Text);
            prof.GodinaSkolovanja = Int32.Parse(txtGodinaSkolovanja.Text);
            prof.SkolskaGodina = Int32.Parse(txtSkolskaGodina.Text);

            VezaSBazom.DodavanjeProfesora(prof);

            
        }
    }
}