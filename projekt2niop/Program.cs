using System;
using System.Collections.Generic;

namespace KonzolnaAplikacija
{
 
    class Objekat
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public string Vrsta { get; set; }
        public decimal Cijena { get; set; }

       
        public Objekat(int id, string naziv, string vrsta, decimal cijena)
        {
            ID = id;
            Naziv = naziv;
            Vrsta = vrsta;
            Cijena = cijena;
        }

        
        public override string ToString()
        {
            return $"ID: {ID}, Naziv: {Naziv}, Vrsta: {Vrsta}, Cijena: {Cijena:C}";
        }
    }

    
    class UpravljanjeObjektima
    {
       
        private List<Objekat> objekti = new List<Objekat>();

        
        public void DodajObjekat(Objekat objekat)
        {
            objekti.Add(objekat);
            Console.WriteLine("Objekat je uspješno dodan.");
        }

        
        public void ObrisiObjekat(int id)
        {
            var objekatZaBrisanje = objekti.Find(o => o.ID == id);
            if (objekatZaBrisanje != null)
            {
                objekti.Remove(objekatZaBrisanje);
                Console.WriteLine("Objekat je uspješno obrisan.");
            }
            else
            {
                Console.WriteLine("Objekat s tim ID-em nije pronađen.");
            }
        }

      
        public void IspisObjekata()
        {
            if (objekti.Count == 0)
            {
                Console.WriteLine("Popis objekata je prazan.");
                return;
            }

            Console.WriteLine("Popis objekata:");
            foreach (var objekat in objekti)
            {
                Console.WriteLine(objekat);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            UpravljanjeObjektima upravljanje = new UpravljanjeObjektima();

            while (true)
            {
                Console.WriteLine("\nOdaberite opciju:");
                Console.WriteLine("1. Dodaj objekat");
                Console.WriteLine("2. Obrisi objekat");
                Console.WriteLine("3. Ispis objekata");

                Console.Write("Unesite izbor: ");
                string izbor = Console.ReadLine();

                switch (izbor)
                {
                    case "1":
                        Console.Write("Unesite ID objekta: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Unesite naziv objekta: ");
                        string naziv = Console.ReadLine();
                        Console.Write("Unesite vrstu objekta: ");
                        string vrsta = Console.ReadLine();
                        Console.Write("Unesite cijenu objekta: ");
                        decimal cijena = decimal.Parse(Console.ReadLine());
                        upravljanje.DodajObjekat(new Objekat(id, naziv, vrsta, cijena));
                        break;

                    case "2":
                        Console.Write("Unesite ID objekta za brisanje: ");
                        int idZaBrisanje = int.Parse(Console.ReadLine());
                        upravljanje.ObrisiObjekat(idZaBrisanje);
                        break;

                    case "3":
                        upravljanje.IspisObjekata();
                        break;

                    default:
                        Console.WriteLine("Neispravan unos. Pokušajte ponovno.");
                        break;
                }
            }
        }
    }
}
