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
                                <li><div class="listItem"><h1>Test</h1></div></li>
                                <li><div class="listItem"><h1>Test</h1></div></li>
                                <li><div class="listItem"><h1>Test</h1></div></li>
                                <li><div class="listItem"><h1>Test</h1></div></li>
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
                            <ul>
                                <li><div class="listItem"><h1>Test</h1></div></li>
                                <li><div class="listItem"><h1>Test</h1></div></li>
                            </ul>
                            <%-- Item List | STOP | --%>
                        </div>
                    </center>
                </div>
                <div class="OrderDiv column">
                    <center>
                        <h2>Complete Orders</h2>
                        <div class="listDiv">
                            <%-- Item List | START | --%>
                            <ul>
                                <li><div class="listItem"><h1>Test</h1></div></li>
                                <li><div class="listItem"><h1>Test</h1></div></li>
                                <li><div class="listItem"><h1>Test</h1></div></li>
                            </ul>
                            <%-- Item List | STOP | --%>
                        </div>
                    </center>
                </div>
            </div>
        </center>
    </div>
    <style>
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
            padding-top: 3px;
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
            background-color: #333337;
            border: 0px solid #f1f1f1;
            border-radius: 10px;
            box-shadow: 0px 0px 25px black;
        }
    </style>
</asp:Content>
