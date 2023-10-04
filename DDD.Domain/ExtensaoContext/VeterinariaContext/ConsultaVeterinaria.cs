using DDD.Domain.ExtensaoContext.VeterinarioContext;
using DDD.Domain.SecretariaContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.ExtensaoContext.VeterinariaContext
{
    public class ConsultaVeterinaria
    {
        public int ConsultaId { get; set; }

        public int AnimalId { get; set; }
        public Animal Animal { get; set; }

        public int VeterinariaId { get; set; }
        public Veterinaria Veterinaria { get; set; }

        public DateTime Data { get; set; }
    }
}
