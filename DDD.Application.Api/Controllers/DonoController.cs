using DDD.Domain.ExtensaoContext.VeterinariaContext;
using DDD.Domain.ExtensaoContext.VeterinarioContext;
using DDD.Domain.SecretariaContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonoController : ControllerBase
    {
        readonly IDonoRepository _donoRepository;

        public DonoController(IDonoRepository DonoRepository)
        {
            _donoRepository = DonoRepository;
        }

        // GET: api/<vetsController>
        [HttpGet]
        public ActionResult<List<Dono>> Get()
        {
            return Ok(_donoRepository.GetDonos());
        }

        [HttpGet("{id}")]
        public ActionResult<Dono> GetById(int id)
        {
            return Ok(_donoRepository.GetDonoById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Dono> CreateVeterinario(Dono dono)
        {
            if (dono.Nome.Length < 3 || dono.Nome.Length > 30)
            {
                return BadRequest("Nome deve ser maior que 3 e menor que 30 caracteres.");
            }
            _donoRepository.InsertDono(dono);
            return CreatedAtAction(nameof(GetById), new { id = dono.UserId }, dono);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Dono dono)
        {
            try
            {
                if (dono == null)
                    return NotFound();

                _donoRepository.UpdateDono(dono);
                return Ok("Dono Atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete([FromBody] Dono dono)
        {
            try
            {
                if (dono == null)
                    return NotFound();

                _donoRepository.DeleteDono(dono);
                return Ok("Dono Removido com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
