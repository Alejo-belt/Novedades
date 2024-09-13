using DTOs;
using Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OverTimeReportsController : ControllerBase
    {
        private readonly IOverTimeReportService _overTimeReportService;

        public OverTimeReportsController(IOverTimeReportService overTimeReportService)
        {
            _overTimeReportService = overTimeReportService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OverTimeReportDto>>> GetAllOverTimeReports()
        {
            var reports = await _overTimeReportService.GetAllOverTimeReportsAsync();
            return Ok(reports);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OverTimeReportDto>> GetOverTimeReportById(int id)
        {
            var report = await _overTimeReportService.GetOverTimeReportByIdAsync(id);
            if (report == null)
            {
                return NotFound();
            }
            return Ok(report);
        }

        [HttpPost]
        public async Task<ActionResult<OverTimeReportDto>> CreateOverTimeReport(OverTimeReportCreateDto overTimeReportCreateDto)
        {
            try
            {
                var createdReport = await _overTimeReportService.CreateOverTimeReportAsync(overTimeReportCreateDto);
                return CreatedAtAction(nameof(GetOverTimeReportById), new { id = createdReport.OverTimeReportId }, createdReport);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<OverTimeReportDto>> UpdateOverTimeReport(int id, OverTimeReportDto reportDto)
        {
            try
            {
                var updatedReport = await _overTimeReportService.UpdateOverTimeReportAsync(id, reportDto);
                return Ok(updatedReport);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOverTimeReport(int id)
        {
            var result = await _overTimeReportService.DeleteOverTimeReportAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}