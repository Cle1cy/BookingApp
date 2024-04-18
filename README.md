# ToDoApp 
<h3> ToDo </h3>

- Update list state if 0, pending, if 1 completed
- Update user info
- Delete account
- You can add, delete, or modify a task in your to do.
- Ones you create a task it is created with the current date, if you modify it, it will be added an additional date as the last update date
<h3> Task Done </h3>
<details>
<summary> Create User </summary>
</details>


<details>
<summary> Create DB </summary>
  
<h2> DB </h2>
Stright to the point, simple DB for the very basic functions

<h2> Query for DB using SQL server, with SSMS </h2>

```SQL
CREATE TABLE [User](
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Password VARCHAR(50) NOT NULL,
    Mail VARCHAR(50) NOT NULL,
    FirtstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL
);
CREATE TABLE [Note](
    Id BIGINT IDENTITY(1,1) PRIMARY KEY,
    Title VARCHAR(50) NOT NULL,
    Description VARCHAR(50) NOT NULL,
    CreateDate DATE NOT NULL,
    UpdateDate DATE NOT NULL,
    State VARCHAR(50) NOT NULL,
    UserId INT NOT NULL,
    FOREIGN KEY(UserId) REFERENCES [user](Id)
);
```
<h2> Diagram </h2> 

![image](https://github.com/Cle1cy/ToDoApp/assets/72827264/2b1fa7ea-c96c-4f70-8ffc-d6518d83e6df)
</details>



