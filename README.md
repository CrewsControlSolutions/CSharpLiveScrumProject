# CSharpLiveScrumProject

<h2>Introduction</h2>
This project provides a Blog Photos section to a client's web app.  The purpose was to increase customer satisfaction and provide timely community news.  The blog section is written in C# using ASP.NET MVC and contributes to the web app's existing codebase.  For simplicity, only code for the blog is included in this repository.

<h2>Front End</h2>
The front end consists of features commonly found in a blog.  The <a href="https://github.com/CrewsControlSolutions/CSharpLiveScrumProject/blob/main/Screenshots/HomePage.PNG">Landing Page</a> provides a place for all blog posts to be displayed.  Each post is contained within a Bootstrap card, which is an extensible content container.  The number of columns containing cards depends on the window size; hence, this solution scales well for any window size, including mobile.  <a href="https://github.com/CrewsControlSolutions/CSharpLiveScrumProject/blob/main/Screenshots/HomePageCardOnHoverOver.PNG">Hovering over a card</a> reveals more information, including options for viewing details, editing, or deleting the post.

Selecting the Details option simply displays the blog photo and title in a more expanded format in a new page. The Edit page allows for the changing of the blog title and/or photo.  Selecting the Delete option takes the user to a confirmation page for verification of blog post removal.

A new blog post can be created by selecting Create New on from the Landing Page.  Once selected, a new page opens for 
