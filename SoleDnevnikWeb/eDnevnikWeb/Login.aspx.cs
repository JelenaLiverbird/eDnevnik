using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eDnevnikDLL;

namespace eDnevnikWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            string Korisnik = txtKorisnik.Text;
            string Sifra = txtPassword.Text;
            int whoID = 0;
            int who = 0;

            //VezaSBazom.LoginKorisnika(Email, Sifra);
            int Ret = VezaSBazom.LoginKorisnika(Korisnik, Sifra, ref who, ref whoID);

            if (Ret == 0)
            {
                Session["Korisnik"] = Korisnik;
                if (who == 3)
                {
                    Response.Redirect("Admin.aspx");
                }
                else if (who == 2)
                {
                    Response.Redirect("Profesori.aspx");
                }
                else if (who == 1)
                {
                    Response.Redirect("Ucenik.aspx");
                }

            }
            else if (Ret == -1)
            {
                LblInfo.Text = "Korisnik ne postoji";

            }
            else
            {
                LblInfo.Text = "Greska " + Ret.ToString();
            }

            
        }
    }
}