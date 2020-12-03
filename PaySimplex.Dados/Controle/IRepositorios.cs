using System;
using System.Collections.Generic;

namespace PaySimplex.Dados.Modelos
{
    public interface ITarefaRepositorio
    {
        void Add(Tarefa item);
        IEnumerable<Tarefa> GetAll();
        Tarefa Find(Int64 key);
        void Remove(Int64 key);
        void Update(Tarefa item);
    }

    //public interface IEnvioArquivoRepositorios
    //{
    //    void Add(EnvioArquivo item);
    //    IEnumerable<EnvioArquivo> GetAll();
    //    Tarefa Find(long key);
    //    void Remove(long key);
    //    void Update(EnvioArquivo item);
    //}
}
