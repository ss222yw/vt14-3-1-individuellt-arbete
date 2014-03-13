using ss222yw_Projekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ss222yw_Projekt.Pages.CarAdPages
{
    public partial class Create : System.Web.UI.Page
    {


        private Service _service;


        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        //protected void Page_Load(object sender, EventArgs e)
        //{

        //}

        public void CarAdFormView_InsertItem(CarAd carAd)
        {
    
            if (ModelState.IsValid)
            {
                try
                {
                    Service service = new Service();
                    service.SaveCarAd(carAd);

                    Response.RedirectToRoute("CarAdDetails", new { id = carAd.CarAdID });
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Fel inträffade då Bilannonsen skulle läggas till.");
                }

            }
        }


        public IEnumerable<CarBrand> CarBrandMethod_GetData()
        {
            Service service = new Service();
          return service.GetCarBrand();

        }

    }
}