<%@ Page Title="" Language="C#" MasterPageFile="~/JobRecruiterModule/JobRecruiterMaster.Master" AutoEventWireup="true" CodeBehind="JobRecruiterManageJobSeeker.aspx.cs" Inherits="Project_JobPortal_0507.JobRecruiterModule.JobRecruiterManageJobSeeker" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <asp:DropDownList ID="ddljobprofile" runat="server"></asp:DropDownList>

                <asp:DropDownList ID="ddlgender" runat="server">
                    <asp:ListItem Text="--Select Gender--" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Both" Value="3"></asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddlcity" runat="server"></asp:DropDownList>
            
                <asp:Button ID="btnsearch" runat="server" Text="Search" OnClick="btnsearch_Click" />
            </td>
        </tr>
        <tr>
            <td><asp:GridView ID="gvjobseeker" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" >
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <%#Eval("JobSeekerName") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <%#Eval("JobSeekerEmail") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Gender">
                        <ItemTemplate>
                            <%#Eval("JobSeekerGender").ToString()=="1" ? "Male":Eval("JobSeekerGender").ToString()=="2" ? "Female":"Other" %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Job Profile">
                        <ItemTemplate>
                            <%#Eval("JobSeekerJobProfileName") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Qualification">
                        <ItemTemplate>
                            <%#Eval("JobSeekerQualificationName") %> <%#Eval("JobSeekerExperiance").ToString()=="1"?"Fresher":Eval("JobSeekerExperiance").ToString()=="2"?"1+":Eval("JobSeekerExperiance").ToString()=="3"?"2+":Eval("JobSeekerExperiance").ToString()=="4"?"3+":"4+" +"Years" %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Address">
                        <ItemTemplate>
                            <%#Eval("JobSeekerAddress") %> , <%#Eval("JobSeekerCityName") %> , <%#Eval("JobSeekerStateName") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date Of Birth">
                        <ItemTemplate>
                            <%#Eval("Jbdob") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Contact No.">
                        <ItemTemplate>
                            <%#Eval("JobSeekerMobile") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Image">
                        <ItemTemplate>
                            <asp:Image ID="img" runat="server" Height="95px" Width="95px" ImageUrl='<%#Eval("JobSeekerImage","~/JobSeekerModule/JobseekerImage/{0}") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Resume">
                        <ItemTemplate>
                            <%#Eval("JobSeekerResume") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Comments">
                        <ItemTemplate>
                            <%#Eval("JobSeekerComments") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Inserted Date">
                        <ItemTemplate>
                            <%#Eval("insertdate") %>
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
