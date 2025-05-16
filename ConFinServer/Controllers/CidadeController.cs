using ConFinServer.Data;
using ConFinServer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConFinServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CidadeController(AppDbContext context)
        {
            _context = context;
        } 

        [HttpGet]
        [Route("Lista")]
        public IActionResult GetCidade()
        {
            try
            {
                var lista = _context.Cidade
                            .Include(c => c.Estado)
                            .OrderBy(c => c.Nome)
                            .ToList();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao consultar cidade . " + ex.Message);
            }
        }

        [HttpPost]
        public IActionResult PostCidade([FromBody] Cidade cidade)
        {
            try
            {
                _context.Cidade.Add(cidade);
                _context.SaveChanges();
                return Ok("Cidade adicionada com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao incluir cidade. " + ex.Message);
            }
        }

        [HttpPut]
        public IActionResult PutCidade([FromBody] Cidade cidade)
        {
            try
            {
                var cidadeExiste = _context.Cidade
                                    .Where(l => l.Codigo == cidade.Codigo)
                                    .FirstOrDefault();
                if (cidadeExiste != null)
                {
                    cidadeExiste.Nome = cidade.Nome;
                    cidadeExiste.Estado = cidade.Estado;
                    _context.Cidade.Update(cidadeExiste);
                    _context.SaveChanges();
                    return Ok("Cidade alterada com sucesso!");
                }
                else
                {
                    return NotFound("Cidade não encontrada!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao alterar cidade. " + ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteCidade([FromBody] Cidade cidade)
        {
            try
            {
                var cidadeExiste = _context.Cidade
                                    .Where(l => l.Codigo == cidade.Codigo)
                                    .FirstOrDefault();
                if (cidadeExiste != null)
                {
                    _context.Cidade.Remove(cidadeExiste);
                    _context.SaveChanges();
                    return Ok("Cidade excluída com sucesso!");
                }
                else
                {
                    return NotFound("Cidade não encontrada!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao excluir cidade. " + ex.Message);
            }
        }

    }
}
