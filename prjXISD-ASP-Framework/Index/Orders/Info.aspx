<%@ Page Title="Order Info" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Info.aspx.cs" Inherits="prjXISD_ASP_Framework.Index.Orders.Info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="height: 100%">
        <h1>Orders > Info</h1>
        <br />
        <center>
            <div class="row" runat="server" id="divOrders">
                <div class="OrderDiv column">
                    <center>
                        <h2>Cargo Details</h2>
                        <div class="listDiv">
                            <table runat="server" id="tblOrderDetails" style="width: 95%; margin-top: 10px">
                                <tr>
                                    <td>
                                        <h3>Cargo Description</h3>
                                    </td>
                                    <td>
                                        <h3>Cargo Quantity (KG)</h3>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox AutoPostBack="true" CssClass="aspTextBox" Width="100%" runat="server" ID="txtCargoDesc" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox AutoPostBack="true" CssClass="aspTextBox" Width="100%" runat="server" ID="txtCargoWeight"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <h3>From (Depot)</h3>
                                    </td>
                                    <td>
                                        <h3>To (Depot)</h3>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <select class="aspTextBox" runat="server" id="fromDepot" style="width: 100%">
                                            <option value="Eastern Cape">Eastern Cape</option>
                                            <option value="Free State">Free State</option>
                                            <option value="Gauteng">Gauteng</option>
                                            <option value="KwaZulu-Natal">KwaZulu-Natal</option>
                                            <option value="Limpopo">Limpopo</option>
                                            <option value="Mpumulanga">Mpumulanga</option>
                                            <option value="Northern Cape">Northern Cape</option>
                                            <option value="North West">North West</option>
                                            <option value="Western Cape">Western Cape</option>
                                        </select>
                                        <%--<asp:DropDownList AutoPostBack="true" CssClass="aspTextBox" Width="100%" runat="server" ID="dropFromDepot"></asp:DropDownList>--%>
                                    </td>
                                    <td>
                                        <select class="aspTextBox" runat="server" id="toDepot" style="width: 100%">
                                            <option value="Eastern Cape">Eastern Cape</option>
                                            <option value="Free State">Free State</option>
                                            <option value="Gauteng">Gauteng</option>
                                            <option value="KwaZulu-Natal">KwaZulu-Natal</option>
                                            <option value="Limpopo">Limpopo</option>
                                            <option value="Mpumulanga">Mpumulanga</option>
                                            <option value="Northern Cape">Northern Cape</option>
                                            <option value="North West">North West</option>
                                            <option value="Western Cape">Western Cape</option>
                                        </select>
                                        <%--<asp:DropDownList AutoPostBack="true" CssClass="aspTextBox" Width="100%" runat="server" ID="dropToDepot"></asp:DropDownList>--%>
                                    </td>
                                </tr>
                            </table>
                            <div id="map">
                            </div>

                            <div id="warnings-panel"></div>
                        </div>

                    </center>
                </div>
                <div class="OrderDiv column">
                    <center>
                        <h2>Customers</h2>
                        <div runat="server" id="divCustomers" class="listDiv">
                        </div>
                    </center>
                </div>
            </div>
        </center>

        <center>
            <asp:Button CssClass="aspButton" runat="server" ID="btnCancel" Text="< Back" OnClientClick="return confirm('You are leaving this page! Any Unsaved data will be lost.');" OnClick="btnCancel_Click" />
            <asp:Button CssClass="aspButton" runat="server" ID="btnUpdateOrder" Text="Save Changes" OnClick="btnUpdateOrder_Click" />
        </center>
    </div>

    <style>
        td {
            width: 49%;
            vertical-align: top;
            padding: 5px;
        }

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
