using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.IdentityModel.Tokens;
using BookingApp_API.Context;
using BookingApp_API.Helpers;
using BookingApp_API.Interfaces;
using BookingApp_API.Models;

namespace BookingApp_API.Repository;
 
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

        //Get the last conversationId
        int conversationId = await _dBContext.UserClassroom
            .OrderByDescending(uc => uc.ConversationId)
            .Select(uc => uc.ConversationId)
            .FirstOrDefaultAsync();
        //get all base classrooms
        var classRoom = await _dBContext.ClassRooms
            .ToListAsync();
        //searching if ther is any classroom with not use at all
        var noClassRoomInUse = await _dBContext.UserClassroom
            .SelectMany(uc => classRoom.Except(uc.ClassRooms))
            .ToListAsync();

        //get a random classroom
        Random rnd = new Random();
        int[] noClassRoomInUseArray = noClassRoomInUse.Select(u => u.Id).ToArray();
        int randomIndex = rnd.Next(0, noClassRoomInUseArray.Length);
        int randomElement = noClassRoomInUseArray[randomIndex];


        if (noClassRoomInUse is null){
            //there is no any UserClassroom that not exist in ClassRoom
            //search for any classroom free in the period of time
            var freeClassroom = await _dBContext.UserClassroom
                .Where( uc => 
                        uc.StartDate >= userClassroom.StartDate &&
                        uc.EndDate <= userClassroom.EndDate)
                .ToListAsync();

            //get a random classroom
            int[] freeClassroomArray = freeClassroom.Select(u => u.Id).ToArray();
            rnd = new Random();
            randomIndex = rnd.Next(0, freeClassroomArray.Length);
            randomElement = freeClassroomArray[randomIndex];
            //add the free classroom in that time to our userClassroom
            if (freeClassroom is not null)
            {
                userClassroom.ClassRooms = (ICollection<ClassRoom>?)freeClassroom
                    .Where(fc => fc.Id == randomElement);

                userClassroom.ConversationId = conversationId + 1;
            }
            else throw new DbOperationException("There is no any classroom free in the selected date");
        }
        else { 
            userClassroom.ClassRooms = (ICollection<ClassRoom>?)noClassRoomInUse
                .Where(cr => cr.Id == randomElement);
            if(conversationId > 0) userClassroom.ConversationId = conversationId + 1;
            else userClassroom.ConversationId = 1;
        }
        try
        {
           var queryResult = await _dBContext.UserClassroom
                .AddAsync(userClassroom);

            if (queryResult is not null)
            {
                await _dBContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        catch(DbOperationException error) 
        {
            throw new DbOperationException(error.Message);
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