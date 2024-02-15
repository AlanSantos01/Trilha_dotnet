using Microsoft.AspNetCore.Mvc;
using TechMed.Application.InputModels;
using TechMed.Application.Services.InterfacesServices;
using TechMed.Application.ViewModels;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class MedicoController : ControllerBase
{
   private readonly IMedicoService _medicoService;
   private readonly IAtendimentoService _atendimentoService;
   public List<MedicoViewModel> Medicos => _medicoService.GetAll().ToList();
   public MedicoController(IMedicoService service, IAtendimentoService atendimentoService)
   {
      _medicoService = service;
      _atendimentoService = atendimentoService;
   }

   [HttpGet("medicos")]
   public IActionResult Get()
   {
      return Ok(Medicos);
   }

   [HttpGet("medico/{id}")]
   public IActionResult GetById(int id)
   {
      var medico = _medicoService.GetById(id);
      if (medico is null)
         return NoContent();
      return Ok(medico);
   }

   [HttpPost("medico")]
   public IActionResult Post([FromBody] NewMedicoInputModel medico)
   {
      _medicoService.Create(medico);
      return CreatedAtAction(nameof(Get), medico);

   }

   [HttpPost("medico/{id}/atendimento")]
   public IActionResult Post(int id, [FromBody] NewAtendimentoInputModel atendimento)
   {
      _medicoService.CreateAtendimento(id, atendimento);
      return CreatedAtAction(nameof(Get), atendimento);

   }

   [HttpPut("medico/{id}")]
   public IActionResult Put(int id, [FromBody] NewMedicoInputModel medico)
   {
      if (_medicoService.GetById(id) == null)
         return NoContent();
      _medicoService.Update(id, medico);
      return Ok(_medicoService.GetById(id));
   }

   [HttpDelete("medico/{id}")]
   public IActionResult Delete(int id)
   {
      if (_medicoService.GetById(id) == null)
         return NoContent();
      _medicoService.Delete(id);
      return Ok();
   }

   [HttpGet("medico/{id}/atendimentos")]
   public IActionResult GetAtendimentosByMedico(int id)
   {
      var atendimentos = _atendimentoService.GetByMedicoId(id);


      if (atendimentos is null)
         return NoContent();
      return Ok(atendimentos);
   }
}
