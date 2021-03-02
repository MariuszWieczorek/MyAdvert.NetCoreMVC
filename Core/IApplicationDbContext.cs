using Microsoft.EntityFrameworkCore;
using MyAdvert.Core.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAdvert.Core
{
    public interface IApplicationDbContext
    {
        DbSet<Advert> Adverts { get; set; }
        DbSet<Category> Categories { get; set; }
        int SaveChanges();
    }
}
