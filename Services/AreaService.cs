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
    public class AreaService : IAreaService
    {
        private readonly CompanyDbContext _context;
        private readonly IMapper _mapper;

        public AreaService(CompanyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AreaDto>> GetAllAreasAsync()
        {
            var areas = await _context.Areas.ToListAsync();
            return _mapper.Map<IEnumerable<AreaDto>>(areas);
        }

        public async Task<AreaDto> GetAreaByIdAsync(int id)
        {
            var area = await _context.Areas.FindAsync(id);
            return _mapper.Map<AreaDto>(area);
        }

        public async Task<AreaDto> CreateAreaAsync(AreaCreateDto areaCreateDto)
        {
            var area = _mapper.Map<Area>(areaCreateDto);
            area.CreationDate = DateTime.UtcNow; // Generar la fecha de creación por defecto
            _context.Areas.Add(area);
            await _context.SaveChangesAsync();
            return _mapper.Map<AreaDto>(area);
        }

        public async Task<AreaDto> UpdateAreaAsync(int id, AreaDto areaDto)
        {
            var existingArea = await _context.Areas.FindAsync(id);
            if (existingArea == null)
            {
                throw new InvalidOperationException("Area no encontrada.");
            }

            _mapper.Map(areaDto, existingArea);
            await _context.SaveChangesAsync();
            return _mapper.Map<AreaDto>(existingArea);
        }

        public async Task<bool> DeleteAreaAsync(int id)
        {
            var area = await _context.Areas.FindAsync(id);
            if (area == null)
            {
                return false;
            }

            _context.Areas.Remove(area);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}