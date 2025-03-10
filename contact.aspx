<%@ Page Title="Contact Us" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeFile="contact.aspx.cs" Inherits="my_project.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Contact Section -->
    <section class="contact">
        <div class="row">
            <div class="image">
                <img src="images/contact-img.svg" alt="Contact Image"/>
            </div>
            
            <form id="contactForm" runat="server">
                <h3>Get in Touch</h3>
                <asp:TextBox ID="txtName" runat="server" CssClass="box" MaxLength="50" placeholder="Enter your name" Required="true"></asp:TextBox>
                
                <asp:TextBox ID="txtEmail" runat="server" CssClass="box" MaxLength="50" placeholder="Enter your email" TextMode="Email" Required="true"></asp:TextBox>
                
                <asp:TextBox ID="txtNumber" runat="server" CssClass="box" MaxLength="15" placeholder="Enter your number" TextMode="Phone" Required="true"></asp:TextBox>
                
                <asp:TextBox ID="txtMessage" runat="server" CssClass="box" MaxLength="1000" placeholder="Enter your message" TextMode="MultiLine" Required="true" Rows="5"></asp:TextBox>
                
                <!-- Label for displaying success/error messages -->
                <asp:Label ID="lblMessage" runat="server" CssClass="message-label"></asp:Label>
                
                <asp:Button ID="btnSubmit" runat="server" CssClass="inline-btn" Text="Send Message" OnClick="btnSubmit_Click" />
            </form>
        </div>
        
        <div class="box-container">
            <div class="box">
                <i class="fas fa-phone"></i>
                <h3>Phone Number</h3>
                <a href="tel:1234567890">123-456-7890</a>
                <a href="tel:1112223333">111-222-3333</a>
            </div>
            
            <div class="box">
                <i class="fas fa-envelope"></i>
                <h3>Email Address</h3>
                <a href="mailto:contact@example.com">contact@example.com</a>
                <a href="mailto:info@example.com">info@example.com</a>
            </div>
            
            <div class="box">
                <i class="fas fa-map-marker-alt"></i>
                <h3>Office Address</h3>
                <a href="#">Flat No. 1, A-1 Building, Jogeshwari, Mumbai, India - 400104</a>
            </div>
        </div>
    </section>
</asp:Content>