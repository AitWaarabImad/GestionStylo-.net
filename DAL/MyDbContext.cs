using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Stylo> stylos { get; set; }
        public DbSet<Marque> marques { get; set; } 
        public DbSet<TypeSt> types { get; set; }
        public DbSet<User> users { get; set; }
    }
}
