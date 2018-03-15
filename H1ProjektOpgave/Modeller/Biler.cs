using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1ProjektOpgave.Modeller
{
    public class Biler
    {
        private int regNR;

        public int RegNR
        {
            get { return regNR; }
            set { regNR = value; }
        }

        private string maerke;

        public string Maerke
        {
            get { return maerke; }
            set { maerke = value; }
        }

        private string aargang;

        public string Aargang
        {
            get { return aargang; }
            set { aargang = value; }
        }

        private int km;

        public int Km
        {
            get { return km; }
            set { km = value; }
        }

        private string brandstoftype;

        public string BrandStofType
        {
            get { return brandstoftype; }
            set { brandstoftype = value; }
        }

        private int bilID;

        public int BilID
        {
            get { return bilID; }
            set { bilID = value; }
        }

        
    }
}
