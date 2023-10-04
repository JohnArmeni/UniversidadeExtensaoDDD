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
    public interface IDonoRepository
    {
        public List<Dono> GetDonos();
        public Dono GetDonoById(int id);
        public void InsertDono(Dono dono);
        public void UpdateDono(Dono dono);
        public void DeleteDono(Dono dono);

        public void AdicionarAnimal(int donoId, Animal animal); // Adicionar Animal ao dono
        public void RemoverAnimal(int donoId, int animalId); // Remover Animal do Dono
    }
}
