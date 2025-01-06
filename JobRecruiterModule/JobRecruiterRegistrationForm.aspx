<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="JobRecruiterRegistrationForm.aspx.cs" Inherits="Project_JobPortal_0507.Job_Recruiter_Module.JobRecruiterREgistrationForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <asp:ScriptManager ID="mng" runat="server"></asp:ScriptManager>
        <tr style="background-color:antiquewhite;border:dotted">
            <td>Name :</td>
            <td><asp:TextBox ID="txtname" runat="server"></asp:TextBox></td>
        
            <td>Email :</td>
            <td><asp:TextBox ID="txtemail" runat="server"></asp:TextBox></td>
        </tr>
        <tr style="background-color:antiquewhite;border:dotted">
            <td>Password :</td>
            <td><asp:TextBox ID="txtpassword" runat="server"></asp:TextBox></td>
        
            <td>HR :</td>
            <td><asp:TextBox ID="txthr" runat="server"></asp:TextBox></td>
        </tr>
        <tr style="background-color:antiquewhite;border:dotted">
            <td>State :</td>
            <td><asp:DropDownList ID="ddlstate" runat="server" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
       
            <td>City :</td>
            <td><asp:DropDownList ID="ddlcity" runat="server"></asp:DropDownList></td>
        </tr>
        <tr style="background-color:antiquewhite;border:dotted">
            <td>Address :</td>
            <td><asp:TextBox ID="txtaddress" runat="server"></asp:TextBox></td>
        
            <td>Company Website:</td>
            <td><asp:TextBox ID="txtwebsite" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr style="background-color:antiquewhite;border:dotted">
            <td>Mobile :</td>
            <td><asp:TextBox ID="txtmobile" runat="server"></asp:TextBox></td>
        
            <td>Image :</td>
            <td><asp:FileUpload ID="fuimg" runat="server" /></td>
        </tr>
        <tr style="background-color:antiquewhite;border:dotted">
            <td style="vertical-align:top;">Comments :</td>
            <td colspan="3"><asp:TextBox ID="txtcomments" runat="server" TextMode="MultiLine" Rows="6" Columns="80"></asp:TextBox></td>
        </tr>
        <tr style="background-color:antiquewhite;border:dotted">
            
            <td colspan="4" align="center"><asp:Button ID="btnadd" runat="server" Text="Add" OnClick="btnadd_Click" /></td>
        </tr>

    </table>

</asp:Content>
