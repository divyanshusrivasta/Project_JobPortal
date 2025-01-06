<%@ Page Title="" Language="C#" MasterPageFile="~/JobSeekerModule/JobSeekerMaster.Master" AutoEventWireup="true" CodeBehind="JobSeekerChangePassword.aspx.cs" Inherits="Project_JobPortal_0507.JobSeekerModule.JobSeekerChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table>
        <tr style="background-color:#FAFAD2;border:dotted">
            <td>Current Password :</td> 
            <td>
               <asp:TextBox ID="txtcurrentpassword" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr style="background-color:#FAFAD2;border:dotted">
            <td>New Password :</td>
            <td><asp:TextBox ID="txtnewpassword" runat="server"></asp:TextBox></td>
        </tr>
        <tr style="background-color:#FAFAD2;border:dotted">
            <td>Confirm Password :</td>
            <td><asp:TextBox ID="txtconfirmpassword" runat="server"></asp:TextBox></td>
        </tr>
        <tr style="background-color:#FAFAD2;border:dotted">
             <td colspan="2" align="center"><asp:Button ID="btnchange" runat="server" Text="Change" OnClick="btnchange_Click" /> </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Label ID="lblmsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
            </td>
        </tr>
    </table>    
</asp:Content>
