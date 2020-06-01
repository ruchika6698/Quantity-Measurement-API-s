using CommanLayer;
using CommanLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.ApplicationDatabase
{
    public class AppDbContext : DbContext
    { 
        // Parameterized Constructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Quantity> Quantities { get; set; }
        public DbSet<Comparision> Comparisions { get; set; }
    }
}
