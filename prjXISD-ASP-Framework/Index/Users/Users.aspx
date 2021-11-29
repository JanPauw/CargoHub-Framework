<%@ Page Title="Users" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="prjXISD_ASP_Framework.Users" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="height: 100%">
        <h1>Users / Employees</h1>
        <br />
        <center>
            <div class="row" runat="server" id="divOrders">
                <div class="UserDiv column">
                    <center>
                        <h2>User List</h2>
                        <div runat="server" id="divUsers" class="listDiv">
                        </div>
                    </center>
                </div>
                <div class="UserDiv column">
                    <center>
                        <h2>User Details</h2>
                        <div runat="server" id="divCustomers" class="listDiv">
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
                                        <select runat="server" id="selRoles" class="aspTextBox" style="width: 100%">
                                            <option value="Admin">Admin</option>
                                            <option value="Manager">Manager</option>
                                            <option value="Driver">Driver</option>
                                            <option value="Service Manager">Service Manager</option>
                                            <option value="Timesheet Manager">Timesheet Manager</option>
                                            <option value="Trip/Usage Manager">Trip/Usage Manager</option>
                                        </select>
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
                            <asp:Button CssClass="aspButton btnDelete btnAnim" ID="btnDelete" runat="server" Text="Delete User" OnClientClick="return confirm('You are deleting this User profile! Continue?');" OnClick="btnDelete_Click" />
                            <asp:Button CssClass="aspButton btnSave btnAnim" ID="btnSave" runat="server" Text="Save Changes" OnClick="btnSave_Click" />
                        </div>
                    </center>
                </div>
            </div>
        </center>

        <asp:Button CssClass="aspButton btnAddUser btnAnim" runat="server" ID="btnAddUser" Text="Add Employee" OnClick="btnAddUser_Click" />

    </div>

    <style>
        .btnSave {
            float: right;
            margin-right: 15px !important;
        }

            .btnSave:hover {
                color: green !important;
            }

        .btnDelete {
            float: left;
            margin-left: 15px !important;
        }

            .btnDelete:hover {
                color: red !important;
            }

        .btnAddUser {
            float: right !important;
        }

        td {
            width: 49%;
            vertical-align: top;
            padding: 5px;
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
        }

            .aspButton:hover {
                background-color: black;
                border: 2px solid #FF7A38;
                border-radius: 10px;
                margin: 2%;
                padding: 7px 5px 7px 5px;
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

            .aspTextBox .textArea {
                text-align: left;
            }

            .aspTextBox:focus {
                text-align: center;
                margin-top: 1%;
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

        #users {
            color: white;
            background-color: #2D2D30;
            text-decoration: underline #FF7A38;
            box-shadow: 0px 0px 10px #FF7A38;
        }

        .UserDiv {
            margin-left: 11.5%;
            background-color: #333337;
            border: 0px solid #f1f1f1;
            border-radius: 10px;
            box-shadow: 0px 0px 25px black;
        }

        .listDiv {
            overflow-y: auto;
            padding-top: 3px;
            padding-bottom: 10px;
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
                width: 95%;
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
