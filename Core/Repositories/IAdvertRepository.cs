using MyAdvert.Core.Models;
using MyAdvert.Core.Models.Domains;
using MyAdvert.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAdvert.Core.Repositories
{
    public interface IAdvertRepository
    {
        IEnumerable<Advert> GetAdverts(FilterAdverts filterTasks, PagingInfo pagingInfo);
        Advert GetAdvert(int id);
        int GetNumberOfRecords(FilterAdverts filterTasks);
        void AddAdvert(Advert advert);
        void UpdateAdvert(Advert advert, string userId);
        void DeleteAdvert(int id, string userId);
    }
}

