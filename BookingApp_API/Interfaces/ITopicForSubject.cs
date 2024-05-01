using BookingApp_API.Models;

namespace BookingApp_API.Interfaces
{
    public interface ITopicForSubject
    {
        Task<ICollection<TopicsForSubject>> GetAllAsync();
    }
}
