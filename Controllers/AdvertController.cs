using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAdvert.Core;
using MyAdvert.Core.Models;
using MyAdvert.Core.Services;
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

        private readonly IAdvertService _advertService;
        private readonly ICategoryService _categoryService;

        public AdvertController(IAdvertService advertService, ICategoryService categoryService)
        {
            _advertService = advertService;
            _categoryService = categoryService;
        }


        public IActionResult Adverts()
        {
            var userId = User.GetUserId();

            var vm = new AdvertViewModel()
            {
                FilterAdverts = new FilterAdverts(),
                Categories = _categoryService.GetCategories(),
                Adverts =  _advertService.GetAdverts(new FilterAdverts())
            };

            return View(vm);
        }
    }
}
