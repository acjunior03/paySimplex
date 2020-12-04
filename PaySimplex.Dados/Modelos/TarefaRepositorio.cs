using PaySimplex.Dados.Controle;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;

namespace PaySimplex.Dados.Modelos
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private readonly Contexto _context;
        public TarefaRepositorio(Contexto context)
        {
            _context = context;
        }
        public IEnumerable<Tarefa> BuscarTodos()
        {
            return _context.TarefaItens.Include(x => x.Usuario).ToList();
        }
        public void Adicionar(Tarefa item)
        {
            _context.TarefaItens.Add(item);
            _context.SaveChanges();
        }
        public Tarefa Procurar(Int64 key)
        {
            return _context.TarefaItens.Include(x => x.Usuario).FirstOrDefault(t => t.IdTarefa == key);
        }
        public void Remover(Int64 key)
        {
            var entity = _context.TarefaItens.First(t => t.IdTarefa == key);
            _context.TarefaItens.Remove(entity);
            _context.SaveChanges();
        }
        public void Atualizar(Tarefa item)
        {
            _context.TarefaItens.Update(item);
            _context.SaveChanges();
        }
    }
}
