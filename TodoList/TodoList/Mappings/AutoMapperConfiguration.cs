using AutoMapper;
using TodoList.DTOs;
using TodoList.Models;

namespace TodoList.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Register, Users>();
            cfg.CreateMap<Users, Register>();
        }
        
    }
}
