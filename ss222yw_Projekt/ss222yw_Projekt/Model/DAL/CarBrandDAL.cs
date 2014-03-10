using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ss222yw_Projekt.Model.DAL
{
    public class CarBrandDAL : DALBase
    {
        // Hämtar alla kontakttyper i databasen.
        public IEnumerable<CarBrand> GetCarBrand()
        {
            // Skapar ett anslutningsobjekt.
            using (var conn = CreateConnection())
            {
                try
                {
                    // Skapar och initierar ett SqlCommand-objekt som används till att 
                    // exekveras specifierad lagrad procedur.
                    var cmd = new SqlCommand("appschema.usp_GetCarBrand", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Skapar det List-objekt som initialt har plats för 20 referenser till ContactType-objekt.
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
                            // Hämtar ut datat för en post. Använder GetXxx-metoder - vilken beror av typen av data.
                            // Du måste känna till SQL-satsen för att kunna välja rätt GetXxx-metod.
                            carBrands.Add(new CarBrand
                            {
                                CarBrandID = reader.GetInt32(CarBrandIDIndex),
                                BrandName = reader.GetString(BrandNameIndex),

                            });
                        }
                    }


                    //Avallokerar minne som inte används.
                    carBrands.TrimExcess();

                    // Returnerar referensen till List-objektet med referenser med ContactType-objekt.
                    return carBrands;
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("An error occured while getting CarBrand from the database.");
                }
            }
        }
    }
}