using ConFinServer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConFinServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private static List<Estado> lista = new List<Estado>();

        [HttpGet]
        public string Estado()
        {
            var valor = "Teste";
            return valor;
        }

        [HttpGet("Estado2")]

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
        }

        [HttpPost]
        public string PostEstado(Estado estado)
        {
            lista.Add(estado);
            return "Estado adicionado com sucesso!";
        }

        [HttpPut]
        public string PutEstado(Estado estado)
        {
            var estadoExiste = lista
                                .Where(l => l.Sigla == estado.Sigla)
                                .FirstOrDefault();
            if (estadoExiste != null)
            {
                estadoExiste.Nome = estado.Nome;
                return "Estado alterado com sucesso!";
            }
            else
            {
                return "Estado não encontrado!";
            }
        }

        [HttpDelete]
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
        }

        [HttpDelete("{sigla}")]
        public string DeleteEstado4([FromRoute] string sigla)
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
    }
}
