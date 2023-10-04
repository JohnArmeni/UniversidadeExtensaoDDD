using DDD.Domain.ExtensaoContext.VeterinariaContext;
using DDD.Domain.SecretariaContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DDD.Domain.ExtensaoContext.VeterinarioContext
{
    public class Animal
    {
        public int AnimalId { get; set; }
        public string NomeAnimal { get; set; }
        public string Raca { get; set;}
        public int Idade { get; set; }
        public string Genero { get; set; }
        public string Cor { get; set; }

        public int DonoId { get; set; } // Propriedade que representa associacao ao dono

        [JsonIgnore]
        public Dono? Dono { get; set; }

        [JsonIgnore]
        //public ICollection<ConsultaVeterinaria>? Consultas { get; set; }
        public IList<Veterinaria>? Veterinarios { get; set; }

    }
}
