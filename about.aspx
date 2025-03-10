<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="about.aspx.cs" Inherits="my_project.about" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>About Us - Educa</title>
    <link rel="stylesheet" href="css/about.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- About Section -->
    <section class="about">
        <div class="row">
            <div class="image">
                <img src="ProfileImages/about-img.svg" alt="" />
            </div>

            <div class="content">
                <h3>Why Choose Us?</h3>
                <p>Expert-Led Courses
Learn from industry professionals and experienced educators who provide high-quality content tailored to real-world applications.</p>
                <a href="courses.aspx" class="inline-btn">Our Courses</a>
            </div>
        </div>

        <div class="box-container">
            <div class="box">
                <i class="fas fa-graduation-cap"></i>
                <div>
                    <h3>+10</h3>
                    <p>Online Courses</p>
                </div>
            </div>
            <div class="box">
                <i class="fas fa-user-graduate"></i>
                <div>
                    <h3>+40</h3>
                    <p>Brilliant Students</p>
                </div>
            </div>
            <div class="box">
                <i class="fas fa-chalkboard-user"></i>
                <div>
                    <h3>+10</h3>
                    <p>Expert Tutors</p>
                </div>
            </div>
            <div class="box">
                <i class="fas fa-briefcase"></i>
                <div>
                    <h3>100%</h3>
                    <p>Job Placement</p>
                </div>
            </div>
        </div>
    </section>

    <!-- Student Reviews Section -->
    <section class="reviews">
        <h1 class="heading">Student's Reviews</h1>

        <div class="box-container">
            <div class="box">
                                <p>I love how I can learn at my own pace while balancing my studies and work. The interactive quizzes and real-world examples make learning enjoyable!"</p>

                <div class="student">
                    <img src="ProfileImages/pic-2.jpg" alt="" />
                    <div>
                        <h3>John Deo</h3>
                        <div class="stars">
                            <i class="fas fa-star"></i>
                            <i class="fas fa-star"></i>
                            <i class="fas fa-star"></i>
                            <i class="fas fa-star"></i>
                            <i class="fas fa-star-half-alt"></i>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Repeat similar blocks for other reviews -->
        </div>
    </section>

</asp:Content>
