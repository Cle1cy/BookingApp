using AutoMapper;
using System.Runtime;
using ToDoApp_API.Dto;
using ToDoApp_App.Models;

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
