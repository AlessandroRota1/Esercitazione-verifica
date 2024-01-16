using Esercitazione_verifica;
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
    class Persona
    {
        private string nome;
        private string cognome;
        private string provincia;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public string Cogome
        {
            get { return cognome; }
            set { cognome = value; }
        }
        public string Provincia_
        {
            get { return provincia; }
            set { provincia = value; }
        }
    }

    class Conto : Persona
    {
        private float euro;
        private bool chiu;

        public float Euro
        {
            get { return euro; }
            set { euro = value; }
        }

        public bool Chiu
        {
            get { return chiu; }
            set { chiu = value; }
        }

        public Conto()
        {
            Euro = 0;
            Chiu = true;
        }

        public void Apri()
        {
            Chiu = false;
        }

        public void Deposita(float cifra)
        {
            Euro = Euro + cifra;
        }

        public void Preleva(float cifra)
        {
            if (cifra <= Euro)
                Euro = Euro - cifra;
            else
                Console.WriteLine("Saldo insufficiente.");
        }

        public float Saldo()
        {
            return Euro;
        }

        public void Chiusura()
        {
            Chiu = true;
        }

        public bool Chiuso()
        {
            return Chiu;
        }

        public void GetInfo()
        {
            Console.WriteLine($"Nome: {Nome}, Saldo: {Euro}, Chiuso: {Chiu} provincia: {Provincia_}");
        }

        public string Provincia()
        {
            return Provincia_;
        }
    }

    class Banca
    {
        private Conto[] conti;
        private int numConti;

        public Banca(int maxConti)
        {
            conti = new Conto[maxConti];
            numConti = 0;
        }

        public void ApriConto()
        {
            Console.Clear();
            Conto nuovoConto = new Conto();

            Console.Write("Inserisci il nome del titolare del conto: ");
            nuovoConto.Nome = Console.ReadLine();
            Console.WriteLine("Inserire la provincia di provenienza:");
            nuovoConto.Provincia_ = Console.ReadLine();
            conti[numConti] = nuovoConto;
            numConti++;
        }

        public void ChiudiConto()
        {
            Console.Clear();
            Console.Write("Inserisci il nome del titolare del conto da chiudere: ");
            string nomeTitolare = Console.ReadLine();

            foreach (Conto c in conti)
            {
                if (c != null && c.Nome == nomeTitolare)
                {
                    c.Chiusura();
                    Console.WriteLine("Conto chiuso con successo.");
                    return;
                }
            }

            Console.WriteLine("Conto non trovato.");
        }

        public void DepositaSuConto()
        {
            Console.Clear();
            Console.Write("Inserisci il nome del titolare del conto: ");
            string nomeTitolare = Console.ReadLine();
            foreach (Conto c in conti)
            {
                if (c != null && c.Nome == nomeTitolare)
                {
                    if (c.Chiuso() == true)
                    {
                        Console.Write("Inserisci l'importo da depositare: ");
                        float cifra = float.Parse(Console.ReadLine());
                        c.Deposita(cifra);
                        Console.WriteLine($"Deposito di {cifra} euro effettuato con successo.");
                        return;
                    }
                }
            }

            Console.WriteLine("Conto non trovato.");
        }

        public void PrelevaDaConto()
        {
            Console.Clear();
            Console.Write("Inserisci il nome del titolare del conto: ");
            string nomeTitolare = Console.ReadLine();

            foreach (Conto c in conti)
            {
                if (c != null && c.Nome == nomeTitolare)
                {
                    Console.Write("Inserisci l'importo da prelevare: ");
                    float cifra = float.Parse(Console.ReadLine());
                    c.Preleva(cifra);
                    Console.WriteLine($"Prelievo di {cifra} euro effettuato con successo.");
                    return;
                }
            }

            Console.WriteLine("Conto non trovato.");
        }

        public void VediSaldoConto()
        {
            Console.Clear();
            Console.Write("Inserisci il nome del titolare del conto: ");
            string nomeTitolare = Console.ReadLine();

            foreach (Conto c in conti)
            {
                if (c != null && c.Nome == nomeTitolare)
                {
                    Console.WriteLine($"Il saldo del conto di {c.Nome} è: {c.Saldo()} euro.");
                    return;
                }
            }

            Console.WriteLine("Conto non trovato.");
        }

        public void VediInfoConto()
        {
            Console.Clear();
            Console.Write("Inserisci il nome del titolare del conto: ");
            string nomeTitolare = Console.ReadLine();

            foreach (Conto c in conti)
            {
                if (c != null && c.Nome == nomeTitolare)
                {
                    c.GetInfo();
                    return;
                }
            }

            Console.WriteLine("Conto non trovato.");
        }
        public float DepositoClientiProvincia(string provincia)
        {
            Console.Clear();
            float totaleDeposito = 0;

            Conto c = null;
            int i = 0;
            while (i < conti.Length && c == null)
            {
                if (conti[i] != null && conti[i].Nome == conti[i].Nome)
                {
                    totaleDeposito += conti[i].Saldo();
                }
                i++;
            }

            if (c != null)
            {
                c.GetInfo();
            }

            return totaleDeposito;
        }
    }

}
class Program
{
    static void Main()
    {
        Banca banca = new Banca(10);

        int scelta;


        do
        {
            Console.WriteLine("1. Apri Conto");
            Console.WriteLine("2. Chiudi Conto");
            Console.WriteLine("3. Deposita su Conto");
            Console.WriteLine("4. Preleva da Conto");
            Console.WriteLine("5. Vedi Saldo Conto");
            Console.WriteLine("6. Vedi Info Conto");
            Console.WriteLine("7. Somma conti province");
            Console.WriteLine("0. Esci");

            Console.Write("Scelta: ");
            scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    banca.ApriConto();
                    break;

                case 2:
                    banca.ChiudiConto();
                    break;

                case 3:
                    banca.DepositaSuConto();
                    break;

                case 4:
                    banca.PrelevaDaConto();
                    break;

                case 5:
                    banca.VediSaldoConto();
                    break;

                case 6:
                    banca.VediInfoConto();
                    break;

                case 7:
                    Console.Write("Inserisci la provincia: ");
                    string prov = Console.ReadLine();
                    float totale = banca.DepositoClientiProvincia(prov);
                    Console.WriteLine($"Il totale dei depositi dei clienti residenti in {prov} è: {totale} euro.");
                    break;

                case 0:
                    Console.WriteLine("Esci.");
                    break;

                default:
                    Console.WriteLine("Non valido.");
                    break;
            }

        } while (scelta != 0);
    }
}

