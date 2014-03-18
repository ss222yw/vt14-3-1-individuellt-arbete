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
        protected void Page_Load(object sender, EventArgs e)
        {
            // Om det finns något meddelande så hämtas det
            MessageLiteral.Text = Page.GetTempData("Message") as string;
            MessagePanel.Visible = !String.IsNullOrWhiteSpace(MessageLiteral.Text);
        }

        // Privat fält
        private Service _service;   

        // Egenskap som skapar ny objekt ifall det behövs.
        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        //Anropa service för att hämta data för alla bilmärkerna.
        public int CarBrandID { get; set; }
        public IEnumerable<CarBrand> CarBrandMethod_GetData()
        {
            Service service = new Service();
            return service.GetCarBrand();
       
        }


        // Lägga till nya bilannonser.
        public void CarAdFormView_InsertItem(CarAd carAd)
        {
            //DropDownList för att hitta rättt dropdownlist och sen kolla nogga vilket bilmärka man har valt.
            var carBrandsIDs = 0;
            DropDownList cb = (DropDownList)CarAdFormView.FindControl("CarBrandDropDownList");
            foreach (ListItem bm in cb.Items)
            {
                if (bm.Selected)
                {
                    // int sen lägger den .
                     carBrandsIDs = int.Parse(bm.Value);
                    
                }
            }
            if (ModelState.IsValid)
            {
                try
                {
                    Service service = new Service();
                    carAd.CarBrandID = CarBrandID;
                    service.SaveCarAd(carAd, carBrandsIDs);
                    Page.SetTempData("Message", "Bilannonsen har lades till.");
                    Response.RedirectToRoute("CarAdDetails", new { id = carAd.CarAdID });
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Fel inträffade då Bilannonsen skulle läggas till.");
                }

            }
        }

    }
}