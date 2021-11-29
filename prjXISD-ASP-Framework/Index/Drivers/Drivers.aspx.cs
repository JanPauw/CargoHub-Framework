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
    public partial class Drivers : System.Web.UI.Page
    {
        private EmpList emps = new EmpList();
        private UserList users = new UserList();
        private TruckList trucks = new TruckList();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDrivers();

                //Get selected Cust ID from URL passthrough
                if (!String.IsNullOrWhiteSpace(Request.QueryString["empNum"]))
                {
                    string num = Request.QueryString["empNum"];
                    LoadFields(num);
                    LoadTrucks(num);
                }
            }
        }

        public void LoadFields(string num)
        {
            Employee e = emps.List().Where(x => x.empNum == num).FirstOrDefault();

            txtEmpName.Text = e.empName;
            txtContactNum.Text = e.empContact;
            txtEmpNum.Text = e.empNum;
        }

        public void LoadTrucks(string num)
        {
            //StringBuilder to build InnerH
            StringBuilder sb = new StringBuilder();

            sb.Append("<ul>");

            foreach (Truck t in trucks.List().Where(x => x.empNum == num).ToList())
            {
                sb.Append("<li>");
                sb.Append("<div class=\"listItem\">");
                sb.Append("<div style=\"width: 70%; display: inline-block\">");
                sb.Append($"<h3>Reg: {t.vehRegNum}</h3>");
                sb.Append($"<p>");
                sb.Append($"Type: {t.vehType}");
                sb.Append($"<br />");
                sb.Append($"Odometer: {t.vehOdoReading}");
                sb.Append($"</p>");
                sb.Append("</div>");
                sb.Append("<div style=\"width: 30%; float: right;\">");
                sb.Append($"<a href=\"/Index/Trucks/Trucks?reg={t.vehRegNum}\">");
                sb.Append("<img src=\"../../Images/info-icon.png\" />");
                sb.Append("</a>");
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("</li>");
            }

            sb.Append("</ul>");

            divTruck.InnerHtml = sb.ToString();
        }

        public void LoadDrivers()
        {
            string num = "";

            //Get selected Cust ID from URL passthrough
            if (!String.IsNullOrWhiteSpace(Request.QueryString["empNum"]))
            {
                num = Request.QueryString["empNum"];
            }

            //StringBuilder to build InnerH
            StringBuilder sb = new StringBuilder();

            sb.Append("<ul>");

            //Add Registered Drivers to Display List
            foreach (Employee e in emps.List().Where(x => x.empRole == "Driver").ToList())
            {
                User u = users.List().Where(x => x.EmpNum == e.empNum).FirstOrDefault();

                if (u != null)
                {
                    sb.Append($"<a href=\"/Index/Drivers/Drivers?empNum={u.EmpNum}\">");
                    sb.Append("<li>");

                    if (u.EmpNum == num)
                    {
                        sb.Append("<div class=\"listDriver\" style=\"box-shadow: 0px 0px 10px #FF7A38 !important;\">");
                    }
                    else
                    {
                        sb.Append("<div class=\"listDriver\">");
                    }

                    sb.Append("<div>");
                    sb.Append($"<h3>{u.EmpNum} | {emps.List(u.EmpNum)[0].empName}</h3>");
                    sb.Append("</div>");
                    sb.Append("</div>");
                    sb.Append("</li>");
                    sb.Append("</a>");
                }
                else
                {
                    sb.Append($"<a href=\"/Index/Drivers/Drivers?empNum={e.empNum}\">");
                    sb.Append("<li>");

                    if (e.empNum == num)
                    {
                        sb.Append("<div class=\"listDriver\" style=\"box-shadow: 0px 0px 10px #FF7A38 !important;\">");
                    }
                    else
                    {
                        sb.Append("<div class=\"listDriver\">");
                    }

                    sb.Append("<div>");
                    sb.Append($"<h3 style=\"color: #fc3503 !important\">{e.empNum} | {e.empName}</h3>");
                    sb.Append("</div>");
                    sb.Append("</div>");
                    sb.Append("</li>");
                    sb.Append("</a>");
                }
            }

            sb.Append("</ul>");

            divDrivers.InnerHtml = sb.ToString();
        }

        protected void btnAddTruck_Click(object sender, EventArgs e)
        {
            //Get selected Cust ID from URL passthrough
            if (!String.IsNullOrWhiteSpace(Request.QueryString["empNum"]))
            {
                string num = Request.QueryString["empNum"];
                Response.Redirect($"/Index/Trucks/Add?empNum={num}");
                return;
            }
            else
            {
                alert("Please select a Driver First.");
                return;
            }
        }

        //Browser Alert Method - To Display "MessageBox" type content.
        public void alert(string message)
        {
            Response.Write($"<script>alert('{message}')</script>");
        }

    }
}