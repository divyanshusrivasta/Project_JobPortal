<%@ Page Title="" Language="C#" MasterPageFile="~/JobSeekerModule/JobSeekerMaster.Master" AutoEventWireup="true" CodeBehind="JobSeekerSendMail.aspx.cs" Inherits="Project_JobPortal_0507.JobSeekerModule.JobSeekerSendMail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <table>
            <tr>
                <td>From Email :</td>
                <td><asp:TextBox ID="txtfromemail" runat="server" ></asp:TextBox></td>
            </tr>
            <tr>
                <td>From Password :</td>
                <td><asp:TextBox ID="txtfrompassword" runat="server" ></asp:TextBox></td>
            </tr>
            <tr>
                <td>To Email :</td>
                <td><asp:TextBox ID="txttoemail" runat="server" ></asp:TextBox></td>
            </tr>
            <tr>
                <td>CC Email :</td>
                <td><asp:TextBox ID="txtccemail" runat="server" ></asp:TextBox></td>
            </tr>
            <tr>
                <td>Subject :</td>
                <td><asp:TextBox ID="txtsubject" runat="server" ></asp:TextBox></td>
            </tr>
            <tr>
                <td>Body :</td>
                <td><asp:TextBox ID="txtbody" runat="server" TextMode="MultiLine" Rows="5" Columns="60" ></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" align="center"><asp:Button ID="btnsend" runat="server" Text="Send" OnClick="btnsend_Click" /></td>
            </tr>

        </table>
    </center>

</asp:Content>
