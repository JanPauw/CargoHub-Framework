using prjXISD_Lib_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjXISD_ASP_Framework
{
    public partial class Login : System.Web.UI.Page
    {
        //Global Variables
        User attempt = null;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtEmpNum.Text))
            {
                alert("Invalid Employee Number! Please enter another.");
                return;
            }

            //Registration Input
            string u_name = txtUsername.Text;
            string p_name = txtPassword.Text;
            string e_num = txtEmpNum.Text;

            //New Register Attempt
            attempt = new User(u_name, p_name, e_num);

            #region Validation
            if (attempt.UsernameExists()) //
            {
                alert("Username is already in use! Please choose another.");
                return;
            }

            if (!attempt.regValidUsername())
            {
                alert("Invalid Username! Please choose another.");
                return;
            }

            if (!attempt.regValidPassword())
            {
                alert("Invalid Password! Please choose another.");
                return;
            }

            if (!attempt.regValidEmpNum())
            {
                alert("Invalid Employee Number, Employee Number Might already be Registered! Please choose another.");
                return;
            }
            #endregion

            Session["user"] = attempt.register();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //Registration Input
            string u_name = txtUsername.Text;
            string p_name = txtPassword.Text;
            string e_num = txtEmpNum.Text;

            //New Register Attempt
            attempt = new User(u_name, p_name, e_num);

            Session["user"] = attempt.login();

            if (Session["user"] == null)
            {
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtEmpNum.Text = "";

                Response.Redirect("Login.aspx?Auth=False");
                alert("Invalid Login Details! Please try again.");
                return;
            }


            Response.Redirect("Login.aspx?Auth=True");
            return;
        }

        #region Validation (Mainly for empty Fields)

        #endregion

        //Browser Alert Method - To Display "MessageBox" type content.
        public void alert(string message)
        {
            Response.Write($"<script>alert('{message}')</script>");
        }
    }
}