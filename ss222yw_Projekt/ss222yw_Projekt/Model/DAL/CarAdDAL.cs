using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ss222yw_Projekt.Model.DAL
{
    public class CarAdDAL : DALBase
    {

        //Hämtar alla CarAdS i databasen.
        public IEnumerable<CarAd> GetCarAd()
        {
            //Skapar ett anslutningsobjekt.
            using (var conn = CreateConnection())
            {
                try
                {
                    // Skapar det List-objekt som initialt har plats för 100 referenser till CarAd-objekt.
                    var carAds = new List<CarAd>(100);

                    // Skapar ett SqlCommand-objekt för att exekvera specifierad lagrad procedur. 
                    var cmd = new SqlCommand("appSchema.usp_GetCarAd", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Öppnar anslutningen till databasen.
                    conn.Open();


                    //skapar ett SqlDataReader-objekt och returnerar en referens till objektet.
                    using (var reader = cmd.ExecuteReader())
                    {
                        var carAdIDIndex = reader.GetOrdinal("CarAdID");
                        var headerIndex = reader.GetOrdinal("Header");
                        var carBrandIDIndex = reader.GetOrdinal("CarBrandID");
                        var userIDIndex = reader.GetOrdinal("UserID");
                        var modelYearIndex = reader.GetOrdinal("ModelYear");
                        var carColorIndex = reader.GetOrdinal("CarColor");
                        var priceIndex = reader.GetOrdinal("Price");
                        var descriptionIndex = reader.GetOrdinal("Description");


                        // Så länge som det finns poster att läsa returnerar Read true annars false.
                        while (reader.Read())
                        {
                            // Hämtar ut datat för en post.
                            carAds.Add(new CarAd
                            {
                                CarAdID = reader.GetInt32(carAdIDIndex),
                                Header = reader.GetString(headerIndex),
                                CarBrandID = reader.GetInt32(carBrandIDIndex),
                                UserID = reader.GetInt32(userIDIndex),
                                ModelYear = reader.GetString(modelYearIndex),
                                CarColor = reader.GetString(carColorIndex),
                                Price = reader.GetDouble(priceIndex),
                                Description = reader.GetString(descriptionIndex)
                            });
                        }

                    }

                    //avallokerar minne som inte används.
                    carAds.TrimExcess();

                    // Returnerar referensen till List-objektet.
                    return carAds;
                }
                catch
                {
                    throw new ApplicationException("An error occured while getting Users from the database.");

                }
            }

        }



        // Hämtar CarAd en i taget .
        public CarAd GetCarAdByID(int carAdID)
        {
            //Skapar en anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar ett SqlCommand-objekt för att exekvera specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("appSchema.usp_GetCarAdByID", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Lägger till den paramter den lagrade proceduren kräver.
                    cmd.Parameters.Add("@CarAdID", SqlDbType.Int, 4).Value = carAdID;

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    // Skapar ett SqlDataReader-objekt och returnerar en referens till objektet.
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Tar reda på vilket index de olika kolumnerna har.
                            var carAdIDIndex = reader.GetOrdinal("CarAdID");
                            var headerIndex = reader.GetOrdinal("Header");
                            var carBrandIDIndex = reader.GetOrdinal("CarBrandID");
                            var userIDIndex = reader.GetOrdinal("UserID");
                            var modelYearIndex = reader.GetOrdinal("ModelYear");
                            var carColorIndex = reader.GetOrdinal("CarColor");
                            var priceIndex = reader.GetOrdinal("Price");
                            var descriptionIndex = reader.GetOrdinal("Description");

                            // Returnerar referensen till de skapade CarAd-objektet.
                            return new CarAd
                            {
                                CarAdID = reader.GetInt32(carAdIDIndex),
                                Header = reader.GetString(headerIndex),
                                CarBrandID = reader.GetInt32(carBrandIDIndex),
                                UserID = reader.GetInt32(userIDIndex),
                                ModelYear = reader.GetString(modelYearIndex),
                                CarColor = reader.GetString(carColorIndex),
                                Price = reader.GetDouble(priceIndex),
                                Description = reader.GetString(descriptionIndex)
                            };
                        }
                    }
                    return null;
                }

                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }



        //Skapar en ny CarAd i tabellen CarAd.
        public void InsertCarAd(CarAd carAd)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar ett SqlCommand-objekt för att exekvera specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("appSchema.usp_InsertCarAd", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till de paramterar den lagrade proceduren kräver.
                    cmd.Parameters.Add("@Header", SqlDbType.VarChar, 25).Value = carAd.Header;
                    cmd.Parameters.Add("@CarColor", SqlDbType.VarChar, 25).Value = carAd.CarColor;
                    cmd.Parameters.Add("@ModelYear", SqlDbType.Char, 4).Value = carAd.ModelYear;
                    cmd.Parameters.Add("@Description", SqlDbType.VarChar, 500).Value = carAd.Description;
                    cmd.Parameters.Add("@Price", SqlDbType.Decimal, 2).Value = carAd.Price;
                    cmd.Parameters.Add("@UserID", SqlDbType.Int, 4).Value = carAd.UserID;
                    cmd.Parameters.Add("CarBrand", SqlDbType.TinyInt, 1).Value = carAd.CarBrandID;

                    // Lägger till de paramterar den lagrade proceduren kräver.
                    cmd.Parameters.Add("@CarAdID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    // Den lagrade proceduren innehåller en INSERT-sats och returnerar inga poster varför metoden 
                    // ExecuteNonQuery används för att exekvera den lagrade proceduren
                    cmd.ExecuteNonQuery();

                    // Hämtar primärnyckelns värde för den nya posten och tilldelar CarAd-objektet värdet.
                    carAd.CarAdID = (int)cmd.Parameters["@CarAdID"].Value;
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }


        //Uppdaterar en CarAd i tabellen CarAd.
        public void UpdateCarAd(CarAd carAd)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar ett SqlCommand-objekt för att exekvera specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("appSchema.usp_UpdateCarAd", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till de paramterar den lagrade proceduren kräver.
                    cmd.Parameters.Add("@Header", SqlDbType.VarChar, 25).Value = carAd.Header;
                    cmd.Parameters.Add("@CarColor", SqlDbType.VarChar, 25).Value = carAd.CarColor;
                    cmd.Parameters.Add("@ModelYear", SqlDbType.Char, 4).Value = carAd.ModelYear;
                    cmd.Parameters.Add("@Description", SqlDbType.VarChar, 500).Value = carAd.Description;
                    cmd.Parameters.Add("@Price", SqlDbType.Decimal, 2).Value = carAd.Price;
                    cmd.Parameters.Add("@UserID", SqlDbType.Int, 4).Value = carAd.UserID;
                    cmd.Parameters.Add("CarBrand", SqlDbType.TinyInt, 1).Value = carAd.CarBrandID;

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    // Den lagrade proceduren innehåller en INSERT-sats och returnerar inga poster varför metoden 
                    // ExecuteNonQuery används för att exekvera den lagrade proceduren
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }

        //Tar bort en CarAd .
        public void DeleteCarAd(int CarAdID)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar ett SqlCommand-objekt för att exekvera specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("appSchema.usp_DeleteCarAd", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till den paramter den lagrade proceduren kräver.
                    cmd.Parameters.Add("@CarAdID", SqlDbType.Int, 4).Value = CarAdID;

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    // Den lagrade proceduren innehåller en INSERT-sats och returnerar inga poster varför metoden 
                    // ExecuteNonQuery används för att exekvera den lagrade proceduren
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }
    }
}