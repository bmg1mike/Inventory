using System;
using System.Threading.Tasks;
using Inventory.API.Data;
using Inventory.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventory.API.Controllers
{
    [Route("/api/books")]
    public class BooksController:Controller
    {
        private readonly DataContext _Context;

        public BooksController(DataContext _context) => _Context = _context;

        [HttpGet]
        public async Task<IActionResult> GetBooks(){

            var book = await _Context.Books.ToListAsync();

            return Ok(book);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id){

            var book = await _Context.Books.FirstOrDefaultAsync(b=>b.Id == id);

            if(book == null)
                NotFound();

            return StatusCode(200);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] Book book){

            if(!ModelState.IsValid)
                BadRequest();

           await _Context.Books.AddAsync(book);

            _Context.SaveChanges();

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Book book, int id){

            var bookId = await _Context.Books.FirstOrDefaultAsync(b=>b.Id == id);

            if(book == null)
               return NotFound();

            if(!ModelState.IsValid)
               return BadRequest();

            bookId.Name = book.Name;
            bookId.Quantity = book.Quantity;
            bookId.CategoryId = book.CategoryId;
            bookId.CostPrice = book.CostPrice;
            bookId.SellingPrice = book.SellingPrice;
            bookId.UpdatedDate = DateTime.Now;

            _Context.SaveChanges();
            return StatusCode(200);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){

            var book = await _Context.Books.FirstOrDefaultAsync(b=>b.Id == id);

            if(book == null)
                NotFound();

            _Context.Books.Remove(book);

            _Context.SaveChanges();

            return StatusCode(200);
        }
    }
}