using Microsoft.EntityFrameworkCore;
namespace PaySimplex.Dados.Controle
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
          : base(options)
        { }
        public DbSet<Tarefa> TarefaItens { get; set; }
    }
    //public class EnvioArquivoContexto : Microsoft.EntityFrameworkCore.DbContext
    //{
    //    public EnvioArquivoContexto(DbContextOptions<EnvioArquivoContexto> options)
    //      : base(options)
    //    { }
    //    public System.Data.Entity.DbSet<EnvioArquivo> EnvioArquivoItens { get; set; }
    //}
}
