<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="update.aspx.cs" Inherits="my_project.update" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Update Profile</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="form-container">
        <form action="" method="post" enctype="multipart/form-data">
            <h3>Update Profile</h3>

            <!-- Name Update -->
            <p>Update Name</p>
            <input type="text" name="name" placeholder="Shaikh Anas" maxlength="50" class="box">

            <!-- Email Update -->
            <p>Update Email</p>
            <input type="email" name="email" placeholder="shaikh@gmail.com" maxlength="50" class="box">

            <!-- Previous Password -->
            <p>Previous Password</p>
            <input type="password" name="old_pass" placeholder="Enter your old password" maxlength="20" class="box">

            <!-- New Password -->
            <p>New Password</p>
            <input type="password" name="new_pass" placeholder="Enter your new password" maxlength="20" class="box">

            <!-- Confirm Password -->
            <p>Confirm Password</p>
            <input type="password" name="c_pass" placeholder="Confirm your new password" maxlength="20" class="box">

            <!-- Profile Picture Update -->
            <p>Update Picture</p>
            <input type="file" accept="image/*" class="box">

            <!-- Submit Button -->
            <input type="submit" value="Update Profile" name="submit" class="btn">
        </form>
    </section>

</asp:Content>
