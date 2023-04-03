# Yeşilçam Movies Web Application
This is a movie web application built using ASP.NET Core 6 MVC, SQLite, JavaScript, jQuery, HTML, and CSS. The application allows users to browse movies, view movie details, and purchase movies by signing up for an account. Additionally, an admin user can perform CRUD operations on movies, actors, producers, and cinemas and view user orders.

# Usage
## Home Page
The home page displays a list of movies with their prices. Clicking on a movie will take you to the movie details page.

## Movie Details Page
The movie details page displays information about the movie, including the actors, producer, and cinema. Users can click on the actor, producer, or cinema names to view more information about them. To purchase the movie, the user must sign up for an account.

## Sign Up Page
The sign-up page allows users to create an account with their email address and a password.

## Admin Page
The admin page is accessible only to admin users. Admin users can perform CRUD operations on movies, actors, producers, and cinemas and view user orders.

# Technologies Used
- ASP.NET Core 6 MVC
- SQLite
- JavaScript
- JQuery
- Bootstrap
- HTML
- CSS
- Docker

# Installation
To run this application, you will need to have .NET and Docker installed on your machine. Follow these steps to install the application:

### 1- Clone the repository
```
 git clone https://github.com/onrdr/eCommerce-AspNetCore-MVC
```

### 2- Navigate to the API Directory
```
 cd eCommerce-AspNetCore-MVC
``` 

### 3- Build the docker image
(If you get docker daemon is not running error, Please make sure that the docker is running on your device.)
```
 docker build -f API/Dockerfile  -t movie-app .
```

### 5- Start the docker container
```
 docker run -it --rm -p 5000:80 movie-app
```

## Notes
### The Url should be in this format : localhost:5000

### The API uses SQLite as its database, so no additional setup is required for the database.

### You should now be able to run the project on your local machine now.   
 
