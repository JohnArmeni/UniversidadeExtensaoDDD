using DDD.Domain.ExtensaoContext.VeterinariaContext;
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
    public class DonoRepositorySqlServer : IDonoRepository
    {

        private readonly SqlContext _context;

        public DonoRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }

        public void DeleteDono(Dono dono)
        {
            try
            {
                _context.Set<Dono>().Remove(dono);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Dono GetDonoById(int id)
        {
            return _context.Donos.Find(id);
        }

        public List<Dono> GetDonos()
        {
            return _context.Donos.ToList();

        }

        public void InsertDono(Dono dono)
        {
            try
            {
                _context.Donos.Add(dono);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                //log exception

            }
        }

        public void UpdateDono(Dono dono)
        {
            try
            {
                _context.Entry(dono).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void AdicionarAnimal(int donoId, Animal animal)
        {
            var dono = _context.Donos.Include(d => d.Animais).FirstOrDefault(d => d.UserId == donoId);
            if (dono != null)
            {
                dono.Animais.Add(animal);
                _context.SaveChanges();
            }
        }

        public void RemoverAnimal(int donoId, int animalId)
        {
            var dono = _context.Donos.Include(d => d.Animais).FirstOrDefault(d => d.UserId == donoId);
            if (dono != null)
            {
                var animal = dono.Animais.FirstOrDefault(a => a.AnimalId == donoId);
                if (animal != null)
                {
                    dono.Animais.Remove(animal);
                    _context.SaveChanges();
                }
            }
        }
    }
}
