<%@ Page Title="" Language="C#" MasterPageFile="~/JobRecruiterModule/JobRecruiterMaster.Master" AutoEventWireup="true" CodeBehind="JobRecruiterJobPost.aspx.cs" Inherits="Project_JobPortal_0507.JobRecruiterModule.JobRecruiterJobPost" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr style="background-color:antiquewhite;border:dotted">
            <td>Job Profile Name :</td>
            <td><asp:DropDownList ID="ddljobprofile" runat="server"></asp:DropDownList></td>
        
            <td>Mode Of Work :</td>
            <td><asp:RadioButtonList ID="rblworkmode" runat="server" RepeatColumns="3">
                <asp:ListItem Text="Work From Office" Value="1"></asp:ListItem>
                <asp:ListItem Text="Work From Home" Value="2"></asp:ListItem>
                <asp:ListItem Text="Hybrid Mode" Value="3"></asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr style="background-color:antiquewhite;border:dotted">
            <td>Gender :</td>
            <td><asp:RadioButtonList ID="rblgender" runat="server" RepeatColumns="3">
                <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                <asp:ListItem Text="Both" Value="3"></asp:ListItem>
                </asp:RadioButtonList></td>
        
            <td>Qualification :</td>
            <td><asp:CheckBoxList ID="cblqualification" runat="server" RepeatColumns="4"></asp:CheckBoxList></td>
        </tr>
        <tr style="background-color:antiquewhite;border:dotted">
            <td>Min Experiance :</td>
            <td><asp:TextBox ID="txtminexp" runat="server"></asp:TextBox></td>
        
            <td>Max Experiance :</td>
            <td><asp:TextBox ID="txtmaxexp" runat="server"></asp:TextBox></td>
        </tr>

        <tr style="background-color:antiquewhite;border:dotted">
            <td>Min Salary :</td>
            <td><asp:TextBox ID="txtminsalary" runat="server"></asp:TextBox></td>
        
            <td>Max Salary :</td>
            <td><asp:TextBox ID="txtmaxsalary" runat="server"></asp:TextBox></td>
        </tr>
        <tr style="background-color:antiquewhite;border:dotted">
            <td>Vacancy:</td>
            <td><asp:TextBox ID="txtvacancy" runat="server"></asp:TextBox></td>
        
            <td>Comments :</td>
            <td><asp:TextBox ID="txtcomments" runat="server" TextMode="MultiLine" Rows="5" Columns="50"></asp:TextBox></td>
        </tr>
        <tr style="background-color:antiquewhite;border:dotted">
            <td colspan="4" align="center"><asp:Button ID="btnadd" runat="server" Text="Add Job" OnClick="btnadd_Click" /></td>
        </tr>




    </table>
</asp:Content>
