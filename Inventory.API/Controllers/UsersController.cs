using System.Threading.Tasks;
using Inventory.API.Data;
using Inventory.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventory.API.Controllers
{
    [Route("/api/users")]
    public class UsersController:Controller
    {
        private readonly DataContext _Context;

        public UsersController(DataContext _context)
        {
            _Context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers(){
            
            var user = await _Context.Users.ToListAsync();

            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Getuser(int id){

            var user = await _Context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if(user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User user){
            
            if(!ModelState.IsValid)
                return BadRequest();

            await _Context.Users.AddAsync(user);

            _Context.SaveChanges();

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromBody] User user, int id){

            var idInDb = await _Context.Users.FirstOrDefaultAsync(u => u.Id == id);
            
            if(idInDb == null)
                return NotFound();

            if(!ModelState.IsValid)
                return BadRequest();

            idInDb.Email = user.Email;
            idInDb.FirstName = user.FirstName;
            idInDb.LastName = user.LastName;
            idInDb.Password = user.Password;

            _Context.SaveChanges();

            return StatusCode(200);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id){

            var user = await _Context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if(user == null)
                return NotFound();

            _Context.Users.Remove(user);

            _Context.SaveChanges();

            return StatusCode(200);

        }

    }
}