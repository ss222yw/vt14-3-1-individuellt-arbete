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

        ////privat fällt
        //private CarBrandDAL _CarBrandDAL;

        //privat fällt
        private UserDAL _UserDAL;

        // Ett CarAdDAL-objekt skapas först då det behövs för första gången.
        private CarAdDAL CarAdDAL
        {
            get { return _CarAdDAL ?? (_CarAdDAL = new CarAdDAL()); }
        }

        //// Ett CarBrandDAL-objekt skapas först då det behövs för första gången.
        //private CarBrandDAL CarBrandDAL
        //{
        //    get { return _CarBrandDAL ?? (_CarBrandDAL = new CarBrandDAL()); }
        //}

        // Ett UserDAL-objekt skapas först då det behövs för första gången.
        private UserDAL UserDAL
        {
            get { return _UserDAL ?? (_UserDAL = new UserDAL()); }
        }





        // Tar bort specifierad UserUppgifter ur databasen.
        public void DeleteUser(int UserID)
        {
            UserDAL.DeleteUser(UserID);
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

        public void SaveUser(User user)
        {
            // Contact-objektet sparas antingen genom att en ny post 
            // skapas eller genom att en befintlig post uppdateras.
            if (user.UserID == 0)
            {
                UserDAL.InsertUser(user);
            }
            else
            {
                UserDAL.UpdateUser(user);
            }
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
    }
}