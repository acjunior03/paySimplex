using System;
using System.Collections.Generic;

namespace PaySimplex.Dados.Modelos
{
    public interface ITarefaRepositorio
    {
        void Adicionar(Tarefa item);
        IEnumerable<Tarefa> BuscarTodos();
        Tarefa Procurar(Int64 key);
        void Remover(Int64 key);
        void Atualizar(Tarefa item);
    }
}
