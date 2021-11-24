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
        private Order order = null;
        private Customer customer = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProvinces();
                LoadDepots();
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
                dropCustomer.Items.Add("| 0" + c.custID + " | " + c.custName);
            }

            dropCustomer.Items.Add("Add New Customer");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../../Index/Orders/Orders");
            return;
        }

        protected void btnSaveCustomer_Click(object sender, EventArgs e)
        {
            //Selected Index.
            int index = dropCustomer.SelectedIndex;
            Session["sIndex"] = index;
            int last = dropCustomer.Items.Count - 1;
            int first = 0;

            //Checks if First Option is selected | None Selected
            if (index == first)
            {
                alert("Please select a valid customer or add a new one!");
                return;
            }

            //Checks if selection falls inbetween first and last options | Existing Customer Selected
            if (index > first && index < last)
            {
                //Get customer object from index.
                Customer c = customers.List()[index - 1];

                //Sets new values to customer object
                c.custName = txtCustName.Text;
                c.custAddress = txtAddress.Text;
                c.custProvince = dropProvince.SelectedValue;
                c.custEmail = txtCustEmail.Text;
                c.custNum = txtCustNum.Text;

                #region Validation
                //Email Validation
                if (!IsValidEmail(c))
                {
                    alert("Invalid Email! Please check the email field and try again.");
                    txtCustEmail.Focus();
                    return;
                }

                //Phone Num Validation
                if (!IsValidPhone(c))
                {
                    alert("Invalid Phone Number! Please check the phone number field and try again.");
                    txtCustNum.Focus();
                    return;
                }

                //If email is already in the DB
                if (!IsNewEmail(c))
                {
                    alert("This Email is already in our system! Check Customer list for Client Name and Surname");
                    txtCustEmail.Focus();
                    return;
                }

                //If cell is already in the DB
                if (!IsNewNumber(c))
                {
                    alert("This Phone Number is already in our system! Check Customer list for Client Name and Surname");
                    txtCustNum.Focus();
                    return;
                }
                #endregion

                //Save new data to existing customer in DB
                customers.UpdateCustomer(c);

                alert("SUCCESS | Customer details updated!");
                return;
            }

            //Checks if last option is selected | To add new Customer
            if (index == last)
            {
                //Create new Customer to add to DB
                Customer c = new Customer();

                //Set new Customer Fields
                c.custName = txtCustName.Text;
                c.custAddress = txtAddress.Text;
                c.custProvince = dropProvince.SelectedValue;
                c.custEmail = txtCustEmail.Text;
                c.custNum = txtCustNum.Text;

                #region Validation
                //Email Validation
                if (!IsValidEmail(c))
                {
                    alert("Invalid Email! Please check the email field and try again.");
                    txtCustEmail.Focus();
                    return;
                }

                //Phone Num Validation
                if (!IsValidPhone(c))
                {
                    alert("Invalid Phone Number! Please check the phone number field and try again.");
                    txtCustNum.Focus();
                    return;
                }

                //If email is already in the DB
                if (!IsNewEmail(c))
                {
                    alert("This Email is already in our system! Check Customer list for Client Name and Surname");
                    txtCustEmail.Focus();
                    return;
                }

                //If cell is already in the DB
                if (!IsNewNumber(c))
                {
                    alert("This Phone Number is already in our system! Check Customer list for Client Name and Surname");
                    txtCustNum.Focus();
                    return;
                }
                #endregion

                //Add to DB
                customers.AddToDB(c);

                alert("SUCCESS | Customer added to the database | " + customer.custName);
                return;
            }
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

        //Browser Alert Method - To Display "MessageBox" type content.
        public void alert(string message)
        {
            Response.Write($"<script>alert('{message}')</script>");
        }

        //populates fields with selected customer's details
        public void PopulateCustFields(int index)
        {
            //Last option: Add new Customer
            int last = (dropCustomer.Items.Count - 1);

            if (index < 1 || index > last - 1) //If selection is outside of Customer List
            {
                txtAddress.Text = "";
                txtCustName.Text = "";
                txtCustEmail.Text = "";
                txtCustNum.Text = "";
                dropProvince.SelectedIndex = 0;
                return;
            }
            else //If selection is within the Customer List.
            {
                //Remove first default option.
                index--;

                //Get customer object from index.
                Customer c = customers.List()[index];

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

        protected void dropCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["sIndex"] = dropCustomer.SelectedIndex;
            PopulateCustFields((int)Session["sIndex"]);
        }

        #region Customer Input Validation
        //Email Validation (Method from StackOverflow | https://stackoverflow.com/a/1374644)
        public bool IsValidEmail(Customer c)
        {
            string email = c.custEmail;

            if (email.Trim().EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public bool IsValidPhone(Customer c)
        {
            //Check Length of Number
            if (c.custNum.Length != 10)
            {
                return false;
            }

            //Passed all checks | returns true | Valid Phone Number
            return true;
        }

        //Check DB for existing email
        public bool IsNewEmail(Customer c)
        {
            //List variable to use in LINQ
            List<Customer> cl = customers.List();

            var lQuery = from cust in cl
                         where cust.custEmail == c.custEmail
                         select cust;

            return (lQuery.FirstOrDefault() == null);
        }

        //Check DB for existing cell number
        public bool IsNewNumber(Customer c)
        {
            //List variable to use in LINQ
            List<Customer> cl = customers.List();

            var lQuery = from cust in cl
                         where cust.custNum == c.custNum
                         select cust;

            return (lQuery.FirstOrDefault() == null);
        }
        #endregion

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

        protected void btnAddOrder_Click(object sender, EventArgs e)
        {
            #region Customer Details
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
            //<Customer ID>
            oTemp.ordDate = DateTime.Now;
            oTemp.ordStatus = "Un-assigned";
            #endregion
        }
    }
}