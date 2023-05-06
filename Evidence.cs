using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace evidence_pojisteni_zjednodusena_verze
{
    class Evidence
    {
        // Inicializace List<> pojištěnců
        private List<Pojistenec> pojistenci = new List<Pojistenec>();

        // Automaticky napíše velkým písmenem u prvního písmena
        public string PrvniPismenoVelke(string znak)
        {
            string prvniPismenoVelke = znak.Substring(0, 1).ToUpper() + znak.Substring(1);
            return prvniPismenoVelke;
        }

        // Přidání pojištěnce
        public void PridaniPojistence()
        {
            //Výpis a vstup jména
            Console.WriteLine("Zadejte jméno pojištěnce:");
            string jmeno = Console.ReadLine().Trim();

            // Validace jména pojištěnce a jméno s velkým písmenem na začátku
            while (string.IsNullOrWhiteSpace(jmeno))
            {
                Console.WriteLine("Zadejte jméno pojištěnce znovu:");
            }
            jmeno = PrvniPismenoVelke(jmeno);

            // Výpis a vstup příjmení
            Console.WriteLine("Zadejte příjmení pojištěnce:");
            string prijmeni = Console.ReadLine().Trim();

            // Validace příjmení pojištěnce a příjmení s velkým písmenem na začátku
            while (string.IsNullOrWhiteSpace(prijmeni))
            {
                Console.WriteLine("Zadejte příjmení pojištěnce znovu:");
            }
            prijmeni = PrvniPismenoVelke(prijmeni);

            // Výpis zadání k datu
            Console.WriteLine("Zadejte datum narození ve tvaru [01.01.1950]:");

            DateTime datumNarozeni;
            // Validace a zjištění věku pojištěnce podle data
            while (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out datumNarozeni))
            {
                Console.WriteLine("Zadejte datum narození ve správném formátu:");
            }

            TimeSpan vypocet = DateTime.Now - datumNarozeni;
            int vek = (int)(vypocet.TotalDays / 365.255);

            // Výpis a vstup telefonního čísla
            Console.WriteLine("Zadej telefonní číslo ve správném formátu +420 123 456 789:");
            string telCislo = Console.ReadLine().Trim();

            // Validace telefonního čísla
            Regex validaceTelCisla = new Regex(@"^(\+420|\+421) ?[0-9]{3} ?[0-9]{3} ?[0-9]{3}$");

            while(!validaceTelCisla.IsMatch(telCislo))
            {
                Console.WriteLine("Zadali jste neplatné telefonní číslo, zadejte znovu:");
                telCislo = Console.ReadLine();
            }

            // Přidání pojištence s konstruktorem uvnitř
            pojistenci.Add(new Pojistenec(jmeno, prijmeni, vek, telCislo));
            Console.WriteLine(VypisHlavickuDat());
            Console.WriteLine(pojistenci.Last());
            Console.WriteLine("Uloženo!");
        }

        // Vypsání pojištěnců
        public void VypsaniPojistencu()
        {
            if (pojistenci.Count > 0)
            {
                //LINQ dotaz včetně řazení podle jména a příjmení
                var vypsaniPojistencu = from poj
                                        in pojistenci
                                        orderby poj.Jmeno, poj.Prijmeni
                                        select poj
                                        ;

                Console.WriteLine(VypisHlavickuDat());

                foreach (Pojistenec pj in vypsaniPojistencu)
                {
                    Console.WriteLine(pj);
                }
            }
            else 
            {
                Console.WriteLine("Nemáte žádné záznamy o pojištěncích!");
            }
        }

        // Hledání pojištence podle jména a příjmení
        public void VyhledaniPojistence()
        {
            
            if (pojistenci.Count > 0) 
            {
                Console.WriteLine("Zadej jméno pojištěnce k vyhledání:");

                string vyhledejJmeno = Console.ReadLine().Trim();
                
                // Validace jména
                while (string.IsNullOrWhiteSpace(vyhledejJmeno))
                {
                    Console.WriteLine("Zadejte jméno pojištěnce znovu:");
                    vyhledejJmeno = Console.ReadLine().Trim();
                }

                Console.WriteLine("Zadej příjmení pojištěnce k vyhledání:");

                string vyhledejPrijmeni = Console.ReadLine().Trim();
                
                // Validace příjmení
                while (string.IsNullOrWhiteSpace(vyhledejPrijmeni))
                {
                    Console.WriteLine("Zadejte příjmení pojištěnce znovu:");
                    vyhledejPrijmeni = Console.ReadLine().Trim();
                }

                // LINQ dotaz k přesnému vyhledávání jména a příjmení
                var vyhledaniPojistence = from v
                                          in pojistenci
                                          where (v.Jmeno == PrvniPismenoVelke(vyhledejJmeno) && v.Prijmeni == PrvniPismenoVelke(vyhledejPrijmeni))
                                          orderby v.Jmeno, v.Prijmeni
                                          select v;

                if (vyhledaniPojistence.Count() > 0)
                {
                    Console.WriteLine(VypisHlavickuDat());

                    foreach (Pojistenec p in vyhledaniPojistence)
                    {
                        Console.WriteLine(p);
                    }
                }

                else
                {
                    Console.WriteLine("Hledaný pojištěnec nebyl nalezen");
                }


            }
            else
            {
                Console.WriteLine("Nemáte žádné záznamy o pojištěncích!");
            }

        }
        
        public string VypisHlavickuDat()
        {
            return String.Format("{0,-15} {1,-15} {2,-15} {3,-15}\n", "Jméno", "Příjmení", "Věk", "Telefonní číslo");
        }
    }
}
