using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radnici

{

    class Radnik          // 1.Klasa
    {
        public string ime;
        public string prezime;
        public int godRada;
        public string jmbg;

        public Radnik()
        {
            this.ime = "Srdjan";
            this.prezime = "Savic";
            this.jmbg = "111111111111111";
            this.godRada = 2;
        }

        public Radnik(string ime, string prezime)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.jmbg = "2222222222222";
            this.godRada = 2;
        }

        public Radnik(string ime, string prezime, string jmbg, int godRada)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.jmbg = jmbg;
            this.godRada = godRada;

        }

        public string Jmbg
        {
            get { return jmbg; }
            set { jmbg = value; }
        }

        public int GodRada
        {
            get { return godRada; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Uneli ste negativan broj za godine rada!");
                    godRada = 0;
                }
                else godRada = value;       //prevencija negativnog broja
            }
        }

        public int Penzija()
        {
            return 45 - godRada;
        }

        public void Ispis()
        {
            Console.WriteLine("Ime: " + ime);
            Console.WriteLine("Prezime : " + prezime);
            Console.WriteLine("Jmbg: " + jmbg);
            Console.WriteLine("Godina rada: " + godRada);
            Console.WriteLine("Godina do penzije: " + Penzija());
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("");
        }
    }


    class Kvalifikovani : Radnik                // 2.Klasa (Nasledjena)
    {


        public Kvalifikovani(string ime, string prezime, string jmbg, int godRada)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.jmbg = jmbg;
            this.godRada = godRada;
        }

        public string kvalifikacija()        //<--------------- Metoda kvalifikacije za povisicu
        {
            if (GodRada >= 5)
                return "Da";
            else return "Ne";

        }


        public void IspisK()
        {
            Console.WriteLine("Ime radnika : " + ime);
            Console.WriteLine("Prezime  radnika : " + prezime);
            Console.WriteLine("Jmbg  radnika : " + jmbg);
            Console.WriteLine("Da li je radnik kvalifikovan za povisicu? : " + kvalifikacija());
            Console.WriteLine("Godina do penzije: " + Penzija());          //<------------Nasledjena Metoda
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("");
        }

    }



    class KreirajSam : Radnik      //3.Klasa (Klasa kojom upravlja korisnik)
    {
        public int redniBr;
        public KreirajSam(string ime, string prezime, string jmbg, int godRada)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.jmbg = jmbg;
            this.godRada = godRada;
            this.redniBr = 1;
        }



        public int GODINA()
        {
            return Convert.ToInt32(Console.ReadLine());
        }



        public string citac()
        {
            return Console.ReadLine();
        }

        public void KIspis()
        {
            Console.WriteLine("Ime: " + ime);
            Console.WriteLine("Prezime : " + prezime);
            Console.WriteLine("Jmbg: " + jmbg);
            Console.WriteLine("Godina rada: " + godRada);
            Console.WriteLine("Godina do penzije: " + Penzija());
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("");
        }

    }

    class Program                     // 4. Klasa ( Klasa za pozivanje )
    {
        static void Main(string[] args)
        {
            Radnik radnik1 = new Radnik();
            Radnik radnik2 = new Radnik("Petar", "Petrovic");
            Radnik radnik3 = new Radnik("Milan", "Milanovic", "4444444444444444", 5);
            Kvalifikovani Kradnik1 = new Kvalifikovani("Uros", "Urosevic", "555555555555555", 3);        //Kreiranje objekta iz nasledjene klase


            radnik1.Ispis();
            radnik2.Ispis();
            radnik2.GodRada = -2;           //Provera regulacije negativnog broja
            radnik2.Ispis();

            radnik3.Ispis();
            Kradnik1.IspisK();
            Kradnik1.GodRada = -4;          //Provera regulacije negativnog broja
            Kradnik1.IspisK();



            Console.WriteLine("Da li zelite da kreirate nalog sopstvenom radniku?  (Pritisnuti (1) za Da / Pritisnuti (2) za Ne)");
            int a = 0;
            a = Convert.ToInt32(Console.ReadLine());

            if (a == 1)                          // If komanda koja cita da li korisnik zeli da napravi sopstvenog ragnika
            {
                KreirajSam SRadnik = new KreirajSam("j", "k", "l", 3);//Kreiranje objekta date klase,(Nasumicni broj i slova su ubaceni kako bi bar nesto bilo upisano)
                Console.WriteLine("Molimo unesite ime vaseg radnika: ");
                SRadnik.ime = SRadnik.citac();
                Console.WriteLine("Molimo unesite prezime vaseg radnika: ");
                SRadnik.prezime = SRadnik.citac();
                Console.WriteLine("Unesite jmbg vaseg radnika : ");
                SRadnik.jmbg = SRadnik.citac();
                Console.WriteLine("Unesite broj godina rada vaseg radnika: ");
                SRadnik.godRada = SRadnik.GODINA();

                Console.WriteLine(" ");
                Console.WriteLine(" ");
                SRadnik.Ispis();
            }

        }
    }
}