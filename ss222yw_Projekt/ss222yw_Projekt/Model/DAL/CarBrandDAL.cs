﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ss222yw_Projekt.Model.DAL
{
    public class CarBrandDAL : DALBase
    {

        public CarBrand GetCarBrandByCarAdID(int carAdID)
        {
            // Skapar ett anslutningsobjekt.
            using (var conn = CreateConnection())
            {
                try
                {
                    // exekveras specifierad lagrad procedur.
                    var cmd = new SqlCommand("appSchema.usp_GetCarBrandByCarAdID", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CarAdID", carAdID);

                    CarBrand carBrands = new CarBrand();

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    // SqlDataReader-objekt och returnerar en referens till objektet.
                    using (var reader = cmd.ExecuteReader())
                    {

                        var carBrandIDIdIndex = reader.GetOrdinal("CarBrandID");
                        var brandNameIndex = reader.GetOrdinal("BrandName");


                        if (reader.Read())
                        {

                            return (new CarBrand
                            {

                                CarBrandID = reader.GetByte(carBrandIDIdIndex),
                                BrandName = reader.GetString(brandNameIndex)

                            });
                        }
                    }
                    return null;
                }
                catch
                {
                    throw new ApplicationException("Fel! Det gick inte att hämta carbrands via caradid");
                }
            }
        }



        // Hämtar alla CarBrand i databasen.
        public IEnumerable<CarBrand> GetCarBrand()
        {
            // Skapar ett anslutningsobjekt.
            using (var conn = CreateConnection())
            {
                try
                {

                    // exekveras specifierad lagrad procedur.
                    var cmd = new SqlCommand("appschema.usp_GetCarBrand", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Skapar det List-objekt som initialt har plats för 20 referenser till CarBrand-objekt.
                    List<CarBrand> carBrands = new List<CarBrand>(20);

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    // skapar ett SqlDataReader-objekt och returnerar en referens till objektet.
                    using (var reader = cmd.ExecuteReader())
                    {
                        // Tar reda på vilket index de olika kolumnerna har.
                        var CarBrandIDIndex = reader.GetOrdinal("CarBrandID");
                        var BrandNameIndex = reader.GetOrdinal("BrandName");

                        // Så länge som det finns poster att läsa returnerar Read true annars false.
                        while (reader.Read())
                        {

                            carBrands.Add(new CarBrand
                            {
                                CarBrandID = reader.GetByte(CarBrandIDIndex),
                                BrandName = reader.GetString(BrandNameIndex),

                            });
                        }
                    }


                    //Avallokerar minne som inte används.
                    carBrands.TrimExcess();

                    // Returnerar referensen till List-objektet med referenser med CarBrand-objekt.
                    return carBrands;
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("An error occured while getting CarBrand from the database.");
                }
            }
        }






        // Hämtar CarBrand en i taget .
        public CarBrand GetCarBrandByID(int carBrandID)
        {
            //Skapar en anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    //Skapar ett SqlCommand-objekt för att exekvera specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("appSchema.uspGetCarBrandByID", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Lägger till den paramter den lagrade proceduren kräver.
                    cmd.Parameters.Add("@CarBrandID", SqlDbType.TinyInt, 1).Value = carBrandID;


                    //Öppnar anslutningen till databasen.
                    conn.Open();

                    //Skapar ett SqlDataReader-objekt och returnerar en referens till objektet.
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            //Tar reda på vilket index de olika kolumnerna har.
                            var carBrandIDIndex = reader.GetOrdinal("CarBrandID");
                            var brandNameIndex = reader.GetOrdinal("BrandName");


                            //Returnerar referensen till de skapade CarBrand-objektet.
                            return new CarBrand
                            {
                                CarBrandID = reader.GetByte(carBrandIDIndex),
                                BrandName = reader.GetString(brandNameIndex),

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



        //Skapar en ny CarBrand i tabellen CarBrand.
        public void InsertCarBrand(CarBrand carBrand)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar ett SqlCommand-objekt för att exekvera specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("appSchema.uspInsertCarBrand", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till de paramterar den lagrade proceduren kräver.
                    cmd.Parameters.Add("@BrandName", SqlDbType.VarChar, 40).Value = carBrand.BrandName;

                    // Lägger till de paramterar den lagrade proceduren kräver.
                    cmd.Parameters.Add("@CarBrandID", SqlDbType.TinyInt, 1).Direction = ParameterDirection.Output;

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    // Exekvera den lagrade proceduren
                    cmd.ExecuteNonQuery();

                    // Hämtar primärnyckelns värde för den nya posten och tilldelar CarBrand-objektet värdet.
                    carBrand.CarBrandID = (byte)cmd.Parameters["@CarBrandID"].Value;
                }
                catch
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }


        //Uppdaterar en CarBrand i tabellen CarBrand.
        public void UpdateCarBrand(CarBrand carBrand)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar ett SqlCommand-objekt för att exekvera specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("appSchema.uspUpdateCarBrand", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till de paramterar den lagrade proceduren kräver.
                    cmd.Parameters.Add("@BrandName", SqlDbType.VarChar, 40).Value = carBrand.BrandName;
                    cmd.Parameters.Add("@CarBrandID", SqlDbType.TinyInt, 1).Value = carBrand.CarBrandID;
                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    // ExecuteNonQuery används för att exekvera den lagrade proceduren
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }

        //Tar bort en CarBrand .
        public void DeleteCarBrand(int carBrand)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar ett SqlCommand-objekt för att exekvera specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("appSchema.uspDeleteCarBrand", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till den paramter den lagrade proceduren kräver.
                    cmd.Parameters.Add("@CarBrandID", SqlDbType.TinyInt, 1).Value = carBrand;

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
    }
}