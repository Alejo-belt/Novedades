using DTOs;
using Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{



    [ApiController]
    [Route("api/[controller]")]
    public class AreasController : ControllerBase
    {
        private readonly IAreaService _areaService;

        public AreasController(IAreaService areaService)
        {
            _areaService = areaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AreaDto>>> GetAllAreas()
        {
            var areas = await _areaService.GetAllAreasAsync();
            return Ok(areas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AreaDto>> GetAreaById(int id)
        {
            var area = await _areaService.GetAreaByIdAsync(id);
            if (area == null)
            {
                return NotFound();
            }
            return Ok(area);
        }

        [HttpPost]
        public async Task<ActionResult<AreaDto>> CreateArea(AreaCreateDto areaCreateDto)
        {
            var createdArea = await _areaService.CreateAreaAsync(areaCreateDto);
            return CreatedAtAction(nameof(GetAreaById), new { id = createdArea.AreaId }, createdArea);
        }

        [HttpPut]
        public async Task<ActionResult<AreaDto>> UpdateArea(int id, AreaDto areaDto)
        {
            try
            {
                var updatedArea = await _areaService.UpdateAreaAsync(id, areaDto);
                return Ok(updatedArea);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteArea(int id)
        {
            var result = await _areaService.DeleteAreaAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
    }
