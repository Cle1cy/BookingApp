using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ToDoApp_API.Context;
using ToDoApp_API.Helpers;
using ToDoApp_API.Interfaces;
using ToDoApp_App.Models;

namespace ToDoApp_API.Repository;
 
public class UserClassroomRepository : IUserClassroomRepository 
{

    private DBContext _dBContext;

    public UserClassroomRepository(DBContext context){

        _dBContext = context;
    }
    public Task<bool> CreateUserJoinClassroomAsync(int conversationId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CreateUserToClassroomAsync(UserClassroom userClassroom)
    {
        var queryResult =  _dBContext.UserClassroom
            .Add(userClassroom);
    }

    public Task<bool> DeleteUserClassroomAsync(int idUser, int conversationId)
    {
        throw new NotImplementedException();
    }

    public async Task<int> GetUserClassroomConversationIdasync(int idUser)
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<UserClassroom>> GetUserClassroomsAsync(int idUser)
    {
        ICollection<UserClassroom> queryResult = await _dBContext.UserClassroom
            .Where(uc => uc.Users.All(u => u.Id == idUser))
            .ToListAsync();
        
        if(queryResult.Any()){
            return queryResult;
        } throw new DbOperationException("The user is not attached to any classroom");
    }

    public async Task<ICollection<UserClassroom>> GetUsersClassroomsAsync(  string subject, string topic, 
                                                                            DateTime? startDate)
    {
        ICollection<UserClassroom> queryResult;
        if(startDate is null)
        {
            queryResult = await _dBContext.UserClassroom
                .Where( uc => uc.Subject == subject && 
                        uc.Topic == topic)
                .ToListAsync();
        }
        else if(string.IsNullOrEmpty(subject))
        {
            queryResult = await _dBContext.UserClassroom
                .Where( uc => uc.Topic == topic &&
                        uc.StartDate == startDate)
                .ToListAsync();
        }
        else if(string.IsNullOrEmpty(topic))
        {
            queryResult = await _dBContext.UserClassroom
                .Where( uc => uc.Subject == subject && 
                        uc.StartDate == startDate)
                .ToListAsync();
        }
        else if(string.IsNullOrEmpty(topic) && string.IsNullOrEmpty(subject))
        {
            queryResult = await _dBContext.UserClassroom
                .Where( uc => uc.StartDate == startDate)
                .ToListAsync();
        }
        else if(string.IsNullOrEmpty(subject) && startDate is not null){

            queryResult = await _dBContext.UserClassroom
                .Where( uc => uc.Topic == topic)
                .ToListAsync();
        }
        else
        {
            queryResult = await _dBContext.UserClassroom
                .Where( uc => uc.Subject == subject )
                .ToListAsync();
        }

        queryResult = await _dBContext.UserClassroom
            .Where( uc => uc.Subject == subject && 
                    uc.Topic == topic &&
                    uc.StartDate == startDate)
                    .ToListAsync();

        if(queryResult.Any()){
            return queryResult;
        }throw new DbOperationException("Couldn't found a classroom that matched the fields");
    }

}