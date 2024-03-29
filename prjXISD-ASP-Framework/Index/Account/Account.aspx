﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="prjXISD_ASP_Framework.Account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div style="height: 100%">
        <h1>Account Settings</h1>
        <br />
        <center>
            <div class="row" runat="server" id="divOrders">
                <div class="AccountDiv column">
                    <center>
                        <h2>User Details</h2>
                        <div class="listDiv">
                            <table runat="server" id="tblDetails" style="width: 90%; margin-top: 10px">
                                <tr>
                                    <td>
                                        <h3>Name</h3>
                                    </td>
                                    <td>
                                        <h3>Contact Number</h3>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox Width="100%" CssClass="aspTextBox" ID="txtEmpName" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox Width="100%" CssClass="aspTextBox" ID="txtContactNum" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <h3>Employee Number</h3>
                                    </td>
                                    <td>
                                        <h3>User Role</h3>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox Width="100%" CssClass="aspTextBox" ID="txtEmpNum" runat="server" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox Width="100%" CssClass="aspTextBox" ID="txtRole" runat="server" ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <asp:Button CssClass="aspButton btnSave" ID="btnSave" runat="server" Text="Save Changes" />
                        </div>
                    </center>
                </div>

                <div class="AccountDiv column">
                    <center>
                        <h2>Change Password</h2>
                        <div runat="server" id="divCustomers" class="listDiv">
                            <table runat="server" id="Table1" style="width: 90%; margin-top: 10px">
                                <tr>
                                    <td>
                                        <h3>Old Password</h3>
                                    </td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox Width="100%" CssClass="aspTextBox" ID="txtOldPass" runat="server" OnTextChanged="txtOldPass_TextChanged" TextMode="Password"></asp:TextBox>
                                    </td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>
                                        <h3>New Password</h3>
                                    </td>
                                    <td>
                                        <h3></h3>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox Width="100%" CssClass="aspTextBox" ID="txtNewPass" runat="server" OnTextChanged="txtNewPass_TextChanged" TextMode="Password"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox Width="100%" CssClass="aspTextBox" ID="txtConfirmPass" runat="server" OnTextChanged="txtConfirmPass_TextChanged" TextMode="Password"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <asp:Button CssClass="aspButton btnSave" ID="btnChangePass" runat="server" Text="Change Password" OnClick="btnChangePass_Click"></asp:Button>
                        </div>
                    </center>
                </div>
            </div>
        </center>
    </div>

    <style>
        .btnSave {
            float: right;
            margin-right: 15px !important;
        }

        td {
            width: 49%;
            vertical-align: top;
            padding: 5px;
        }

        #account {
            color: white;
            background-color: #2D2D30;
            text-decoration: underline #FF7A38;
            box-shadow: 0px 0px 10px #FF7A38;
        }

        .aspButton {
            font-size: 20px;
            color: white;
            font-weight: bold;
            background-color: #252526;
            border: 2px solid #FF7A38;
            border-radius: 10px;
            width: 40%;
            margin: 2%;
            padding: 7px 5px 7px 5px;
            margin-left: -15px;
        }

            .aspButton:hover {
                background-color: black;
                border: 2px solid #FF7A38;
                border-radius: 10px;
                margin: 2%;
                padding: 7px 5px 7px 5px;
                box-shadow: 0px 0px 5px #FF7A38;
                margin-left: -15px;
            }

        .aspTextBox {
            text-align: center;
            width: 45%;
            background-color: white;
            border-color: black;
            padding: 10px 5px 10px 5px;
            border-radius: 15px;
        }

            .aspTextBox .textArea {
                text-align: left;
            }

            .aspTextBox:focus {
                padding: 10px 5px 10px 5px;
                border-radius: 15px;
                box-shadow: 0px 0px 15px #FF7A38;
            }

        .btnInDiv {
            float: right;
            font-size: 20px;
            color: white;
            font-weight: bold;
            background-color: #252526;
            border: 2px solid #FF7A38;
            border-radius: 10px;
            width: 30%;
            margin: 2%;
            padding: 7px 5px 7px 5px;
        }

            .btnInDiv:hover {
                background-color: black;
                border: 2px solid #FF7A38;
                border-radius: 10px;
                width: 30%;
                margin: 2%;
                padding: 7px 5px 7px 5px;
                box-shadow: 0px 0px 5px #FF7A38;
            }

        /* Create three equal columns that floats next to each other */
        .column {
            float: left;
            width: 32.3333%;
            margin-left: 0.5%;
            margin-right: 0.5%;
            padding: 15px;
        }

        /* Clear floats after the columns */
        .row:after {
            content: "";
            display: table;
            clear: both;
        }

        #orders {
            color: white;
            background-color: #2D2D30;
            text-decoration: underline #FF7A38;
            box-shadow: 0px 0px 10px #FF7A38;
        }

        .AccountDiv {
            margin-left: 11.5%;
            background-color: #333337;
            border: 0px solid #f1f1f1;
            border-radius: 10px;
            box-shadow: 0px 0px 25px black;
        }

        .listDiv {
            overflow-y: auto;
            padding-top: 3px;
            padding-bottom: 15px;
            height: 57vh;
            background-color: #333337;
            border: 0px solid #f1f1f1;
            border-radius: 10px;
            box-shadow: inset 0px 0px 25px black;
        }

            .listDiv ul {
                width: 100%;
                margin: 0;
                padding: 0;
                list-style-type: none;
            }

            .listDiv li {
                margin-top: 15px;
                width: 90%;
            }

        .listItem {
            padding: 3%;
            text-align: left;
            color: white;
            background-color: #333337;
            border: 0px solid #f1f1f1;
            border-radius: 10px;
            box-shadow: 0px 0px 15px black;
        }

            .listItem h3 {
                margin: 0;
            }

            .listItem:hover {
                box-shadow: 0px 0px 10px #FF7A38;
            }
    </style>
</asp:Content>

