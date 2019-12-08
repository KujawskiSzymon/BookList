using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookletRazer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookletRazer.Pages.BookList
{
    public class UpsertModel : PageModel
    {
        private readonly ApplicationDbContext dbContext;

        public UpsertModel(ApplicationDbContext db)
        {
            dbContext = db;
        }
        [BindProperty]
        public Book Book { get; set; }
        public async Task<IActionResult> OnGet(int? id)
        {
            Book = new Book();
            
                if (id == null) {
                return Page();
            }
            Book = await dbContext.Book.FirstOrDefaultAsync(u => u.Id == id);
            if (Book == null)
            {
                return NotFound();
            }
            return Page();
           
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Book.Id == 0)
                {
                    dbContext.Book.Add(Book);

                }
                else
                {
                    dbContext.Book.Update(Book);
                }
                await dbContext.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return RedirectToPage();
            }
        }
    }

}