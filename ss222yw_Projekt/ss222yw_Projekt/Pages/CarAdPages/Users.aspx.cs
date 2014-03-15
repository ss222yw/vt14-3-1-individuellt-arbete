using ss222yw_Projekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ss222yw_Projekt.Pages.CarAdPages
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }



        public IEnumerable<User> UsersDropDown_GetData()
        {

            Service service = new Service();
            return service.GetUsers();
        }


        public IEnumerable<User> UsersDropDown_GetData1()
        {


            Service service = new Service();

            return service.GetUsers();
        }

    }
}