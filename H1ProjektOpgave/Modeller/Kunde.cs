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


        public static string Create(string Navn, string Email)
        {
            DateTime Oprettelsesdato = DateTime.Now;
            string Creation = ("INSERT INTO Kunde (Navn, Email, KundeOprettelsesdato) " + "Values('" + Navn + "', '" + Email + "', '" + Oprettelsesdato + "');");
            try
            {
                DBController.CRUD(Creation);
                return Convert.ToString("Kunde " + Navn + " er nu oprettet.");
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
            string userProperties = "Kundeoplysninger: \nNavn: " + KundeDataTable.Rows[0]["Navn"].ToString() + "\nID: " + KundeDataTable.Rows[0]["KundeID"].ToString() + "\nEmail: " + KundeDataTable.Rows[0]["Email"].ToString() + "\nOprettelses Dato: " + KundeDataTable.Rows[0]["KundeOprettelsesdato"].ToString();
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
                bilData = bilData + "\nBilID: " + nyBil.BilID + "\nRegisterings Nummer: " + nyBil.RegNR + "\nMærke: " + nyBil.Maerke + "\nÅrgang: " + nyBil.Aargang + "\nKilometer Kørt: " + nyBil.Km + "\nBrændstofs Type: " + nyBil.BrandStofType + "\n";
            }
            return userProperties + "\n" + bilData;
            Console.WriteLine("Test");
        }
    }
}
