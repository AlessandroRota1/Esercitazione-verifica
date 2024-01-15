using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercitazione_verifica
{
    class persona
    {
        private string nome;
        public string Nome
        {
            get => nome;
            set
            { if (value.Length >= 2)
                    nome = value;
              else nome = "Sconosciuto";
            }
        }
        private string cognome;
        public string Cognome
        {
            get => cognome;
            set
            {
                if (value.Length >= 2)
                    cognome = value;
                else cognome = "Sconosciuto";
            }
        }
        private string provincia;
        public string Provincia
        {
            get => provincia;
            set
            {
                provincia = value;
            }
        }
    }
    class conto : persona
    {
        private double saldo;
        public double Saldo
        {
            get => saldo;
            set
            { 
                if (value > 0)
                    saldo = value;
                else 
                    Console.WriteLine("Inserire un valore maggiore di 0");
            }
        }
        private bool chiuso;
        public bool Chiuso
        {
            get { return chiuso; }
            set { chiuso = value; }
        }
        public void cconto()
        {
            chiuso = false;
            saldo = 0;
        }
        public void apri()
        {
            chiuso = true;
        }
        public void deposita()
        {
            Console.WriteLine("Quanto vuoi depositare sul conto corrente");
            saldo = saldo + (double.Parse(Console.ReadLine()));
        }
        public void preleva()
        {
            Console.WriteLine("Quanto vuoi prelevare sul conto corrente");
            saldo = saldo - (double.Parse(Console.ReadLine()));
        }
        public double ssaldo()
        {
            return saldo;
        }
        public void chiudiconto()
        {
            chiuso = false;
        }
        public bool cchiuso()
        { 
            return chiuso; 
        }
        public void getinfo()
        {
            Console.WriteLine("Nome e cognome del titolare del conto corrente:" + Nome + " " + Cognome + " "+ "dalla provincia di: " + Provincia);
            if (chiuso) { Console.WriteLine("Conto aperto"); }
            else { Console.WriteLine("Conto chiuso"); }
            Console.WriteLine("Saldo all'interno del conto: "+ saldo);
        }
    }
    class banca
    {
        private conto[] arrayconti = new conto[100];
        private int i = 0;
        public banca()
        {
            for (int i = 0; i < 100; i++)
            {
                arrayconti[i] = new conto();
            }
        }
        public void Apriconto()
        {
            arrayconti[i].apri();
            i++;
            Console.WriteLine("Benvenuto nella banca!\n");
            Console.WriteLine("Inserisci il nome");
            arrayconti[i].Nome = Console.ReadLine();
            Console.WriteLine("Inserisci il cognome");
            arrayconti[i].Cognome = Console.ReadLine();
            Console.WriteLine("Inserisci la provincia");
            arrayconti[i].Provincia = Console.ReadLine();
        }
        public void Chiudiconto()
        {
            arrayconti[i].chiudiconto();
            i++;
            Console.WriteLine("Il conto è stato chiuso.\n");
        }
        public void Depositasuconto()
        {
            arrayconti[i].deposita();
            i++;
        }
        public void Prelevadaconto()
        {
            arrayconti[i].preleva();
            i++;
        }
        public void Vedisaldoconto()
        {
            Console.WriteLine("Il saldo sul conto è di: " + arrayconti[i].ssaldo() + "\n");
        }
        public void Vediinfoconto()
        {
            arrayconti[i].getinfo();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            banca paolobanchero = new banca();
            string risposta;

            do
            {
                Console.WriteLine("Inserisci il numero corrispondente alla pratica da svolgere:");
                Console.WriteLine("1) Apri il conto");
                Console.WriteLine("2) Chiudi il conto");
                Console.WriteLine("3) Deposita sul conto");
                Console.WriteLine("4) Preleva dal conto");
                Console.WriteLine("5) Vedi saldo sul conto");
                Console.WriteLine("6) Vedi informazioni sul conto");
                Console.WriteLine("7) Esci");

                risposta = Console.ReadLine();

                switch (risposta)
                {
                    case "1":

                        Console.Clear();
                        paolobanchero.Apriconto();
                        break;

                    case "2":

                        Console.Clear();
                        paolobanchero.Chiudiconto();
                        break;

                    case "3":

                        Console.Clear();
                        paolobanchero.Depositasuconto();
                        break;

                    case "4":

                        Console.Clear();
                        paolobanchero.Prelevadaconto();
                        break;

                    case "5":

                        Console.Clear();
                        paolobanchero.Vedisaldoconto();
                        break;

                    case "6":

                        Console.Clear();
                        paolobanchero.Vediinfoconto();
                        break;
                }
            } while (risposta != string.Empty || risposta != "7");

            Console.ReadKey();
        }
    }
}
