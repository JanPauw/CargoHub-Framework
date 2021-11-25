<%@ Page Title="Add Customer" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="prjXISD_ASP_Framework.Index.Customers.Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="height: 100%">
        <h1>Customers > Add</h1>
        <br />
        <center>
            <div class="row" runat="server" id="divOrders">
                <div class="OrderDiv column">
                    <center>
                        <h2>Customer Details</h2>
                        <div class="listDiv" style="overflow-y: auto">
                            <table runat="server" id="tblDetails" style="width: 90%; margin-top: 10px">
                                <tr>
                                    <td>
                                        <h3>Name</h3>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox CssClass="aspTextBox" Width="100%" runat="server" ID="txtCustName"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <h3>Address</h3>
                                    </td>
                                    <td>
                                        <h3>Province</h3>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox CssClass="aspTextBox textArea" Width="100%" runat="server" ID="txtAddress" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:DropDownList CssClass="aspTextBox" Width="100%" runat="server" ID="dropProvince"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <h3>Email</h3>
                                    </td>
                                    <td>
                                        <h3>Phone Number</h3>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox CssClass="aspTextBox" Width="100%" runat="server" ID="txtCustEmail"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="aspTextBox" Width="100%" runat="server" ID="txtCustNum"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </center>
                </div>
            </div>
        </center>
        <center>
            <asp:Button CssClass="aspButton btnCancel" runat="server" ID="btnCancel" Text="< Back" OnClick="btnCancel_Click" OnClientClick="return confirm('You are leaving this page! Any Unsaved data will be lost.');" />
            <asp:Button CssClass="aspButton btnAddCust" runat="server" ID="btnAddCust" Text="Add Customer" OnClick="btnAddCust_Click" />
        </center>
    </div>
    <style>
        .btnAddCust {
        }

            .btnAddCust:hover {
                color: green;
            }

        .btnCancel {
        }

            .btnCancel:hover {
                color: red !important;
            }

        td {
            width: 49%;
            vertical-align: top;
            padding: 5px;
        }

        .aspTextBox {
            width: 45%;
            background-color: white;
            border-color: black;
            text-align: left;
            margin-top: 1%;
            padding: 10px 5px 10px 10px;
            border-radius: 15px;
        }

            .aspTextBox:focus {
                margin-top: 1%;
                border-radius: 15px;
                box-shadow: 0px 0px 15px #FF7A38;
            }

        .aspButton {
            font-size: 20px;
            color: white;
            font-weight: bold;
            background-color: #252526;
            border: 2px solid #FF7A38;
            border-radius: 10px;
            width: 35%;
            margin: 2%;
            padding: 7px 5px 7px 5px;
        }

            .aspButton:hover {
                background-color: black;
                border: 2px solid #FF7A38;
                border-radius: 10px;
                margin: 2%;
                padding: 7px 5px 7px 5px;
                box-shadow: 0px 0px 5px #FF7A38;
            }

        /* Create three equal columns that floats next to each other */
        .column {
            float: left;
            width: 32.3333%;
            margin-left: 33.8333%;
            margin-right: 33.8333%;
            padding: 15px;
        }

        /* Clear floats after the columns */
        .row:after {
            content: "";
            display: table;
            clear: both;
        }

        #customers {
            color: white;
            background-color: #2D2D30;
            text-decoration: underline #FF7A38;
            box-shadow: 0px 0px 10px #FF7A38;
        }

        .OrderDiv {
            background-color: #333337;
            border: 0px solid #f1f1f1;
            border-radius: 10px;
            box-shadow: 0px 0px 25px black;
        }

        .listDiv {
            overflow-y: scroll;
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
