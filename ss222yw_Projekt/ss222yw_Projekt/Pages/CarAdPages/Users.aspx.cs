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
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public IEnumerable<User> UserMethod_GetData()
        {
            Service service = new Service();
            return service.GetUsers();

        }


     

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public IEnumerable<CarAd> CarAdFormView_GetItem()
        {
            
            Service service = new Service();
            return service.GetCarAds();
        }
        // Klick button för att kunna veta  vilken user som valt för att logga in .
        protected void Button1_Click(object sender, EventArgs e)
        {
            var userIDs = 0;
            DropDownList cb = (DropDownList)CarAdFormView.FindControl("UserDropDownList");
            foreach (ListItem bm in cb.Items)
            {
                if (bm.Selected)
                {
                    userIDs = int.Parse(bm.Value);

                }

            }
            Response.RedirectToRoute("CarAd", new { id = userIDs });

        }

     }

    }
