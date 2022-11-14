using Alura.WebApi.Data.DTOs;
using Alura.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace Alura.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private CinemaService _service;

        public CinemaController(CinemaService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult AdicionaCinema([FromBody] CreateCinemaDTO cinemaDto)
        {
            var cinema = _service.AdicionaCinema(cinemaDto);

            return CreatedAtAction(nameof(RecuperaCinemaPorId), new { Id = cinema.Id }, cinema);
        }

        [HttpGet]
        public IEnumerable<ReadCinemaDTO> RecuperaCinemas()
        {
            return _service.RecuperaCinemas();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCinemaPorId(int id)
        {
            var cinema = _service.RecuperaCinemaPorId(id);
            
            if (cinema == null)
                return NotFound();

            return Ok(cinema);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDTO cinemaDto)
        {
            var result = _service.AtualizaCinema(id, cinemaDto);

            if (result.IsFailed)
                return NotFound();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletaCinema(int id)
        {
            var result = _service.DeletaCinema(id);
            
            if (result.IsFailed)
                return NotFound();
            
            return NoContent();
        }
    }
}
