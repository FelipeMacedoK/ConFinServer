using ConFinServer.Data;
using ConFinServer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConFinServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        //private static List<Estado> lista = new List<Estado>();
        private readonly AppDbContext _context;

        public EstadoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Estado> GetEstado()
        {
            var lista = _context.Estado.ToList();
            return lista;
        }

        /* [HttpGet("Estado2")]
         public string Estado(string valor)
         {
             //var valor = "Teste";
             return valor;
         }

         [HttpGet]
         [Route("Lista")]
         public List<Estado> EstadoLista()
         {
             return lista;
         } */

        [HttpPost]
        public IActionResult PostEstado([FromBody] Estado estado)
        {
            try
            {
                _context.Estado.Add(estado);
                _context.SaveChanges();
                return Ok("Estado adicionado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao incluir estado. " + ex.Message);
            }
        }
        [HttpPut]
        public IActionResult PutEstado([FromBody] Estado estado)
        {
            var estadoExiste = _context.Estado
                                .Where(l => l.Sigla == estado.Sigla)
                                .FirstOrDefault();
            if (estadoExiste != null)
            {
                try
                {
                    estadoExiste.Nome = estado.Nome;
                    _context.Estado.Update(estadoExiste);
                    _context.SaveChanges();
                    return Ok("Estado alterado com sucesso!");
                }
                catch (Exception ex)
                {
                    return BadRequest("Erro ao alterar estado. " + ex.Message);
                }
            }
            else
            {
                return NotFound("Estado não encontrado!");
            }
        }

        /*[HttpDelete]
        public string DeleteEstado(Estado estado)
        {
            var estadoExiste = lista
                                .Where(l => l.Sigla == estado.Sigla)
                                .FirstOrDefault();
            if (estadoExiste != null)
            {
                lista.Remove(estadoExiste);
                return "Estado removido com sucesso!";
            }
            else
            {
                return "Estado não encontrado!";
            }
        }

        [HttpDelete("Exclui2")]
        public string DeleteEstado2([FromQuery]string sigla)
        {
            var estadoExiste = lista
                                .Where(l => l.Sigla == sigla)
                                .FirstOrDefault();
            if (estadoExiste != null)
            {
                lista.Remove(estadoExiste);
                return "Estado removido com sucesso!";
            }
            else
            {
                return "Estado não encontrado!";
            }
        }

        [HttpDelete("Exclui3")]
        public string DeleteEstado3([FromHeader] string sigla)
        {
            var estadoExiste = lista
                                .Where(l => l.Sigla == sigla)
                                .FirstOrDefault();
            if (estadoExiste != null)
            {
                lista.Remove(estadoExiste);
                return "Estado removido com sucesso!";
            }
            else
            {
                return "Estado não encontrado!";
            }
        }*/

        [HttpDelete("{sigla}")]
        public IActionResult DeleteEstado([FromRoute] string sigla)
        {
            var estadoExiste = _context.Estado
                                .Where(l => l.Sigla == sigla)
                                .FirstOrDefault();
            if (estadoExiste != null)
            {
                try
                {
                    _context.Estado.Remove(estadoExiste);
                    _context.SaveChanges();
                    return Ok("Estado removido com sucesso!");
                }
                catch (Exception ex)
                {
                    return BadRequest("Erro ao remover estado. " + ex.Message);
                }

            }
            else
            {
                return NotFound("Estado não encontrado!");
            }
        }
    }
}
