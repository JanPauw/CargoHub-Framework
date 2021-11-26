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
    public partial class Orders : System.Web.UI.Page
    {
        private OrderList orders = new OrderList();
        private CustomerList customers = new CustomerList();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUnAssigned();
                LoadAssigned();
                LoadCompleted();
            }
            else
            {

            }
        }

        protected void btnAddOrder_Click(object sender, EventArgs e)
        {
            Response.Redirect("../../Index/Orders/Add");
            return;
        }

        //Load Selected Customer's Orders
        public void LoadUnAssigned()
        {
            #region <ul> HTMl Generation
            //StringBuilder to build InnerH
            StringBuilder sb = new StringBuilder();

            sb.Append("<ul>");

            List<Order> l = orders.List().Where(x => x.ordStatus == "Un-assigned").ToList();

            foreach (Order o in l)
            {
                sb.Append("<li>");
                sb.Append("<div class=\"listItem\">");
                sb.Append("<div style=\"width: 70%; display: inline-block\">");
                sb.Append($"<h3>Order: {o.ordNum}</h3>");
                sb.Append($"<p>");
                sb.Append($"From: {o.fromDepot}");
                sb.Append($"<br />");
                sb.Append($"To: {o.toDepot}");
                sb.Append($"</p>");
                sb.Append("</div>");
                sb.Append("<div style=\"width: 30%; float: right;\">");
                sb.Append($"<a href=\"/Index/Orders/Info?ordNum={o.ordNum}\">");
                sb.Append("<img src=\"../../Images/info-icon.png\" />");
                sb.Append("</a>");
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("</li>");
            }

            sb.Append("</ul>");

            ordersNA.InnerHtml = sb.ToString();
            #endregion
        }
        
        //Load Selected Customer's Orders
        public void LoadAssigned()
        {
            #region <ul> HTMl Generation
            //StringBuilder to build InnerH
            StringBuilder sb = new StringBuilder();

            sb.Append("<ul>");

            List<Order> l = orders.List().Where(x => x.ordStatus == "Assigned").ToList();

            foreach (Order o in l)
            {
                sb.Append("<li>");
                sb.Append("<div class=\"listItem\">");
                sb.Append("<div style=\"width: 70%; display: inline-block\">");
                sb.Append($"<h3>Order: {o.ordNum}</h3>");
                sb.Append($"<p>");
                sb.Append($"From: {o.fromDepot}");
                sb.Append($"<br />");
                sb.Append($"To: {o.toDepot}");
                sb.Append($"</p>");
                sb.Append("</div>");
                sb.Append("<div style=\"width: 30%; float: right;\">");
                sb.Append($"<a href=\"/Index/Orders/Info?ordNum={o.ordNum}\">");
                sb.Append("<img src=\"../../Images/info-icon.png\" />");
                sb.Append("</a>");
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("</li>");
            }

            sb.Append("</ul>");

            ordersA.InnerHtml = sb.ToString();
            #endregion
        }
        
        //Load Selected Customer's Orders
        public void LoadCompleted()
        {
            #region <ul> HTMl Generation
            //StringBuilder to build InnerH
            StringBuilder sb = new StringBuilder();

            sb.Append("<ul>");

            List<Order> l = orders.List().Where(x => x.ordStatus == "Completed").ToList();

            foreach (Order o in l)
            {
                sb.Append("<li>");
                sb.Append("<div class=\"listItem\">");
                sb.Append("<div style=\"width: 70%; display: inline-block\">");
                sb.Append($"<h3>Order: {o.ordNum}</h3>");
                sb.Append($"<p>");
                sb.Append($"From: {o.fromDepot}");
                sb.Append($"<br />");
                sb.Append($"To: {o.toDepot}");
                sb.Append($"</p>");
                sb.Append("</div>");
                sb.Append("<div style=\"width: 30%; float: right;\">");
                sb.Append($"<a href=\"/Index/Orders/Info?ordNum={o.ordNum}\">");
                sb.Append("<img src=\"../../Images/info-icon.png\" />");
                sb.Append("</a>");
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("</li>");
            }

            sb.Append("</ul>");

            ordersC.InnerHtml = sb.ToString();
            #endregion
        }

        //Browser Alert Method - To Display "MessageBox" type content.
        public void alert(string message)
        {
            Response.Write($"<script>alert('{message}')</script>");
        }
    }
}