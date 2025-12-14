# Hotel Booking Web Application

A full-stack **ASP.NET Core MVC** web application that simulates a hotel booking platform.  
The project includes **room management**, **user authentication**, **reservations**, and an **admin dashboard**, with a clean UI built using **Bootstrap**.

---

## Features

### User
- User registration & login (ASP.NET Identity)
- View available rooms
- Book rooms
- View personal reservations
- Profile page with personal information
- Request profile changes via contact form (fake email)

### Rooms
- List of available rooms
- Room details: number, type, price
- Room images via URL
- Responsive card-based UI

### Admin Panel
- Admin-only access
- Create new rooms
- Delete rooms
- View all reservations
- Confirm or delete reservations
- Manage registered users
- Seeded admin account

---

## Technologies Used

- **ASP.NET Core MVC**
- **Entity Framework Core**
- **SQL Server**
- **ASP.NET Identity**
- **Bootstrap 5**
- **Razor Views**
- **Dependency Injection**
- **Code First + Migrations**

---

## Setup Instructions

1. Clone the repository:

     git clone https://github.com/RiccardoEpicode/Week6-Progetto-Hotel.git
   
3. Open the solution in Visual Studio

4. Update database:

    add-migration InitialCreate
    update-database

5. Explore the features:

    Register a new user
    
    Log in
    
    Create at least one booking
    
    View profile and reservations

6. For Admin Login:
    - username: admin@hotel.com
    - password: Admin123!

 ## Author

Riccardo Reali
ASP.NET / Back-End Student – Epicode
