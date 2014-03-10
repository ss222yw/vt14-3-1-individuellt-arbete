using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace ss222yw_Projekt.Model.DAL
{
    public abstract class DALBase
    {

        //Privat statik Sträng med information som används för att ansluta till "SQL Server"-databasen.
        private static string _connectionString;

        // Initierar statiskt data.
        static DALBase()
        {
            // Hämtar anslutningssträngen från web.config.
            _connectionString = WebConfigurationManager.ConnectionStrings["UD13_ss222yw_SellYourCarFastConnectionString"].ConnectionString;
        }

        //Referens till ett nytt SqlConnection.
        protected SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}