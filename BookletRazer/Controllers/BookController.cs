using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookletRazer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookletRazer.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public BookController(ApplicationDbContext db)
        {
            dbContext = db;
        }
        [HttpGet]
        public async Task <IActionResult> GetAll()
        {
            return Json(new { data = await dbContext.Book.ToListAsync() });
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id) {
            var BookToDel = await dbContext.Book.FirstOrDefaultAsync(i => i.Id == id);
            if (BookToDel == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            dbContext.Book.Remove(BookToDel);
            await dbContext.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });

        }

     
    }
}