using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaySimplex.Dados;
using PaySimplex.Dados.Modelos;
using System;
using System.IO;
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
        public IEnumerable<Tarefa> BuscarTodos()
        {
            return _tarefaRepositorio.BuscarTodos();
        }

        [HttpGet("GetTarefa")]
        public IActionResult BuscarPorId(Int64 id)
        {
            var item = _tarefaRepositorio.Procurar(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult InserirItem(Tarefa tarefaItem)
        {
            try
            {
                _tarefaRepositorio.Adicionar(tarefaItem);
                return Ok("Adicionado com sucesso");
            }
            catch (Exception)
            {
                return BadRequest("Erro ao inserir tarefa.");
            }
        }

        [HttpPut( "AtualizarObjeto")]
        public async Task<IActionResult> AtualizarObjeto(Int64 id, Tarefa tarefaItem)
        {
            try
            {
                var item = _tarefaRepositorio.Procurar(id);
                if (item == null)
                {
                    return NotFound();
                }
                _tarefaRepositorio.Atualizar(tarefaItem);
                return Ok("Atualizado com sucesso");
            }
            catch (Exception)
            {
                return BadRequest("Erro ao atualizar tarefa.");
            }
        }

        [HttpPut( "AdiantarEstado")]
        public IActionResult AdiantarEstado(Int64 id)
        {
            try
            {
                var item = _tarefaRepositorio.Procurar(id);
                if (item == null)
                {
                    return NotFound();
                }
                if (item.Estado.Equals("Agendado"))
                {
                    item.Estado = "Andamento";
                    item.DataInicio = DateTime.Parse(item.DataInicio.Value.ToShortDateString()+ " " + DateTime.Now.ToShortTimeString());
                }
                else if (item.Estado.Equals("Andamento"))
                {
                    item.Estado = "Finalizado";
                    item.DataFim = DateTime.Now;

                }
                else
                {
                    return BadRequest("Tarefa já finalizada");
                }

                _tarefaRepositorio.Atualizar(item);
                return Ok("Atualizado com sucesso");
            }
            catch (Exception)
            {
                return BadRequest("Erro ao atualizar tarefa.");
            }
        }

        [HttpGet("PeriodoAndamento")]
        public IActionResult PeriodoAndamento(Int64 id)
        {
            var item = _tarefaRepositorio.Procurar(id);
            if (item == null)
            {
                return BadRequest("Objeto não encontrado");
            }
            var tempo = item.DataFim.Value.Subtract(item.DataInicio.Value);
            return Ok( tempo.Hours  + " Horas, " +  tempo.Minutes + " Minutos, " + tempo.Seconds + " Segundos ");
        }

        [HttpDelete]
        public IActionResult Deletar(Int64 id)
        {
            try
            {
                var item = _tarefaRepositorio.Procurar(id);
                if (item == null)
                {
                    return NotFound();
                }
                _tarefaRepositorio.Remover(id);
                return Ok("Deletado com sucesso");
            }
            catch (Exception)
            {
                return BadRequest("Erro ao deletar tarefa.");
            }
        }

        [HttpPost("EnviarArquivo")]
        public IActionResult Enviar(IFormFile arquivo,Int64 id)
        {
            try
            {
                var item = _tarefaRepositorio.Procurar(id);
                if (item == null)
                {
                    return BadRequest("Objeto não encontrado");
                }
                var nomeNovoArquivo = arquivo.FileName.Split('.');
                var path = Path.Combine(Directory.GetCurrentDirectory(), "ArquivosUpload", id.ToString() + "." + nomeNovoArquivo[nomeNovoArquivo.Length - 1]);
                var stream = new FileStream(path, FileMode.Create);
                arquivo.CopyTo(stream);
                stream.Close();
                return Ok("Envio de arquivo finalizado com sucesso.");
            }
            catch (Exception)
            {
                return BadRequest("Erro ao deletar tarefa.");
            }
        }

    }
}
