using MyAdvert.Core.Models;
using MyAdvert.Core.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAdvert.Core.Services
{
    public interface IAdvertService
    {
        IEnumerable<Advert> GetAdverts(FilterAdverts filterTasks);

        Advert GetAdvert(int id);
        void AddAdvert(Advert advert);
        void UpdateAdvert(Advert advert);
        void DeleteAdvert(int id);
    }
}
