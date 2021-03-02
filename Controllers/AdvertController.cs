using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAdvert.Core.Models;
using MyAdvert.Core.ViewModels;
using MyAdvert.Persistence;
using MyAdvert.Persistence.Extensions;
using MyAdvert.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAdvert.Controllers
{
    [Authorize]
    public class AdvertController : Controller
    {

        private UnitOfWork _unitOfWork;

        public AdvertController(ApplicationDbContext context)
        {
            _unitOfWork = new UnitOfWork(context);           
        }


        public IActionResult Adverts()
        {
            var userId = User.GetUserId();

            var vm = new AdvertViewModel()
            {
                FilterAdverts = new FilterAdverts(),
                Categories = _unitOfWork.Category.GetCategories(),
                Adverts = _unitOfWork.Advert.GetAdverts(new FilterAdverts())
            };

            return View(vm);
        }
    }
}
