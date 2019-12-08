using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookletRazer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookletRazer.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public CreateModel(ApplicationDbContext dbContext)
        {
            _db = dbContext; 
        }
        [BindProperty]
        public Book Book { get; set; }
        public void OnGet()
        { 

        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Book.AddAsync(Book);
                await _db.SaveChangesAsync();
              return  RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}