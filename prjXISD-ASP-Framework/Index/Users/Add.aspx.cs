using prjXISD_Lib_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjXISD_ASP_Framework.Index.Users
{
    public partial class Add : System.Web.UI.Page
    {
        private EmpList emps = new EmpList();
        private UserList users = new UserList();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../../Index/Users/Users");
            return;
        }

        protected void btnAddCust_Click(object sender, EventArgs e)
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

            //Generated Employee Number
            if (String.IsNullOrWhiteSpace(txtEmpNum.Text) || (txtEmpNum.Text.Length != 6))
            {
                alert("Please Generate Employee Number first");
                return;
            }
            #endregion

            Employee temp = new Employee();

            temp.empNum = txtEmpNum.Text;
            temp.empName = txtEmpName.Text;
            temp.empContact = txtContactNum.Text;
            temp.empRole = selRoles.Items[selRoles.SelectedIndex].Value;

            try
            {
                emps.AddToDB(temp);
            }
            catch (Exception)
            {
                alert("Something went wrong, please contact DevHub support!");
                return;
            }

            Response.Redirect("/Index/Users/Users");
        }

        protected void btnGenNum_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtEmpName.Text))
            {
                alert("Please enter the Employee Name first.");
                txtEmpName.Focus();
                return;
            }

            txtEmpNum.Text = emps.EmpNumGen(txtEmpName.Text);
        }

        //Browser Alert Method - To Display "MessageBox" type content.
        public void alert(string message)
        {
            Response.Write($"<script>alert('{message}')</script>");
        }


    }
}