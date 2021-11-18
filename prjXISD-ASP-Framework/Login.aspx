<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="prjXISD_ASP_Framework.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="padding-top: 15%;">
        <center>
            <div style="width: 30%;">
                <h1>Login / Register</h1>
                <div>
                    <asp:TextBox CssClass="aspTextBox" ID="txtUsername" placeholder="Username" runat="server"></asp:TextBox>
                    <br />
                    <asp:TextBox CssClass="aspTextBox" TextMode="Password" ID="txtPassword" placeholder="Password" runat="server"></asp:TextBox>
                    <br />
                    <asp:TextBox CssClass="aspTextBox" ID="txtEmpNum" placeholder="Employee Number" runat="server"></asp:TextBox>
                </div>

                <asp:Button CssClass="aspButton" ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
                <asp:Button CssClass="aspButton" ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            </div>
        </center>
    </div>

    <style>
        .aspButton {
            border: 1px solid black;
            border-radius: 5px;
            width: 30%;
            margin: 2%;
            padding: 7px 5px 7px 5px;
        }

        .aspTextBox {
            text-align: center;
            margin-top: 1%;
            padding: 10px 5px 10px 5px;
            border-radius: 15px;
        }
    </style>
</asp:Content>
