using DDD.Domain.ExtensaoContext.VeterinarioContext;
using DDD.Domain.SecretariaContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        readonly IAnimalRepository _animalRepository;
        readonly IDonoRepository _donoRepository;

        public AnimalController(IAnimalRepository animalRepository, IDonoRepository donoRepository)
        {
            _animalRepository = animalRepository;
            _donoRepository = donoRepository;
        }

        // GET: api/<vetsController>
        [HttpGet]
        public ActionResult<List<Animal>> Get()
        {
            return Ok(_animalRepository.GetAnimais());
        }

        [HttpGet("{id}")]
        public ActionResult<Animal> GetById(int id)
        {
            return Ok(_animalRepository.GetAnimalById(id));
        }

        [HttpPost("api/Animal/CadastrarAnimal")]
        public IActionResult AssociarAnimal(int donoId, Animal animal)
        {
            _donoRepository.AdicionarAnimal(donoId, animal);
            return Ok("Animal do dono Cadastrado com sucesso!");
        }

        [HttpPut]
        public ActionResult Put([FromBody] Animal animal)
        {
            try
            {
                if (animal == null)
                    return NotFound();

                _animalRepository.UpdateAnimal(animal);
                return Ok("Animal Atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete([FromBody] Animal animal)
        {
            try
            {
                if (animal == null)
                    return NotFound();

                _animalRepository.DeleteAnimal(animal);
                return Ok("Animal Removido com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
