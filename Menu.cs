using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evidence_pojisteni_zjednodusena_verze
{
    internal class Menu
    {
        Evidence evidence = new Evidence();

        bool pokracovat = true;
        public void VypisVolbaMenu()
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine("Evidence pojištěných");
            Console.WriteLine("--------------------------");
            Console.WriteLine("\n");
            Console.WriteLine("Vyberte si akci:");
            Console.WriteLine("1 - Přidat nového pojištěnce");
            Console.WriteLine("2 - Vypsat všechny pojištěnce");
            Console.WriteLine("3 - Vyhledat pojištěnce");
            Console.WriteLine("4 - Konec");
        }

        public void HlavniMenu()
        {
            bool pokracovani = true;   

            while (pokracovani) {
                VypisVolbaMenu();

                int volba = 0;

                while (!(int.TryParse(Console.ReadLine().Trim(), out volba) && volba >= 1 && volba <= 4))
                {
                    Console.WriteLine("Neplatná volba. Zadejte číslo v rozmezí 1-4.");
                }

                switch (volba)
                    {
                        case 1:
                            evidence.PridaniPojistence();
                            Pokracovani();
                            break;
                        case 2:
                            evidence.VypsaniPojistencu();
                            Pokracovani();
                            break;
                        case 3:
                            evidence.VyhledaniPojistence();
                            Pokracovani();
                            break;
                        case 4:
                            pokracovani = false;
                            Konec();
                            break;
                        default:
                            Console.WriteLine("Program spadl. Zkuste program znovu otevřít.");
                            Konec();
                            break;
                            
                }
            



            }


        }

        // Metody, které nesouvisí s manipulací a výběrem dat

        public void Pokracovani()
        {
            Console.WriteLine("Pokračujte libovolnou klávesou");
            Console.ReadKey();
            Console.Clear();
        }

        public void Konec()
        {
            Console.WriteLine("Děkujeme za využití programu Evidence pojištění...");
        }
    }
}
