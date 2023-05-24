using Microsoft.AspNetCore.Mvc;
using RectanglesApp.Models.DTO;
using RectanglesApp.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RectanglesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RectanglesController : ControllerBase
    {
        private readonly IRegtanglesService _regtanglesService;

        public RectanglesController(IRegtanglesService regtanglesService)
        {
            _regtanglesService = regtanglesService;
        }

        // GET: api/<RectangularsController>
        [HttpGet]
        public async Task<ActionResult<RectangleDTO>> GetAll()
        {
            var result = await _regtanglesService.GetRectanglesAsync();

            return Ok(result);
        }

        // GET api/<RectangularsController>/5/6
        [HttpGet("{x}/{y}")]
        public async Task<ActionResult<RectangleDTO>> GetRectaglesByParams(int x, int y)
        {
            var result = await _regtanglesService.GetRectanglesByCoordinatesAsync(x,y);

            if (result?.Count>0)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
