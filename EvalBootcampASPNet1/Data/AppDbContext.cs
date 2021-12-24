using System;
using EvalBootcampASPNet1.Models;
using Microsoft.EntityFrameworkCore;

namespace EvalBootcampASPNet1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Author> Authors {get; set;}
        public DbSet<Course> Courses { get; set; }
}
}
