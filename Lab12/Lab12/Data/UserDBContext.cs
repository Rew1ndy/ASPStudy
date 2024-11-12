using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab12.Models;

namespace Lab12.Data
{
    public class UserDBContext : DbContext
    {
        public UserDBContext (DbContextOptions<UserDBContext> options)
            : base(options)
        {
        }

        public DbSet<Lab12.Models.User> User { get; set; } = default!;
    }
}
