using DDD.Domain.ExtensaoContext.VeterinariaContext;
using DDD.Domain.SecretariaContext;
using DDD.Infra.SQLServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Repositories
{
    public class ConsultaRepositorySqlServer : IConsultaRepository
    {
        private readonly SqlContext _context;

        public ConsultaRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }

        public List<ConsultaVeterinaria> GetConsultas()
        {
            var list = _context.Consultas.ToList();
            return list;
        }

        public ConsultaVeterinaria GetConsultaById(int id)
        {
            return _context.Consultas.Find(id);
        }

        public ConsultaVeterinaria InsertConsulta(int idVeterinario, int idAnimal)
        {
            var veterinaria = _context.Veterinarios.First(i => i.UserId == idVeterinario);
            var animal = _context.Animais.First(i => i.AnimalId == idAnimal);

            var Consulta = new ConsultaVeterinaria
            {
                Veterinaria = veterinaria,
                Animal = animal,
                Data = DateTime.Now
            };

            try
            {

                _context.Add(Consulta);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                var msg = ex.InnerException;
                throw;
            }

            return Consulta;
        }

    }
}
