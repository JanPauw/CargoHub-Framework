<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Timesheet.aspx.cs" Inherits="prjXISD_ASP_Framework.Timesheet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="height: 100%">
        <h1>Timesheet</h1>
        <br />
        <center>
            <div class="row" runat="server" id="divOrders">
                <div class="OrderDiv column" style="width: 32.3333%;">
                    <center>
                        <h2>Employees</h2>
                        <div runat="server" id="divEmployees" class="listDiv">
                        </div>
                    </center>
                </div>
                <div class="OrderDiv column" style="width: 64%">
                    <center>
                        <h2>Work</h2>
                        <div runat="server" id="divTimes" class="listDiv">
                            <div id="Col1" style="vertical-align: middle !important; height: 100%; padding-top: 15px;">
                                <h2>Past Work Hours</h2>
                                <asp:GridView CssClass="DataGrid" ID="grdTimeSheet" runat="server">
                                </asp:GridView>
                            </div>
                            <div id="Col2" style="vertical-align: middle !important; height: 100%; padding-top: 15px;">
                                <h2>Add Work Hours</h2>
                                <table>
                                    <tr>
                                        <td>
                                            <h3>Amount of Hours Worked</h3>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox TextMode="Number" CssClass="aspTextBox" Width="100%" ID="txtHours" runat="server">0</asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h3>Date Worked</h3>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Calendar Width="100%" ID="calWorkDate" runat="server" BorderColor="#333337" DayHeaderStyle-BackColor="#1E1E1E" DayHeaderStyle-ForeColor="White" SelectedDayStyle-BackColor="#252526" SelectedDayStyle-ForeColor="orange" TitleStyle-BackColor="#2D2D30" TitleStyle-ForeColor="white" BorderStyle="Solid" ForeColor="white" NextPrevStyle-ForeColor="white" BackColor="#2D2D30"></asp:Calendar>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <asp:Button CssClass="aspButton btnAddHours" ID="btnAddHours" runat="server" Text="Record Hours" OnClick="btnAddHours_Click" />
                            </div>
                        </div>
                    </center>
                </div>
            </div>
        </center>
    </div>
    <style>
        .btnAddHours {
        }

            .btnAddHours:hover {
                color: green;
            }

        .cal {
            border-color: black;
            border-radius: 15px;
        }

        #Col1 {
            display: inline-block;
            width: 45%;
            overflow-y: auto;
        }

        #Col2 {
            display: inline-block;
            width: 45%;
        }

        .DataGrid {
            border: 1px solid #333337 !important;
            color: white;
            width: 100%;
        }

        .aspButton {
            font-size: 20px;
            color: white;
            font-weight: bold;
            background-color: #252526;
            border: 2px solid #FF7A38;
            border-radius: 10px;
            width: 100%;
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

        #timesheet {
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
