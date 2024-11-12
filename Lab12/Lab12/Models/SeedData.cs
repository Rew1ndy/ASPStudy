using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Lab12.Data;
using System;
using System.Linq;

namespace Lab12.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new UserDBContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<UserDBContext>>()))
        {
            // Look for any movies.
            if (context.User.Any())
            {
                return;   // DB has been seeded
            }
            context.User.AddRange(
                new User
                {
                    Age = 18,
                    FirstName = "Day",
                    LastName = "Db"
                },
                new User
                {
                    Age = 22,
                    FirstName = "Hi",
                    LastName = "MN"
                },
                new User
                {
                    Age = 21,
                    FirstName = "Rey",
                    LastName = "Kil"
                },
                new User
                {
                    Age = 55,
                    FirstName = "Bat",
                    LastName = "Wer"
                }
            );
            context.SaveChanges();
        }
    }
}