# CodingTracker

CodingTracker is a simple console-based application for tracking time spent coding.  
The application is written in **C#** and uses **SQLite** for data storage.

The main goal of this project is to practice working with databases, Dapper ORM, and building a clean console user interface using Spectre.Console.

---

## Features

- Add a new coding session (start time & end time)
- View all recorded coding sessions
- Update existing coding sessions
- Delete coding sessions
- Persistent data storage using SQLite
- User-friendly console UI with Spectre.Console

---

##  Technologies Used

- **C#**
- **.NET**
- **SQLite**
- **Dapper ORM**
- **Spectre.Console**

---

## Requirements

- .NET SDK (recommended .NET 8 or newer)
- Windows, Linux, or macOS

---

## Database

The application uses SQLite as a local database.
The database file is created automatically on the first run of the application.

## Project Purpose

This project was created as a learning exercise to improve skills in:

- C# and .NET
- Working with SQLite databases
- Using Dapper ORM
- Building interactive console applications
- Writing clean and maintainable code

## Possible Future Improvements

- Add daily / weekly / monthly statistics
- Add unit tests

## How to Use

 **Run the Application**  
   Launch the console app — it will automatically create the database and table if need.  

**Main Menu**

	You will see the following option:

		1. Add Session

		2. Edit Session

		3. Delete Session

		4. Show Sessions

		5. Exit 

**Add Session**  
- Select option.  
- Enter the start time (`dd-MM-yy HH:mm`).  
- Enter the end time (`dd-MM-yy HH:mm`). 

**Edit Session**  
- Select option.  
- Type in the record `Id`.  
- Provide a new start or end time.

**Delete Session**
- Select option.
- Type in the record `Id`.

**Show Sessions**  
- Select this option to see all sessions.  

 **Exit**  
- Select to quit the application.  

## Lecense

This project is open-source and available under the MIT License.



