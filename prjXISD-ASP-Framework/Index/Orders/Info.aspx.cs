using prjXISD_Lib_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjXISD_ASP_Framework.Index.Orders
{
    public partial class Info : System.Web.UI.Page
    {
        private OrderList orders = new OrderList();
        private CustomerList customers = new CustomerList();

        //Order and Customer used on this Page
        Order oTemp = null;
        Customer cTemp = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Get Back Button URL
                if (Request.UrlReferrer != null)
                {
                    Session["PrevPage"] = Request.UrlReferrer.ToString();
                }
                else
                {
                    Response.Redirect("/Index/Orders/Orders");
                    return;
                }

                //Get Selected Order and it's Customer
                if (!String.IsNullOrWhiteSpace(Request.QueryString["ordNum"]))
                {
                    string num = Request.QueryString["ordNum"];

                    oTemp = orders.List().Where(x => x.ordNum == num).FirstOrDefault();
                    cTemp = customers.List().Where(x => x.custID == Convert.ToInt32(oTemp.custID)).FirstOrDefault();

                    LoadFields();
                }
                else
                {
                    Response.Redirect(Session["PrevPage"].ToString());
                    return;
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Session["PrevPage"].ToString());
            return;
        }



        //Browser Alert Method - To Display "MessageBox" type content.
        public void alert(string message)
        {
            Response.Write($"<script>alert('{message}')</script>");
        }

        public void LoadFields()
        {
            //Cargo Description and Weight
            txtCargoDesc.Text = oTemp.ordCargo;
            txtCargoWeight.Text = oTemp.ordQuantity.ToString();

            //Depot Dropdowns
            for (int i = 0; i < 9; i++)
            {
                if (oTemp.fromDepot == fromDepot.Items[i].ToString())
                {
                    fromDepot.SelectedIndex = i;
                }

                if (oTemp.toDepot == toDepot.Items[i].ToString())
                {
                    toDepot.SelectedIndex = i;
                }
            }
        }

        protected void btnUpdateOrder_Click(object sender, EventArgs e)
        {
            //Get Selected Order and it's Customer
            if (oTemp == null)
            {
                string num = Request.QueryString["ordNum"];

                oTemp = orders.List().Where(x => x.ordNum == num).FirstOrDefault();
            }

            oTemp.ordCargo = txtCargoDesc.Text;
            oTemp.ordQuantity = Convert.ToInt32(txtCargoWeight.Text);
            oTemp.fromDepot = fromDepot.Items[fromDepot.SelectedIndex].ToString();
            oTemp.toDepot = toDepot.Items[toDepot.SelectedIndex].ToString();

            orders.UpdateOrder(oTemp);

            Response.Redirect(Session["PrevPage"].ToString());
            alert("Order Updated Successfully!");
            return;
        }
    }
}