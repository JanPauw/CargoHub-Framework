using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjXISD_ASP_Framework;

namespace prjXISD_ASP_Framework
{
    public partial class Account : System.Web.UI.Page
    {
        public string userName, userNum, empNum, oldPass, newPass, confirmPass;

        //page loads
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region user input
        //user name
        protected void txtUserName_TextChanged(object sender, EventArgs e)
        {
            userName = txtUserName.Text;
        }

        //user contact number
        protected void txtUserNum_TextChanged(object sender, EventArgs e)
        {
            userNum = txtUserNum.Text;
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

        }

        //save details button
        protected void btnSaveDetails_Click(object sender, EventArgs e)
        {

        }
        #endregion

    }
}