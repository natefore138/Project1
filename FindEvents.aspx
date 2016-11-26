<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FindEvents.aspx.vb" Inherits="FindEvents" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 26px;
        }
    </style>
</head>
<body style="font-family: Verdana, Geneva, Tahoma, sans-serif; font-size: medium; font-weight: normal; font-style: normal; color: #FFFFFF; background-color: #FF0000">
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">Find an Event</td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlEvents" runat="server" AutoPostBack="True">
                        <asp:ListItem>Select an Event Type</asp:ListItem>
                        <asp:ListItem>Basketball</asp:ListItem>
                        <asp:ListItem>Soccer</asp:ListItem>
                        <asp:ListItem>Football</asp:ListItem>
                        <asp:ListItem>Drinking</asp:ListItem>
                        <asp:ListItem>Dancing</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="btnFind" runat="server" Text="Find Event" height="29px" width="169px" />
                </td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="btnAnalytics" runat="server" Text="Events By Type" />
                    <asp:Button ID="btnHost" runat="server" Text="Events By Host" />
                </td>
                <td class="auto-style2"></td>
            </tr>
        </table>
    <div>
    
    </div>
        <asp:GridView ID="GridView1" runat="server">
            <Columns>
                <asp:ButtonField ButtonType="Button" 
                    CommandName ="Attend"
      
                    Text="Attend" />
            </Columns>
         
        </asp:GridView>
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="White">To Profile</asp:LinkButton>
    </form>
</body>
</html>
