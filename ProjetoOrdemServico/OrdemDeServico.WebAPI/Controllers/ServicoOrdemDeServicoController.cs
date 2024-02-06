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
            // Lógica para obter todos os serviços de ordem de serviço
            return Ok("Get all servicos-ordem-de-servico");
        }

        [HttpGet("servico-ordem-de-servico/{id}")]
        public IActionResult GetById(int id)
        {
            // Lógica para obter um serviço de ordem de serviço pelo ID
            return Ok($"Get servico-ordem-de-servico with ID {id}");
        }

        [HttpPost("servico-ordem-de-servico")]
        public IActionResult Post([FromBody] NewPrestadorDeServicoInputModel servicoOrdemDeServico)
        {
            // Lógica para criar um novo serviço de ordem de serviço
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
