using ConFinServer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConFinServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadeController : ControllerBase
    {
        private static List<Cidade> lista = new List<Cidade>();

        [HttpGet]
        [Route("Lista")]
        public List<Cidade> CidadeLista()
        {
            return lista;
        }

        [HttpPost]
        public string PostEstado(Cidade cidade)
        {
            lista.Add(cidade);
            return "Cidade adicionada com sucesso!";
        }

        [HttpPut]
        public string PutCidade(Cidade cidade)
        {
            var cidadeExiste = lista
                                .Where(l => l.Codigo == cidade.Codigo)
                                .FirstOrDefault();
            if (cidadeExiste != null)
            {
                cidadeExiste.Nome = cidade.Nome;
                cidadeExiste.Estado = cidade.Estado;
                return "Cidade alterada com sucesso!";
            }
            else
            {
                return "Cidade não encontrada!";
            }
        }

        [HttpDelete]
        public string DeleteCidade(Cidade cidade)
        {
            var cidadeExiste = lista
                                .Where(l => l.Codigo == cidade.Codigo)
                                .FirstOrDefault();
            if (cidadeExiste != null)
            {
                lista.Remove(cidadeExiste);
                return "Cidade removida com sucesso!";
            }
            else
            {
                return "Cidade não encontrada!";
            }
        }

    }
}
