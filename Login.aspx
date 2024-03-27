<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AttendanceSystem.Login" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> </title>
    
</head>
<body>
    <form id="form1" runat="server">
        <div style="height:450px;">
            <table style="width: 565px; height: 421px; background-color:palegoldenrod; margin: 0 auto;">

                <tr>
                    <td colspan="2" align="center">
                        &nbsp;<img id="Img1"
                            src="images/login.png" alt="" runat="server"
                            style="height:190px;width:199px" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <h2>Teacher ,Admin &amp; Student Login</h2>

                    </td>
                </tr>
                <tr>
                <td align="center" style="width:50%">
                    <b>Email ID/User ID:</b>

                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Backcolor="Transparent" height="29px"
                        width="166px" Font-Bold="True" placeholder="Enter Email_ID/User ID"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="TextBox1" ErrorMessage="Enter Email-ID" ForeColor="Red" ></asp:RequiredFieldValidator>

                </td>
                   </tr>
                <tr>
                    <td align="center" style="width:50%">
                      <b>Password:</b>
                        </td>
                   <td>
                       <asp:TextBox ID="TextBox2" runat="server" Backcolor="Transparent" height="29px"
                           width="166px" Font-Bold="True" placeholder="Enter Password"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="Enter Password" ForeColor="Red"></asp:RequiredFieldValidator>
                   </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="Button1" runat="server" Text="Login" Font-Bold="true"
                            Height="46px" Width="201px" OnClick="Button1_Click" /><hr />
                        </td>

                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                    </td>

                    
                </tr>
                
                
            </table>
        </div>
    </form>
</body>
</html>
