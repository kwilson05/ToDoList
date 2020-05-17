using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Models;


namespace ToDoList.Controllers
{
    public class ToDoItemController : Controller
    {
        private readonly ToDoListContext _context;

        public ToDoItemController(ToDoListContext context)
        {
            _context = context;
        }


        // GET: All ToDoItems
        [Route("")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.ToDoItems.ToListAsync());
        }






    }
}
