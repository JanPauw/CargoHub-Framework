using prjXISD_Lib_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjXISD_ASP_Framework.Index.Orders
{
    public partial class Info : System.Web.UI.Page
    {
        private OrderList orders = new OrderList();
        private CustomerList customers = new CustomerList();
        private EmpList emps = new EmpList();
        private UserList users = new UserList();

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
                    LoadDrivers();
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

        public void LoadDrivers()
        {
            string num;

            if (!String.IsNullOrWhiteSpace(Request.QueryString["ordNum"]))
            {
                num = Request.QueryString["ordNum"];
            }

            if (true)
            {

            }

            selDrivers.Items.Clear();
            int count = -1;

            selDrivers.Items.Add("Un-Assigned");
            count++;

            foreach (Employee e in emps.List().Where(x => x.empRole == "Driver").ToList())
            {
                selDrivers.Items.Add(e.empName);
                count++;
                selDrivers.Items[count].Value = e.empNum;
            }

            for (int i = 0; i < selDrivers.Items.Count; i++)
            {
                if (selDrivers.Items[i].Value == oTemp.empNum)
                {
                    selDrivers.SelectedIndex = i;
                }
            }
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

            for (int i = 0; i < selStatus.Items.Count; i++)
            {
                if (selStatus.Items[i].Value == oTemp.ordStatus)
                {
                    selStatus.SelectedIndex = i;
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //Get Selected Order
            if (oTemp == null)
            {
                string num = Request.QueryString["ordNum"];

                oTemp = orders.List().Where(x => x.ordNum == num).FirstOrDefault();
            }

            if (selDrivers.SelectedIndex > 0)
            {
                oTemp.empNum = selDrivers.Items[selDrivers.SelectedIndex].Value;
                oTemp.ordStatus = selStatus.Items[selStatus.SelectedIndex].Value;

                orders.UpdateOrder(oTemp);

                Response.Redirect(Session["PrevPage"].ToString());
                return;
            }
            else
            {
                alert("Please select a driver!");
                return;
            }
        }
    }
}