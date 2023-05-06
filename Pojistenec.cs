using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evidence_pojisteni_zjednodusena_verze
{
    class Pojistenec
    {
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public int Vek { get; set; }
        public string TelCislo { get; set; }

        public Pojistenec(string jmeno, string prijmeni, int vek, string telCislo)
        {
            Jmeno = jmeno;
            Prijmeni = prijmeni;
            Vek = vek;
            TelCislo = telCislo;
        }

        public override string ToString()
        {
            return String.Format ("{0,-15} {1,-15} {2,-15} {3,-15}\n", Jmeno, Prijmeni, Vek, TelCislo);
                
        }
    }
}
