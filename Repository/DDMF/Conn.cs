﻿using System.Data.SqlClient;

namespace Repository
{
    public static class Conn
    {
        // Koden kan bruges fridt så længe denne tekst bliver i toppen af filen.
        // Copyright 2016 E-train I/S, Udviklet af Henrik Obsen

        /// <summary>
        /// Metoden indeholder formindelsesindstillinger til databaen
        /// </summary>
        /// <returns>Retunere en MS SQL connection string</returns>
        public static SqlConnection GetCon()
        {
            SqlConnection con = new SqlConnection("server=mssql8.unoeuro.com;database=lassewormark_com_db;uid=lasseworma_com;pwd=x2k2mm23;MultipleActiveResultSets=True");
            return con;
        }

        /// <summary>
        /// Metoden retunere en åben forbindelse til databasen der er defineret i GetCon()
        /// </summary>
        /// <returns>Retunere en åben forbindelse til databasen</returns>
        public static SqlConnection CreateConnection()
        {
            var cn = GetCon();
            cn.Open();
            return cn;
        }
    }
}


