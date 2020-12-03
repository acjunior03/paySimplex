using PaySimplex.Dados.Controle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaySimplex.Dados.Modelos
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private readonly TarefaContexto _context;
        public TarefaRepositorio(TarefaContexto context)
        {
            _context = context;
            Add(new Tarefa{IdTarefa=1 ,IdUsuario = 1,Estado = "agendada",DuracaoEstimada = new TimeSpan(1,12,12), DataFim=new DateTimeOffset(DateTime.Now),DataInicio= new DateTimeOffset(DateTime.Now)});
        }
        public IEnumerable<Tarefa> GetAll()
        {
            return _context.TarefaItens.ToList();
        }
        public void Add(Tarefa item)
        {
            _context.TarefaItens.Add(item);
            _context.SaveChanges();
        }
        public Tarefa Find(Int64 key)
        {
            return _context.TarefaItens.FirstOrDefault(t => t.IdTarefa == key);
        }
        public void Remove(Int64 key)
        {
            var entity = _context.TarefaItens.First(t => t.IdTarefa == key);
            _context.TarefaItens.Remove(entity);
            _context.SaveChanges();
        }
        public void Update(Tarefa item)
        {
            _context.TarefaItens.Update(item);
            _context.SaveChanges();
        }





    }
}
