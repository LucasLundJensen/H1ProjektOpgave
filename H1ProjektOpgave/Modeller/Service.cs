using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1ProjektOpgave.Modeller
{
    class Service
    {
        private int opholdID;

        public int OpholdID
        {
            get { return opholdID; }
            set { opholdID = value; }
        }

        private int bilID_fk;

        public int BilID_fk
        {
            get { return bilID_fk; }
            set { bilID_fk = value; }
        }

        private string værkstedsopholdDato;

        public string VærkstedsopholdDato
        {
            get { return værkstedsopholdDato; }
            set { værkstedsopholdDato = value; }
        }


        public static string Create(int BilID, string OpholdOprettelsesDato)
        {
            string Creation = ("INSERT INTO Værkstedsophold(BilID_fk, VærkstedsopholdDato) " + "Values('" + BilID + "', '" + OpholdOprettelsesDato + "');");

            try
            {
                DBController.CRUD(Creation);
                return Convert.ToString("Værksteds ophold er nu oprettet for bilen: " + BilID);

            }
            catch (Exception e)
            {
                return Convert.ToString("Error: " + e);
            }
        }

        public static string Delete(int OpholdID)
        {
            string Deletion = "DELETE FROM Værkstedsophold WHERE OpholdID=";
            string ServiceLookup = "select * from Værkstedsophold WHERE OpholdID=";
            DataTable opholdDataTabel = DBController.Select(ServiceLookup + OpholdID);
            try
            {
                DBController.CRUD(Deletion + OpholdID);
                return Convert.ToString("Ophold " + opholdDataTabel.Rows[0]["OpholdID"].ToString() + " er nu slettet.");

            }
            catch (Exception)
            {
                return Convert.ToString("Opholdet blev ikke fundet");
            }
        }

        public static string Update(int OpholdID, string option, string value)
        {
            if (option == "1")
            {
                string sql = "UPDATE Værkstedsophold SET BilID_fk=";
                try
                {
                    DBController.CRUD(sql + Convert.ToInt32(value) + " WHERE OpholdID=" + OpholdID);
                    return OpholdID + " er opdateret med ny bil: " + value;
                }
                catch (Exception)
                {
                    return "Der skete en fejl, det kunne være forkert input";
                }
            }
            else if (option == "2")
            {
                string sql = "UPDATE Værkstedsophold SET VærkstedsopholdDato=";
                try
                {
                    DBController.CRUD(sql + "'" + value + "'" + " WHERE OpholdID=" + OpholdID);
                    return OpholdID + " er opdateret med ny værkstedsopholds dato: " + value;
                }
                catch (Exception)
                {
                    return "Der skete en fejl, det kunne være forkert input";
                }
            }
            else
            {
                return "Ikke en valid mulighed, prøv igen.";
            }
        }

        public static string ShowOphold(int OpholdID)
        {
            string Selection = "select * from Værkstedsophold WHERE OpholdID=";
            string opholdData = string.Empty;
            DataTable opholdDataTable = DBController.Select(Selection + OpholdID);
            for (int i = 0; i < opholdDataTable.Rows.Count; i++)
            {
                Modeller.Service nyService = new Modeller.Service()
                {
                    OpholdID = Convert.ToInt32(opholdDataTable.Rows[i]["OpholdID"]),
                    BilID_fk = Convert.ToInt32(opholdDataTable.Rows[i]["BilID_fk"]),
                    VærkstedsopholdDato = opholdDataTable.Rows[i]["VærkstedsopholdDato"].ToString(),

                };
                opholdData = opholdData + "OpholdID: " + nyService.OpholdID + "\nBil Ejer: " + nyService.BilID_fk + "\nVærksteds Ophold: " + nyService.VærkstedsopholdDato;
            }
            return opholdData;
        }
    }
}
