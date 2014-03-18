using ss222yw_Projekt.Model.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ss222yw_Projekt.Model
{
    public class Service
    {
        //Privat fält
        private CarAdDAL _CarAdDAL;

        // Ett CarAdDAL-objekt skapas först då det behövs för första gången.
        private CarAdDAL CarAdDAL
        {
            get { return _CarAdDAL ?? (_CarAdDAL = new CarAdDAL()); }
        }

        //privat fällt
        private CarBrandDAL _CarBrandDAL;

        // Ett CarBrandDAL-objekt skapas först då det behövs för första gången.
        private CarBrandDAL CarBrandDAL
        {
            get { return _CarBrandDAL ?? (_CarBrandDAL = new CarBrandDAL()); }
        }

        //privat fällt
        private UserDAL _UserDAL;

        // Ett UserDAL-objekt skapas först då det behövs för första gången.
        private UserDAL UserDAL
        {
            get { return _UserDAL ?? (_UserDAL = new UserDAL()); }
        }






        // Hämtar CarBrand med ett specifikt nummer från databasen.
        public CarBrand GetCarBrandByID(int id)
        {
            return CarBrandDAL.GetCarBrandByID(id);
        }


        // Tar bort specifierad CarBrandUppgifter ur databasen.
        public void DeleteCarBrand(int CarBrandID)
        {
            CarBrandDAL.DeleteCarBrand(CarBrandID);
        }

        public void SaveCarBrand(CarBrand carBrand)
        {
            // Validering på affärslogiklagret
            ICollection<ValidationResult> validationResults;
            if (!carBrand.Validate(out validationResults))
            {
                // kastas ett undantag med ett allmänt felmeddelande samt en referens till samlingen med resultat av valideringen
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }
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


        /// Hämtar alla Users och catchar dom för 10 min så det sparas i asp och inte behöva anropa connectiong för database.
        public IEnumerable<User> GetUser(bool refresh = false)
        {
            // Försöker hämta lista med CarBrands från cachen.
            var users = HttpContext.Current.Cache["User"] as IEnumerable<User>;

            // Om det inte finns det en lista med CarBrands...
            if (users == null || refresh)
            {
                // ...hämtar då lista med CarBrands...
                users = UserDAL.GetUser();

                // ...och cachar dessa. List-objektet, inklusive alla User-objekt, kommer att cachas 
                // under 10 minuter, varefter de automatiskt avallokeras från webbserverns primärminne.
                HttpContext.Current.Cache.Insert("User", users, null, DateTime.Now.AddMinutes(10), TimeSpan.Zero);
            }

            // Returnerar listan med CarBrands.
            return users;
        }









        // Hämtar User med ett specifikt nummer från databasen.
        public User GetUserByID(int userID)
        {
            return UserDAL.GetUserByID(userID);
        }

        // Hämtar alla CarBrand som finns lagrade i databasen.
        public IEnumerable<CarBrand> GetCarBrand()
        {
            return CarBrandDAL.GetCarBrand();
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
        public void SaveCarAd(CarAd carAd, int id)
        {
            // Validering på affärslogiklagret
            ICollection<ValidationResult> validationResults;
            if (!carAd.Validate(out validationResults))
            {
                // kastas ett undantag med ett allmänt felmeddelande samt en referens till samlingen med resultat av valideringen
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }
            // CarAd-objektet sparas antingen genom att en ny post 
            // skapas eller genom att en befintlig post uppdateras.
            if (carAd.CarAdID == 0)
            {
                CarAdDAL.InsertCarAd(carAd, id);
            }
            else
            {
                CarAdDAL.UpdateCarAd(carAd, id);
            }
        }






        public CarBrand GetCarBrandByCarAdID(int id)
        {
            return CarBrandDAL.GetCarBrandByCarAdID(id);
        }


        public List<CarAd> GetCarAdByUserID(int id)
        {
            return CarAdDAL.GetCarAdByUserID(id);
        }
    }
}