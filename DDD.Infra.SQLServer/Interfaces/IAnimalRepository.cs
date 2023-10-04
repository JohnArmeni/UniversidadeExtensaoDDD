using DDD.Domain.ExtensaoContext.VeterinarioContext;
using DDD.Domain.SecretariaContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface IAnimalRepository
    {
        public List<Animal> GetAnimais();
        public Animal GetAnimalById(int id);
        public void InsertAnimal(Animal animal);
        public void UpdateAnimal(Animal animal);
        public void DeleteAnimal(Animal animal);
    }
}