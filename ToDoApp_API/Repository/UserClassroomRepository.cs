using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
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

    public async Task<bool> CreateUserToClassroomAsync(UserClassroom userClassroom)
    {
        //get all base classrooms
        var classRoom = await _dBContext.ClassRooms
            .ToListAsync();
        //searching if ther is any classroom with not use at all
        var noClassRoomInUse =  await _dBContext.UserClassroom
            .Select(uc => classRoom.Except(uc.ClassRooms))
            .ToListAsync();
        
        if(noClassRoomInUse is not null){
            //there is no any UserClassroom that not exist in ClassRoom
            //search for any classroom free in the period of time
            var queryResult = await _dBContext.UserClassroom
                .Where( uc => 
                        uc.StartDate >= userClassroom.StartDate &&
                        uc.EndDate <= userClassroom.EndDate)
                .Select(uc => uc.ClassRooms)
                .FirstOrDefaultAsync();
            //add the free classroom in that time to our userClassroom
            if(queryResult is not null){
                userClassroom.ClassRooms = queryResult;                
            } 
        }

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