using Microsoft.AspNetCore.Mvc;
using OrdemDeServico.WebAPI.InputModels.NewPrestadorDeServicoInputModel;

namespace OrdemDeServico.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v0.1/")]
    public class ServicoOrdemDeServicoController : ControllerBase
    {
        [HttpGet("servicos-ordem-de-servico")]
        public IActionResult Get()
        {
            return Ok("Get all servicos-ordem-de-servico");
        }

        [HttpGet("servico-ordem-de-servico/{id}")]
        public IActionResult GetById(int id)
        {            
            return Ok($"Get servico-ordem-de-servico with ID {id}");
        }

        [HttpPost("servico-ordem-de-servico")]
        public IActionResult Post([FromBody] NewPrestadorDeServicoInputModel servicoOrdemDeServico)
        {    
            return CreatedAtAction(nameof(GetById), new { id = 1 }, servicoOrdemDeServico);
        }

        [HttpPut("servico-ordem-de-servico/{id}")]
        public IActionResult Put(int id, [FromBody] NewPrestadorDeServicoInputModel servicoOrdemDeServico)
        {
            
            return NoContent();
        }

        [HttpDelete("servico-ordem-de-servico/{id}")]
        public IActionResult Delete(int id)
        {
            
            return NoContent();
        }
    }
}
