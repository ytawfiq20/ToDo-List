This is a basic Todo list app where you can create as many lists as you want. Within each list, you can add numerous tasks, each equipped with a completion button. Additionally, each task allows you to add notes. The app provides functionalities to edit or delete lists, tasks, and notes.

How to run project?
You must install dotnet core 8, sql server and Visual studio code or visual studio 2022
to run project in visual studio code
- first you should add migration to create database in sql server
go to (ToDoList.Data)
from terminal write (add-migration InitialCreate) if you use visual studio 2022 or (dotnet ef migrations add InitialCreate) if you use visual studio code
then write (update-database) if you use visual studio 2022 or (dotnet ef database update) if you use visual studio code

- second go to (ToDoList.Api) and use {dotnet run} command from terminal if you use visual studio code or run it from visual studio 2022

