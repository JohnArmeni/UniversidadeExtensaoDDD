using DDD.Domain.ExtensaoContext.VeterinarioContext;
using DDD.Domain.SecretariaContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface IVeterinariaRepository
    {
        public List<Veterinaria> GetVeterinarios();
        public Veterinaria GetVeterinarioById(int id);
        public void InsertVeterinario(Veterinaria veterinario);
        public void UpdateVeterinario(Veterinaria veterinaria);
        public void DeleteVeterinario(Veterinaria veterinaria);
    }
}
