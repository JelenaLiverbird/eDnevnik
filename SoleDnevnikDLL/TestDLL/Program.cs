using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnikDLL
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test professor
           /* Profesor prof = new Profesor();
            prof.ImeProfesora = "Le"; //Data anotacija treba da ga izbaci
            prof.Email = "nindza@kornjaca.com";
            Console.WriteLine(VezaSBazom.DodavanjeProfesora(prof));
            Console.ReadKey();*/

            int vracenID = -1;
            string maticniID = "";

            Console.WriteLine(VezaSBazom.LoginKorisnika("Em1", "neki hash", ref vracenID , ref maticniID ));
            Console.WriteLine(vracenID);
            Console.WriteLine(maticniID);
            Console.ReadKey();





        }
    }
}
