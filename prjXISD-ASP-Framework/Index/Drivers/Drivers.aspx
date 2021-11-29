<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Drivers.aspx.cs" Inherits="prjXISD_ASP_Framework.Drivers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="height: 100%">
        <h1>Drivers</h1>
        <br />
        <center>
            <div class="row" runat="server" id="divOrders">
                <div class="DriverDiv column">
                    <center>
                        <h2>Drivers</h2>
                        <div runat="server" id="divDrivers" class="listDiv">
                            <%-- Item List | START | --%>

                            <%-- Item List | STOP | --%>
                        </div>
                    </center>
                </div>
                <div class="DriverDiv column">
                    <center>
                        <h2>Driver Details</h2>
                        <div runat="server" id="divDetails" class="listDiv">
                            <center>
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
                                            <asp:TextBox ReadOnly="true" Width="100%" CssClass="aspTextBox" ID="txtEmpName" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ReadOnly="true" Width="100%" CssClass="aspTextBox" ID="txtContactNum" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h3>Employee Number</h3>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox Width="100%" CssClass="aspTextBox" ID="txtEmpNum" runat="server" ReadOnly="True"></asp:TextBox>
                                        </td>
                                        <td></td>
                                    </tr>
                                </table>
                            </center>
                        </div>
                    </center>
                </div>
                <div class="DriverDiv column">
                    <center>
                        <h2>Truck</h2>
                        <div runat="server" id="divTruck" class="Trucklist">
                        </div>
                        <asp:Button CssClass="aspButton addTruck" runat="server" ID="btnAddTruck" Text="Add Truck" OnClick="btnAddTruck_Click" />
                    </center>
                </div>
            </div>
        </center>
    </div>
    <style>
        .addTruck {
            float: right;
        }

            .addTruck:hover {
                color: green;
            }

        .btnOrders {
            float: right;
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

        #drivers {
            color: white;
            background-color: #2D2D30;
            text-decoration: underline #FF7A38;
            box-shadow: 0px 0px 10px #FF7A38;
        }

        .DriverDiv {
            background-color: #333337;
            border: 0px solid #f1f1f1;
            border-radius: 10px;
            box-shadow: 0px 0px 25px black;
        }

        .Trucklist {
            overflow-y: auto;
            padding-top: 3px;
            padding-bottom: 10px;
            height: 49.8vh;
            background-color: #333337;
            border: 0px solid #f1f1f1;
            border-radius: 10px;
            box-shadow: inset 0px 0px 25px black;
        }

            .Trucklist ul {
                width: 100%;
                margin: 0;
                padding: 0;
                list-style-type: none;
            }

            .Trucklist li {
                margin-top: 15px;
                width: 95%;
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

        .listDriver {
            padding: 3%;
            text-align: left;
            color: white;
            background-color: #333337;
            border: 0px solid #f1f1f1;
            border-radius: 10px;
            box-shadow: 0px 0px 15px black;
        }

            .listDriver h3 {
                margin: 0;
            }

            .listDriver:hover {
                box-shadow: 0px 0px 10px #FF7A38;
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
                width: 50%;
                padding: 0;
                margin: 0;
                margin-top: 15%;
                margin-right: 10%;
            }

            .listItem:hover {
                box-shadow: 0px 0px 10px #FF7A38;
            }
    </style>
</asp:Content>
