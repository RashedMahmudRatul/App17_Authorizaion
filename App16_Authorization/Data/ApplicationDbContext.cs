using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using App16_Authorization.Models;

namespace App16_Authorization.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<App16_Authorization.Models.Person> Person { get; set; }
        public DbSet<App16_Authorization.Models.Product> Product { get; set; }
        public DbSet<App16_Authorization.Models.Size> Size { get; set; }
        public DbSet<App16_Authorization.Models.Color> Color { get; set; }
 
    }
}
