<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reporting.aspx.cs" Inherits="prjXISD_ASP_Framework.Reporting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="height: 100%">
        <h1>Reporting</h1>
        <br />
        <center>
            <div class="row" runat="server" id="divOrders">
                <div class="OrderDiv column" style="width: 32.3333%;">
                    <center>
                        <h2>Select Report</h2>
                        <div runat="server" id="divSelReport" class="listDiv">
                            <ul>
                                <li>
                                    <div class="listItem">
                                        <h3>Vehicle Satus</h3>
                                    </div>
                                </li>
                                <li>
                                    <div class="listItem">
                                        <h3>Service Appointments</h3>
                                    </div>
                                </li>
                                <li>
                                    <div class="listItem">
                                        <h3>Service Requirements Job Sheet</h3>
                                    </div>
                                </li>
                                <li>
                                    <div class="listItem">
                                        <h3>Vehicle Services Completed</h3>
                                    </div>
                                </li>
                                <li>
                                    <div class="listItem">
                                        <h3>Complete Service Information</h3>
                                    </div>
                                </li>
                                <li>
                                    <div class="listItem">
                                        <h3>Planned Trip Teport</h3>
                                    </div>
                                </li>
                                <li>
                                    <div class="listItem">
                                        <h3>Completed Trip Report</h3>
                                    </div>
                                </li>
                                <li>
                                    <div class="listItem">
                                        <h3>Timesheet Report</h3>
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </center>
                </div>
                <div class="OrderDiv column" style="width: 64%">
                    <center>
                        <h2>Report</h2>
                        <div runat="server" id="divReport" class="listDiv">
                        </div>
                    </center>
                </div>
            </div>
        </center>
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

        #reporting {
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
