<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherMaster.Master" AutoEventWireup="true" CodeBehind="Mark_Attendance.aspx.cs" Inherits="AttendanceSystem.Mark_Attendance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-top: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div style="background-image: url('images/photo2.jpg');  background-size:cover; background-position: center;width: 1200px" >
            <center>
                 <table align="center" style="Width:1200px;height:366px" >
                     <tr style="width:1200px;">
                         <td>
                             <b>Course</b>
                         </td>
                         <td>
                             <asp:DropDownList ID="DropDownList1" runat="server" Height="40px" Width="115px" AutoPostBack="true"></asp:DropDownList>
                         </td>
                         <td>
                             &nbsp;
                         </td>
                         <td>
                             <b> Year:</b>
                         </td>
                         <td>
                             <asp:DropDownList ID="DropDownList2" runat="server" Height="40px" Width="125px">
                                 <asp:ListItem>Select Year</asp:ListItem>
                                 <asp:ListItem>First Year</asp:ListItem>
                                 <asp:ListItem>Second Year</asp:ListItem>
                                 <asp:ListItem>Third Year</asp:ListItem>
                             </asp:DropDownList>
                         </td>
                         <td>
                             <b> Semester</b>
                         </td>
                         <td>
                             <asp:DropDownList ID="DropDownList5" runat="server" Height="40px" Width="125px" AutoPostBack="true" OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged">
                                 <asp:ListItem>Select Semester</asp:ListItem>
                                 <asp:ListItem>Sem I</asp:ListItem>
                                 <asp:ListItem>Sem II</asp:ListItem>
                                 <asp:ListItem>Sem III</asp:ListItem>
                                 <asp:ListItem>Sem IV</asp:ListItem>
                                 <asp:ListItem>Sem V</asp:ListItem>
                                 <asp:ListItem>Sem VI</asp:ListItem>
                             </asp:DropDownList>

                         </td>
                         <td>
                             &nbsp;
                         </td>
                         <td>
                             <b>Subject:</b>
                         </td>
                         <td>
                             <asp:DropDownList ID="DropDownList3" runat="server" Height="40px" Width="215px" AutoPostBack="true"></asp:DropDownList>

                         </td>
                     </tr>
                     <tr style="width:1200px;">
                         <td colspan="10"align="center">
                             <b>Total Lectures</b>
                             <asp:DropDownList ID="DropDownList4" runat="server" AutoPostBack="true">
                                 <asp:ListItem>Select</asp:ListItem>
                                 <asp:ListItem>1</asp:ListItem>
                                 <asp:ListItem>2</asp:ListItem>
                                 <asp:ListItem>3</asp:ListItem>
                                 <asp:ListItem>4</asp:ListItem>
                             </asp:DropDownList>

                         </td>

                     </tr>
                     <tr>
                         <td colspan="10" align="center">
                             <asp:Button ID="Button1" runat="server" Text="Select" Font-Bold="true" Height="40px"
                                 Width="92px" OnClick="Button1_Click"/>

                         </td>
                     </tr>
                     <tr>
                         <td colspan="10" align="center">
                             <asp:Label ID="Label4" runat="server" Font-Bold="true" ForeColor="#9900FF"></asp:Label>
                             <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

                         </td>
                     </tr>
                     <tr>
                     <td colspan="10" align="center">
                         <asp:GridView ID="GridView1" runat="server">
                             <Columns>
                                 <asp:TemplateField HeaderText="Mark Attdendance">
                                     <ItemTemplate>
                                         <asp:RadioButton ID="RadioButton1" runat="server" Checked="True" GroupName="attend" Text="Present" />
                                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                         <asp:RadioButton ID="RadioButton2" runat="server" GroupName="attend" Text="Absent" />
                                         &nbsp;
                                     </ItemTemplate>
                                     <ItemStyle HorizontalAlign="Center" />
                                 </asp:TemplateField>
                             </Columns>
                             <EmptyDataTemplate>
                                 <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="No Such Records Found"></asp:Label>
                             </EmptyDataTemplate>
                         </asp:GridView>
                         
                     </td>
                     <tr>
                         <td colspan="10" align="center">
                             <asp:Button ID="markattendance" runat="server" Text="Mark Attendance" Font-Bold="True"
                                 Height="30px" Width="159px" Font-Size="Medium" CssClass="auto-style1" OnClick="Button2_Click1"  />

                         </td>
                     </tr>
                     <tr>
                         <td colspan="10" align="center">
                             <asp:Label ID="Label3" runat="server" Text="Label3"></asp:Label>
                         </td>
                     </tr>

                     </table>
                   
            </center>
               </div>
    </center>
</asp:Content>
