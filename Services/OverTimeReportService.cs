using AutoMapper;
using DTOs;
using Entities;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Repository;
using SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OverTimeReportService : IOverTimeReportService
    {
        private readonly CompanyDbContext _context;
        private readonly IMapper _mapper;

        public OverTimeReportService(CompanyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OverTimeReportDto>> GetAllOverTimeReportsAsync()
        {
            var reports = await _context.OverTimeReports.ToListAsync();
            return _mapper.Map<IEnumerable<OverTimeReportDto>>(reports);
        }

        public async Task<OverTimeReportDto> GetOverTimeReportByIdAsync(int id)
        {
            var report = await _context.OverTimeReports.FindAsync(id);
            return _mapper.Map<OverTimeReportDto>(report);
        }

        public async Task<OverTimeReportDto> CreateOverTimeReportAsync(OverTimeReportCreateDto reportCreateDto)
        {
            var employee = await _context.Employees
                .Include(e => e.OverTimeReports)
                .FirstOrDefaultAsync(e => e.EmployeeId == reportCreateDto.EmployeeId);

            if (employee == null)
            {
                throw new InvalidOperationException("Empleado no encontrado.");
            }

            // Regla de negocio 3: Un colaborador no puede reportar más de 40 horas extras para ser remuneradas en dinero dentro del mismo mes.
            if (reportCreateDto.IsRemunerated)
            {
                if (employee.TotalRemuneratedHoursThisMonth + reportCreateDto.ReportedHours > 40)
                {
                    throw new InvalidOperationException("No se pueden reportar más de 40 horas extras remuneradas en dinero dentro del mismo mes.");
                }
            }

            var report = _mapper.Map<OverTimeReport>(reportCreateDto);
            _context.OverTimeReports.Add(report);
            await _context.SaveChangesAsync();
            return _mapper.Map<OverTimeReportDto>(report);
        }

        public async Task<OverTimeReportDto> UpdateOverTimeReportAsync(int id, OverTimeReportDto reportDto)
        {
            var existingReport = await _context.OverTimeReports.FindAsync(id);
            if (existingReport == null)
            {
                throw new InvalidOperationException("Reporte de horas extras no encontrado.");
            }

            _mapper.Map(reportDto, existingReport);
            await _context.SaveChangesAsync();
            return _mapper.Map<OverTimeReportDto>(existingReport);
        }

        public async Task<bool> DeleteOverTimeReportAsync(int id)
        {
            var report = await _context.OverTimeReports.FindAsync(id);
            if (report == null)
            {
                return false;
            }

            _context.OverTimeReports.Remove(report);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}

