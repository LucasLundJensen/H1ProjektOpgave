using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace H1ProjektOpgave
{
    class Kunde
    {
        private string kundeid;

        public string Kundeid
        {
            get { return kundeid; }
            set { kundeid = value; }
        }

        private string fornavn;

        public string Fornavn
        {
            get { return fornavn; }
            set { fornavn = value; }
        }

        private string efternavn;

        public string Efternavn
        {
            get { return efternavn; }
            set { efternavn = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string oprettelsesdato;

        public string Oprettelsesdato
        {
            get { return oprettelsesdato; }
            set { oprettelsesdato = value; }
        }

        public static string Create(string Fornavn, string Efternavn, string Email)
        {
            DateTime Oprettelsesdato = DateTime.Now;
            string Creation = ("INSERT INTO Kunde (Fornavn, Efternavn, Email, KundeOprettelsesdato) " + "Values('" + Fornavn + "', '" + Efternavn + "', '" + Email + "', '" + Oprettelsesdato + "');");
            try
            {
                DBController.CRUD(Creation);
                return Convert.ToString("Kunde " + Fornavn + " " + Efternavn + " er nu oprettet.");
            }
            catch (Exception e)
            {
                return Convert.ToString("Error: " + e);
            }

        }

        public static string Delete(int KundeID)
        {
            string Deletion = "DELETE FROM Kunde WHERE KundeID=";
            string UserLookup = "select * from Kunde WHERE KundeID=";
            DataTable KundeDataTable = DBController.Select(UserLookup + KundeID);
            try
            {
                DBController.CRUD(Deletion + KundeID);
                return Convert.ToString("Kunde " + KundeDataTable.Rows[0]["Navn"].ToString() + " er nu slettet.");

            }
            catch (Exception)
            {
                return Convert.ToString("Bruger blev ikke fundet");
            }
        }

        public static string Overview(int KundeID)
        {
            string UserLookup = "SELECT * from Kunde, Biler WHERE KundeID = EjesAf_fk AND KundeID=";
            DataTable KundeDataTable = DBController.Select(UserLookup + KundeID);

            //return Convert.ToString("");
            string userProperties = "Kundeoplysninger: \nNavn: " + KundeDataTable.Rows[0]["Fornavn"].ToString() + " " + KundeDataTable.Rows[0]["Efternavn"].ToString() + "\nID: " + KundeDataTable.Rows[0]["KundeID"].ToString() + "\nEmail: " + KundeDataTable.Rows[0]["Email"].ToString() + "\nOprettelses Dato: " + KundeDataTable.Rows[0]["KundeOprettelsesdato"].ToString();
            string bilData = string.Empty;
            for (int i = 0; i < KundeDataTable.Rows.Count; i++)
            {
                Modeller.Biler nyBil = new Modeller.Biler()
                {
                    BilID = Convert.ToInt32(KundeDataTable.Rows[i]["BilID"]),
                    RegNR = Convert.ToInt32(KundeDataTable.Rows[i]["RegNr"]),
                    Maerke = KundeDataTable.Rows[i]["Mærke"].ToString(),
                    Aargang = KundeDataTable.Rows[i]["ModelÅrgang"].ToString(),
                    Km = Convert.ToInt32(KundeDataTable.Rows[i]["KmKørt"]),
                    BrandStofType = KundeDataTable.Rows[i]["Brændstofstype"].ToString(),

                };
                bilData = bilData + "BilID: " + nyBil.BilID + "\nRegisterings Nummer: " + nyBil.RegNR + "\nMærke: " + nyBil.Maerke + "\nÅrgang: " + nyBil.Aargang + "\nKilometer Kørt: " + nyBil.Km + "\nBrændstofs Type: " + nyBil.BrandStofType + "\n";
            }
            return userProperties + "\n" + bilData;
        }

        public static string KundeOversigt(string Option)
        {
            string sqlKunde = "SELECT * FROM Kunde;";
            string sqlBil = "SELECT * FROM Biler;";
            if (Option == "Kundeoversigt")
            {
                DataTable KundeTabel = DBController.Select(sqlKunde);

                string Kunder = string.Empty;

                for (int i = 0; i < KundeTabel.Rows.Count; i++)
                {
                    Kunde kunde = new Kunde()
                    {
                        Kundeid = Convert.ToString(KundeTabel.Rows[i]["KundeID"]),
                        Fornavn = Convert.ToString(KundeTabel.Rows[i]["Fornavn"]),
                        Efternavn = Convert.ToString(KundeTabel.Rows[i]["Efternavn"]),
                        Email = Convert.ToString(KundeTabel.Rows[i]["Email"]),
                        Oprettelsesdato = Convert.ToString(KundeTabel.Rows[i]["KundeOprettelsesdato"])
                    };
                    Kunder = Kunder + "\nKundeID: " + kunde.Kundeid + "\nNavn " + kunde.Fornavn + " " + kunde.Efternavn + "\nEmail: " + kunde.Email + "\nOprettelses Dato: " + kunde.Oprettelsesdato + "\n";
                }
                return Kunder;
            }
            else if (Option == "Biloversigt")
            {
                DataTable BilTabel = DBController.Select(sqlBil);

                string Biler = string.Empty;

                for (int i = 0; i < BilTabel.Rows.Count; i++)
                {
                    Modeller.Biler nyBil = new Modeller.Biler()
                    {
                        BilID = Convert.ToInt32(BilTabel.Rows[i]["BilID"]),
                        RegNR = Convert.ToInt32(BilTabel.Rows[i]["RegNr"]),
                        Maerke = BilTabel.Rows[i]["Mærke"].ToString(),
                        Aargang = BilTabel.Rows[i]["ModelÅrgang"].ToString(),
                        Km = Convert.ToInt32(BilTabel.Rows[i]["KmKørt"]),
                        BrandStofType = BilTabel.Rows[i]["Brændstofstype"].ToString(),

                    };
                    Biler = Biler + "\nBilID: " + nyBil.BilID + "\nRegisterings Nummer: " + nyBil.RegNR + "\nMærke: " + nyBil.Maerke + "\nÅrgang: " + nyBil.Aargang + "\nKilometer Kørt: " + nyBil.Km + "\nBrændstofs Type: " + nyBil.BrandStofType + "\n";
                }
                return Biler;
            }
            else
            {
                return Convert.ToString("Der er ikke skrevet en gyldig valgmulighed ind");
            }
        }
    }
}
