using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace eDnevnikDLL
{
    public static class VezaSBazom
    {
        static SqlConnection Cn = new SqlConnection("server=.;integrated security=true;database=eDnevnik");

        #region ProfesorCRUD
        public static int DodavanjeProfesora(Profesor dodati) //Da li ce mo da vracamo i poruku ili ne???
        {
            //Validate first
            var responseFromValidator = Check.DataAnnotation.ValidateEntity<Profesor>(dodati);
            if (responseFromValidator.HasError)
            {
                /*foreach (var error in responseFromValidator.ValidationErrors)
                {
                    whatError = whatError + error + System.Environment.NewLine;           <<< ???
                }*/
                return 99;
            }


            try
            {
                SqlCommand Cm = new SqlCommand();
                Cm.Connection = Cn;
                Cm.CommandType = CommandType.StoredProcedure;
                Cm.CommandText = "dbo.profesoriINSERT";

                int Ret = 99;
              
                Cm.Parameters.Add(new SqlParameter("@ImeProfesora", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, dodati.ImeProfesora));
                Cm.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, dodati.Email));
                Cm.Parameters.Add(new SqlParameter("@KontaktTelefon", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, dodati.KontaktTelefon));
                Cm.Parameters.Add(new SqlParameter("@LoginSifra", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, dodati.LoginSifra));
                Cm.Parameters.Add(new SqlParameter("@Admin", SqlDbType.Bit, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, dodati.Admin));
                Cm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, Ret));

                Cn.Open();
                Cm.ExecuteNonQuery();
                Cn.Close();

                Ret = (int)Cm.Parameters["@RETURN_VALUE"].Value;
                return Ret;
                
            }
            catch (Exception ex)
            {
                return 99;
            }
        }
        
        public static int IzmenaProfesora(Profesor izmeniti)
        {
            try
            {
                SqlCommand Cm = new SqlCommand();
                Cm.Connection = Cn;
                Cm.CommandType = CommandType.StoredProcedure;
                Cm.CommandText = "dbo.profesoriUPDATE";

                int Ret = 99;

                Cm.Parameters.Add(new SqlParameter("@ImeProfesora", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, izmeniti.ImeProfesora));
                Cm.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, izmeniti.Email));
                Cm.Parameters.Add(new SqlParameter("@KontaktTelefon", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, izmeniti.KontaktTelefon));
                Cm.Parameters.Add(new SqlParameter("@LoginSifra", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, izmeniti.LoginSifra));
                Cm.Parameters.Add(new SqlParameter("@Admin", SqlDbType.Bit, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, izmeniti.Admin));
                Cm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, Ret));

                Cn.Open();
                Cm.ExecuteNonQuery();
                Cn.Close();


                Ret = (int)Cm.Parameters["@RETURN_VALUE"].Value;
                return Ret;

            }
            catch (Exception ex)
            {
                return 99;
            }
        }


        public static int BrisanjeProfesora(Profesor izbrisati)
        {
            try
            {
                SqlCommand Cm = new SqlCommand();
                Cm.Connection = Cn;
                Cm.CommandType = CommandType.StoredProcedure;
                Cm.CommandText = "dbo.profesoriDELETE";

                int Ret = 99;

                Cm.Parameters.Add(new SqlParameter("@ProfesorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, izbrisati.ProfesorID));
                Cm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, Ret));

                Cn.Open();
                Cm.ExecuteNonQuery();
                Cn.Close();


                Ret = (int)Cm.Parameters["@RETURN_VALUE"].Value;
                return Ret;

            }
            catch (Exception ex)
            {
                return 99;
            }
        }
        #endregion

        #region OdeljenjeCRUD
        public static int DodavanjeOdeljenja(Odeljenja dodati)
        {
            try
            {
                SqlCommand Cm = new SqlCommand();
                Cm.Connection = Cn;
                Cm.CommandType = CommandType.StoredProcedure;
                Cm.CommandText = "dbo.odeljenjaUPDATE";

                int Ret = 99;

                Cm.Parameters.Add(new SqlParameter("@OdeljenjeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, dodati.OdeljenjeID));
                Cm.Parameters.Add(new SqlParameter("@RazredniID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, dodati.RazredniID));
                Cm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, Ret));

                Cn.Open();
                Cm.ExecuteNonQuery();
                Cn.Close();

                Ret = (int)Cm.Parameters["@RETURN_VALUE"].Value;
                return Ret;

            }
            catch (Exception ex)
            {
                return 99;
            }
        }

        public static int SelektovanjeOdeljenja(Odeljenja select, int BrojPoStrani, int TrenutnaStrana)
        {
            try
            {
                SqlCommand Cm = new SqlCommand();
                Cm.Connection = Cn;
                Cm.CommandType = CommandType.StoredProcedure;
                Cm.CommandText = "dbo.odeljenjaSELECT";

                int Ret = 99;
                //@BrojPoStrani int = 20, @TrenutnaStrana int, @BrojOdeljenja int, @GodinaSkolovanja int, @SkolskaGodina int = year
                Cm.Parameters.Add(new SqlParameter("@BrojPoStrani", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, BrojPoStrani));
                Cm.Parameters.Add(new SqlParameter("@TrenutnaStrana", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, TrenutnaStrana));
                Cm.Parameters.Add(new SqlParameter("@BrojOdeljenja", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, select.BrojOdeljenja));
                Cm.Parameters.Add(new SqlParameter("@GodinaSkolovanja", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, select.RazredniID));
                Cm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, Ret));

                Cn.Open();
                Cm.ExecuteNonQuery();
                Cn.Close();

                Ret = (int)Cm.Parameters["@RETURN_VALUE"].Value;
                return Ret;

            }
            catch (Exception ex)
            {
                return 99;
            }
        }
        #endregion

        #region OceneCRUD
        public static int DodavanjeOcena(Ocena dodati)
        {
            try
            {
                SqlCommand Cm = new SqlCommand();
                Cm.Connection = Cn;
                Cm.CommandType = CommandType.StoredProcedure;
                Cm.CommandText = "dbo.OceneINSERT";

                int Ret = 99;
       
                Cm.Parameters.Add(new SqlParameter("@TipOcene", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, dodati.TipOcene));
                Cm.Parameters.Add(new SqlParameter("@Ocena", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, dodati.OcenaVrednost));
                Cm.Parameters.Add(new SqlParameter("@OpisOcene", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, dodati.OpisOcene));
                Cm.Parameters.Add(new SqlParameter("@MaticniBroj", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, dodati.MaticniBroj));
                Cm.Parameters.Add(new SqlParameter("@ProfesorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, dodati.ProfesorID));
                Cm.Parameters.Add(new SqlParameter("@PredmetID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, dodati.PredmetID));
                Cm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, Ret));

                Cn.Open();
                Cm.ExecuteNonQuery();
                Cn.Close();

                Ret = (int)Cm.Parameters["@RETURN_VALUE"].Value;
                return Ret;

            }
            catch (Exception ex)
            {
                return 99;
            }
        }

        public static int IzmenaOcena(Ocena izmeniti)
        {
            try
            {
                SqlCommand Cm = new SqlCommand();
                Cm.Connection = Cn;
                Cm.CommandType = CommandType.StoredProcedure;
                Cm.CommandText = "dbo.OceneUPDATE";

                int Ret = 99;

                Cm.Parameters.Add(new SqlParameter("@OcenaID", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, izmeniti.OcenaID));
                Cm.Parameters.Add(new SqlParameter("@TipOcene", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, izmeniti.TipOcene));
                Cm.Parameters.Add(new SqlParameter("@Ocena", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, izmeniti.OcenaVrednost));
                Cm.Parameters.Add(new SqlParameter("@OpisOcene", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, izmeniti.OpisOcene));
                Cm.Parameters.Add(new SqlParameter("@MaticniBroj", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, izmeniti.MaticniBroj));
                Cm.Parameters.Add(new SqlParameter("@ProfesorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, izmeniti.ProfesorID));
                Cm.Parameters.Add(new SqlParameter("@PredmetID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, izmeniti.PredmetID));
                Cm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, Ret));

                Cn.Open();
                Cm.ExecuteNonQuery();
                Cn.Close();

                Ret = (int)Cm.Parameters["@RETURN_VALUE"].Value;
                return Ret;

            }
            catch (Exception ex)
            {
                return 99;
            }
        }

        public static int BrisanjeOcena(Ocena izbrisati)
        {
            try
            {
                SqlCommand Cm = new SqlCommand();
                Cm.Connection = Cn;
                Cm.CommandType = CommandType.StoredProcedure;
                Cm.CommandText = "dbo.oceneDELETE";

                int Ret = 99;

                Cm.Parameters.Add(new SqlParameter("@OcenaID", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, izbrisati.OcenaID));
                Cm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, Ret));

                Cn.Open();
                Cm.ExecuteNonQuery();
                Cn.Close();


                Ret = (int)Cm.Parameters["@RETURN_VALUE"].Value;
                return Ret;

            }
            catch (Exception ex)
            {
                return 99;
            }
        }
        #endregion

        #region UceniciCRUD

        public static int DodavanjeUcenika(Ucenik dodati)
        {
            try
            {
                SqlCommand Cm = new SqlCommand();
                Cm.Connection = Cn;
                Cm.CommandType = CommandType.StoredProcedure;
                Cm.CommandText = "dbo.uceniciINSERT";

                int Ret = 99;
                Cm.Parameters.Add(new SqlParameter("@MaticniBroj", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, dodati.MaticniBroj));
                Cm.Parameters.Add(new SqlParameter("@Ime", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, dodati.Ime));
                Cm.Parameters.Add(new SqlParameter("@Prezime", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, dodati.Prezime));
                Cm.Parameters.Add(new SqlParameter("@JMBG", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, dodati.JMBG));
                Cm.Parameters.Add(new SqlParameter("@OdeljenjeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, dodati.OdeljenjeID));
                Cm.Parameters.Add(new SqlParameter("@DatumRodjenja", SqlDbType.Date, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, dodati.DatumRodjenja));
                Cm.Parameters.Add(new SqlParameter("@MestoRodjenja", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, dodati.MestoRodjenja));
                Cm.Parameters.Add(new SqlParameter("@OpstinaRodjenja", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, dodati.OpstinaRodjenja));
                Cm.Parameters.Add(new SqlParameter("@DrzavaRodjenja", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, dodati.DrzavaRodjenja));
                Cm.Parameters.Add(new SqlParameter("@KontaktTelefonUcenika", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, dodati.KontaktTelefonUcenika));
                Cm.Parameters.Add(new SqlParameter("@EmailUcenika", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, dodati.EmailUcenika));
                Cm.Parameters.Add(new SqlParameter("@ImeOca", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, dodati.ImeOca));
                Cm.Parameters.Add(new SqlParameter("@PrezimeOca", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, dodati.PrezimeOca));
                Cm.Parameters.Add(new SqlParameter("@KontaktTelefonOca", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, dodati.KontaktTelefonOca));
                Cm.Parameters.Add(new SqlParameter("@EmailOca", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, dodati.EmailOca));
                Cm.Parameters.Add(new SqlParameter("@ImeMajke", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, dodati.ImeMajke));
                Cm.Parameters.Add(new SqlParameter("@PrezimeMajke", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, dodati.PrezimeMajke));
                Cm.Parameters.Add(new SqlParameter("@KontaktTelefonMajke", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, dodati.KontaktTelefonMajke));
                Cm.Parameters.Add(new SqlParameter("@EmailMajke", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, dodati.EmailMajke));
                Cm.Parameters.Add(new SqlParameter("@LoginSifra", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, dodati.LoginSifra));
                Cm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, Ret));

                Cn.Open();
                Cm.ExecuteNonQuery();
                Cn.Close();

                Ret = (int)Cm.Parameters["@RETURN_VALUE"].Value;
                return Ret;

            }
            catch (Exception ex)
            {
                return 99;
            }
        }
        public static int IzmenaUcenika(Ucenik izmeniti)
        {
            try
            {
                SqlCommand Cm = new SqlCommand();
                Cm.Connection = Cn;
                Cm.CommandType = CommandType.StoredProcedure;
                Cm.CommandText = "dbo.uceniciUPDATE";

                int Ret = 99;
                Cm.Parameters.Add(new SqlParameter("@MaticniBroj", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, izmeniti.MaticniBroj));
                Cm.Parameters.Add(new SqlParameter("@Ime", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, izmeniti.Ime));
                Cm.Parameters.Add(new SqlParameter("@Prezime", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, izmeniti.Prezime));
                Cm.Parameters.Add(new SqlParameter("@JMBG", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, izmeniti.JMBG));
                Cm.Parameters.Add(new SqlParameter("@OdeljenjeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, izmeniti.OdeljenjeID));
                Cm.Parameters.Add(new SqlParameter("@DatumRodjenja", SqlDbType.Date, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, izmeniti.DatumRodjenja));
                Cm.Parameters.Add(new SqlParameter("@MestoRodjenja", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, izmeniti.MestoRodjenja));
                Cm.Parameters.Add(new SqlParameter("@OpstinaRodjenja", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, izmeniti.OpstinaRodjenja));
                Cm.Parameters.Add(new SqlParameter("@DrzavaRodjenja", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, izmeniti.DrzavaRodjenja));
                Cm.Parameters.Add(new SqlParameter("@KontaktTelefonUcenika", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, izmeniti.KontaktTelefonUcenika));
                Cm.Parameters.Add(new SqlParameter("@EmailUcenika", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, izmeniti.EmailUcenika));
                Cm.Parameters.Add(new SqlParameter("@ImeOca", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, izmeniti.ImeOca));
                Cm.Parameters.Add(new SqlParameter("@PrezimeOca", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, izmeniti.PrezimeOca));
                Cm.Parameters.Add(new SqlParameter("@KontaktTelefonOca", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, izmeniti.KontaktTelefonOca));
                Cm.Parameters.Add(new SqlParameter("@EmailOca", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, izmeniti.EmailOca));
                Cm.Parameters.Add(new SqlParameter("@ImeMajke", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, izmeniti.ImeMajke));
                Cm.Parameters.Add(new SqlParameter("@PrezimeMajke", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, izmeniti.PrezimeMajke));
                Cm.Parameters.Add(new SqlParameter("@KontaktTelefonMajke", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, izmeniti.KontaktTelefonMajke));
                Cm.Parameters.Add(new SqlParameter("@EmailMajke", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, izmeniti.EmailMajke));
                Cm.Parameters.Add(new SqlParameter("@LoginSifra", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, izmeniti.LoginSifra));
                Cm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, Ret));

                Cn.Open();
                Cm.ExecuteNonQuery();
                Cn.Close();

                Ret = (int)Cm.Parameters["@RETURN_VALUE"].Value;
                return Ret;

            }
            catch (Exception ex)
            {
                return 99;
            }
        }
        #endregion
    }




    public class Profesor
    {
        
        public int ProfesorID { get; set; }
        [MinLength(2)]
        public string ImeProfesora { get; set; }

        public string Email { get; set; }
        public string KontaktTelefon { get; set; }
        public string LoginSifra { get; set; }
        public bool Admin { get; set; }
    }

    public class Odeljenja
    {
        public int OdeljenjeID { get; set; }
        public int BrojOdeljenja { get; set; }
        public int GodinaID { get; set; }
        public int RazredniID { get; set; }
    }

    public class Ocena
    {
        public int OcenaID { get; set; }
        public string TipOcene { get; set; }
        public int OcenaVrednost { get; set; }
        public string OpisOcene { get; set; }
        public string MaticniBroj { get; set; }
        public int ProfesorID { get; set; }
        public int PredmetID { get; set; }
        
    }

    public class Ucenik
    {
        public int MaticniBroj { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string JMBG { get; set; }
        public int OdeljenjeID { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string MestoRodjenja { get; set; }
        public string OpstinaRodjenja { get; set; }
        public string DrzavaRodjenja { get; set; }
        public string KontaktTelefonUcenika { get; set; }
        public string EmailUcenika { get; set; }
        public string ImeOca { get; set; }
        public string PrezimeOca { get; set; }
        public string KontaktTelefonOca { get; set; }
        public string EmailOca { get; set; }
        public string ImeMajke { get; set; }
        public string PrezimeMajke { get; set; }
        public string KontaktTelefonMajke { get; set; }
        public string EmailMajke { get; set; }
        public string LoginSifra { get; set; }
    }
}
