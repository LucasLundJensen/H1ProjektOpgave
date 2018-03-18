using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1ProjektOpgave.Modeller
{
    class Biler
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

        public static string Create(int RegNr, string Maerke, string Aargang, int Km, string Brandstofstype, int KundeID = 0)
        {
            DateTime BilOprettelsesDato = DateTime.Now;
            string Creation = ("INSERT INTO Biler(RegNr, Mærke, Modelårgang, Kmkørt, Brændstofstype, EjesAf_fk, BilOprettelsesDato) " + "Values('" + RegNr + "', '" + Maerke + "', '" + Aargang + "', '" + Km + "', '" + Brandstofstype + "', '" + KundeID + "', '" + BilOprettelsesDato + "');");
            try
            {
                DBController.CRUD(Creation);
                return Convert.ToString("Bil " + RegNr + " er nu oprettet.");
            }
            catch (Exception e)
            {
                return Convert.ToString("Error: " + e);
            }
        }

        public static string Delete(int BilID)
        {
            string Deletion = "DELETE FROM Biler WHERE BilID=";
            string CarLookup = "select * from Biler WHERE BilID=";
            DataTable bilDataTabel = DBController.Select(CarLookup + BilID);
            try
            {
                DBController.CRUD(Deletion + BilID);
                return Convert.ToString("Bil " + bilDataTabel.Rows[0]["RegNr"].ToString() + " er nu slettet.");

            }
            catch (Exception)
            {
                return Convert.ToString("Bilen blev ikke fundet");
            }
        }

        public static string Update(int BilID, string option, string value)
        {
            if (option == "1")
            {
                string regnr = "UPDATE Biler SET RegNr=";
                try
                {
                    DBController.CRUD(regnr + Convert.ToInt32(value) + " WHERE BilID=" + BilID);
                    return BilID + " er opdateret med registerings nummeret: " + value;
                }
                catch (Exception)
                {
                    return "Der skete en fejl, det kunne være forkert input";
                }
            }
            else if (option == "2")
            {
                string maerke = "UPDATE Biler SET Mærke=";
                try
                {
                    DBController.CRUD(maerke + "'" + value + "'" + " WHERE BilID=" + BilID);
                    return BilID + " er opdateret med mærket til: " + value;
                }
                catch (Exception)
                {
                    return "Der skete en fejl, det kunne være forkert input";
                }
            }
            else if (option == "3")
            {
                string aargang = "UPDATE Biler SET ModelÅrgang=";
                try
                {
                    DBController.CRUD(aargang + value + " WHERE BilID=" + BilID);
                    return BilID + " har fået opdateret sin årgang til: " + value;
                }
                catch (Exception)
                {
                    return "Der skete en fejl, det kunne være forkert input";
                }
            }
            else if (option == "4")
            {
                string km = "UPDATE Biler SET KmKørt=";
                try
                {
                    DBController.CRUD(km + Convert.ToInt32(value) + " WHERE BilID=" + BilID);
                    return BilID + " har fået opdateret sin kilometer kørt til: " + value;
                }
                catch (Exception)
                {
                    return "Der skete en fejl, det kunne være forkert input";
                }
            }
            else if (option == "5")
            {
                string brandstofstype = "UPDATE Biler SET Brændstofstype=";
                try
                {
                    DBController.CRUD(brandstofstype + value + " WHERE BilID=" + BilID);
                    return BilID + " har fået opdateret sin brændstofstype til: " + value;
                }
                catch (Exception)
                {
                    return "Der skete en fejl, det kunne være forkert input";
                }
            }
            else if (option == "6")
            {
                string ejesaf = "UPDATE Biler SET EjesAf_fk=";
                try
                {
                    DBController.CRUD(ejesaf + Convert.ToInt32(value) + " WHERE BilID=" + BilID);
                    return BilID + " har fået opdateret sin ejer til: " + value;
                }
                catch (Exception)
                {
                    return "Der skete en fejl, det kunne være forkert input";
                }
            }
            else
            {
                return "Ikke gyldig muliged!";
            }
        }

        public static string ShowCar(int BilID)
        {
            string Selection = "select * from Biler WHERE BilID=";
            string bilData = string.Empty;
            DataTable bilDataTable = DBController.Select(Selection + BilID);
            for (int i = 0; i < bilDataTable.Rows.Count; i++)
            {
                Modeller.Biler nyBil = new Modeller.Biler()
                {
                    BilID = Convert.ToInt32(bilDataTable.Rows[i]["BilID"]),
                    RegNR = Convert.ToInt32(bilDataTable.Rows[i]["RegNr"]),
                    Maerke = bilDataTable.Rows[i]["Mærke"].ToString(),
                    Aargang = bilDataTable.Rows[i]["ModelÅrgang"].ToString(),
                    Km = Convert.ToInt32(bilDataTable.Rows[i]["KmKørt"]),
                    BrandStofType = bilDataTable.Rows[i]["Brændstofstype"].ToString(),

                };
                bilData = bilData + "BilID: " + nyBil.BilID + "\nRegisterings Nummer: " + nyBil.RegNR + "\nMærke: " + nyBil.Maerke + "\nÅrgang: " + nyBil.Aargang + "\nKilometer Kørt: " + nyBil.Km + "\nBrændstofs Type: " + nyBil.BrandStofType + "\n";
            }
            return bilData;
        }
    }
}
