# ToDoApp 
<h3>Nuget</h3>

```
dotnet add package AutoMapper --version 13.0.1

dotnet add package Microsoft.AspNetCore.OpenApi --version 8.0.4

dotnet add package Microsoft.EntityFrameworkCore --version 8.0.4

dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.4

dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 8.0.4

dotnet add package Swashbuckle.AspNetCore --version 6.5.0
```

<h3> ToDo </h3>

- Update list state if 0, pending, if 1 completed
- You can add, delete, or modify a task in your to do.
- Ones you create a task it is created with the current date, if you modify it, it will be added an additional date as the last update date
- constraint for sections
- validation for a strong password, and a real mail
- implement JWT Auth
- encryption of password

<h3> Tasks Done </h3>
<details>
<summary>  Exception handler  </summary>
  <hr>
  <h2>Working un documentation 😅</h2>
</details>
<details>
<summary>  AutoMapper  </summary>
    <hr>
Using AutoMapper for endpoints 
<h3>Create the Model for User</h3>

```C#
namespace ToDoApp_App.Models;
public class User{

    [Key]
    [JsonPropertyName("id")]
    public int Id { get; set; } = 0;
    [JsonPropertyName("password")]
    public string Password{get; set;} = string.Empty;
    [JsonPropertyName("mail")]
    public string Mail { get; set; } = string.Empty;
    [JsonPropertyName("firstName")]
    public string FirtstName { get; set; } = string.Empty;
    [JsonPropertyName("lastName")]
    public string LastName{get;set;} = string.Empty;
    [JsonPropertyName("Note")]
    public ICollection<Note> Note{get; set;} = new List<Note>();

}
```
<h2>Create UserDto</h2>

```C#
namespace ToDoApp_API.Dto
{
    public class UserDto
    {
        [JsonPropertyName("password")]
        public string Password { get; set; } = string.Empty;
        [JsonPropertyName("mail")]
        public string Mail { get; set; } = string.Empty;
        [JsonPropertyName("firstName")]
        public string FirtstName { get; set; } = string.Empty;
        [JsonPropertyName("lastName")]
        public string LastName { get; set; } = string.Empty;

    }
}

</details>
```
<h3>Create AutoMapper</h3>

```C#
namespace ToDoApp_API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto , User>();
        }
    }
}
```

<h3> Look at the implemetation of AutoMapper en CreateUserAsync in Controllers</h3>

In this method we use AutoMapper for create storage, because we wanted the user only have the needed to write the necessary camps, we receive an UserDto and convert into a User, that way we can insert the user into DB then return the user but 
as a UserDtop, that way we can control what we are returning. in this case I don’t want to return the Id.

```C#
[HttpPost]
public async Task<IActionResult> CreateUserAsync(UserDto user)
{
    try
    {
        //AutoMapper part --------------------------------------
        User userMapper = _mapper.Map<User>(user);
        UserDto queryResult = _mapper.Map<UserDto>
            (await _userService.CreateUserAsync(userMapper));
        //------------------------------------------------------
        return Ok(queryResult);
    }
    catch (AppValidationException error)
    {
        return BadRequest($"Ops! Valitadion Error: {error.Message}");
    }
    catch (DbOperationException error)
    {
        return BadRequest($"Ops! Someting went wrong in DB Operation: {error.Message}");
    }
}
```
</details>


<details>
<summary> User functions: Delete account, update user info, create a new user </summary>
  <hr>
these are the methods for user, all of them that update the DB return a bool
in that way we can take the result of the operation and if it was true 
return the actualization in the services exept for DeletUserAsync. 

Look the following example

<h3>IUserRepository</h3>

```C#
using ToDoApp_App.Models;
namespace ToDoApp_API.Interfaces;
public interface IUserRepository{
    // GETTERS
    Task<ICollection<User>> GetUsersAsync();
    Task<User> GetUserAsync(string mail);
    //SETTERS   
    Task<bool> CreateUserAsync(User OneUser);
    //UPDATES
    Task<bool> UpdateUserMailAsync(string mail, string targetMail);
    Task<bool> UpdateUserPasswordAsync(string password, string mail);
    Task<bool> UpdateUserFirstNameAsync(string firtstName, string mail);
    Task<bool> UpdateUserLastNameAsync(string lastName, string mail);
    //DELETS
    //For delete the acount
    Task<bool> DeleteUserAsync(string password, string mail);
    //MORE
    Task<bool> ExistUserAsyn(string mail);
}
```


<h3>Repository for CreateUserAsync</h3>

```C#
    public async Task<bool> CreateUserAsync(User OneUser)
    {
        if (await ExistUserAsyn(OneUser.Mail)) 
            throw new DbOperationException("Couldn't insert. Account already exist.");
        try
        {
            var queryResult = await _dbContext
                    .AddAsync(OneUser);
            
            if (queryResult is not null)
            {
                await _dbContext.SaveChangesAsync();
                return true;
            }
                
            return false;
        }
        catch (DbUpdateException error)
        {
            throw new DbOperationException(error.Message);
        }  
    }
```

<h3>Service for CreateUserAsync</h3>

```C#
    public async Task<User> CreateUserAsync(User user)
    {
        if (user.Password.Length <= 8 ||
            user.Mail.Length <= 8 ||
            user.FirtstName.Length <= 3 ||
            user.LastName.Length <= 3)
        {
            throw new AppValidationException("One of the fields haven't correct format");
        } 

        bool queryOperation = await _userRepository
            .CreateUserAsync(user);
        if (!queryOperation)
            throw new AppValidationException("Operation executed but wasn't changes");
        return await GetUserAsync(user.Mail);
    }
```

</details>

<details>
<summary> Create DB </summary>
  <hr>
<h3> DB </h3>
Stright to the point, simple DB for the very basic functions

<h3> Query for DB using SQL server, with SSMS </h3>

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
<h3> Diagram </h3> 

![image](https://github.com/Cle1cy/ToDoApp/assets/72827264/2b1fa7ea-c96c-4f70-8ffc-d6518d83e6df)
</details>



