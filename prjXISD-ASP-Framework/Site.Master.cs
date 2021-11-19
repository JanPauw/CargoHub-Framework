using prjXISD_Lib_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjXISD_ASP_Framework
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Get current page URL
            string path = HttpContext.Current.Request.Url.AbsolutePath;

            //Hide Menu by Default
            divSideMenuTop.Visible = false;
            divSideMenuBot.Visible = false;
            divNotLoggedIn.Visible = true;

            //Not the Login Page
            if (path != "/Index/Login")
            {
                if (Session["user"] == null) //if not logged in
                {
                    Response.Redirect("/Index/Login");
                    return;
                }
                else
                {
                    divSideMenuTop.Visible = true;
                    divSideMenuBot.Visible = true;
                    divNotLoggedIn.Visible = false;
                }
            }

            if (path == "/Index/Login")
            {
                if (Session["user"] != null) //if logged in
                {
                    Response.Redirect("/Index/Orders/Orders");
                    return;
                }
            }
        }
    }
}