using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp2v2.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ExpensesDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ExpensesDbContext>>()))
            {
                // Look for any expenses.
                if (context.Expenses.Any())
                {
                    return;   // DB table has been seeded
                }

                context.Expenses.AddRange(
                        new Expense
                        {
                            Description = "First expense",
                            Sum = 120,
                            Location = "Auchan",
                            Date = new DateTime(2020, 03, 11),
                            Currency = "lei",
                            Type = Type.utilities
                        },

                         new Expense
                         {
                             Description = "other expense",
                             Sum = 100,
                             Location = "Profi",
                             Date = new DateTime(2020, 04, 10),
                             Currency = "lei",
                             Type = Type.food
                         },

                         new Expense
                         {
                             Description = "test expense",
                             Sum = 20,
                             Location = "Lidl",
                             Date = new DateTime(2020, 05, 14),
                             Currency = "lei",
                             Type = Type.utilities
                         },

                          new Expense
                          {
                              Description = "shoes",
                              Sum = 400,
                              Location = "Decatlon",
                              Date = new DateTime(2020, 02, 15),
                              Currency = "lei",
                              Type = Type.clothes
                          }
                );
                context.SaveChanges();
            }
        }
    }
}


