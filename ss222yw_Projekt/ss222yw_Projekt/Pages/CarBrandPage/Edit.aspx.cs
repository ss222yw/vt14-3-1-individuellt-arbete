using ss222yw_Projekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ss222yw_Projekt.Pages.CarBrandPage
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Om det finns något meddelande i extension-metoden så hämtas det
            MessageLiteral.Text = Page.GetTempData("Message") as string;
            MessagePanel.Visible = !String.IsNullOrWhiteSpace(MessageLiteral.Text);
        }


        private Service _service;


        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }


        // The id parameter name should match the DataKeyNames value set on the control
        public void CarBrandFormView_UpdateItem(CarBrand carBrand)
        {
            try
            {

                // Load the item here, e.g. item = MyDataLayer.Find(id);
                if (carBrand == null)
                {
                    // The item wasn't found
                    ModelState.AddModelError(String.Empty, String.Format("Item with id {0} was not found", carBrand));
                    return;
                }

                if (TryUpdateModel(carBrand))
                {
                    // Save changes here, e.g. MyDataLayer.SaveChanges();
                    Service.SaveCarBrand(carBrand);
                    Page.SetTempData("Message", "Bilmärken har uppdateras.");
                    Response.RedirectToRoute("EditCarBrand");
                    Context.ApplicationInstance.CompleteRequest();

                }

            }
            catch
            {
                Page.ModelState.AddModelError(String.Empty, "Fel då skulle bilmärken uppdateras.");
            }
        }

        public IEnumerable<CarBrand> CarAdFormView_GetItem()
        {
            Service service = new Service();

            return service.GetCarBrand();


        }

    }
}