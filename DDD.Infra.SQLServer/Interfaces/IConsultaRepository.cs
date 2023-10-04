using DDD.Domain.ExtensaoContext.VeterinariaContext;
using DDD.Domain.ExtensaoContext.VeterinarioContext;
using DDD.Domain.SecretariaContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface IConsultaRepository
    {

        public List<ConsultaVeterinaria> GetConsultas();
        public ConsultaVeterinaria GetConsultaById(int id);
        public ConsultaVeterinaria InsertConsulta(int idVeterinario, int idAnimal);
    }
}