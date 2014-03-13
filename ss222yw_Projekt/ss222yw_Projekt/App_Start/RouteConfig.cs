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
            routes.MapPageRoute("CarAdCreate", "Bilannonser/ny", "~/Pages/CarAdPages/Create.aspx");
            routes.MapPageRoute("CarAdDetails", "Bilannonser/{id}", "~/Pages/CarAdPages/Details.aspx");
            routes.MapPageRoute("CarAdEdit", "Bilannonser/{id}/edit", "~/Pages/CarAdPages/Edit.aspx");
            routes.MapPageRoute("CarAdDelete", "Bilannonser/{id}/tabort", "~/Pages/CarAdPages/Delete.aspx");
            routes.MapPageRoute("Error", "serverfel", "~/Pages/Shared/Error.aspx");
            routes.MapPageRoute("Default", "", "~/Pages/CarAdPages/Listning.aspx");
        }
    }
}