using Microsoft.EntityFrameworkCore;
using PaySimplex.Dados.Classes;


namespace PaySimplex.Dados.Controle
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
          : base(options)
        { }
        public DbSet<Tarefa> TarefaItens { get; set; }
        public DbSet<Usuario> UsuaroItens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarefa>().HasKey(c => new { c.IdTarefa });
            modelBuilder.Entity<Usuario>().HasKey(c => new { c.IdUsuario });
        }
    }
}
