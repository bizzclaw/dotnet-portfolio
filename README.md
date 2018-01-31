# Portfolio Site (Working Title)
Joseph Tomlinson

A Web application programmed in .NET 1.1 meant to show my skills as a developer.

![Preview](https://i.imgur.com/VorW450.png)

## Requirements for building
__.NET 1.1 SDK__ [Windows](https://download.microsoft.com/download/F/4/F/F4FCB6EC-5F05-4DF8-822C-FF013DF1B17F/dotnet-dev-win-x64.1.1.4.exe) | [Mac OSX](https://download.microsoft.com/download/F/4/F/F4FCB6EC-5F05-4DF8-822C-FF013DF1B17F/dotnet-dev-osx-x64.1.1.4.pkg)

__.NET Runtime__ [Windows](https://download.microsoft.com/download/6/F/B/6FB4F9D2-699B-4A40-A674-B7FF41E0E4D2/dotnet-win-x64.1.1.4.exe) | [Max OSX](https://download.microsoft.com/download/6/F/B/6FB4F9D2-699B-4A40-A674-B7FF41E0E4D2/dotnet-osx-x64.1.1.4.pkg)

__MySQL Server__ [NAMP](https://www.mamp.info/en/) | [MySQL Workbench](https://www.mysql.com/products/workbench/)

__IDE:__ [Visual Studio](https://www.visualstudio.com)

__GIT CLI__ [Git-SCM](https://git-scm.com/downloads)

## Build Instructions
1. Clone with git to your local machine.
2. cd into Portfolio/Portfolio with your terminal/command prompt
3. run `dotnet restore`, this will install needed packaged for the app.
4. run `dotnet ef database update`, this will prepare the database for the app.
5. Open "Portfolio.sln" with Visual Studio
6. Click "__Run__" from visual studio, a web page will open displaying the site.

## Design
### User Stories
as a user, I want the main page to display some information about the developer, showing a hero at the top. below the hero will be two boxes, one will be titled "blog", the second will be titled "About"

as a user, I want to be able to sign in using standard authentication.

as a User, I want to be able to click on "Blog" and switch to a view that shows up to 5 blog posts.

as a User, I want to be able to search the blog, which will search all blog posts for matching strings. I want search results to populate without reloading the page.

As a user, I want to be able to click on the title of a blog post to view the full article.

As a user, I want to be able to see up to 10 user comments on the bottom of a blog post, and submit comments if I'm logged in.

As a user, I want to be able to sort comments by post date ascending or descending.

As a user, I want comments to be sorted without reloading the page.

as a user, I want to be able to click "more comments" and swap to a page that shows older comments

As a user, I want to be able to delete or edit my own posts.

as an admin, I want to be able to delete or edit all posts.

as a User, I want to be able to select the "About Page" from the home, which will display a new view that shows information about the developer, as well as a list of projects
as a User, I want to be able to search all of the projects by name, results will be displayed without reloading the page.

As an admin, I want to be able to submit a new project with a title, main image and description.
