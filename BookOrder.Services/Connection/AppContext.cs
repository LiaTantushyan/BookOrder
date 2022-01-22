using BookOrder.Services.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOrder.Services.Connection
{
    public class AppContext:DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<Member> Members { get; set; }

        public DbSet<BookIssues> BookIssues { get; set; }


        public AppContext(DbContextOptions<AppContext> options)
           : base(options)
        {
            Database.EnsureCreated();   
        }
    }
}
