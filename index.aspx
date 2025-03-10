<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Admin_learning.WebForm1" MasterPageFile="~/Site1.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="dashboard">
        <div class="top">
            <i class="uil uil-bars sidebar-toggle"></i>
            <div class="search-box">
                <i class="uil uil-search"></i>
                <input type="text" placeholder="Search here..."/>
            </div>
            <img src="img/profile.jpg" alt=""/>
        </div>

        <div class="dash-content">
            <div class="overview">
                <div class="title">
                    <i class="uil uil-tachometer-fast-alt"></i>
                    <span class="text">Dashboard</span>
                </div>

                <div class="boxes">
                    <div class="box box1">
                        <i class="uil uil-thumbs-up"></i>
                        <span class="text">Total Likes</span>
                        <span class="number">50,120</span>
                    </div>
                    <div class="box box2">
                        <i class="uil uil-comments"></i>
                        <span class="text">Comments</span>
                        <span class="number">20,120</span>
                    </div>
                    <div class="box box3">
                        <i class="uil uil-share"></i>
                        <span class="text">Total Share</span>
                        <span class="number">10,120</span>
                    </div>
                </div>
            </div>

            <div class="activity">
                <div class="title">
                    <i class="uil uil-clock-three"></i>
                    <span class="text">Students</span>
                </div>

                <div class="activity-data">
                    <asp:GridView ID="gvLecturers" runat="server" AutoGenerateColumns="False" CssClass="activity-grid">
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Id" />
                            <asp:BoundField DataField="Stud_Name" HeaderText="Student Name" SortExpression="Stud_Name" />
                            <asp:BoundField DataField="Stud_Email" HeaderText="Email" SortExpression="Stud_Email" />
                            <asp:TemplateField HeaderText="Image">
                                <ItemTemplate>
                                    <asp:Image ID="imgStudent" runat="server" ImageUrl='<%# Eval("Image") %>' Width="50px" Height="50px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Video">
                                <ItemTemplate>
                                    <asp:HyperLink ID="lnkVideo" runat="server" Text="View Video" 
                                        NavigateUrl='<%# Eval("Video") %>' Target="_blank">
                                    </asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
