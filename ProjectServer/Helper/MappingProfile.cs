using AuthLibrary.Dtos;
using AutoMapper;
using DataLibrary.Models;

namespace ProjectServer.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Projects, ProjectDtos>().ReverseMap();
            CreateMap<Tasks, TasksDtos>().ReverseMap();
            CreateMap<SubTasks, SubTasksDtos>().ReverseMap();
            CreateMap<SubDetails, SubDetailsDtos>().ReverseMap();
        }
    }
}
