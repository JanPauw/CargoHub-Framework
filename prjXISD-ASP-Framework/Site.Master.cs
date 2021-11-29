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
        private EmpList emps = new EmpList();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Get current page URL
            string path = HttpContext.Current.Request.Url.AbsolutePath;

            //Hide by Default
            orders.Visible = false;
            customers.Visible = false;
            trucks.Visible = false;
            drivers.Visible = false;
            timesheet.Visible = false;
            reporting.Visible = false;
            users.Visible = false;
            account.Visible = true;
            logout.Visible = true;

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

                    User u = (User)Session["user"];
                    Employee emp = emps.List().Where(x => x.empNum == u.EmpNum).FirstOrDefault();

                    showMenus(emp.empRole);
                }
            }

            if (path == "/Index/Login")
            {
                if (Session["user"] != null)
                {
                    Response.Redirect("/Index/Orders/Orders");
                    return;
                }
            }
        }

        public void showMenus(string empRole)
        {
            switch (empRole)
            {
                case "Admin":
                    orders.Visible = true;
                    customers.Visible = true;
                    trucks.Visible = true;
                    drivers.Visible = true;
                    timesheet.Visible = true;
                    reporting.Visible = true;
                    users.Visible = true;
                    return;
                case "Driver":
                    orders.Visible = false;
                    customers.Visible = false;
                    trucks.Visible = true;
                    drivers.Visible = true;
                    timesheet.Visible = false;
                    reporting.Visible = false;
                    users.Visible = false;
                    account.Visible = true;
                    logout.Visible = true;
                    return;
                case "Manager":
                    orders.Visible = true;
                    customers.Visible = true;
                    trucks.Visible = false;
                    drivers.Visible = false;
                    timesheet.Visible = false;
                    reporting.Visible = false;
                    users.Visible = false;
                    account.Visible = true;
                    logout.Visible = true;
                    return;
                case "Timesheet Manager":
                    orders.Visible = false;
                    customers.Visible = false;
                    trucks.Visible = false;
                    drivers.Visible = false;
                    timesheet.Visible = true;
                    reporting.Visible = false;
                    users.Visible = false;
                    account.Visible = true;
                    logout.Visible = true;
                    return;
                case "Service Manager":
                    orders.Visible = false;
                    customers.Visible = false;
                    trucks.Visible = true;
                    drivers.Visible = false;
                    timesheet.Visible = false;
                    reporting.Visible = false;
                    users.Visible = false;
                    account.Visible = true;
                    logout.Visible = true;
                    return;
                case "Trip/Usage Manager":
                    orders.Visible = true;
                    customers.Visible = false;
                    trucks.Visible = true;
                    drivers.Visible = false;
                    timesheet.Visible = false;
                    reporting.Visible = false;
                    users.Visible = false;
                    account.Visible = true;
                    logout.Visible = true;
                    return;
                default:
                    orders.Visible = false;
                    customers.Visible = false;
                    trucks.Visible = false;
                    drivers.Visible = false;
                    timesheet.Visible = false;
                    reporting.Visible = false;
                    users.Visible = false;
                    account.Visible = true;
                    logout.Visible = true;
                    return;
            }
        }
    }
}