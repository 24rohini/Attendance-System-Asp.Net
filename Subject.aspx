<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Subject.aspx.cs" Inherits="AttendanceSystem.Subject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div style="background-image: url('images/photo2.jpg');  background-size:cover; background-position: center;width: 1200px; height: 500px;" align="center">
            <table align="center" class="auto-style3">
                <tr>
                    <td colspan="2" align="center" class="auto-style1">
                        <h2>
                            Add Subject
                        </h2>
                        <br />

                    </td>
                </tr>
                <tr>
                <td>
                    <b>Course:&nbsp;&nbsp;&nbsp;</b>
                </td>

                <td class="auto-style4">
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Height="40px" Width="197px"></asp:DropDownList>  
                </td>
                </tr>

                <tr>
                    <td>
                        <b> Year:&nbsp;&nbsp;&nbsp; </b></td>
                    <td class="auto-style4">
                    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" Height="40px" Width="197px" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                        <asp:ListItem Value="0">Select Year</asp:ListItem>
                        <asp:ListItem Value="1">First Year</asp:ListItem>
                        <asp:ListItem Value="2">Second Year</asp:ListItem>
                        <asp:ListItem Value="3">Third Year</asp:ListItem>
                        </asp:DropDownList></td>
                    
                </tr>
                <tr>
                    <td>
                        <b> Semester:&nbsp;&nbsp;&nbsp;</b>
                    </td>
                    <td class="auto-style4">
                        <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" Height="40px" Width="197px" >
                            <asp:ListItem>Select Semester</asp:ListItem>
                        </asp:DropDownList>

                    </td>

                </tr>

                <tr>
                    <td>
                        <b>Subject:&nbsp;&nbsp;&nbsp;</b>
                        <td class="auto-style4">
                            <asp:TextBox ID="TextBox1" runat="server" Width="197px" Height="41px"
                                CousesValidation="true" placeholder="Subject Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ForeColor="Red" ErrorMessage="Enter Subject Name"></asp:RequiredFieldValidator>
                    </td>

                </tr>
              <%--  <tr>
    <td>
        <b>SID:&nbsp;&nbsp;&nbsp;</b>
    </td>
    <td class="auto-style4">
        <asp:TextBox ID="SIDTextBox" runat="server" Width="197px" Height="41px" placeholder="Enter SID"></asp:TextBox>
        <asp:RequiredFieldValidator ID="SIDRequiredFieldValidator" runat="server" ControlToValidate="SIDTextBox" ForeColor="Red" ErrorMessage="Enter SID"></asp:RequiredFieldValidator>
    </td>
</tr>--%>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="Button1" runat="server" Text="Add" Font-Bold="True"
                            Height="47px" Width="86px" Font-Size="Medium" OnClick="Button1_Click"/>

                    </td>
                </tr>
                <tr>
                    <asp:Label ID="Label1" runat="server" Font-Bold="True"></asp:Label>
                </tr>
                <tr>
                    <td colspan="2" align="center" class="auto-style2">
                        <asp:GridView ID="GridView1" runat="server"></asp:GridView>

                    </td>
                </tr>
                
            </table>
            <br/>
            <br/>
            <br/>
            <br/>
            <br/>
            <br/>
            <br/>
            <br/>
            </div>

    </center>
</asp:Content>
