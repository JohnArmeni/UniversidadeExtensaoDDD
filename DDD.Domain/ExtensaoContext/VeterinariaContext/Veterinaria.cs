using DDD.Domain.ExtensaoContext.VeterinariaContext;
using DDD.Domain.UserManagementContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DDD.Domain.ExtensaoContext.VeterinarioContext
{
    public class Veterinaria : User
    {
        [JsonIgnore]
        //public ICollection<ConsultaVeterinaria>? Consultas { get; set; }
        public IList<Animal>? Animais { get; set; }
    }
}
