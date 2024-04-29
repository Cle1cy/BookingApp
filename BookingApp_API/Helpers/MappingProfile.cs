using AutoMapper;
using System.Runtime;
using BookingApp_API.Dto;
using BookingApp_API.Models;

namespace BookingApp_API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto , User>();
            CreateMap<UserClassroom, UserClassroomDto>();
            CreateMap<UserClassroomDto, UserClassroom>();
        }
    }
}
