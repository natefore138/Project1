<%@ Page Language="VB" AutoEventWireup="false" CodeFile="events.aspx.vb" Inherits="events" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 8px;
        }
    </style>
</head>
<body style="font-size: medium; font-family: Verdana, Geneva, Tahoma, sans-serif; font-weight: normal; color: #FFFFFF; font-style: normal; background-color: #FF0000">
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td>Submit an Event</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Event Type</td>
                <td>
                    <asp:DropDownList ID="ddlEvent" runat="server" AutoPostBack="True">
                        <asp:ListItem>Please Select an Event</asp:ListItem>
                        <asp:ListItem>Basketball</asp:ListItem>
                        <asp:ListItem>Football</asp:ListItem>
                        <asp:ListItem>Soccer</asp:ListItem>
                        <asp:ListItem>Drinking</asp:ListItem>
                        <asp:ListItem>Dancing</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Location</td>
                <td>
                    <asp:TextBox ID="txtLocation" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Date</td>
                <td>
                    <asp:Calendar ID="Calendar1" runat="server" BackColor="Red" BorderColor="Black" Font-Bold="True" ForeColor="White" NextPrevFormat="ShortMonth" ShowGridLines="True">
                        <DayStyle BackColor="White" ForeColor="Red" />
                        <NextPrevStyle BackColor="Silver" />
                        <OtherMonthDayStyle BackColor="#CCCCCC" />
                        <SelectedDayStyle BackColor="Black" />
                    </asp:Calendar>
                </td>
            </tr>
            <tr>
                <td>Time</td>
                <td>
                    <asp:TextBox ID="txtTime" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Max Party Size</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtMax" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Host</td>
                <td>
                    <asp:DropDownList ID="ddlHost" runat="server" Height="19px" Width="169px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" Height="39px" Width="110px" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="White">To Profile</asp:LinkButton>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    <div>
    
    </div>
    </form>
</body>
</html>
