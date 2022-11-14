using Microsoft.AspNetCore.Mvc;
using Alura.WebApi.Models;
using Alura.WebApi.Data.DTOs.Sessao;
using Alura.WebApi.Services;

namespace Alura.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SessaoController : ControllerBase
    {
        private SessaoService _service;

        public SessaoController(SessaoService service)
        {
            _service = service;
        }


        [HttpGet]
        public IEnumerable<ReadSessaoDTO> RecuperaSessoes()
        {
            return _service.RecuperaSessoes();
        }

        [HttpGet("{id}")]
        public ActionResult<ReadSessaoDTO> RecuperaSessaoPorId(int id)
        {
            var sessao = _service.RecuperaSessaoPorId(id);

            if (sessao == null)
            {
                return NotFound();
            }

            return Ok(sessao);
        }


        [HttpPost]
        public ActionResult<Sessao> AdicionaSessao(CreateSessaoDTO sessaoDTO)
        {
            var sessao = _service.AdicionaSessao(sessaoDTO);

            return CreatedAtAction("RecuperaSessaoPorId", new { id = sessao.Id }, sessao);
        }

    }
}
