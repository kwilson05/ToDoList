using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Models;
using ToDoList.ViewModels;

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
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            loadActiveItems();
            loadCompletedItems();
            return View();
                
        }



        [HttpPost]
        public async Task<IActionResult> Create(ToDoItem toDoItem)
        { 

            _context.ToDoItems.Add(toDoItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
        }

        [HttpPut]
        [Route("MarkComplete/{id?}")]
        public async Task<IActionResult> MarkComplete(int? id)
        {
            if (id != null)
            {
                var toDoItem = await _context.ToDoItems.FindAsync(id);
                toDoItem.IsComplete = true;
                _context.ToDoItems.Update(toDoItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }


        [HttpDelete]
        [Route("Delete/{id?}")]
        public async Task<IActionResult> Delete(int? id)
        {
            


            if(id != null)
            {
                var toDoItem = await _context.ToDoItems.FindAsync(id);
                _context.ToDoItems.Remove(toDoItem);
                await _context.SaveChangesAsync();
            }


            
            return RedirectToAction("Index");

        }


        private async void loadActiveItems()
        {
            ViewBag.activeItems = await _context.ToDoItems.
                Where(item => item.IsComplete == false).ToListAsync();
            
        }

        private async void loadCompletedItems()
        {
            ViewBag.completedItems = await _context.ToDoItems.
                Where(item => item.IsComplete == true).ToListAsync();
        
        
        }






    }
}
