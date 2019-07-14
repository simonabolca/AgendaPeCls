using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaPeClase
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("AGENDA");

            Persoana [] contacte  = new Persoana[6];

            contacte[0] = new Persoana();         //instantiaza obiectul
            contacte[0]._nume = "Maria";
            contacte[0]._numarDeTelefon = "0748616319";

            contacte[1] = new Persoana();        
            contacte[1]._nume = "Ana";
            contacte[1]._numarDeTelefon =" 0745678345";

            contacte[2] = new Persoana();
            contacte[2]._nume = "Ioana";
            contacte[2]._numarDeTelefon =" 0745078345";

            contacte[3] = new Persoana();
            contacte[3]._nume = "Rares";
            contacte[3]._numarDeTelefon = "0745612345";

            contacte[4] = new Persoana();
            contacte[4]._nume = "Ovidiu";
            contacte[4]._numarDeTelefon = "0745676387";

            contacte[5] = new Persoana();
            contacte[5]._nume = "Lorana";
            contacte[5]._numarDeTelefon = "02645678" ;

            AfisareMeniu();

            Console.WriteLine("Alege una dintre cele 4 optiuni ");

            int optiune = int.Parse(Console.ReadLine());
            if (optiune > 4) Console.WriteLine("Aceasta optiune nu exista");
          
                switch (optiune)
                {
                    case 1:
                        AfisareContacte(contacte);
                        break;
                    case 2:
                        CautareContacte(contacte);
                        break;
                    case 3:
                        Modificare(contacte);
                        break;
                    case 4:
                        Console.WriteLine("Agenda se inchide");
                        Console.Clear();
                        break;
                }
                Console.ReadKey();
            
        }

        static void AfisareMeniu()
        {
            Console.WriteLine("1.Afisare");
            Console.WriteLine("2.Cautare");
            Console.WriteLine("3.Modificare");
            Console.WriteLine("4.Exit");
        }

        static void AfisareContacte( Persoana[] contacte)
        {
            for (int i = 0; i < contacte.Length; i++)
            {
                Console.WriteLine(contacte[i]._nume + "\n" + contacte[i]._numarDeTelefon);
                Console.WriteLine();
            }
        }

         static int CautareContacte(Persoana[] contacte)
        {
            int deReturnat = 0;
            Console.WriteLine("Introduceti numele sau numarul de telefon pe care doriti sa le cautati");
            string stringCautat = Console.ReadLine();
            for (int i = 0; i < contacte.Length ; i++)
            {
                if(contacte[i]._nume.ToLower().Contains(stringCautat.ToLower()) || contacte[i]._numarDeTelefon.Contains(stringCautat))
                {
                    deReturnat++;
                    Console.WriteLine(contacte[i]._nume +" " + contacte[i]._numarDeTelefon);
                    Console.WriteLine();
                }
            } if (deReturnat == 0)
            {
                Console.WriteLine("Nu aveti aceasta persoana in agenda");
            }
            return deReturnat;
        }

         static void Modificare(Persoana[] contacteNoi)
        {
            int a = CautareContacte(contacteNoi);
            bool found = true;
            if (a > 0)
            {
                Console.WriteLine("Introduceti numele exact ca in Agenda pentru modificare: ");
                string deModificat = Console.ReadLine();
                for (int i = 0; i < contacteNoi.Length ; i++)
                {
                    if (deModificat.Equals(contacteNoi[i]._nume))
                    {
                        Console.WriteLine("Pentru modificarea numelui apasa tasta 1.\n Pentru modificarea numarului de telefon apasta tasta 2");
                        int optiuneModificare = int.Parse(Console.ReadLine());

                        if (optiuneModificare == 1)
                        {
                            Console.WriteLine("Introduceti numele nou: ");
                            string numeNou = Console.ReadLine();
                            contacteNoi[i]._nume = numeNou;
                        }

                        if (optiuneModificare == 2)
                        {
                            Console.WriteLine("Introduceti numarul de telefon nou: ");
                            string numarNou = Console.ReadLine();
                            contacteNoi[i]._numarDeTelefon = numarNou;
                        }
                        AfisareContacte(contacteNoi);
                        found = true;
                        break;
                    }
                    else
                    {
                        found = false;
                    }
                }

                if (found == false)
                {
                    Console.WriteLine("Numele introdus nu se gaseste in agenda.");
                }
            }
        }

    }
}
