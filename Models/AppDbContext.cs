using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore; // we need to add this in order to inherit from DbContext

namespace BethanysPieShop.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser> // I pass to IdentityDbContext the type I want to use to represent the user
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base (options) // we pass DbContext Options through a Constructor
        {
            
        }

        public DbSet<Pie> Pies { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }
    }
}
