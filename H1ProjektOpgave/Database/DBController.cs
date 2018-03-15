using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace H1ProjektOpgave
{
    class DBController
    {
        //Connection to database
        private static string databaseConnection = "Server= localhost; Database=H1;Integrated Security=SSPI;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //Database Functions
        public static void CRUD(string sql)
        {
            using (SqlConnection con = new SqlConnection(databaseConnection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public static DataTable Select(string sql)
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(databaseConnection))
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                adapter.Fill(table);
            }

            return table;
        }


    }
}
