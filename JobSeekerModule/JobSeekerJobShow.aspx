<%@ Page Title="" Language="C#" MasterPageFile="~/JobSeekerModule/JobSeekerMaster.Master" AutoEventWireup="true" CodeBehind="JobSeekerJobShow.aspx.cs" Inherits="Project_JobPortal_0507.JobSeekerModule.JobSeekerJobShow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table>
    <tr>
        <td>
            <asp:DropDownList ID="ddljobprofile" runat="server"></asp:DropDownList>
        
            <asp:Button ID="btnsearch" runat="server" Text="Search" OnClick="btnsearch_Click" />
        </td>
    </tr>
        <tr>
            <td>
                <asp:GridView ID="gvjobshow" runat="server" AutoGenerateColumns="False" OnRowCommand="gvjobshow_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="Company Name">
                            <ItemTemplate>
                                <%#Eval("JobRecruiterName") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="JobProfile">
                            <ItemTemplate>
                                <%#Eval("JobSeekerJobProfilename") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Working Mode">
                            <ItemTemplate>
                                <%#Eval("JobPostMode").ToString()=="1" ? "Work From Office" : Eval("JobPostMode").ToString()=="2" ? "Work From Home" : "Hybrid Mode" %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Gender">
                            <ItemTemplate>
                                <%#Eval("JobPostGender").ToString()=="1" ? "Male" :Eval("JobPostGender").ToString()=="2" ? "Female" : "Both"  %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Required Qualifications">
                            <ItemTemplate>
                                <%#Eval("JobPostQaulification") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Required Exp">
                            <ItemTemplate>
                                <%#Eval("JobPostMinExp") %> year - <%#Eval("JobPostMaxExp") %> year
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="Offered Salary">
                            <ItemTemplate>
                                Rs. <%#Eval("JobPostMinSalary") %>  - Rs. <%#Eval("JobPostMaxSalary") %> 
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Vacancy">
                            <ItemTemplate>
                                <%#Eval("JobPostVacancy") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Inserted Date">
                            <ItemTemplate>
                                <%#Eval("JPInserteddate") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnapply" runat="server" Text="Apply" CommandName="Apply" />
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
            </td>
        </tr>
    <tr>
        <td>
            <asp:Label ID="lblmsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
        </td>
    </tr>
    </table>

</asp:Content>
