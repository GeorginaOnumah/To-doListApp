using AutoMapper;
using To_doListApp.Dtos;
using To_doListApp.Models;

namespace To_doListApp.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Map from DTOs to Models and vice versa if needed
            CreateMap<TaskCreateDto, TaskItem>();
            CreateMap<TaskUpdateDto, TaskItem>();
            CreateMap<TaskItem, TaskResponseDto>();
        }
    }
}
