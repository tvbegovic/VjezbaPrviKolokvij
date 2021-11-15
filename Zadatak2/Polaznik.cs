using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak2
{
    class Polaznik
    {
        private string ime;
        private string prezime;
        private string oib;
        private DateTime datumUpisa;
        private double dug;
        private double score;

        public string Ime
        {
            get
            {
                return ime;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Ime mora biti upisano");
                ime = value;
            }
        }

        public string Prezime
        {
            get
            {
                return prezime;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Prezime mora biti upisano");
                prezime = value;
            }
        }

        public string Oib
        {
            get
            {
                return oib;
            }
            set
            {
                if (value.Length != 11)
                    throw new ArgumentException("Oib mora imati 11 znamenki");
                oib = value;
            }
        }

        public DateTime DatumUpisa
        {
            get
            {
                return datumUpisa;
            }
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Datum ne smije biti u budućnosti");
                datumUpisa = value;
            }
        }

        public double Dug
        {
            get
            {
                return dug;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Dug ne smije biti negativan");
                dug = value;
            }
        }

        public double Score { get => score; set => score = value; }
    }
}
