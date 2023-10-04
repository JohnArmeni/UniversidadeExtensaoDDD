using DDD.Domain.ExtensaoContext.VeterinarioContext;
using DDD.Domain.SecretariaContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeterinarioController : ControllerBase
    {
        readonly IVeterinariaRepository _veterinarioRepository;

        public VeterinarioController(IVeterinariaRepository veterinarioRepository)
        {
            _veterinarioRepository = veterinarioRepository;
        }

        // GET: api/<vetsController>
        [HttpGet]
        public ActionResult<List<Veterinaria>> Get()
        {
            return Ok(_veterinarioRepository.GetVeterinarios());
        }

        [HttpGet("{id}")]
        public ActionResult<Veterinaria> GetById(int id)
        {
            return Ok(_veterinarioRepository.GetVeterinarioById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Veterinaria> CreateVeterinario(Veterinaria veterinaria)
        {
            if (veterinaria.Nome.Length < 3 || veterinaria.Nome.Length > 30)
            {
                return BadRequest("Nome deve ser maior que 3 e menor que 30 caracteres.");
            }
            _veterinarioRepository.InsertVeterinario(veterinaria);
            return CreatedAtAction(nameof(GetById), new { id = veterinaria.UserId }, veterinaria);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Veterinaria veterinaria)
        {
            try
            {
                if (veterinaria == null)
                    return NotFound();

                _veterinarioRepository.UpdateVeterinario(veterinaria);
                return Ok("Veterinario Atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete([FromBody] Veterinaria veterinaria)
        {
            try
            {
                if (veterinaria == null)
                    return NotFound();

                _veterinarioRepository.DeleteVeterinario(veterinaria);
                return Ok("Veterinario Removido com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
