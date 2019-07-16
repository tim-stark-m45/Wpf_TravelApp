using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_TravelApp.Models
{
    class AppDbContext : DbContext
    {
        public AppDbContext() : base("DefaultConnection")
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}
