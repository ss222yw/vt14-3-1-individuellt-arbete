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

        //Hämtar alla bilannonser i databasen.
        public IEnumerable<CarAd> GetCarAds()
        {
            //Skapar ett anslutningsobjekt.
            using (var conn = CreateConnection())
            {
                try
                {
                    // Skapar det List-objekt som initialt har plats för 100 referenser till CarAd-objeket.
                    var carAds = new List<CarAd>(100);

                    // Skapar ett SqlCommand-objekt för att exekvera specifierad lagrad procedur. 
                    var cmd = new SqlCommand("appSchema.uspGetCarAd", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Öppnar anslutningen till databasen.
                    conn.Open();


                    //skapar ett SqlDataReader-objekt och returnerar en referens till objektet.
                    using (var reader = cmd.ExecuteReader())
                    {
                        var carAdIDIndex = reader.GetOrdinal("CarAdID");
                        var headerIndex = reader.GetOrdinal("Header");
                        var modelYearIndex = reader.GetOrdinal("ModelYear");
                        var carColorIndex = reader.GetOrdinal("CarColor");
                        var priceIndex = reader.GetOrdinal("Price");
                        var descriptionIndex = reader.GetOrdinal("Description");
                        var dateIndex = reader.GetOrdinal("Date");
                        var carBrandIDIndex = reader.GetOrdinal("CarBrandID");
                        var userIDIndex = reader.GetOrdinal("UserID");


                        // Så länge som det finns poster att läsa returnerar Read true annars false.
                        while (reader.Read())
                        {
                            // Hämtar ut datat för en post.
                            carAds.Add(new CarAd
                            {
                                CarAdID = reader.GetInt32(carAdIDIndex),
                                Header = reader.GetString(headerIndex),
                                ModelYear = reader.GetString(modelYearIndex),
                                CarColor = reader.GetString(carColorIndex),
                                Price = reader.GetDecimal(priceIndex),
                                Description = reader.GetString(descriptionIndex),
                                Date = reader.GetDateTime(dateIndex),
                                CarBrandID = reader.GetByte(carBrandIDIndex),
                                UserID = reader.GetInt32(userIDIndex)
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
                    throw new ApplicationException("An error occured while getting CarAd from the database.");

                }
            }

        }



        // Hämtar CarAd en i taget via id.
        public CarAd GetCarAdByID(int carAdID)
        {
            //Skapar en anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar ett SqlCommand-objekt för att exekvera specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("appSchema.uspGetCarAdByID", conn);
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
                            int carAdIDIndex = reader.GetOrdinal("CarAdID");
                            int headerIndex = reader.GetOrdinal("Header");
                            int modelYearIndex = reader.GetOrdinal("ModelYear");
                            int carColorIndex = reader.GetOrdinal("CarColor");
                            int priceIndex = reader.GetOrdinal("Price");
                            int descriptionIndex = reader.GetOrdinal("Description");
                            int dateIndex = reader.GetOrdinal("Date");
                            int userIndex = reader.GetOrdinal("UserID");
                            // Returnerar referensen till de skapade CarAd-objektet.
                            return new CarAd
                            {
                                CarAdID = reader.GetInt32(carAdIDIndex),
                                Header = reader.GetString(headerIndex),
                                ModelYear = reader.GetString(modelYearIndex),
                                CarColor = reader.GetString(carColorIndex),
                                Price = reader.GetDecimal(priceIndex),
                                Description = reader.GetString(descriptionIndex),
                                Date = reader.GetDateTime(dateIndex),
                                UserID = reader.GetInt32(userIndex)
                            };
                        }
                    }
                    return null;
                }

                catch
                {

                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }



        //Skapar en ny CarAd i tabellen CarAd.
        public void InsertCarAd(CarAd carAd, int id)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar ett SqlCommand-objekt för att exekvera specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("appSchema.uspInsertCarAd", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till de paramterar den lagrade proceduren kräver.
                    cmd.Parameters.Add("@Header", SqlDbType.VarChar, 25).Value = carAd.Header;
                    cmd.Parameters.Add("@CarColor", SqlDbType.VarChar, 25).Value = carAd.CarColor;
                    cmd.Parameters.Add("@ModelYear", SqlDbType.Char, 4).Value = carAd.ModelYear;
                    cmd.Parameters.Add("@Description", SqlDbType.VarChar, 500).Value = carAd.Description;
                    cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = carAd.Price;
                    cmd.Parameters.Add("@CarBrandID", SqlDbType.TinyInt, 1).Value = id;
                    // Lägger till de paramterar den lagrade proceduren kräver.
                    cmd.Parameters.Add("@CarAdID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;


                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    // Exekvera den lagrade proceduren
                    cmd.ExecuteNonQuery();

                    // Hämtar primärnyckelns värde för den nya posten och tilldelar CarAd-objektet värdet.
                    carAd.CarAdID = (int)cmd.Parameters["@CarAdID"].Value;

                }
                catch
                {

                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }


        //Uppdaterar en CarAd
        public void UpdateCarAd(CarAd carAd, int id)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar ett SqlCommand-objekt för att exekvera specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("appSchema.uspUpdateCarAd", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till de paramterar den lagrade proceduren kräver.
                    cmd.Parameters.Add("@CarAdID", SqlDbType.Int, 4).Value = carAd.CarAdID;
                    cmd.Parameters.Add("@Header", SqlDbType.VarChar, 25).Value = carAd.Header;
                    cmd.Parameters.Add("@CarColor", SqlDbType.VarChar, 25).Value = carAd.CarColor;
                    cmd.Parameters.Add("@ModelYear", SqlDbType.Char, 4).Value = carAd.ModelYear;
                    cmd.Parameters.Add("@Description", SqlDbType.VarChar, 500).Value = carAd.Description;
                    cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = carAd.Price;
                    cmd.Parameters.Add("@CarBrandID", SqlDbType.TinyInt, 1).Value = id;


                    // Öppnar anslutningen till databasen.
                    conn.Open();

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
        public void DeleteCarAd(int carAdID)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar ett SqlCommand-objekt för att exekvera specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("appSchema.uspDeleteCarAd", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till den paramter den lagrade proceduren kräver.
                    cmd.Parameters.Add("@CarAdID", SqlDbType.Int, 4).Value = carAdID;

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    // Exekvera den lagrade proceduren
                    cmd.ExecuteNonQuery();
                }
                catch
                {

                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }


        }

        //Hämtar Header från User.
        public List<CarAd> GetCarAdByUserID(int userID)
        {
            // Skapar ett anslutningsobjekt.
            using (var conn = CreateConnection())
            {
                try
                {
                    // exekveras specifierad lagrad procedur.
                    var cmd = new SqlCommand("appSchema.uspGetUserByCarAdID", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID", userID);

                    var carAds = new List<CarAd>();

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    // SqlDataReader-objekt och returnerar en referens till objektet.
                    using (var reader = cmd.ExecuteReader())
                    {

                        var userIDIdIndex = reader.GetOrdinal("UserID");
                        var nameIndex = reader.GetOrdinal("Header");
                        var carAdIDIndex = reader.GetOrdinal("CarAdID");


                        while (reader.Read())
                        {

                            carAds.Add(new CarAd
                            {

                                UserID = reader.GetInt32(userIDIdIndex),
                                Header = reader.GetString(nameIndex),
                                CarAdID = reader.GetInt32(carAdIDIndex)

                            });
                        }
                    }
                    return carAds;
                }
                catch
                {
                    throw new ApplicationException("Fel! Det gick inte att hämta USER via caradid");
                }
            }
        }

    }
}