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
    public partial class Edit : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {

            get { return _service ?? (_service = new Service()); }
        }

        public int CarBrandID { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Om det finns något meddelande i extension-metoden så hämtas det
            MessageLiteral.Text = Page.GetTempData("Message") as string;
            MessagePanel.Visible = !String.IsNullOrWhiteSpace(MessageLiteral.Text);
        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public ss222yw_Projekt.Model.CarAd CarAdFormView_GetItem([RouteData]int id)
        {
            try
            {
                return Service.GetCarAdByID(id);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då Bilannonsen hämtades vid redigering.");
                return null;
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void CarAdFormView_UpdateItem(CarAd carAd)
        {

            var carBrandsIDs = 0;

            DropDownList cb = (DropDownList)CarAdFormView.FindControl("DropDownList1");
            foreach (ListItem bm in cb.Items)
            {
                if (bm.Selected)
                {
                    carBrandsIDs = int.Parse(bm.Value);

                }
            }
            try
            {

                if (carAd == null)
                {
                    // The item wasn't found
                    ModelState.AddModelError(String.Empty, String.Format("CarAd with id {0} was not found", carAd));
                    return;
                }

                if (TryUpdateModel(carAd))
                {
                    carAd.CarBrandID = CarBrandID;
                    Service.SaveCarAd(carAd, carBrandsIDs);
                    Page.SetTempData("Message", "Bilannonsen har uppdaterats.");
                    Response.RedirectToRoute("CarAdDetails", new { id = carAd.CarAdID });
                    Context.ApplicationInstance.CompleteRequest();


                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då bilannonsen skulle uppdateras.");
            }
        }



        public IEnumerable<CarBrand> EditGetCarBrands()
        {
            return Service.GetCarBrand();
        }

    }
}