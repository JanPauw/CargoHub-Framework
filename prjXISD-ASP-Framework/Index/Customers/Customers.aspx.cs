using prjXISD_Lib_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjXISD_ASP_Framework
{
    public partial class Customers : System.Web.UI.Page
    {
        private OrderList orders = new OrderList();
        private CustomerList customers = new CustomerList();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void LoadCustomers()
        {
            StringBuilder sb = new StringBuilder();
            
            foreach (Customer c in customers.List())
            {
                sb.Append(
                    "<li>" +
                    "<div class=\"listItem\">" +
                    "<div>" +
                    $"<h3>| 0{c.custID} | {c.custName}</h3>" +
                    "</div>" +
                    "</div>" +
                    "</li>");
            }


        }
    }
}