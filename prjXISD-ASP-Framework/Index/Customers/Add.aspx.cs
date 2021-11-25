using prjXISD_Lib_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjXISD_ASP_Framework.Index.Customers
{
    public partial class Add : System.Web.UI.Page
    {
        //List Variables
        private CustomerList customers = new CustomerList();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProvinces();
            }
            else
            {

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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../../Index/Customers/Customers");
            return;
        }

        protected void btnAddCust_Click(object sender, EventArgs e)
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
            //Name Validation
            if (String.IsNullOrWhiteSpace(c.custName))
            {
                alert("Invalid Name! Please check the name field and try again.");
                txtCustName.Focus();
                return;
            }

            //Address Validation
            if (String.IsNullOrWhiteSpace(c.custAddress))
            {
                alert("Invalid Address! Please check the address field and try again.");
                txtAddress.Focus();
                return;
            }

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

            alert("SUCCESS | Customer added to the database | " + c.custName);
            return;

        }

        //Browser Alert Method - To Display "MessageBox" type content.
        public void alert(string message)
        {
            Response.Write($"<script>alert('{message}')</script>");
        }


    }
}