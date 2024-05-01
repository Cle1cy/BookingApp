using BookingApp_API.Interfaces;
using BookingApp_API.Models;
using BookingApp_API.Helpers;

namespace BookingApp_API.Services

{
    public class UserClassroomService
    {
        IUserClassroomRepository _userClassroomRepository;
        ITopicForSubject _topicForSubject;

        public UserClassroomService(IUserClassroomRepository userClassroomService,
                                     ITopicForSubject topicForSubject) 
        {
            _userClassroomRepository = userClassroomService;
            _topicForSubject = topicForSubject;
        }

        public async Task<ICollection<UserClassroom>> GetUserClassroomsAsync(int idUser)
        {
            return await _userClassroomRepository.GetUserClassroomsAsync(idUser);
        }
        public async Task<ICollection<UserClassroom>> GetUsersClassroomsAsync(TopicsForSubject topicsForSubjects,
                                                                            DateTime? startDate)
        {
            var ts = await _topicForSubject.GetAllAsync();

            if (!ts.Any(ts => ts.Topic == topicsForSubjects.Topic))
                throw new AppValidationException("Subject don't exist");

            if (!ts.Any(ts => ts.Subject == topicsForSubjects.Subject))
                throw new AppValidationException("Topic don't exist");

            if (startDate <= DateTime.Now) 
                throw new AppValidationException("You can't join a classroom that already started");

            return await _userClassroomRepository.GetUsersClassroomsAsync(topicsForSubjects, startDate);
        }
    }
}
