using MyAdvert.Core;
using MyAdvert.Core.Models;
using MyAdvert.Core.Models.Domains;
using MyAdvert.Core.Services;
using MyAdvert.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAdvert.Persistence.Services
{
    public class AdvertService : IAdvertService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdvertService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Advert> GetAdverts(FilterAdverts filterAdverts, PagingInfo pagingInfo)
        {
            return _unitOfWork.Advert.GetAdverts(filterAdverts,pagingInfo);
        }

        public int GetNumberOfRecords(FilterAdverts filterTasks)
        {
            return _unitOfWork.Advert.GetNumberOfRecords(filterTasks);
        }
        public Advert GetAdvert(int id)
        {
            return _unitOfWork.Advert.GetAdvert(id);
        }

        public void AddAdvert(Advert advert)
        {
            _unitOfWork.Advert.AddAdvert(advert);
            _unitOfWork.Complete();
        }

        public void UpdateAdvert(Advert advert, string userId)
        {
            _unitOfWork.Advert.UpdateAdvert(advert, userId);
            // metoda wysyłająca maila
            // ...
            // dodatkowa modyfikacja danych
            _unitOfWork.Complete();
        }

         public void DeleteAdvert(int id, string userId)
        {
            _unitOfWork.Advert.DeleteAdvert(id,userId);
            _unitOfWork.Complete();
        }
    }
}
