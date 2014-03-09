using ss222yw_SellYourCarFast.Model.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ss222yw_SellYourCarFast.Model
{
    public class Service
    {
        private CarAdDAL _CarAdDAL;

        private CarBrandDAL _CarBrandDAL;

        private UserDAL _UserDAL;


        private CarAdDAL CarAdDAL
        {
            get { return _CarAdDAL ?? (_CarAdDAL = new CarAdDAL()); }
        }

        private CarBrandDAL CarBrandDAL
        {
            get { return _CarBrandDAL ?? (_CarBrandDAL = new CarBrandDAL()); }
        }

        private UserDAL UserDAL
        {
            get { return _UserDAL ?? (_UserDAL = new UserDAL()); }
        }
    }
}