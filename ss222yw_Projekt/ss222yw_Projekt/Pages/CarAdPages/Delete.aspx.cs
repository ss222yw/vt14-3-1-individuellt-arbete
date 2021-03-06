﻿using ss222yw_Projekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ss222yw_Projekt.Pages.CarAdPages
{
    public partial class Delete : System.Web.UI.Page
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
            CancelHyperLink.NavigateUrl = GetRouteUrl("CarAdDetails", new { id = Id });

            if (!IsPostBack)
            {
                try
                {
                    var carAd = Service.GetCarAdByID(Id);

                     if (carAd != null)
                    {
                        CarAdName.Text = carAd.Header;
                        return;
                    }

          
                    ModelState.AddModelError(String.Empty,
                        String.Format("bilannonsen med bilannosnummer {0} hittades inte.", Id));
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Fel inträffade då bilannosnen hämtades inför borttagning.");
                }

                ConfirmationPlaceHolder.Visible = false;
                DeleteLinkButton.Visible = false;
            }
        }
        //Hämtar Routdara värde för att kunna nå den.
        protected int Id
        {
            get { return int.Parse(RouteData.Values["id"].ToString()); }
        }

        // Ta bort.
        protected void DeleteLinkButton_Command(object sender, CommandEventArgs e)
        {
            try
            {
                var iD = int.Parse(e.CommandArgument.ToString());
                Service.DeleteCarAd(iD);
                var id1= int.Parse(RouteData.Values["id1"].ToString());
                Page.SetTempData("Message", "Bilannonsen togs bort.");
                Response.RedirectToRoute("CarAd", new { id= id1 });
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då bilannonsen skulle tas bort.");
            }
        }
    }
}