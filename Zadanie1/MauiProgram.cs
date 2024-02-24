

using System.Collections.Generic;

using static Programm;

Console.WriteLine("Hello, World!");

public class Program1

{

    private static Klient klient = new Klient("Adam", "Wiertarka");

    public static void Main(string[] args)

    {

        bool running = true;

        while (running)

        {

            Console.WriteLine("1. Dodaj gre do koszyka");

            Console.WriteLine("2. Dodaj do koszyka twoją rzecz");

            Console.WriteLine("3. Dodaj twoją odzież do koszyka");

            Console.WriteLine("4. Wyświetl cenę końcową");

            Console.WriteLine("5. Wyjście");

            Console.Write("Wybierz opcję: ");

            string option = Console.ReadLine();

            switch (option)

            {

                case "1":

                    klient.DodajDoKoszyka(new Ksiazka("Fifa", 30, 5));

                    Console.WriteLine("Dodano gre do koszyka.");

                    break;

                case "2":

                    klient.DodajDoKoszyka(new Elektronika("Konsola", 3200, 20));

                    Console.WriteLine("Dodano do koszyka twoją rzecz.");

                    break;

                case "3":

                    klient.DodajDoKoszyka(new Odziez("Bluza", 200, 10));

                    Console.WriteLine("Dodano twoją odzież do koszyka.");

                    break;

                case "4":

                    Console.WriteLine($"Cena koszyka: {klient.ObliczCeneKoszyka()} zł");

                    break;

                case "5":

                    running = false;

                    break;

                default:

                    Console.WriteLine("Nieznana opcja.");

                    break;

            }

        }

    }

}

internal class Programm

{

    public interface IProdukt

    {

        string WyswietlInfo();

        int AktualnaCena();

        int DostępnaIlosc();

    }

    public abstract class Produkt : IProdukt

    {

        public string Nazwa { get; set; }

        public int Cena { get; set; }

        public int Ilosc { get; set; }

        protected Produkt(string Nazwa, int Cena, int Ilosc)

        {

            Nazwa = Nazwa;

            Cena = Cena;

            Ilosc = Ilosc;

        }

        public string WyswietlInfo()

        {

            return Nazwa;

        }

        public int AktualnaCena()

        {

            return Cena;

        }

        public int DostępnaIlosc()

        {

            return Ilosc;

        }

    }

    public class Ksiazka : Produkt

    {

        public Ksiazka(string nazwa, int cena, int ilosc) : base(nazwa, cena, ilosc)

        {

        }

    }

    public class Elektronika : Produkt

    {

        public Elektronika(string nazwa, int cena, int ilosc) : base(nazwa, cena, ilosc)

        {

        }

    }

    public class Odziez : Produkt

    {

        public Odziez(string nazwa, int cena, int ilosc) : base(nazwa, cena, ilosc)

        {

        }

    }

    public abstract class Osoba

    {

        public string Imie { get; private set; }

        public string Nazwisko { get; private set; }

        protected Osoba(string Imie, string Nazwisko)

        {

            Imie = Imie;

            Nazwisko = Nazwisko;

        }

    }

    public class Klient : Osoba

    {

        private List<IProdukt> koszyk = new List<IProdukt>();

        public Klient(string imie, string nazwisko) : base(imie, nazwisko)

        {

        }

        public int Ilosc { get; set; }

        public void DodajDoKoszyka(IProdukt produkt)

        {

            int ilosc = produkt.DostępnaIlosc();

            if (produkt != null && produkt.DostępnaIlosc() > 0)

            {

                koszyk.Add(produkt);

                produkt.DostępnaIlosc();

            }

        }

        public int ObliczCeneKoszyka()

        {

            int Suma = 0;

            foreach (var produkt in koszyk)

            {

                Suma += produkt.AktualnaCena();

            }

            return Suma;

        }

    }

}