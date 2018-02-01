using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace TodoApi.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TodoContext(
                serviceProvider.GetRequiredService<DbContextOptions<TodoContext>>()))
            {
                // Look for any movies.
                if (context.TodoItems.Any())
                {
                    return;   // DB has been seeded
                }

                context.TodoItems.AddRange(
                     new TodoItem
                     {
                         Id = 1,
                         Name = "Brush Teeth",
                         IsComplete = false
                     },

                     new TodoItem
                     {
                         Id = 2,
                         Name = "Walk Toby",
                         IsComplete = false
                     },

                   new TodoItem
                   {
                       Id = 3,
                       Name = "Cook Dinner",
                       IsComplete = false
                   }
                );
                context.SaveChanges();
            }
        }
    }
}