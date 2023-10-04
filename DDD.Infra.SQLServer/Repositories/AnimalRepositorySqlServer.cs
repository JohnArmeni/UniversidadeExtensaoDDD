using DDD.Domain.ExtensaoContext.VeterinarioContext;
using DDD.Domain.SecretariaContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Repositories
{
    public class AnimalRepositorySqlServer : IAnimalRepository
    {

        private readonly SqlContext _context;

        public AnimalRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }

        public void DeleteAnimal(Animal animal)
        {
            try
            {
                _context.Set<Animal>().Remove(animal);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Animal GetAnimalById(int id)
        {
            return _context.Animais.Find(id);
        }

        public List<Animal> GetAnimais()
        {
            return _context.Animais.ToList();

        }

        public void InsertAnimal(Animal animal)
        {
            try
            {
                _context.Animais.Add(animal);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                //log exception

            }
        }

        public void UpdateAnimal(Animal animal)
        {
            try
            {
                _context.Entry(animal).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
