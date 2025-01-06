<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMaster.Master"  AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="Project_JobPortal_0507.LogIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr style="background-color:#FAFAD2;border:dotted">
            <td>User Type :</td> 
            <td>
                <asp:DropDownList ID="ddlusertype" runat="server">
                    <asp:ListItem Text="--SELECT--" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Admin" Value="1"></asp:ListItem>
                    <asp:ListItem Text="JobRecruiter" Value="2"></asp:ListItem>
                    <asp:ListItem Text="JobSeeker" Value="3"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="background-color:#FAFAD2;border:dotted">
            <td>Email Id :</td>
            <td><asp:TextBox ID="txtemail" runat="server"></asp:TextBox></td>
        </tr>
        <tr style="background-color:#FAFAD2;border:dotted">
            <td>Password :</td>
            <td><asp:TextBox ID="txtpassword" runat="server"></asp:TextBox></td>
        </tr>
        <tr style="background-color:#FAFAD2;border:dotted">
             <td colspan="2" align="center"><asp:Button ID="btnadd" runat="server" Text="Log In" OnClick="btnadd_Click" /> </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Label ID="lblmsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
