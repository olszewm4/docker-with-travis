using Db_Service;
using Db_Service.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public AnimalsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET api/values
        [HttpGet]
        public async Task<List<Animal>> Get()
        {
            return await _dbContext.Animals.ToListAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Animal> Get(int id)
        {
            return await _dbContext.Animals.FirstOrDefaultAsync(r => r.Id == id);
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody] string value)
        {
            var newAnimal = new Animal { Name = value };

            _dbContext.Animals.Add(newAnimal);
            await _dbContext.SaveChangesAsync();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var animal = await _dbContext.Animals.FirstOrDefaultAsync(r => r.Id == id);
            if (animal != null)
            {
                _dbContext.Remove(animal);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
