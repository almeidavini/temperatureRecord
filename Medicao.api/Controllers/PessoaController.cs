using System.Linq;
using SistemaMedicao.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SistemaMedicao.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        protected MedicaoDbContext _medicaoDbContext;
        protected DbSet<Pessoa> _dbSet;

        public PessoaController(MedicaoDbContext medicaoDbContext)
        {
            _medicaoDbContext = medicaoDbContext;
            _dbSet = medicaoDbContext.Set<Pessoa>();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var pessoas = _dbSet.Include(o => o.Setor)
            .ToList();
            return Ok(pessoas);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var pessoa = _dbSet.Include(o => o.Setor)
                .FirstOrDefault(o => o.Id == id);

            if (pessoa != null)
                return Ok(pessoa);
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Pessoa pessoa)
        {
            try
            {
                pessoa.Id = 0;

                _dbSet.Add(pessoa);

                _medicaoDbContext.SaveChanges();
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(500, new { msg = "Erro ao executar operação" });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pessoa = _dbSet.FirstOrDefault(o => o.Id == id);

            if (pessoa == null)
                return NoContent();

            _dbSet.Remove(pessoa);

            _medicaoDbContext.SaveChanges();
            
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Pessoa pessoa)
        {
            if (_dbSet.Any(o => o.Id == id))
            {
                pessoa.Id = id;
                _dbSet.Update(pessoa);

                _medicaoDbContext.SaveChanges();

                return Ok();
            }

            return NoContent();
        }
    }
}