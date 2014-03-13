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



        public IEnumerable<CarBrand> CarBrandMethod_GetData()
        {
            Service service = new Service();
            return service.GetCarBrand();

        }

        //// The id parameter should match the DataKeyNames value set on the control
        //// or be decorated with a value provider attribute, e.g. [QueryString]int id
        //public int CarAdID { get; set; }
        //public IEnumerable<CarBrand> CarBrandFormView_GetItem()
        //{
        //    return Service.GetCarBrandByCarAdID(CarAdID);
        //}

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        //public ss222yw_Projekt.Model.CarBrand CarBrandFormView_GetItem([RouteData]int id)
        //{

        //    try
        //    {
        //        Service service = new Service();
        //        return service.GetCarBrandByCarAdID(id);
        //    }
        //    catch (Exception)
        //    {
        //        ModelState.AddModelError(String.Empty, "Fel inträffade då CarBrand hämtades.");
        //        return null;
        //    }
        //}

        // The id parameter should match the DataKeyNames value set on the control
        //// or be decorated with a value provider attribute, e.g. [QueryString]int id
        //public ss222yw_Projekt.Model.CarBrand CarBrandFormView_GetItem([RouteData]int id)
        //{

        //    try
        //    {
        //        return Service.GetCarBrandByID(id);
        //    }
        //    catch (Exception)
        //    {
        //        ModelState.AddModelError(String.Empty, "Fel inträffade då bilmärken hämtades vid redigering.");
        //        return null;
        //    }
        //}

    }
}