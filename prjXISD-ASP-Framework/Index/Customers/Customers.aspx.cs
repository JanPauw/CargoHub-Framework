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
            if (!IsPostBack)
            {
                LoadCustomers();
                LoadProvinces();

                HideCustFields();

                if (!String.IsNullOrWhiteSpace(Request.QueryString["custID"]))
                {
                    int id = Convert.ToInt32(Request.QueryString["custID"]);

                    if (customers.List().Where(x => x.custID == id).FirstOrDefault() != null)
                    {
                        ShowCustFields();
                        PopulateCustFields(id);
                        LoadOrders();
                    }
                }
            }
        }

        //Hide Customer Fields
        public void HideCustFields()
        {
            tblDetails.Visible = false;

            btnDelete.Visible = false;
            btnSave.Visible = false;
        }

        //Show Customer Fields
        public void ShowCustFields()
        {
            tblDetails.Visible = true;

            btnDelete.Visible = true;
            btnSave.Visible = true;
        }

        //Load Customers onot Page List
        public void LoadCustomers()
        {
            int id = -1;

            //Get selected Cust ID from URL passthrough
            if (!String.IsNullOrWhiteSpace(Request.QueryString["custID"]))
            {
                id = Convert.ToInt32(Request.QueryString["custID"]);
            }

            //StringBuilder to build InnerH
            StringBuilder sb = new StringBuilder();

            sb.Append("<ul>");

            foreach (Customer c in customers.List())
            {
                sb.Append($"<a href=\"/Index/Customers/Customers?custID={c.custID}\">");
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

            divCustList.InnerHtml = sb.ToString();
        }

        //Load Selected Customer's Orders
        public void LoadOrders()
        {
            if (!String.IsNullOrWhiteSpace(Request.QueryString["custID"]))
            {
                string id = Request.QueryString["custID"];

                #region <ul> HTMl Generation
                //StringBuilder to build InnerH
                StringBuilder sb = new StringBuilder();

                sb.Append("<ul>");

                foreach (Order o in orders.List(id))
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
                    sb.Append($"</a>");
                    sb.Append("</div>");
                    sb.Append("</div>");
                    sb.Append("</li>");
                }

                sb.Append("</ul>");

                divOrderList.InnerHtml = sb.ToString();
                #endregion
            }
        }

        //Add a customer
        protected void btnAddCust_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Index/Customers/Add");
        }

        //Loads dropdown list with provinces
        public void LoadProvinces()
        {
            dropProvince.Items.Add("Eastern Cape");
            dropProvince.Items.Add("Free State");
            dropProvince.Items.Add("Gauteng");
            dropProvince.Items.Add("KwaZulu-Natal");
            dropProvince.Items.Add("Limpopo");
            dropProvince.Items.Add("Mpumalanga");
            dropProvince.Items.Add("Northern Cape");
            dropProvince.Items.Add("North West");
            dropProvince.Items.Add("Western Cape");
        }

        //populates fields with selected customer's details
        public void PopulateCustFields(int id)
        {
            //Get customer object from index.
            Customer c = customers.List().Where(x => x.custID == id).FirstOrDefault();

            if (c != null)
            {
                //Set TextBoxes to selected customer.
                txtAddress.Text = c.custAddress;
                txtCustName.Text = c.custName;
                txtCustNum.Text = c.custNum;
                txtCustEmail.Text = c.custEmail;
                dropProvince.SelectedIndex = 0;

                //Selecting matching province.
                for (int i = 0; i < 9; i++)
                {
                    if (dropProvince.Items[i].ToString() == c.custProvince)
                    {
                        dropProvince.SelectedIndex = i;
                    }
                }
            }
        }

        //Browser Alert Method - To Display "MessageBox" type content.
        public void alert(string message)
        {
            Response.Write($"<script>alert('{message}')</script>");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //Get selected Cust ID from URL passthrough
            int id = Convert.ToInt32(Request.QueryString["custID"]);

            //Temp cutsomer to store in DB
            Customer cTemp = customers.List().Where(x => x.custID == id).FirstOrDefault();

            //Setting new Details
            cTemp.custName = txtCustName.Text;
            cTemp.custAddress = txtCustNum.Text;
            cTemp.custEmail = txtCustEmail.Text;
            cTemp.custNum = txtCustNum.Text;
            cTemp.custProvince = dropProvince.SelectedValue;

            customers.UpdateCustomer(cTemp);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //Get selected Cust ID from URL passthrough
            int id = Convert.ToInt32(Request.QueryString["custID"]);

            //Temp cutsomer to store in DB
            Customer cTemp = customers.List().Where(x => x.custID == id).FirstOrDefault();

            customers.DeleteCustomer(cTemp);

            alert($"{cTemp.custName} has been deleted from the client list!");
            Response.Redirect("/Index/Customers/Customers");
            return;
        }
    }
}
