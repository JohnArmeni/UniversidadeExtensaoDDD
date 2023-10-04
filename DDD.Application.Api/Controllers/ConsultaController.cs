using DDD.Domain.ExtensaoContext.VeterinariaContext;
using DDD.Domain.SecretariaContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        readonly IConsultaRepository _consultaRepository;

        public ConsultaController(IConsultaRepository consultaRepository)
        {
            _consultaRepository = consultaRepository; 
        }

        [HttpGet]
        public ActionResult<List<ConsultaVeterinaria>> Get()
        {
            return Ok(_consultaRepository.GetConsultas());
        }

        [HttpGet("{id}")]
        public ActionResult<ConsultaVeterinaria> GetById(int id)
        {
            return Ok(_consultaRepository.GetConsultaById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ConsultaVeterinaria> CreateConsulta(int idVeterinario, int idAnimal)
        {
            ConsultaVeterinaria consultaIdSaved = _consultaRepository.InsertConsulta(idVeterinario, idAnimal);
            return CreatedAtAction(nameof(GetById), new { id = consultaIdSaved.ConsultaId }, consultaIdSaved);
        }

    }
}
