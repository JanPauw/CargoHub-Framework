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
    public partial class Trucks : System.Web.UI.Page
    {
        private EmpList emps = new EmpList();
        private UserList users = new UserList();
        private TruckList trucks = new TruckList();
        private string num = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Get selected Cust ID from URL passthrough
                if (!String.IsNullOrWhiteSpace(Request.QueryString["reg"]))
                {
                    num = Request.QueryString["reg"];
                    LoadDetails();
                }

                LoadTrucks();
            }
        }

        public void LoadTrucks()
        {
            if (!String.IsNullOrWhiteSpace(Request.QueryString["reg"]))
            {
                num = Request.QueryString["reg"];
            }

            //StringBuilder to build InnerH
            StringBuilder sb = new StringBuilder();

            sb.Append("<ul>");

            foreach (Truck t in trucks.List())
            {
                sb.Append("<li>");
                sb.Append($"<a href=\"/Index/Trucks/Trucks?reg={t.vehRegNum}\">");

                if (t.vehRegNum == num)
                {
                    sb.Append("<div style=\"box-shadow: 0px 0px 10px #FF7A38 !important;\" class=\"listItem\">");
                }
                else
                {
                    sb.Append("<div class=\"listItem\">");
                }

                sb.Append("<div style=\"width: 70%; display: inline-block\">");
                sb.Append($"<h3>Reg: {t.vehRegNum}</h3>");
                sb.Append($"<p>");
                sb.Append($"Type: {t.vehType}");
                sb.Append($"<br />");
                sb.Append($"Odometer: {t.vehOdoReading}");
                sb.Append($"</p>");
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("</a>");
                sb.Append("</li>");
            }

            sb.Append("</ul>");

            divTrucks.InnerHtml = sb.ToString();
        }

        public void LoadDetails()
        {
            if (!String.IsNullOrWhiteSpace(Request.QueryString["reg"]))
            {
                num = Request.QueryString["reg"];

                Truck t = trucks.List().Where(x => x.vehRegNum == num).FirstOrDefault();

                txtEmpNum.Text = t.empNum;
                txtEngineSize.Text = t.vehEngineSize;
                txtManufacturer.Text = t.vehManufacturer;
                txtOdometer.Text = t.vehOdoReading;
                txtVehReg.Text = t.vehRegNum;

                for (int i = 0; i < selTruckType.Items.Count; i++)
                {
                    if (selTruckType.Items[i].Value == t.vehType)
                    {
                        selTruckType.SelectedIndex = i;
                        break;
                    }
                }
            }
        }
    }
}