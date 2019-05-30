using System.Threading.Tasks;
using Inventory.API.Data;
using Inventory.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventory.API.Controllers
{
    [Route("/api/categories")]
    public class CategoriesController:Controller
    {
        private readonly DataContext _Context;

        public CategoriesController(DataContext _context)
        {
            _Context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories(){
            var category = await _Context.Categories.ToListAsync();

            return Ok(category);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id){
            var category = await _Context.Categories.Include(c=>c.Book).FirstOrDefaultAsync(c=>c.Id == id);

            if(category == null)
                return StatusCode(404);

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] Category category){

            if(!ModelState.IsValid)
                return BadRequest();

                await _Context.Categories.AddAsync(category);

                _Context.SaveChanges();

                return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory([FromBody] Category category, int id){
            var idInDb = await _Context.Categories.FirstOrDefaultAsync(c=>c.Id == id);
            if(idInDb == null)
                return NotFound();

            if(!ModelState.IsValid)
                return BadRequest();
            
            idInDb.Name = category.Name;

            return StatusCode(200);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id){

            var category = await _Context.Categories.FirstOrDefaultAsync(c=>c.Id == id);

            if(category == null)
                return StatusCode(404);

            _Context.Categories.Remove(category);

            _Context.SaveChanges();

            return StatusCode(200);

        }
        
    }
}