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
    public partial class Listning : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IEnumerable<CarAd> CarAdListView_GetData()
        {
            try
            {
                Service service = new Service();
                return service.GetCarAds();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då Bilannonser hämtades.");
                return null;
            }
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IEnumerable<User> UserListView1_GetData()
        {
            try
            {
                Service service = new Service();
                return service.GetUsers();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då Användaren hämtades.");
                return null;
            }
        }
    }
}