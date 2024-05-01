
using BookingApp_API.Models;

namespace BookingApp_API.Interfaces;

public interface IUserClassroomRepository{

    //GET ---------------------------------------------------->
    //Get all the classrooms where an user is part from
    Task<ICollection<UserClassroom>> GetUserClassroomsAsync(int idUser);
    //Search all classroosm that will be use in the next days
    //filtred by Subject,Topic, and start date
    Task<ICollection<UserClassroom>> GetUsersClassroomsAsync(TopicsForSubject topicsForSubject,
                                                            DateTime? startDate
                                                            );
    //DELETE ------------------------------------------------->
    //Delete an user from a classroom
    Task<bool> DeleteUserClassroomAsync(int idUser, int conversationId);

    //SET ------------------------------------------------->
    //The user is attached to a random free classroom in a date withe a range of time,
    //select subject and topic for the study secion
    //MUST GENERATE A CONVERSATION ID
    Task<bool> CreateUserToClassroomAsync(UserClassroom userClassroom);
    Task<bool> CreateUserJoinClassroomAsync(int conversationId, string mail);

    //
}