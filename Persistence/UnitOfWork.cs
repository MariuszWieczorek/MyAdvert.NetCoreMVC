﻿using MyAdvert.Core;
using MyAdvert.Core.Repositories;
using MyAdvert.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAdvert.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        // readonly przy polu oznacza, że jego wartość
        // możemy zmienić tylko w konstruktorze
        private readonly IApplicationDbContext _context;
        public UnitOfWork(IApplicationDbContext context)
        {
            _context = context;
            Advert = new AdvertRepository(context);
            Category = new CategoryRepository(context);
        }

        // obiekty repozytoryjne 
        public IAdvertRepository Advert { get; set; }
        public ICategoryRepository Category { get; set; }

        // na koniec metoda zapisująca zmiany
        public void Complete()
        {
            _context.SaveChanges();
        }

    }
}
