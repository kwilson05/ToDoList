using System;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Data
{
    public class ToDoListContext : DbContext
    {
        public ToDoListContext(DbContextOptions<ToDoListContext> options)
            :base(options)
        {
        }

        //Task is a built-in keyword so we can't use that
        public DbSet<ToDoItem> ToDoItems { get; set; }
    }

}
