using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Data;
using System.Linq;

namespace ToDoList.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            DbContextOptions<ToDoListContext> dbContextOptions =
                serviceProvider.GetRequiredService<DbContextOptions<ToDoListContext>>();
            var context = new ToDoListContext(dbContextOptions);
            using (context) 
            {
                if(context.ToDoItems.Any())
                {
                    return;
                }

                context.ToDoItems.AddRange(
                    new ToDoItem
                    {
                        Name = "Read newsletters",
                        IsComplete = false
                    },
                  new ToDoItem
                  {
                      Name = "Study Algorithms",
                      IsComplete = true
                  },
                  new ToDoItem
                  {
                      Name = "Yoga",
                      IsComplete = false
                  }
                    );

                context.SaveChanges();
            }



        }
    }
}
