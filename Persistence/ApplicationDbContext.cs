using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyAdvert.Core;
using MyAdvert.Core.Models.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAdvert.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Advert> Adverts { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
