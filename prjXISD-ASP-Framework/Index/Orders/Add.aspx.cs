using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjXISD_Lib_Framework;

namespace prjXISD_ASP_Framework.Index.Orders
{
    public partial class Add : System.Web.UI.Page
    {
        //List Variables
        private OrderList orders = new OrderList();
        private CustomerList customers = new CustomerList();

        //Temp Objects to Save
        private Order order = null;
        private Customer customer = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCustomers();
                LoadDepots();

                //Load pre-entered data into textboxes
                if (!String.IsNullOrWhiteSpace(Request.QueryString["custID"]))
                {
                    LoadTempOrder();
                }
            }
            else
            {

            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../../Index/Orders/Orders");
            return;
        }

        //Load Customers onto Page List
        public void LoadCustomers()
        {
            int id = -1;

            //Get selected Cust ID from URL passthrough
            if (!String.IsNullOrWhiteSpace(Request.QueryString["custID"]))
            {
                id = Convert.ToInt32(Request.QueryString["custID"]);
            }

            //StringBuilder to build InnerHtml
            StringBuilder sb = new StringBuilder();

            sb.Append("<ul>");

            foreach (Customer c in customers.List())
            {
                sb.Append($"<a href=\"/Index/Orders/Add?custID={c.custID}\">");
                sb.Append("<li>");

                if (c.custID == id)
                {
                    sb.Append("<div class=\"listItem\" style=\"box-shadow: 0px 0px 10px #FF7A38 !important;\">");
                }
                else
                {
                    sb.Append("<div class=\"listItem\">");
                }

                sb.Append("<div>");
                sb.Append($"<h3>| 0{c.custID} | {c.custName}</h3>");
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("</li>");
                sb.Append("</a>");
            }

            sb.Append("</ul>");

            divCustomers.InnerHtml = sb.ToString();
        }

        //Load Depots
        public void LoadDepots()
        {
            //From Depot Dropdown List
            dropFromDepot.Items.Add("Eastern Cape");
            dropFromDepot.Items.Add("Free State");
            dropFromDepot.Items.Add("Gauteng");
            dropFromDepot.Items.Add("KwaZulu-Natal");
            dropFromDepot.Items.Add("Limpopo");
            dropFromDepot.Items.Add("Mpumalanga");
            dropFromDepot.Items.Add("Northern Cape");
            dropFromDepot.Items.Add("North West");
            dropFromDepot.Items.Add("Western Cape");

            //To Depot Dropdown List
            dropToDepot.Items.Add("Eastern Cape");
            dropToDepot.Items.Add("Free State");
            dropToDepot.Items.Add("Gauteng");
            dropToDepot.Items.Add("KwaZulu-Natal");
            dropToDepot.Items.Add("Limpopo");
            dropToDepot.Items.Add("Mpumalanga");
            dropToDepot.Items.Add("Northern Cape");
            dropToDepot.Items.Add("North West");
            dropToDepot.Items.Add("Western Cape");
        }

        protected void btnAddOrder_Click(object sender, EventArgs e)
        {
            #region Customer Details
            if (!String.IsNullOrWhiteSpace(Request.QueryString["custID"]))
            {
                //Get selected Cust ID from URL passthrough
                int id = Convert.ToInt32(Request.QueryString["custID"]);
                customer = customers.List().Where(x => x.custID == id).FirstOrDefault();
            }

            if (customer == null)
            {
                alert("Please Save/Add Customer Details, before continuing.");
                return;
            }
            #endregion

            #region Order Details
            if (!IsFieldsFilled())
            {
                alert("Please fill all Order Fields");
                return;
            }

            Order oTemp = new Order();

            oTemp.ordNum = orders.OrderNumGen(customer.custName);
            oTemp.ordCargo = txtCargoDesc.Text;
            oTemp.ordQuantity = Convert.ToInt32(txtCargoWeight.Text);
            oTemp.toDepot = dropToDepot.SelectedValue;
            oTemp.fromDepot = dropFromDepot.SelectedValue;
            oTemp.custID = customer.custID.ToString();
            oTemp.ordDate = DateTime.Now;
            oTemp.ordStatus = "Un-assigned";

            orders.AddToDB(oTemp);
            #endregion

            alert("Sucess | Order has been added to the Database!");
            return;
        }

        #region Order Input Validation
        public bool IsFieldsFilled()
        {
            if (String.IsNullOrWhiteSpace(txtCargoDesc.Text))
            {
                return false;
            }

            if (String.IsNullOrWhiteSpace(txtCargoWeight.Text))
            {
                return false;
            }

            return true;
        }
        #endregion

        #region Session Management (Commented Out)

        #region Set Sessions
        protected void txtCargoDesc_TextChanged(object sender, EventArgs e)
        {
            Session["description"] = txtCargoDesc.Text;
        }

        protected void txtCargoWeight_TextChanged(object sender, EventArgs e)
        {
            Session["quantity"] = txtCargoWeight.Text;
        }

        protected void dropFromDepot_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["FromDepot"] = dropFromDepot.SelectedIndex;
        }

        protected void dropToDepot_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ToDepot"] = dropToDepot.SelectedIndex;
        }
        #endregion

        //Clear Sessions
        public void ClearSessions()
        {
            Session["description"] = null;
            Session["quantity"] = null;
            Session["FromDepot"] = null;
            Session["ToDepot"] = null;
        }

        //Load Saved Sessions
        public void LoadTempOrder()
        {
            if (Session["description"] != null)
            {
                txtCargoDesc.Text = Session["description"].ToString();
            }

            if (Session["quantity"] != null)
            {
                txtCargoWeight.Text = Session["quantity"].ToString();
            }

            if (Session["FromDepot"] != null)
            {
                dropFromDepot.SelectedIndex = (int)Session["FromDepot"];
            }

            if (Session["ToDepot"] != null)
            {
                dropToDepot.SelectedIndex = (int)Session["ToDepot"];
            }
        }

        #endregion

        //Browser Alert Method - To Display "MessageBox" type content.
        public void alert(string message)
        {
            Response.Write($"<script>alert('{message}')</script>");
        }
    }
}