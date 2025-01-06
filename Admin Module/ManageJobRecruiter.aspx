<%@ Page Title="" Language="C#" MasterPageFile="~/Admin Module/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageJobRecruiter.aspx.cs" Inherits="Project_JobPortal_0507.Admin_Module.ManageJobRecruiter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td><asp:TextBox ID="txtjorecruitername" runat="server" placeholder="Job Recruiter Name"></asp:TextBox>
            
                <asp:Button ID="btnsearch" runat="server" Text="Search" OnClick="btnsearch_Click" />
            </td>
        </tr>
        <tr>
            <td><asp:GridView ID="gvjobrecruiter" runat="server" AutoGenerateColumns="False" OnRowCommand="gvjobrecruiter_RowCommand" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" >
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <%#Eval("JobRecruiterName") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Website">
                        <ItemTemplate>
                            <%#Eval("JobRecruiterWebsite") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <%#Eval("JobRecruiterEmail") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Contact Person">
                        <ItemTemplate>
                            <%#Eval("JobRecruiterHR") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    
                    <asp:TemplateField HeaderText="Address">
                        <ItemTemplate>
                            <%#Eval("JobRecruiterAddress") %> , <%#Eval("JobSeekerCityName") %> , <%#Eval("JobSeekerStateName") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    

                    <asp:TemplateField HeaderText="Contact No.">
                        <ItemTemplate>
                            <%#Eval("JobRecruiterMobile") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Image">
                        <ItemTemplate>
                            <asp:Image ID="img" runat="server" Height="92px" Width="95px" ImageUrl='<%#Eval("JobRecruiterImage","~/JobRecruiterModule/JobRecruiterImage/{0}") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Comments">
                        <ItemTemplate>
                            <%#Eval("JobRecruiterComments") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Inserted Date">
                        <ItemTemplate>
                            <%#Eval("insertdate") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                         <ItemTemplate>
                            <asp:Button ID="btnblock" runat="server" Text='<%#Eval("JobRecruiterStatus").ToString()=="0" ? "Active":"Blocked" %>' CommandName="block" CommandArgument='<%#Eval("JobRecruiterId") %>' />
                         </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
                </asp:GridView></td>
        </tr>
    <tr>
        <td>
            <asp:Label ID="lblmsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
        </td>
    </tr>
    </table>

</asp:Content>
