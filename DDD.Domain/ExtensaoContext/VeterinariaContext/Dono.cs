using DDD.Domain.ExtensaoContext.VeterinarioContext;
using DDD.Domain.SecretariaContext;
using DDD.Domain.UserManagementContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DDD.Domain.ExtensaoContext.VeterinariaContext
{
    public class Dono : User
    {
        [JsonIgnore]
        public List<Animal>? Animais { get; set; }
    }
}
