using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAdvert.Core;
using MyAdvert.Core.Models;
using MyAdvert.Core.Models.Domains;
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
        private int _itemPerPage = 2;

        public AdvertController(IAdvertService advertService, ICategoryService categoryService)
        {
            _advertService = advertService;
            _categoryService = categoryService;
        }

        #region Adverts
        // akcja wyświetlająca w głównym oknie aplikacji listę ogłoszeń
        public IActionResult Adverts(int currentPage = 1, int categoryId = 0)
        {
            
            int numberOfRecords = _advertService.GetNumberOfRecords(new FilterAdverts(),categoryId);
            var adverts = _advertService.GetAdverts(new FilterAdverts(),
                new PagingInfo() { CurrentPage = currentPage, ItemsPerPage = _itemPerPage },
                categoryId);

            var vm = new AdvertsViewModel()
            {
                FilterAdverts = new FilterAdverts(),
                Categories = _categoryService.GetCategories(),
                Adverts = adverts,
                PagingInfo = new PagingInfo() { CurrentPage = currentPage, ItemsPerPage = _itemPerPage, TotalItems = numberOfRecords }
            };

            return View(vm);
        }

        // akcja wywoływana w widoku Adverts po kliknięciu na submit służącym do filtrowania zadań
        [HttpPost]
        public IActionResult Adverts(AdvertsViewModel viewModel)
        {
            int numberOfRecords = _advertService.GetNumberOfRecords(viewModel.FilterAdverts,0);
            var adverts = _advertService.GetAdverts(viewModel.FilterAdverts,viewModel.PagingInfo,0);

            var vm = new AdvertsViewModel()
            {
                FilterAdverts = new FilterAdverts(),
                Categories = _categoryService.GetCategories(),
                Adverts = adverts,
                PagingInfo = new PagingInfo() { CurrentPage = 1, ItemsPerPage = _itemPerPage, TotalItems = numberOfRecords }
            };

            return PartialView("_AdvertsSummaryPartial", vm);
        }
        #endregion

        #region Advert - dodawanie / edycja / usuwanie ogłoszenia
        // Wejście na ekran dodawania/edycji z przycisku dodaj nowe
        // lub po kliknięciu na link na liście ogłoszeń

        [HttpGet]
        public IActionResult Advert(int id = 0)
        {
            var userId = User.GetUserId();

            var advert = id == 0 ?
                new Advert { Id = 0, UserId = userId, StartDate = DateTime.Now, IsActive = true } :
                _advertService.GetAdvert(id);

            var vm = new AdvertViewModel()
            {
                Advert = advert,
                Categories = _categoryService.GetCategories(),
                Heading = id == 0 ?
                 "nowe ogłoszenie" :
                 "edycja ogłoszenia"
            };

            return View(vm);
        }

        // Wciśnięcie przycisku typu submit na ekranie edycji/dodania ogłoszenia
        // Po którym nastąpi przekazanie zawartości pól na formularzu 
        // i wywołanie metod w repozytorium dodania lub aktualizacji zadania

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Advert(Advert advert)
        {
            var userId = User.GetUserId();
            advert.UserId = userId;

            if (!ModelState.IsValid)
            {
                var vm = new AdvertViewModel()
                {
                    Advert = advert,
                    Categories = _categoryService.GetCategories(),
                    Heading = advert.Id == 0 ?
                     "nowe ogłoszenie" :
                     "edycja ogłoszenia"
                };

                return View("Advert", vm);
            }

            if (advert.Id == 0)
                _advertService.AddAdvert(advert);
            else
                _advertService.UpdateAdvert(advert,userId);


            return RedirectToAction("Adverts", "Advert");
        }

        // po kliknięciu przycisku deleteAdvert
        // zostanie wywołany ajax
        // który wywoła akcję DeleteAdvert typu Post w kontrolerze Advert
        // i to jest ta akcja

        [HttpPost]
        public IActionResult DeleteAdvert(int id)
        {
            try
            {
                var userId = User.GetUserId();
                _advertService.DeleteAdvert(id, userId);
            }
            catch (Exception ex)
            {
                // logowanie do pliku
                return Json(new { success = false, message = ex.Message });
            }

            return Json(new { success = true });
        }


        #endregion

        #region Category: przeglądanie, edycja/dodawanie/usuwanie kategorii ------------------

        public IActionResult Categories()
        {
            var userId = User.GetUserId();
            var categories = _categoryService.GetCategories();

            return View(categories);
        }

        public IActionResult Category(int id)
        {
            var userId = User.GetUserId();
            var category = id == 0 ?
                new Category { Id = 0, Name = string.Empty } :
                _categoryService.GetCategory(id);

            var vm = new CategoryViewModel()
            {
                Category = category,
                Heading = ""
            };

            return View(vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Category(Category category)
        {
            var userId = User.GetUserId();

            if (!ModelState.IsValid)
            {
                var vm = new CategoryViewModel()
                {
                    Category = category,
                    Heading = category.Id == 0 ?
                     "nowa kategoria" :
                     "edycja kategorii"
                };

                return View("Category", vm);
            }

            if (category.Id == 0)
                _categoryService.AddCategory(category);
            else
                _categoryService.UpdateCategory(category);


            return RedirectToAction("Categories", "Advert");
        }

        [HttpPost]
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                var userId = User.GetUserId();
                _categoryService.DeleteCategory(id);
            }
            catch (Exception ex)
            {
                // logowanie do pliku
                return Json(new { success = false, message = ex.Message });
            }

            return Json(new { success = true });
        }
        #endregion

    }
}
