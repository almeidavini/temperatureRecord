using System.Linq;
using SistemaMedicao.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SistemaMedicao.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SetorController : ControllerBase
    {
        protected MedicaoDbContext _medicaoDbContext;
        protected DbSet<Setor> _dbSet;

        public SetorController(MedicaoDbContext medicaoDbContext)
        {
            _medicaoDbContext = medicaoDbContext;
            _dbSet = medicaoDbContext.Set<Setor>();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var setores = _dbSet.ToList();
            return Ok(setores);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var setor = _dbSet.FirstOrDefault(o => o.Id == id);

            if (setor != null)
                return Ok(setor);
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Setor setor)
        {
            try
            {
                setor.Id = 0;

                _dbSet.Add(setor);

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
            var setor = _dbSet.FirstOrDefault(o => o.Id == id);

            if (setor == null)
                return NoContent();

            _dbSet.Remove(setor);

            _medicaoDbContext.SaveChanges();
            
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Setor setor)
        {
            if (_dbSet.Any(o => o.Id == id))
            {
                setor.Id = id;
                _dbSet.Update(setor);

                _medicaoDbContext.SaveChanges();

                return Ok();
            }

            return NoContent();
        }
    }
}