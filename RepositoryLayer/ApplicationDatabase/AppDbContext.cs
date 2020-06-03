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
        //Dbset for Quantity table
        public DbSet<Quantity> Quantities { get; set; }

        //Dbset for Comparison table
        public DbSet<Comparision> Comparisions { get; set; }
    }
}
