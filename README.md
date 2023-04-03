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
 docker build -f WebUI/Dockerfile  -t movie-app .
```

### 5- Start the docker container
```
 docker run -it --rm -p 5000:80 movie-app
```

### 6- Go to the adress below
```
localhost:5000
```
# Important Notes 

### The project uses SQLite as its database and has initial data inside it, so no additional setup is required for the database. 
### But if you want to use another database from scratch, Just change the connection string in appsettings.json and make other settings in Program.cs 
### There is a Data Seeder class in program.cs as you will see and it will automatically seed the data to the DB just for the first time you run the project. 

### Here are login credentials one for admin and one for normal user for you to try the applicatio
Email: admin@etickets.com
Password: @Admin1*

Email: user@etickets.com
Password: @User1* 
