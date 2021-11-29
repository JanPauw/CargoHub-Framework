using prjXISD_Lib_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjXISD_ASP_Framework.Index.Trucks
{
    public partial class Add : System.Web.UI.Page
    {
        private TruckList trucks = new TruckList();
        private string num = "";

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
                    Response.Redirect("/Index/Trucks/Trucks");
                    return;
                }

                //Get selected Cust ID from URL passthrough
                if (!String.IsNullOrWhiteSpace(Request.QueryString["empNum"]))
                {
                    num = Request.QueryString["empNum"];
                    txtEmpNum.Text = num;
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

        protected void btnAddTruck_Click(object sender, EventArgs e)
        {
            //Get selected Cust ID from URL passthrough
            if (!String.IsNullOrWhiteSpace(Request.QueryString["empNum"]))
            {
                num = Request.QueryString["empNum"];


                Truck t = new Truck();

                t.vehRegNum = txtVehReg.Text;
                t.vehType = selTruckType.Items[selTruckType.SelectedIndex].Value;
                t.vehManufacturer = txtManufacturer.Text;
                t.vehEngineSize = txtEngineSize.Text;
                t.vehOdoReading = txtOdometer.Text;

                int nextService = Convert.ToInt32(txtOdometer.Text) + 20000;
                t.vehNextService = nextService.ToString();

                t.empNum = num;
                t.vehStatus = "At Depot";

                trucks.AddToDB(t);
            }

            Response.Redirect(Session["PrevPage"].ToString());
            return;
        }



        //Browser Alert Method - To Display "MessageBox" type content.
        public void alert(string message)
        {
            Response.Write($"<script>alert('{message}')</script>");
        }
    }
}