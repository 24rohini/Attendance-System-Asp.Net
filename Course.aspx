<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Course.aspx.cs" Inherits="AttendanceSystem.Course" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<center>
<div style="background-image: url('images/photo2.jpg');  background-size:cover; background-position: center;width: 1200px; height: 410px;" align="center">

<table align="center" style="width: 386px">
<tr> 
    <td colspan="2" align="center">
  <h2>
      Add Course</h2>
    <br />
   </td>
    </tr>

    <tr>
    <td>
<b>Course: &nbsp;&nbsp;&nbsp;</b>
</td>

<td> 
    <asp:TextBox ID="TextBox1" runat="server" Height="44px" Width="230px"
        CousesValidation="True" placeholder="Course Name"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="TextBox1"
        ForeColor="Red" ErrorMessage="Enter Course Name"></asp:RequiredFieldValidator> 
   </td>

</tr>
    <tr>
        <td colspan="2" align="center" >
            <asp:Button ID="Button1" runat="server" Text="Add" Height="44px"
              Width="80px" Font-Bold="true" OnClick="Button1_Click"/>
        </td>
    </tr>
    <tr>
          <td colspan="2" align="center">
              &nbsp;</td>
    </tr>
<tr>
    <td colspan="2">

        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
</td>
</tr>
</table>
    <div align="center">
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="CID" Height="165px" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" PageSize="4" Width="280px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:TemplateField HeaderText="Course">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("CourseName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("CourseName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField CausesValidation="False" ButtonType="link" HeaderText="Operation" ShowDeleteButton="True" ShowEditButton="True" />
            </Columns>
        </asp:GridView>
           

<br />
<br />
<br />
<br />
<br />
</div>
</div>
</center>

</asp:Content>
