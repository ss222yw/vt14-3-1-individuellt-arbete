using ss222yw_Projekt.Model.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ss222yw_Projekt.Model
{
    public class Service
    {
        //Privat fält
        private CarAdDAL _CarAdDAL;

        //privat fällt
        private CarBrandDAL _CarBrandDAL;

        //privat fällt
        private UserDAL _UserDAL;

        // Ett CarAdDAL-objekt skapas först då det behövs för första gången.
        private CarAdDAL CarAdDAL
        {
            get { return _CarAdDAL ?? (_CarAdDAL = new CarAdDAL()); }
        }

        // Ett CarBrandDAL-objekt skapas först då det behövs för första gången.
        private CarBrandDAL CarBrandDAL
        {
            get { return _CarBrandDAL ?? (_CarBrandDAL = new CarBrandDAL()); }
        }

        // Ett UserDAL-objekt skapas först då det behövs för första gången.
        private UserDAL UserDAL
        {
            get { return _UserDAL ?? (_UserDAL = new UserDAL()); }
        }


        // Hämtar CarBrand med ett specifikt nummer från databasen.
        //public CarBrand GetCarBrandByID(int carBrandID)
        //{
        //    return CarBrandDAL.GetCarBrandByID(carBrandID);
        //}


        // Tar bort specifierad CarBrandUppgifter ur databasen.
        public void DeleteCarBrand(int CarBrandID)
        {
            CarBrandDAL.DeleteCarBrand(CarBrandID);
        }

        // Hämtar User med ett specifikt nummer från databasen.
        public User GetUserByID(int userID)
        {
            return UserDAL.GetUserByID(userID);
        }

        // Hämtar alla User som finns lagrade i databasen.
        public IEnumerable<User> GetUsers()
        {
            return UserDAL.GetUser();
        }

        public void SaveCarBrand(CarBrand carBrand)
        {
            // Contact-objektet sparas antingen genom att en ny post 
            // skapas eller genom att en befintlig post uppdateras.
            if (carBrand.CarBrandID == 0)
            {
                CarBrandDAL.InsertCarBrand(carBrand);
            }
            else
            {
                CarBrandDAL.UpdateCarBrand(carBrand);
            }
        }



        /// Hämtar alla CarBrands.
        public IEnumerable<CarBrand> GetCarBrand(bool refresh = false)
        {
            // Försöker hämta lista med CarBrands från cachen.
            var carBrands = HttpContext.Current.Cache["CarBrand"] as IEnumerable<CarBrand>;

            // Om det inte finns det en lista med CarBrands...
            if (carBrands == null || refresh)
            {
                // ...hämtar då lista med CarBrands...
                carBrands = CarBrandDAL.GetCarBrand();

                // ...och cachar dessa. List-objektet, inklusive alla User-objekt, kommer att cachas 
                // under 10 minuter, varefter de automatiskt avallokeras från webbserverns primärminne.
                HttpContext.Current.Cache.Insert("CarBrand", carBrands, null, DateTime.Now.AddMinutes(10), TimeSpan.Zero);
            }

            // Returnerar listan med CarBrands.
            return carBrands;
        }



        // Tar bort specifierad CarAdUppgifter ur databasen.
        public void DeleteCarAd(int carAdID)
        {
            CarAdDAL.DeleteCarAd(carAdID);
        }

        // Hämtar CarAd med ett specifikt nummer från databasen.
        public CarAd GetCarAdByID(int carAdID)
        {
            return CarAdDAL.GetCarAdByID(carAdID);
        }

        // Hämtar alla CarAd som finns lagrade i databasen.
        public IEnumerable<CarAd> GetCarAds()
        {
            return CarAdDAL.GetCarAds();
        }

        //Spara CarAd efter uppdatering eller Insert.
        public void SaveCarAd(CarAd carAd)
        {
            // Contact-objektet sparas antingen genom att en ny post 
            // skapas eller genom att en befintlig post uppdateras.
            if (carAd.CarAdID == 0)
            {
                CarAdDAL.InsertCarAd(carAd);
            }
            else
            {
                CarAdDAL.UpdateCarAd(carAd);
            }
        }


        //public List<CarBrand> GetCarBrandByCarAdID(int caradID)
        //{
        //    return CarBrandDAL.GetCarBrandByCarAdID(caradID);
        //}
    }
}