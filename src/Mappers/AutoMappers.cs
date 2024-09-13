using AutoMapper;
using DTOs;
using Entities;


namespace Mappers
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Area, AreaDto>().ReverseMap();
            CreateMap<AreaCreateDto, Area>();

            CreateMap<Employee, EmployeeDto>()
                
                .ReverseMap();
            CreateMap<EmployeeCreateDto, Employee>();

            CreateMap<OverTimeReport, OverTimeReportDto>().ReverseMap();
            CreateMap<OverTimeReportCreateDto, OverTimeReport>();
        }
    }
}
