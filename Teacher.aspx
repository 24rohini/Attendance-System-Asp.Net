<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Teacher.aspx.cs" Inherits="AttendanceSystem.Teacher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-left: 0px;
        }
        .auto-style3 {
            width: 779px;
        }
        .auto-style4 {
            height: 340px;
            width: 392px;
        }
        .auto-style5 {
            width: 168px;
        }
        .auto-style6 {
            width: 168px;
            height: 18px;
        }
        .auto-style7 {
            width: 779px;
            height: 18px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div style="background-image: url('images/photo2.jpg');  background-size:cover; background-position: center;width: 1200px"  align="center">
            <table align="center" class="auto-style4">
                <tr>
                    <td colspan="2" align="center">
                        <h2>
                            Add Teacher
                        </h2>
                        <br/>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <b>First Name:&nbsp;&nbsp;&nbsp;</b>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="TextBox2" runat="server" Width="253px" Height="28px"
                            CausesValidation="True" placeholder="Teacher's First Name" CssClass="auto-style1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="First Name Is Empty" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="Name Should Be In Characters"
                            ForeColor="Red" ValidationExpression="^[A-Za-z]*$">*</asp:RegularExpressionValidator>
                    </td>
                    
                </tr>

                <tr>
                    <td class="auto-style5">
                        <b>Last Name:&nbsp;&nbsp;&nbsp;</b>
                    </td>
                    <td class="auto-style3">
                    <asp:TextBox ID="TextBox4" runat="server" Width="273px" Height="24px"
                        CausesValidation="True" placeholder="Teacher's Last Name" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4" ErrorMessage="Last Name is Empty" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox4" ErrorMessage="Name Should be Characters"
                            ForeColor="Red" ValidationExpression="^[A-Za-z]*$">*</asp:RegularExpressionValidator>
                        </td>

                </tr>
                <tr>
                    <td class="auto-style5">
                        <b>Email Id:&nbsp;&nbsp;&nbsp;</b>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="TextBox3" runat="server" Width="272px" Height="28px"
                            TextMode="Email" placeholder="Teacher Email_Id"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3"  ErrorMessage="Email ID is empty" ForeColor="Red"></asp:RequiredFieldValidator>
                        
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6">
                        <b>Password:&nbsp;&nbsp;&nbsp;</b>

                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="TextBox1" runat="server" Width="226px" Height="35px"
                            TextMode="Password" placeholder="Teacher Password"></asp:TextBox>

                    </td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Passwword is empty" ForeColor="Red"></asp:RequiredFieldValidator>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="Button1" runat="server" Text="Add" Font-Bold="true"
                            Height="47px" Width="96px" Font-Size="Medium" OnClick="Button1_Click"/>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="Label1" runat="server" Font-Bold="true"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red"/>

                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:GridView ID="GridView1" runat="server"></asp:GridView>

                    </td>
                </tr>
            </table>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            </div>


        </center>
</asp:Content>
