using AutoMapper;
using Entities.Models;
using Entities.Models.Dto;

namespace API.Mapper
{
    public class ConfigMapper : Profile
    {
       public ConfigMapper()
        {
            CreateMap<TasksDto, Tasks>().ReverseMap();
        }
    }
}
