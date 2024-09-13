using AutoMapper;
using DTOs;
using Entities;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Repository;
using SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly CompanyDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeService(CompanyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
        {
            var employees = await _context.Employees.ToListAsync();
            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public async Task<EmployeeDto> GetEmployeeByIdAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task<EmployeeDto> CreateEmployeeAsync(EmployeeCreateDto employeeCreateDto)
        {
            // Regla de negocio 1: Ningún colaborador puede ingresarse al sistema sin un líder asociado, a excepción del gerente de la empresa.
            if (employeeCreateDto.Rol != Role.gerente && employeeCreateDto.LeaderId == null)
            {
                throw new InvalidOperationException("Un colaborador debe tener un líder asociado.");
            }
            var employee = _mapper.Map<Employee>(employeeCreateDto);
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task<EmployeeDto> UpdateEmployeeAsync(int id, EmployeeDto employeeDto)
        {
            var existingEmployee = await _context.Employees.FindAsync(id);
            if (existingEmployee == null)
            {
                throw new InvalidOperationException("Empleado no encontrado.");
            }

            _mapper.Map(employeeDto, existingEmployee);
            await _context.SaveChangesAsync();
            return _mapper.Map<EmployeeDto>(existingEmployee);
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return false;
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}