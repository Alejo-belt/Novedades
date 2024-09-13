using DTOs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IAreaService
    {
        Task<IEnumerable<AreaDto>> GetAllAreasAsync();
        Task<AreaDto> GetAreaByIdAsync(int id);
        Task<AreaDto> CreateAreaAsync(AreaCreateDto areaCreateDto);
        Task<AreaDto> UpdateAreaAsync(int id, AreaDto areaDto);
        Task<bool> DeleteAreaAsync(int id);
    }
}
