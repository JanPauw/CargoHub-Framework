using System;
using System.Collections.Generic;
using System.Linq;
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
        private Order order = new Order();
        private Customer customer = new Customer();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProvinces();
                LoadCustDropdown();
            }
            else
            {

            }
        }

        //Populate Dropdown with Customers
        public void LoadCustDropdown()
        {
            dropCustomer.Items.Clear();

            dropCustomer.Items.Add("Select Customer...");

            foreach (var c in customers.List())
            {
                dropCustomer.Items.Add(c.custNum + " " + c.custName);
            }

            dropCustomer.Items.Add("Add New Customer");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../../Index/Orders/Orders");
            return;
        }

        protected void btnSaveOrder_Click(object sender, EventArgs e)
        {
            order.ordCargo = txtCargoDesc.Text;
            order.ordQuantity = Convert.ToInt32(txtCargoWeight.Text);
            order.toDepot = dropToDepot.SelectedValue;
            order.fromDepot = dropFromDepot.SelectedValue;
            order.ordDate = DateTime.Now;
            order.ordStatus = "Un-assigned";
        }

        protected void btnSaveCustomer_Click(object sender, EventArgs e)
        {
            //Checks if the correct option is chosen to add a new cutsomer
            if (dropCustomer.SelectedIndex == dropCustomer.Items.Count - 1)
            {
                Customer c = new Customer();

                c.custName = txtCustName.Text;
                c.custAddress = txtAddress.Text;
                c.custProvince = dropProvince.SelectedValue;
                c.custEmail = txtCustEmail.Text;
                c.custNum = txtCustNum.Text;

                customers.AddToDB(c);
                alert("SUCCESS | Customer added to the database!");
                return;
            }

            if (dropCustomer.SelectedIndex == 0)
            {
                alert("Please select a valid customer or add a new one!");
                return;
            }
        }

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

        //Browser Alert Method - To Display "MessageBox" type content.
        public void alert(string message)
        {
            Response.Write($"<script>alert('{message}')</script>");
        }

        public void PopulateCustFields(int index)
        {
            //Alter Index to filter out top and bottom dropdown options.
            switch (index)
            {
                case 0:
                    break;
                default:
                    index--;

                    alert(index.ToString());

                    ////Get customer object from index.
                    //Customer c = customers.Get(index);

                    //txtAddress.Text = c.custAddress;
                    //txtCustName.Text = c.custName;
                    //txtCustNum.Text = c.custNum;
                    //txtCustEmail.Text = c.custEmail;
                    //dropProvince.SelectedIndex = 0;

                    ////Selecting matching province.
                    //for (int i = 0; i < 9; i++)
                    //{
                    //    if (dropProvince.Items[i].ToString() == c.custProvince)
                    //    {
                    //        dropProvince.SelectedIndex = i;
                    //    }
                    //}
                    break;
            }
        }

        protected void dropCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateCustFields(dropCustomer.SelectedIndex);
        }
    }
}