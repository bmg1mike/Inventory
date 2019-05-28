using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Inventory.API.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public IList<Book> Book { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        public Category()
        {
            Book = new List<Book>(); 
        }
    }
}