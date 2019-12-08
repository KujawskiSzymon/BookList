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
    public class IndexModel : PageModel
    {
        ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public IEnumerable<Book> Books { get; set; }
        public async Task OnGet()
        {
            Books = await _db.Book.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var bookToDelete =await _db.Book.FindAsync(id);
            if (bookToDelete == null)
            {
                return NotFound();
            }
            _db.Book.Remove(bookToDelete);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}