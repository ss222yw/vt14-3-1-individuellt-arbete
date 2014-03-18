using ss222yw_Projekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ss222yw_Projekt.Pages.CarBrandPage
{
    public partial class Delete : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        public int CarBrandID { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            CancelHyperLink.NavigateUrl = GetRouteUrl("CarAdCreate");

            if (!IsPostBack)
            {
                try
                {
                    var carBrand = Service.GetCarBrandByID(Id);
                    if (carBrand != null)
                    {
                        CarBrandName.Text = carBrand.BrandName;
                        return;
                    }


                    ModelState.AddModelError(String.Empty,
                        String.Format("Bilmärken med nummert {0} hittades inte.", Id));
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Fel inträffade då bilmärken hämtades inför borttagning.");
                }

                ConfirmationPlaceHolder.Visible = false;
                DeleteLinkButton.Visible = false;
            }
        }

        protected int Id
        {
            get { return int.Parse(RouteData.Values["id"].ToString()); }
        }

        protected void DeleteLinkButton_Command(object sender, CommandEventArgs e)
        {

            try
            {

                var id = int.Parse(e.CommandArgument.ToString());
                Service.DeleteCarBrand(id);

                Page.SetTempData("Message", "Bilmärken togs bort.");
                Response.RedirectToRoute("EditCarBrand");
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då bilmärken skulle tas bort.");
            }
        }
    }
}