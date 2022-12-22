using AutoMapper;
using System.Collections.Generic;
using TodoList.DTOs;
using TodoList.Models;

namespace TodoList.Mappings
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Register, User>().ForMember(
                    des => des.UserName, act => act.MapFrom(src => src.UserName))
                    .ForMember(des => des.Password, act => act.MapFrom(src => BCrypt.Net.BCrypt.HashPassword(src.Password, 10)));
            CreateMap<ToDoRequest, ToDo>();
            CreateMap<Category, CategoryRespond>();
            CreateMap<ToDo, TaskRespond>();
        }
    }
}
