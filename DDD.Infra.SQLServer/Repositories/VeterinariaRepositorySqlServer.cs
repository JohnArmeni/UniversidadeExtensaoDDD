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
    public class VeterinariaRepositorySqlServer : IVeterinariaRepository
    {

        private readonly SqlContext _context;

        public VeterinariaRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }

        public void DeleteVeterinario(Veterinaria veterinario)
        {
            try
            {
                _context.Set<Veterinaria>().Remove(veterinario);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Veterinaria GetVeterinarioById(int id)
        {
            return _context.Veterinarios.Find(id);
        }

        public List<Veterinaria> GetVeterinarios()
        {
            return _context.Veterinarios.ToList();

        }

        public void InsertVeterinario(Veterinaria veterinario)
        {
            try
            {
                _context.Veterinarios.Add(veterinario);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                //log exception

            }
        }

        public void UpdateVeterinario(Veterinaria veterinario)
        {
            try
            {
                _context.Entry(veterinario).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
