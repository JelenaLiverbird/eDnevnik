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
            Profesor prof = new Profesor();
            prof.ImeProfesora = "Le"; //Data anotacija treba da ga izbaci
            prof.Email = "nindza@kornjaca.com";
            Console.WriteLine(VezaSBazom.DodavanjeProfesora(prof));
            Console.ReadKey();

        }
    }
}
