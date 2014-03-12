using ss222yw_Projekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ss222yw_Projekt.Pages.CarAdPages
{
    public partial class Details : System.Web.UI.Page
    {

        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

    

        //protected void Page_Load(object sender, EventArgs e)
        //{
            
        //}




        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public CarAd CarAdView_GetItem([RouteData]int id)
        {
            try
            {
                Service service = new Service();
                return service.GetCarAdByID(id);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då CarAd hämtades.");
                return null;
            }
        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public ss222yw_Projekt.Model.User UserFormView_GetItem([RouteData]int id)
        {
            try
            {
                Service service = new Service();
                return service.GetUserByID(id);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då User hämtades.");
                return null;
            }
        }
    }
}