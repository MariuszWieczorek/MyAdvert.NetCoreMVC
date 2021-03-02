using Microsoft.EntityFrameworkCore;
using MyAdvert.Core.Models;
using MyAdvert.Core.Models.Domains;
using MyAdvert.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAdvert.Persistence.Repositories
{
    public class AdvertRepository : IAdvertRepository
    {

        private readonly ApplicationDbContext _context;
        
        public AdvertRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddAdvert(Advert advert)
        {
            _context.Adverts.Add(advert);
        }

        public void DeleteAdvert(int id)
        {
            var advertToDelete = _context.Adverts.Single(x => x.Id == id);
            _context.Adverts.Remove(advertToDelete);
        }

        public IEnumerable<Advert> GetAdverts(FilterAdverts filterTasks)
        {
            var adverts = _context.Adverts
                .Include(x => x.Category)
                .Where(x =>  x.IsActive == filterTasks.IsActive);

            if (filterTasks.CategoryId != 0)
                adverts = adverts.Where(x => x.CategoryId == filterTasks.CategoryId);

            if (!string.IsNullOrWhiteSpace(filterTasks.Title))
                adverts = adverts.Where(x => x.Title.Contains(filterTasks.Title));

            return adverts.OrderBy(x => x.StartDate).ToList();
        }

        public Advert GetAdvert(int id)
        {
            var advert = _context.Adverts.Single(x => x.Id == id);
            return advert;
        }

        public void UpdateAdvert(Advert advert)
        {
            var advertToUpdate = _context.Adverts.Single(x => x.Id == advert.Id);
            advertToUpdate.Title = advert.Title;
            advertToUpdate.Description = advert.Description;
            advertToUpdate.StartDate = advert.StartDate;
            advertToUpdate.StopDate = advert.StopDate;
            advertToUpdate.IsActive = advert.IsActive;
            advertToUpdate.CategoryId = advert.CategoryId;
        }
    }
}
