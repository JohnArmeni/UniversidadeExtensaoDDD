using DDD.Domain.ExtensaoContext.VeterinariaContext;
using DDD.Domain.ExtensaoContext.VeterinarioContext;
using DDD.Domain.PicContext;
using DDD.Domain.SecretariaContext;
using DDD.Domain.UserManagementContext;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infra.SQLServer
{
    public class SqlContext : DbContext
    {

        //https://balta.io/blog/ef-crud
        //https://jasonwatmore.com/post/2022/03/18/net-6-connect-to-sql-server-with-entity-framework-core

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UniversidadeDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Aluno>()
                .HasMany(e => e.Disciplinas)
                .WithMany(e => e.Alunos)
                .UsingEntity<Matricula>();

            modelBuilder.Entity<Dono>()
               .HasMany(dono => dono.Animais) // Um dono tem muitos animais
               .WithOne(animal => animal.Dono) // Um animal pertence a um dono
               .HasForeignKey(animal => animal.DonoId); // Chave estrangeira em animal

            modelBuilder.Entity<ConsultaVeterinaria>() //PK CONSULTA
                .HasKey(c => c.ConsultaId);

            modelBuilder.Entity<Veterinaria>()
               .HasMany(e => e.Animais)
               .WithMany(e => e.Veterinarios)
               .UsingEntity<ConsultaVeterinaria>();

            //modelBuilder.Entity<ConsultaVeterinaria>()
            //    .HasOne(cv => cv.Animal) //Um Animal pode ter 
            //    .WithMany(a => a.Consultas) // várias consultas veterinárias
            //    .HasForeignKey(cv => cv.AnimalId); //Foreign Key Animal na consulta

            //modelBuilder.Entity<ConsultaVeterinaria>()
            //    .HasOne(cv => cv.Veterinaria)//Um Veterinario pode ter 
            //    .WithMany(v => v.Consultas) //várias consultas veterinárias
            //    .HasForeignKey(cv => cv.VeterinariaId); //Foreign key veterinario na consulta



            modelBuilder.Entity<User>().UseTpcMappingStrategy();
            modelBuilder.Entity<Aluno>().ToTable("Aluno");
            modelBuilder.Entity<Veterinaria>().ToTable("Veterinario");
            modelBuilder.Entity<Animal>().ToTable("Animal");
            modelBuilder.Entity<ConsultaVeterinaria>().ToTable("Consulta");
            modelBuilder.Entity<Pesquisador>().ToTable("Pesquisador");
            modelBuilder.Entity<Dono>().ToTable("Dono");
            //https://learn.microsoft.com/pt-br/ef/core/modeling/inheritance
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Veterinaria> Veterinarios { get; set; }

        public DbSet<Animal> Animais { get; set; }
        public DbSet<Dono> Donos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }

        public DbSet<ConsultaVeterinaria> Consultas { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Pesquisador> Pesquisadores { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
    }
}
