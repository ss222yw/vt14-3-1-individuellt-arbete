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
        //Privat fält
        private Service _service;
        //Egenskap
        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }



        protected void Page_Load(object sender, EventArgs e)
        {

            // Om det finns något meddelande så hämtas det
            MessageLiteral.Text = Page.GetTempData("Message") as string;
            MessagePanel.Visible = !String.IsNullOrWhiteSpace(MessageLiteral.Text);
        }




        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        //Tr emot id som skickas för att hämta caradid.
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




        //Tar emot id som skcikas för att hämta carbrand via caradid. 
        public  CarBrand GetCarBrandByCarAdID([RouteData] int id)
        {
            Service service = new Service();

            return service.GetCarBrandByCarAdID(id);

        }
        public CarBrand GetCarBrandByCarAdID1([RouteData] int id)
        {
            Service service = new Service();

            return service.GetCarBrandByCarAdID(id);
        }

        //Via catcha carbrand så hämtar carbrand som har samma id som finns i carad och i slutet så skriver ut den.
        protected void CarBrandListView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            var listing = sender as DropDownList;
            if (listing != null)
            {
                var carBrand = (CarBrand)e.Item.DataItem;

                var carBrandID = Service.GetCarBrand().Single(ct => ct.CarBrandID == carBrand.CarBrandID);

                listing.Text = String.Format(listing.Text, carBrand.BrandName);
            }
        }
       
    }
}