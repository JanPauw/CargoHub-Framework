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
    public partial class Users : System.Web.UI.Page
    {
        private EmpList emps = new EmpList();
        private UserList users = new UserList();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUsers();

                //Get selected Cust ID from URL passthrough
                if (!String.IsNullOrWhiteSpace(Request.QueryString["empNum"]))
                {
                    string num = Request.QueryString["empNum"];
                    LoadUserDetails(num);
                }
                else
                {
                    ClearUserDetails();
                }

                ShowHideFields();
            }
            else
            {

            }
        }

        public void LoadUserDetails(string num)
        {
            Employee sEmp = emps.List().Where(x => x.empNum == num).FirstOrDefault();

            txtEmpName.Text = sEmp.empName;
            txtContactNum.Text = sEmp.empContact;
            txtEmpNum.Text = sEmp.empNum;

            for (int i = 0; i < selRoles.Items.Count; i++)
            {
                if (selRoles.Items[i].Value == sEmp.empRole)
                {
                    selRoles.SelectedIndex = i;
                }
            }
        }

        public void ClearUserDetails()
        {
            txtEmpName.Text = "";
            txtContactNum.Text = "";
            txtEmpNum.Text = "";
            selRoles.SelectedIndex = -1;
        }

        public void LoadUsers()
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

            //Add Registered Users to Display List
            foreach (User u in users.List())
            {
                sb.Append($"<a href=\"/Index/Users/Users?empNum={u.EmpNum}\">");
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

            //Add Non-Registered Users to Display list
            foreach (Employee e in emps.List())
            {
                User test = users.List().Where(x => x.EmpNum == e.empNum).FirstOrDefault();

                if (test == null)
                {
                    sb.Append($"<a href=\"/Index/Users/Users?empNum={e.empNum}\">");
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

            divUsers.InnerHtml = sb.ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region Validation
            //Correct Name
            if (String.IsNullOrWhiteSpace(txtEmpName.Text) || !(txtEmpName.Text.Contains(" ")))
            {
                alert("Invalid Name entered! Please try again.");
                txtEmpName.Focus();
                return;
            }

            //Correct Cell Num
            if (String.IsNullOrWhiteSpace(txtEmpName.Text) || (txtContactNum.Text.Length != 10))
            {
                alert("Invalid Contact Number! Please try again.");
                txtContactNum.Focus();
                return;
            }
            else
            {
                try
                {
                    int numTest = Convert.ToInt32(txtContactNum.Text);
                }
                catch (Exception)
                {
                    alert("Invalid Contact Number! Please try again.");
                    txtContactNum.Focus();
                    return;
                }
            }
            #endregion

            Employee temp = new Employee();

            temp.empNum = txtEmpNum.Text;
            temp.empName = txtEmpName.Text;
            temp.empContact = txtContactNum.Text;
            temp.empRole = selRoles.Items[selRoles.SelectedIndex].Value;

            emps.UpdateEmployee(temp);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(Request.QueryString["empNum"]))
            {
                string num = Request.QueryString["empNum"];

                Employee eTemp = emps.List().Where(x => x.empNum == num).FirstOrDefault();
                User uTemp = users.List().Where(x => x.EmpNum == num).FirstOrDefault();

                if (uTemp != null)
                {
                    users.DeleteUser(uTemp);
                }

                if (eTemp != null)
                {
                    emps.DeleteEmployee(eTemp);
                }
            }

            Response.Redirect("/Index/Users/Users");
        }

        public void ShowHideFields()
        {
            //Get selected Cust ID from URL passthrough
            if (String.IsNullOrWhiteSpace(Request.QueryString["empNum"]))
            {
                tblDetails.Visible = false;

                btnDelete.Visible = false;
                btnSave.Visible = false;
            }
            else
            {
                tblDetails.Visible = true;

                btnDelete.Visible = true;
                btnSave.Visible = true;
            }
        }

        //Browser Alert Method - To Display "MessageBox" type content.
        public void alert(string message)
        {
            Response.Write($"<script>alert('{message}')</script>");
        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Index/Users/Add");
            return;
        }
    }
}