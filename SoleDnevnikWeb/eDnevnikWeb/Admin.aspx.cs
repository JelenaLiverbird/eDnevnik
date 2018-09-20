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
        
            
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnDelete.Enabled = false;
                FillGridView();
            }

            
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection("server=.;integrated security=true;database=eDnevnik");
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("dbo.profesoriDELETE", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@ProfesorID", Convert.ToInt32(hfProfesorID.Value));
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            Clear();
            FillGridView();
            lblSuccessMessage.Text = "Успешно избрисано!";
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
            SqlConnection sqlCon = new SqlConnection("server=.;integrated security=true;database=eDnevnik");
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("ProfesorINSERTOrUPDATE", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            string ProfesorID = hfProfesorID.Value;
            sqlCmd.Parameters.AddWithValue("@ProfesorID", (hfProfesorID.Value == "" ? 0 : Convert.ToInt32(hfProfesorID.Value)));
            sqlCmd.Parameters.AddWithValue("@ImeProfesora", txtImeProfesora.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@KontaktTelefon", txtKontaktTelefon.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@LoginSifra", txtLoginSifra.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@NazivPredmeta", ddPredmeti.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@BrojOdeljenja", Int32.Parse(txtBrojOdeljenja.Text));
            sqlCmd.Parameters.AddWithValue("@GodinaSkolovanja", Int32.Parse(txtGodinaSkolovanja.Text));
            sqlCmd.Parameters.AddWithValue("@SkolskaGodina", Int32.Parse(txtSkolskaGodina.Text));
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();

            //Profesor prof = new Profesor();

            //prof.ImeProfesora = txtImeProfesora.Text;
            //prof.Email = txtEmail.Text;
            //prof.KontaktTelefon = txtKontaktTelefon.Text;
            //prof.LoginSifra = txtLoginSifra.Text;
            //prof.NazivPredmeta = ddPredmeti.Text;
            //prof.BrojOdeljenja = Int32.Parse(txtBrojOdeljenja.Text);
            //prof.GodinaSkolovanja = Int32.Parse(txtGodinaSkolovanja.Text);
            //prof.SkolskaGodina = Int32.Parse(txtSkolskaGodina.Text);
            //VezaSBazom.DodavanjeIIzmenaProfesora(prof);
            Clear();
            if (ProfesorID == "")
                lblSuccessMessage.Text = "Успешно сачувано!";
            else
                lblSuccessMessage.Text = "Успешно измењено!";
            FillGridView();

            //    Profesor prof = new Profesor();

            //    VezaSBazom.DodavanjeProfesora(prof);

            //    Clear();
            //}

        }
        void FillGridView()
        {
            SqlConnection sqlCon = new SqlConnection("server=.;integrated security=true;database=eDnevnik");
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("dbo.PrikazProfesora", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            gvProfesori.DataSource = dtbl;
            gvProfesori.DataBind();

        }

        protected void lnk_OnClick(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection("server=.;integrated security=true;database=eDnevnik");
            int ProfesorID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("dbo.PrikazProfesoraPoID", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@ProfesorID", ProfesorID);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            
            hfProfesorID.Value = ProfesorID.ToString();
            txtImeProfesora.Text = dtbl.Rows[0]["ImeProfesora"].ToString();
            txtEmail.Text = dtbl.Rows[0]["Email"].ToString();
            txtKontaktTelefon.Text = dtbl.Rows[0]["KontaktTelefon"].ToString();
            txtLoginSifra.Text = dtbl.Rows[0]["LoginSifra"].ToString();
            ddPredmeti.Text = dtbl.Rows[0]["NazivPredmeta"].ToString();
            txtBrojOdeljenja.Text = dtbl.Rows[0]["BrojOdeljenja"].ToString();
            txtGodinaSkolovanja.Text = dtbl.Rows[0]["GodinaSkolovanja"].ToString();
            txtSkolskaGodina.Text = dtbl.Rows[0]["SkolskaGodina"].ToString();
            btnSave.Text = "Update";
            btnDelete.Enabled = true;

            
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}