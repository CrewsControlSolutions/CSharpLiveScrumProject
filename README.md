# CSharpLiveScrumProject

<h2>Introduction</h2>
This project provides a Blog Photos section to a client's web app.  The purpose was to increase customer satisfaction and provide timely community news.  The blog section is written in C# using ASP.NET MVC and contributes to the web app's existing codebase.  For simplicity, only code for the blog is included in this repository.

<h2>Front End</h2>
The front end consists of features commonly found in a blog.  The <a href="https://github.com/CrewsControlSolutions/CSharpLiveScrumProject/blob/main/Screenshots/HomePage.PNG">Landing Page</a> provides a place for all blog posts to be displayed.  Each post is contained within a Bootstrap card, which is an extensible content container.  The number of columns containing cards depends on the window size; hence, this solution scales well for any window size, including mobile.  <a href="https://github.com/CrewsControlSolutions/CSharpLiveScrumProject/blob/main/Screenshots/HomePageCardOnHoverOver.PNG">Hovering over a card</a> reveals more information, including options for viewing details, editing, or deleting the post. <br><br>

Selecting the <a href="https://github.com/CrewsControlSolutions/CSharpLiveScrumProject/blob/main/Screenshots/BlogPhotoDetailsPage.PNG">Details</a> option simply displays the blog photo and title in a more expanded format in a new page. The <a href="https://github.com/CrewsControlSolutions/CSharpLiveScrumProject/blob/main/Screenshots/EditBlogPhotoPage.PNG">Edit page</a> allows for the changing of the blog title and/or photo.  Selecting the <a href="https://github.com/CrewsControlSolutions/CSharpLiveScrumProject/blob/main/Screenshots/DeleteBlogPhotoPage.PNG">Delete</a> option takes the user to a confirmation page for verification of blog post removal. <br>

A new blog post can be created by selecting Create New from the <a href="https://github.com/CrewsControlSolutions/CSharpLiveScrumProject/blob/main/Screenshots/HomePage.PNG">Landing Page</a>.  Once selected, a <a href="https://github.com/CrewsControlSolutions/CSharpLiveScrumProject/blob/main/Screenshots/CreateBlogPhoto.PNG">new page</a> opens for entering a blog title and selecting a photo from the file system.  Currently the selected photo must be in JPEG (.jpg) format.

CSS styling for the Blog Photo section is consistent with the color and font schema of the overall web app.<br><br>

<h2>Back End</h2>
A model contains the properties of a blog post.  Entity Framework is used to create a code-first database which links to the model.  The database is held in MS SQL Server.  Entity Framework is also used to scaffold the CRUD pages (in this case, the Create, Details, Edit, and Delete pages).

One of the more complex aspects is storing and retrieving blog photos. Storing photos is handled from the the Controller's Create action method.  Within this method, a separate ```PhotoConvert``` method (also within the Controller) is called and passed a photo object of type HttpPostedFileBase.  The ```PhotoConvert``` method contains a BinaryReader object which is used to convert the photo into a byte array for proper storage in the database.  

The ```ViewImage``` method, contained within the Controller, receives a photo's byte array from the database, buffers the photo, and returns a ```File``` object containing the buffered photo. The ```ViewImage``` method is called from numerous Views pages, such as at this line in the Index page.
