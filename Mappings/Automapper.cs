using DTOs;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Mapeo de Área
            CreateMap<Area, AreaDto>().ReverseMap();

            // Mapeo de Empleado
            CreateMap<Employee, EmployeeDto>().ReverseMap();

            // Mapeo de Reporte de Horas Extras
            CreateMap<OverTimeReport, OverTimeReport>().ReverseMap();
        }
    }
}
