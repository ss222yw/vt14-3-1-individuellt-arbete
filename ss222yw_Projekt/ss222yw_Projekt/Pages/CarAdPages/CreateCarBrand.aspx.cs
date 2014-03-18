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
    public partial class CreateCarBrand : System.Web.UI.Page
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

        // Lägga till bilmärke 
        public void ListView_InsertItem(CarBrand carBrand)
        {
            if (Page.ModelState.IsValid)
            {
                try
                {
                    Service.SaveCarBrand(carBrand);
                    Page.SetTempData("Message", "Bilmärken har lades till.");
                    Response.RedirectToRoute("CareateCarBrand");
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Fel inträffade då Bilmärken skulle läggas till.");
                }
            }
        }

        public IEnumerable<CarBrand> CarAdFormView_GetItem()
        {
            Service service = new Service();

            return service.GetCarBrand();


        }

    }
}