using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ObrasBibliograficas.Infraestrutura.Data.Mapeamentos;
using ObrasBibliograficas.Dominio.Entidades;
using System;
using System.Linq;

namespace ObrasBibliograficas.Infraestrutura.Data.Contextos
{
    public class Contexto : DbContext
    {
        public DbSet<Autor> Autores { get; set; }

        public IDbContextTransaction Transaction { get; private set; }

        public Contexto(DbContextOptions<Contexto> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        public IDbContextTransaction InitTransacao()
        {
            if (Transaction == null) Transaction = this.Database.BeginTransaction();
            return Transaction;
        }


        private void RollBack()
        {
            if (Transaction != null)
            {
                Transaction.Rollback();
            }
        }

        private void Salvar()
        {
            try
            {
                ChangeTracker.DetectChanges();
                SaveChanges();
            }
            catch (Exception ex)
            {
                RollBack();
                throw new Exception(ex.Message);
            }
        }

        private void Commit()
        {
            if (Transaction != null)
            {
                Transaction.Commit();
                Transaction.Dispose();
                Transaction = null;
            }
        }

        public void SendChanges()
        {
            Salvar();
            Commit();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AutorMap());

            modelBuilder.Entity<Autor>().HasData(
            new Autor { Id = 1, Nome = "Anthony Stark" },
            new Autor { Id = 2, Nome = "Steve Rogers" },
            new Autor { Id = 3, Nome = "Thor Odinson" }
            );

        }
    }
}
