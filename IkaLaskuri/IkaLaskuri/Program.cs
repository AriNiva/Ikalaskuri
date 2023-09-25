using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkaLaskuri
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Double aikaJaljella = 0;
            int elinIanOdote = 0;
            string alkuAika = "", sp = "";
            string vuodetKuukaudetPaivat = "";
            DateTime syntymaAikaDT, elinianOdotusDT;
            DateTime tanaan = DateTime.Today;
            string formaatti = "dd.MM.yyyy";//ParseExact käyttää pvm-formaattia joka esitellään tässä
            CultureInfo kulttuuri = CultureInfo.InvariantCulture;//ParseExact tarvitsee tämän parametrin

            Console.WriteLine("Kerro sukupuoli, M=Mies/N=Nainen");
            sp = Console.ReadLine().ToUpper();
            switch (sp)
            {
                case "M":
                    elinIanOdote = 78;
                    break;
                case "N":
                    elinIanOdote = 84;
                    break;
                default:
                    Console.WriteLine("Virheellinen valinta!");
                    elinIanOdote = 0;
                    break;
            }

            Console.WriteLine("Anna syntymäaika muodossa PP.KK.VVVV");
            alkuAika = Console.ReadLine();
            try
            {
                syntymaAikaDT = DateTime.ParseExact(alkuAika, formaatti, kulttuuri);
                elinianOdotusDT = syntymaAikaDT.AddYears(elinIanOdote);
                aikaJaljella = elinianOdotusDT.Subtract(tanaan).TotalDays;//Laskutoimitus.
                DateTime paivat = new DateTime(new TimeSpan((int)aikaJaljella + 1, 0, 0, 0).Ticks);
                vuodetKuukaudetPaivat = string.Format("{0} vuotta {1} kuukautta ja {2} päivää", paivat.Year - 1, paivat.Month - 1, paivat.Day - 1);
            }
            catch (Exception ee)
            {
                Console.WriteLine("Ohjelma ei osannut laskea päivämääräerotusta. Tarkista pvm-formaatti!");
                Console.WriteLine(ee.Message);
                vuodetKuukaudetPaivat = "";
                aikaJaljella = 0;//Jos pvm-formaatti on väärä, antaa vastauksen 0 tuntia.
            }

            Console.WriteLine("Odotettua elinaikaa jäljellä " + vuodetKuukaudetPaivat + ".");
            Console.ReadLine();
        }
    }
}
