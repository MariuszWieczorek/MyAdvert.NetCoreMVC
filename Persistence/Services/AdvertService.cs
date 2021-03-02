using MyAdvert.Core;
using MyAdvert.Core.Models;
using MyAdvert.Core.Models.Domains;
using MyAdvert.Core.Services;
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

        public IEnumerable<Advert> GetAdverts(FilterAdverts filterAdverts)
        {
            return _unitOfWork.Advert.GetAdverts(filterAdverts);
        }

        public Advert Get(int id)
        {
            return _unitOfWork.Advert.GetAdvert(id);
        }

        public void Add(Advert advert)
        {
            _unitOfWork.Advert.AddAdvert(advert);
            _unitOfWork.Complete();
        }

        public void Update(Advert advert)
        {
            _unitOfWork.Advert.UpdateAdvert(advert);
            // metoda wysyłająca maila
            // ...
            // dodatkowa modyfikacja danych
            _unitOfWork.Complete();
        }

         public void Delete(int id, string userId)
        {
            _unitOfWork.Advert.DeleteAdvert(id);
            _unitOfWork.Complete();
        }
    }
}
