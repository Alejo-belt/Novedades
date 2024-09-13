using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IOverTimeReportService
    {
        Task<IEnumerable<OverTimeReportDto>> GetAllOverTimeReportsAsync();
        Task<OverTimeReportDto> GetOverTimeReportByIdAsync(int id);
        Task<OverTimeReportDto> CreateOverTimeReportAsync(OverTimeReportCreateDto overTimeReportCreateDto);
        Task<OverTimeReportDto> UpdateOverTimeReportAsync(int id, OverTimeReportDto reportDto);
        Task<bool> DeleteOverTimeReportAsync(int id);
    }
}
