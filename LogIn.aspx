<%@ Page Language="VB" AutoEventWireup="false" CodeFile="LogIn.aspx.vb" Inherits="LogIn" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            margin-left: 0px;
        }
        .auto-style3 {
            width: 78px;
        }
        http://localhost:49494/images/StyleSheet.css
    </style>
</head>
<body style="background-color: #FF0000">
     
    <form id="form1" runat="server" style="background-position: center; background-color: #FF0000; background-image: none; background-repeat: no-repeat; background-attachment: fixed; font-family: Verdana, Geneva, Tahoma, sans-serif; font-weight: bolder; font-size: medium; font-style: normal; color: #FFFFFF;">
        <table class="auto-style1">
            <tr>
                <td>
                    <asp:Image ID="Image1" runat="server" Height="350px" Width="450px" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="font-size: larger; font-weight: bold">
                &nbsp;ISU CLIQUE</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    <div>
    
        <br />
    
    </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style3">Log In</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">Username:</td>
                <td>
                    <asp:TextBox ID="txtUser" runat="server" CssClass="auto-style2"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Password:</td>
                <td>
                    <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Button ID="btnLogin" runat="server" Text="Enter" Height="32px" Width="119px" />
                </td>
                <td>
                    <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="White">Sign Up</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <p>
            &nbsp;</p>
        <asp:Panel ID="Panel1" runat="server" Visible="False">
            <table class="auto-style1">
                <tr>
                    <td>
                        <asp:TextBox ID="txtHiddenUser" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtHiddenPass" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    </form>
    </body>
</html>
