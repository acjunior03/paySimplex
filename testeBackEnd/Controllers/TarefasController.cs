using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaySimplex.Dados;
using PaySimplex.Dados.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testeBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefaRepositorio _tarefaRepositorio;
        public TarefasController(ITarefaRepositorio tarefaRepositorio)
        {
            _tarefaRepositorio = tarefaRepositorio;
        }
        [HttpGet]
        public IEnumerable<Tarefa> GetAll()
        {
            return _tarefaRepositorio.GetAll();
        }

        [HttpGet("{id}", Name = "GetTarefa")]
        public IActionResult GetById(Int64 id)
        {
            var item = _tarefaRepositorio.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

    }
}
