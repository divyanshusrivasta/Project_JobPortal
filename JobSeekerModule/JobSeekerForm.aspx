<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="JobSeekerForm.aspx.cs" Inherits="Project_JobPortal_0507.Job_Seeker_Module.JobSeekerForm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
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
        
            <td>Gender :</td>
            <td><asp:RadioButtonList ID="rblgender" runat="server" RepeatColumns="3">
                <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                <asp:ListItem Text="Other" Value="3"></asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr style="background-color:antiquewhite;border:dotted">
            <td>Job Profile :</td>
            <td><asp:DropDownList ID="ddljobprofile" runat="server"></asp:DropDownList></td>
        
            <td>Qualification :</td>
            <td><asp:DropDownList ID="ddlqualification" runat="server"></asp:DropDownList></td>
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
        
            <td>Date Of Birth :</td>
            <td><asp:TextBox ID="txtdob" runat="server"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="cal" runat="server" PopupButtonID="txtdob" PopupPosition="TopRight" TargetControlID="txtdob" />
            </td>
        </tr>
        <tr style="background-color:antiquewhite;border:dotted">
            <td>Mobile :</td>
            <td><asp:TextBox ID="txtmobile" runat="server"></asp:TextBox></td>
        
            <td>Experiance :</td>
            <td><asp:RadioButtonList ID="rblexperiance" runat="server" RepeatColumns="5">
                <asp:ListItem Text="Fresher" Value="1"></asp:ListItem>
                <asp:ListItem Text="1+" Value="2"></asp:ListItem>
                <asp:ListItem Text="2+" Value="3"></asp:ListItem>
                <asp:ListItem Text="3+" Value="4"></asp:ListItem>
                <asp:ListItem Text="4+" Value="5"></asp:ListItem>
             </asp:RadioButtonList></td>
        </tr>
        <tr style="background-color:antiquewhite;border:dotted">
            <td>Image :</td>
            <td><asp:FileUpload ID="fuimg" runat="server" /></td>
       
            <td>Resume :</td>
            <td><asp:FileUpload ID="furesume" runat="server" /></td>
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
