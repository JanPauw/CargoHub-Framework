using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjXISD_Lib_Framework;

namespace prjXISD_ASP_Framework
{
    public partial class Timesheet : System.Web.UI.Page
    {
        private EmpList emps = new EmpList();
        private UserList users = new UserList();
        private static Connection c = new Connection();

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = c.conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadEmployees();

                if (Request.QueryString["empNum"] != null)
                {
                    BindData();
                }
            }
        }

        public void BindData()
        {
            string num = "";

            if (Request.QueryString["empNum"] != null)
            {
                num = Request.QueryString["empNum"];

                cmd.CommandText =
                    $"Select empNum AS [Employee Number], workDate AS [Date Worked], workHours AS [Hours Worked] " +
                    $"from tblTimesheet WHERE empNum = '{num}' " +
                    $"ORDER BY workDate DESC";
                cmd.Connection = conn;
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                conn.Open();
                cmd.ExecuteNonQuery();
                grdTimeSheet.DataSource = ds;
                grdTimeSheet.DataBind();
                conn.Close();
            }
        }

        public void LoadEmployees()
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
            foreach (Employee e in emps.List().Where(x => !String.IsNullOrWhiteSpace(x.empNum)).ToList())
            {
                User u = users.List().Where(x => x.EmpNum == e.empNum).FirstOrDefault();

                if (u != null)
                {


                    sb.Append($"<a href=\"/Index/Timesheet/Timesheet?empNum={u.EmpNum}\">");
                    sb.Append("<li>");

                    if (u.EmpNum == num)
                    {
                        sb.Append("<div class=\"listItem\" style=\"box-shadow: 0px 0px 10px #FF7A38 !important;\">");
                    }
                    else
                    {
                        sb.Append("<div class=\"listItem\">");
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
                    sb.Append($"<a href=\"/Index/Timesheet/Timesheet?empNum={e.empNum}\">");
                    sb.Append("<li>");

                    if (e.empNum == num)
                    {
                        sb.Append("<div class=\"listItem\" style=\"box-shadow: 0px 0px 10px #FF7A38 !important;\">");
                    }
                    else
                    {
                        sb.Append("<div class=\"listItem\">");
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

            divEmployees.InnerHtml = sb.ToString();
        }

        protected void btnAddHours_Click(object sender, EventArgs e)
        {
            string num = "";

            if (Request.QueryString["empNum"] != null)
            {
                num = Request.QueryString["empNum"];

                SqlCommand command = new
                            SqlCommand("INSERT INTO tblTimesheet (empNum, workDate, workHours) " +
                                       "VALUES(@empNum, @workDate, @workHours) ;", conn);
                command.Parameters.AddWithValue("@empNum", num);
                command.Parameters.AddWithValue("@workDate", calWorkDate.SelectedDate.Date);
                command.Parameters.AddWithValue("@workHours", txtHours.Text);

                conn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.InsertCommand = command;
                adapter.InsertCommand.ExecuteNonQuery();
                adapter.Dispose();

                conn.Close();

                Response.Redirect(Request.RawUrl);
            }
            else
            {
                alert("Invalid Employee Selection! Please select an Employee.");
            }
        }

        //Browser Alert Method - To Display "MessageBox" type content.
        public void alert(string message)
        {
            Response.Write($"<script>alert('{message}')</script>");
        }
    }
}