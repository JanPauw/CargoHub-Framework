using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjXISD_ASP_Framework;
using prjXISD_Lib_Framework;

namespace prjXISD_ASP_Framework
{
    public partial class Account : System.Web.UI.Page
    {
        private EmpList emps = new EmpList();
        private UserList users = new UserList();

        //Temp Variable to use in all methods
        User uTemp;
        Employee eTemp;

        //Encryption Class
        private static Encrypt e = new Encrypt();

        public string userName, userNum, empNum, oldPass, newPass, confirmPass;

        //page loads
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] == null)
                {
                    Response.Redirect("/Index/Login");
                    return;
                }
                LoadFields();

                uTemp = (User)Session["user"];
                eTemp = emps.List().Where(x => x.empNum == uTemp.EmpNum).FirstOrDefault();
            }
        }

        //Load Fields with Logged in User
        public void LoadFields()
        {
            uTemp = (User)Session["user"];
            eTemp = emps.List().Where(x => x.empNum == uTemp.EmpNum).FirstOrDefault();

            txtEmpName.Text = eTemp.empName;
            txtContactNum.Text = eTemp.empContact;
            txtEmpNum.Text = eTemp.empNum;
            txtRole.Text = eTemp.empRole;
        }

        #region user input
        //user name
        protected void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        //user contact number
        protected void txtUserNum_TextChanged(object sender, EventArgs e)
        {

        }

        //employee number
        protected void txtEmpNum_TextChanged(object sender, EventArgs e)
        {
            empNum = txtEmpNum.Text;
        }

        //old password
        protected void txtOldPass_TextChanged(object sender, EventArgs e)
        {
            oldPass = txtOldPass.Text;
        }

        //new password
        protected void txtNewPass_TextChanged(object sender, EventArgs e)
        {
            newPass = txtNewPass.Text;
        }

        //confirm password
        protected void txtConfirmPass_TextChanged(object sender, EventArgs e)
        {
            confirmPass = txtConfirmPass.Text;
        }

        #endregion

        #region buttons
        //change password button
        protected void btnChangePass_Click(object sender, EventArgs e)
        {
            #region Validation
            //Valid Old Password
            if (!ValidOldPass(txtOldPass.Text, (User)Session["user"]))
            {
                alert("Old Password is Invalid!");
                txtOldPass.Focus();
                return;
            }

            //Valid New Password
            if (!ValidPassword(txtNewPass.Text))
            {
                alert("New Password is Invalid!");
                txtNewPass.Focus();
                return;
            }

            //Confirm is Valid
            if (txtNewPass.Text != txtConfirmPass.Text)
            {
                alert("New Passwords do not match!");
                txtNewPass.Focus();
                return;
            }
            #endregion

            uTemp = (User)Session["user"];
            uTemp.ChangePass(txtOldPass.Text, txtNewPass.Text);

            alert("Success!");
            return;
        }

        //save details button
        protected void btnSaveDetails_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Validation
        //Valid Old Password
        public bool ValidOldPass(string pass, User temp)
        {
            if (e.EncryptString(pass) != temp.EncPassword)
            {
                return false;
            }

            return true;
        }

        //Valid Password || https://www.c-sharpcorner.com/uploadfile/jitendra1987/password-validator-in-C-Sharp/ ||
        public bool ValidPassword(string pass)
        {
            //Username String for easier usage in code
            string p = pass;

            int validConditions = 0;
            foreach (char c in p)
            {
                if (c >= 'a' && c <= 'z')
                {
                    validConditions++;
                    break;
                }
            }

            foreach (char c in p)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    validConditions++;
                    break;
                }
            }

            if (validConditions == 0) return false;

            foreach (char c in p)
            {
                if (c >= '0' && c <= '9')
                {
                    validConditions++;
                    break;
                }
            }

            if (validConditions == 1) return false;

            if (validConditions == 2)
            {
                char[] special = { '@', '#', '$', '%', '^', '&', '+', '=' }; // or whatever    
                if (p.IndexOfAny(special) == -1) return false;
            }

            return true;
        }
        #endregion

        //Browser Alert Method - To Display "MessageBox" type content.
        public void alert(string message)
        {
            Response.Write($"<script>alert('{message}')</script>");
            return;
        }

    }
}