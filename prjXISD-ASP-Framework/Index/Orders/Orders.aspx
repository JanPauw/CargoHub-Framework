<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="prjXISD_ASP_Framework.Orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="height: 100%">
        <h1>Orders</h1>
        <br />
        <center>
            <div class="row" runat="server" id="divOrders">
                <div class="OrderDiv column">
                    <center>
                        <h2>Un-assigned Orders</h2>
                        <div class="listDiv">
                            <%-- Item List | START | --%>
                            <ul>
                                <li>
                                    <div class="listItem">
                                        <div style="width: 45%; display: inline-block">
                                            <h3>Order: JP001</h3>
                                            <p>
                                                From: Port Elizabeth
                                                <br />
                                                To: Durban
                                            </p>
                                        </div>
                                        <div style="width: 45%; float: right;">
                                            <img src="../../Images/info-icon.png" />
                                        </div>
                                    </div>
                                </li>
                            </ul>
                            <%-- Item List | STOP | --%>
                        </div>
                    </center>
                </div>
                <div class="OrderDiv column">
                    <center>
                        <h2>Assigned Orders</h2>
                        <div class="listDiv">
                            <%-- Item List | START | --%>

                            <%-- Item List | STOP | --%>
                        </div>
                    </center>
                </div>
                <div class="OrderDiv column">
                    <center>
                        <h2>Complete Orders</h2>
                        <div class="listDiv">
                            <%-- Item List | START | --%>

                            <%-- Item List | STOP | --%>
                        </div>
                    </center>
                </div>
            </div>
        </center>
        <asp:Button CssClass="aspButton" runat="server" ID="btnAddOrder" Text="Add Order" OnClick="btnAddOrder_Click" />
    </div>
    <style>
        .aspButton {
            font-size: 20px;
            float: right;
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
            padding-left: 15px;
            text-align: left;
            color: white;
            background-color: #333337;
            border: 0px solid #f1f1f1;
            border-radius: 10px;
            box-shadow: 0px 0px 25px black;
        }

            .listItem h3 {
                margin-top: 7%;
            }

            .listItem img {
                float: right;
                width: 30%;
                padding: 0;
                margin: 0;
                margin-top: 10%;
                margin-right: 10%;
            }

            .listItem:hover {
                box-shadow: 0px 0px 10px #FF7A38;
            }
    </style>
</asp:Content>
