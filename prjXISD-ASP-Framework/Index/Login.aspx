<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="prjXISD_ASP_Framework.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="padding-top: 15%;">
        <center>
            <div id="divLogin" style="width: 30%;">
                <h1>Login / Register</h1>
                <div>
                    <asp:TextBox CssClass="aspTextBox" ID="txtUsername" placeholder="Username" runat="server"></asp:TextBox>
                    <br />
                    <asp:TextBox CssClass="aspTextBox" TextMode="Password" ID="txtPassword" placeholder="Password" runat="server"></asp:TextBox>
                    <br />
                    <asp:TextBox CssClass="aspTextBox" ID="txtEmpNum" placeholder="Employee Number" runat="server"></asp:TextBox>
                    <br />
                    <br />
                </div>

                <asp:Button CssClass="aspButton" ID="btnRegister" runat="server" Text="REGISTER" OnClick="btnRegister_Click" />
                <asp:Button CssClass="aspButton" ID="btnLogin" runat="server" Text="LOGIN" OnClick="btnLogin_Click" />
            </div>
        </center>
    </div>

    <style>
        #divLogin {
            background-color: #333337;
            border: 0px solid #f1f1f1;
            border-radius: 15px;
            padding: 15px;
            box-shadow: 0px 0px 50px black;
        }

        .aspButton {
            color: white;
            font-weight: bold;
            background-color: #252526;
            border: 2px solid #FF7A38;
            border-radius: 10px;
            width: 30%;
            margin: 2%;
            padding: 7px 5px 7px 5px;
        }

            .aspButton:hover {
                background-color: black;
                border: 2px solid #FF7A38;
                border-radius: 10px;
                width: 30%;
                margin: 2%;
                padding: 7px 5px 7px 5px;
                box-shadow: 0px 0px 5px #FF7A38;
            }

        .aspTextBox {
            width: 45%;
            background-color: white;
            border-color: black;
            text-align: center;
            margin-top: 1%;
            padding: 10px 5px 10px 5px;
            border-radius: 15px;
        }

            .aspTextBox:focus {
                text-align: center;
                margin-top: 1%;
                padding: 10px 5px 10px 5px;
                border-radius: 15px;
                box-shadow: 0px 0px 15px #FF7A38;
            }

        #login {
            color: white;
            background-color: #2D2D30;
            text-decoration: underline #FF7A38;
            box-shadow: 0px 0px 10px #FF7A38;
        }
    </style>
</asp:Content>
