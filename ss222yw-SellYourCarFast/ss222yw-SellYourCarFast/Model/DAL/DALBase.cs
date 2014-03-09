using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace ss222yw_SellYourCarFast.Model.DAL
{
    public abstract class DALBase
    {
        private static string _connectionString;


        static DALBase()
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["UD13_ss222yw_SellYourCarFastConnectionString"].ConnectionString;
        }


        protected SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}