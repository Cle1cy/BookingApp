using BookingApp_API.Context;
using BookingApp_API.Interfaces;
using BookingApp_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace BookingApp_API.Repository
{
    public class TopicForSubjectRepository : ITopicForSubject
    {
        private DBContext _dbContext;

        public TopicForSubjectRepository(DBContext context)
        {
            _dbContext = context;
        }

        public async Task<ICollection<TopicsForSubject>> GetAllAsync()
        {
            return await _dbContext.TopicsForSubject
                .ToListAsync();
        }
    }
}
