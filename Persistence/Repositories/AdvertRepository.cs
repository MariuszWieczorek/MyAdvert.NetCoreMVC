using Microsoft.EntityFrameworkCore;
using MyAdvert.Core;
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

        private readonly IApplicationDbContext _context;
        
        public AdvertRepository(IApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Advert> GetAdverts(FilterAdverts filterTasks)
        {
            var adverts = _context.Adverts
                .Include(x => x.Category).AsQueryable();
                //.Where(x => x.IsActive == filterTasks.IsActive);

            if (filterTasks.IsActive == true)
                adverts = adverts.Where(x => x.IsActive == filterTasks.IsActive);

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

        public void AddAdvert(Advert advert)
        {
            _context.Adverts.Add(advert);
        }

        public void UpdateAdvert(Advert advert, string userId)
        {
            var advertToUpdate = _context.Adverts.Single(x => x.Id == advert.Id && x.UserId == userId);
            advertToUpdate.Title = advert.Title;
            advertToUpdate.Description = advert.Description;
            advertToUpdate.Picture = advert.Picture;
            advertToUpdate.Value = advert.Value;
            advertToUpdate.StartDate = advert.StartDate;
            advertToUpdate.StopDate = advert.StopDate;
            advertToUpdate.IsActive = advert.IsActive;
            advertToUpdate.CategoryId = advert.CategoryId;
        }

        public void DeleteAdvert(int id, string userId)
        {
            var advertToDelete = _context.Adverts.Single(x => x.Id == id && x.UserId == userId);
            _context.Adverts.Remove(advertToDelete);
        }
    }
}
