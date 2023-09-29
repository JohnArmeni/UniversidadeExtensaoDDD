using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

    }
}
