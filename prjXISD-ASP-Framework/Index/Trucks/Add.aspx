<%@ Page Title="Add a Truck" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="prjXISD_ASP_Framework.Index.Trucks.Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="height: 100%">
        <h1>Trucks > Add</h1>
        <br />
        <center>
            <div class="row" runat="server" id="divOrders">
                <div class="OrderDiv column">
                    <center>
                        <h2>Truck Details</h2>
                        <div class="listDiv" style="overflow-y: auto">
                            <table runat="server" id="tblDetails" style="width: 90%; margin-top: 10px">
                                <tr>
                                    <td>
                                        <h3>Registration</h3>
                                    </td>
                                    <td>
                                        <h3>Truck Type</h3>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox Width="100%" CssClass="aspTextBox" runat="server" ID="txtVehReg"></asp:TextBox>
                                    </td>
                                    <td>
                                        <select style="width: 100%" class="aspTextBox" runat="server" id="selTruckType">
                                            <option value="None">No Cargo Body</option>
                                            <option value="Bus-15">Bus (9-15 Seats)</option>
                                            <option value="Bus-16">Bus (16+ Seats)</option>
                                            <option value="Dump">Dump</option>
                                            <option value="Pole">Pole</option>
                                            <option value="Concrete">Concrete Mixer</option>
                                            <option value="Log">Log</option>
                                            <option value="Van">Van/Enclosed Box</option>
                                            <option value="Auto">Auto Transporter</option>
                                            <option value="Intermodal">Intermodal Chassis</option>
                                            <option value="Tank">Cargo Tank</option>
                                            <option value="Garbage">Garbage/Refuse</option>
                                            <option value="Tow">Vehicle Towing</option>
                                            <option value="Flat">Flat Bed</option>
                                            <option value="Grain">Grain, Chips, Gravel</option>
                                        </select>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <h3>Manufacturer</h3>
                                    </td>
                                    <td>
                                        <h3>Engine Size</h3>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox Width="100%" CssClass="aspTextBox" runat="server" ID="txtManufacturer"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox Width="100%" CssClass="aspTextBox" runat="server" ID="txtEngineSize" TextMode="Number">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <h3>Odometer Reading</h3>
                                    </td>
                                    <td>
                                        <h3>Employee Num</h3>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox Width="100%" CssClass="aspTextBox" runat="server" ID="txtOdometer" TextMode="Number">0</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox Width="100%" CssClass="aspTextBox" runat="server" ID="txtEmpNum" ReadOnly="true"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </center>
                </div>
            </div>
        </center>
        <center>
            <asp:Button CssClass="aspButton btnCancel" runat="server" ID="btnCancel" Text="< Back" OnClientClick="return confirm('You are leaving this page! Any Unsaved data will be lost.');" OnClick="btnCancel_Click" />
            <asp:Button CssClass="aspButton btnAddTruck" runat="server" ID="btnAddTruck" Text="Add Truck" OnClick="btnAddTruck_Click" />
        </center>
    </div>
    <style>
        .btnAddTruck {
        }

            .btnAddTruck:hover {
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

        #trucks {
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
