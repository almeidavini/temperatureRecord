using System.Linq;
using SistemaMedicao.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SistemaMedicao.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicaoController : ControllerBase
    {
        protected MedicaoDbContext _medicaoDbContext;
        protected DbSet<Medicao> _dbSet;

        public MedicaoController(MedicaoDbContext medicaoDbContext)
        {
            _medicaoDbContext = medicaoDbContext;
            _dbSet = medicaoDbContext.Set<Medicao>();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var medicoes = _dbSet.Include(o => o.Pessoa)
            .ToList();
            return Ok(medicoes);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var medicao = _dbSet.FirstOrDefault(o => o.Id == id);

            if (medicao != null)
                return Ok(medicao);
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Medicao medicao)
        {
            try
            {
                medicao.Id = 0;

                _dbSet.Add(medicao);

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
            var telefone = _dbSet.FirstOrDefault(o => o.Id == id);

            if (telefone == null)
                return NoContent();

            _dbSet.Remove(telefone);

            _medicaoDbContext.SaveChanges();
            
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Medicao medicao)
        {
            if (_dbSet.Any(o => o.Id == id))
            {
                medicao.Id = id;
                _dbSet.Update(medicao);

                _medicaoDbContext.SaveChanges();

                return Ok();
            }

            return NoContent();
        }
    }
}