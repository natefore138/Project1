<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Profile.aspx.vb" Inherits="Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 122px;
        }
    </style>
</head>
<body style="background-color: #FF0000">
    <form id="form1" runat="server" style="background-color: #FF0000; font-family: Verdana, Geneva, Tahoma, sans-serif; font-size: medium; font-style: normal; color: #FFFFFF; font-weight: normal">
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Image ID="image1" runat="server" Height="200px" Width="270px" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">Username</td>
                <td>
                    <asp:Label ID="lblUser" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Name</td>
                <td>
                    <asp:Label ID="lblName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Email</td>
                <td>
                    <asp:Label ID="lblEmail" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Phone Number</td>
                <td>
                    <asp:Label ID="lblPhone" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="btnFind" runat="server" Text="Find Events" Height="53px" Width="165px" />
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Submit Event" height="53px" width="165px" />
                </td>
            </tr>
        </table>
    <div>
    
        <asp:LinkButton ID="lbLogOut" runat="server" ForeColor="White">Log Out</asp:LinkButton>
    
        <br />
        <br />
    
    </div>
        <table class="auto-style1">
            <tr>
                <td>Events I&#39;m Hosting</td>
                <td>Events I&#39;m Attending</td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvHost" runat="server">
                    </asp:GridView>
                </td>
                <td>
                    <asp:GridView ID="gvAttending" runat="server">
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
