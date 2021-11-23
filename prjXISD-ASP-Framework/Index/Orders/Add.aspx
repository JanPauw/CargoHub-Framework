<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="prjXISD_ASP_Framework.Index.Orders.Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="height: 100%">
        <h1>Orders > Add</h1>
        <br />
        <center>
            <div class="row" runat="server" id="divOrders">
                <div class="OrderDiv column">
                    <center>
                        <h2>Cargo Details</h2>
                        <div class="listDiv">
                            <center>
                                <h3>Cargo Description</h3>
                                <asp:TextBox CssClass="aspTextBox" Width="100%" runat="server" ID="txtCargoDesc" TextMode="MultiLine"></asp:TextBox>
                                <br />
                                <br />
                                <h3>Cargo Quantity (KG)</h3>
                                <asp:TextBox CssClass="aspTextBox" Width="100%" runat="server" ID="txtCargoWeight"></asp:TextBox>
                                <br />
                                <br />
                                <h3>From (Depot)</h3>
                                <asp:DropDownList CssClass="aspTextBox" Width="100%" runat="server" ID="dropFromDepot"></asp:DropDownList>
                                <br />
                                <br />
                                <h3>To (Depot)</h3>
                                <asp:DropDownList CssClass="aspTextBox" Width="100%" runat="server" ID="dropToDepot"></asp:DropDownList>
                                <br />
                                <br />
                                <asp:Button CssClass="aspButton btnInDiv" runat="server" ID="btnSaveOrder" Text="Save" OnClick="btnSaveOrder_Click" />
                            </center>
                        </div>
                    </center>
                </div>
                <div class="OrderDiv column">
                    <center>
                        <h2>Customer Details</h2>
                        <div class="listDiv">
                            <center>
                                <h3>Select/Add Customer</h3>
                                <asp:DropDownList AutoPostBack="true" CssClass="aspTextBox" Width="100%" runat="server" ID="dropCustomer" OnSelectedIndexChanged="dropCustomer_SelectedIndexChanged"></asp:DropDownList>
                                <br />
                                <br />
                                <h3>Name</h3>
                                <asp:TextBox CssClass="aspTextBox" Width="100%" runat="server" ID="txtCustName"></asp:TextBox>
                                <br />
                                <br />
                                <h3>Address</h3>
                                <asp:TextBox CssClass="aspTextBox textArea" Width="100%" runat="server" ID="txtAddress" TextMode="MultiLine"></asp:TextBox>
                                <br />
                                <br />
                                <h3>Province</h3>
                                <asp:DropDownList CssClass="aspTextBox" Width="100%" runat="server" ID="dropProvince"></asp:DropDownList>
                                <br />
                                <br />
                                <h3>Email</h3>
                                <asp:TextBox CssClass="aspTextBox" Width="100%" runat="server" ID="txtCustEmail"></asp:TextBox>
                                <br />
                                <br />
                                <h3>Phone Number</h3>
                                <asp:TextBox CssClass="aspTextBox" Width="100%" runat="server" ID="txtCustNum"></asp:TextBox>
                                <br />
                                <br />
                                <asp:Button CssClass="aspButton btnInDiv" runat="server" ID="btnSaveCustomer" Text="Save" OnClick="btnSaveCustomer_Click" />
                            </center>
                        </div>
                    </center>
                </div>
            </div>
        </center>

        <center>
            <asp:Button CssClass="aspButton" runat="server" ID="btnCancel" Text="< Back" OnClick="btnCancel_Click" />
            <asp:Button CssClass="aspButton" runat="server" ID="btnAddOrder" Text="Add Order" />
        </center>
    </div>

    <style>
        #orders {
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
            width: 20%;
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

        #orders {
            color: white;
            background-color: #2D2D30;
            text-decoration: underline #FF7A38;
            box-shadow: 0px 0px 10px #FF7A38;
        }

        .OrderDiv {
            margin-left: 11.5%;
            background-color: #333337;
            border: 0px solid #f1f1f1;
            border-radius: 10px;
            box-shadow: 0px 0px 25px black;
        }

        .listDiv {
            overflow-y: scroll;
            text-align: left;
            padding: 15px;
            height: 57vh;
            background-color: #333337;
            border: 0px solid #f1f1f1;
            border-radius: 10px;
            box-shadow: inset 0px 0px 25px black;
        }

            .listDiv h3 {
                text-align: left;
                padding-left: 21%;
            }
    </style>
</asp:Content>
