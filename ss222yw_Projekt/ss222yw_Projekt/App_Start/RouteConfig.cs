using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace ss222yw_Projekt.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("Logga", "HomePage", "~/Pages/CarAdPages/LoggaIn.aspx");

            routes.MapPageRoute("User", "Inloggad", "~/Pages/CarAdPages/Users.aspx");

            routes.MapPageRoute("CarAd", "User/{id}", "~/Pages/CarAdPages/Listning.aspx");

            routes.MapPageRoute("CarAdCreate", "Bilannonser/ny", "~/Pages/CarAdPages/Create.aspx");

            routes.MapPageRoute("CareateCarBrand", "Bilmärke/ny", "~/Pages/CarAdPages/CreateCarBrand.aspx");

            routes.MapPageRoute("CarAdEdit", "Bilannonser/{id}/edit", "~/Pages/CarAdPages/Edit.aspx");

            routes.MapPageRoute("EditCarBrand", "Bilmärke/redigera", "~/Pages/CarBrandPage/Edit.aspx");

            routes.MapPageRoute("CarAdDelete", "Bilannonser/{id}/tabort/{id1}", "~/Pages/CarAdPages/Delete.aspx");

            routes.MapPageRoute("CarAdDetails", "Bilannonser/{id}", "~/Pages/CarAdPages/Details.aspx");

            routes.MapPageRoute("DeleteCarBrand", "Bilmärke/{id}/tabort", "~/Pages/CarBrandPage/Delete.aspx");

            routes.MapPageRoute("Default", "", "~/Pages/CarAdPages/Listning.aspx");

            routes.MapPageRoute("Error", "serverfel", "~/Pages/Shared/Error.aspx");

        }
    }
}
