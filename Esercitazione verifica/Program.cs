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
            { if (value > 0)
                    saldo = value;
                else Console.WriteLine("Inserire un valore maggiore di 0");
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
            Console.WriteLine("Nome e cognome del titolare del conto corrente:" + Nome + " " + "dalla provincia di: " + Provincia);
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

            Console.WriteLine("Benvenuto nella banca!");
        }
        public void Chiudiconto()
        {
            arrayconti[i].chiudiconto();
            i++;
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
            Console.WriteLine("Il saldo sul conto è di: "+ arrayconti[i].ssaldo());
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

            Console.WriteLine("Inserisci il numero corrispondente alla pratica da svolgere:");
            Console.WriteLine("1) Apri il conto");
            Console.WriteLine("2) Chiudi il conto"); 
            Console.WriteLine("3) Deposita sul conto");
            Console.WriteLine("4) Preleva dal conto");
            Console.WriteLine("5) Vedi saldo sul conto");
            Console.WriteLine("6) Vedi informazioni sul conto");
            risposta = Console.ReadLine();

            switch (risposta)
            {
                case "1":

                    paolobanchero.Apriconto();


                    break;
            }
            Console.ReadKey();
        }
    }
}
