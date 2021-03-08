using Microsoft.AspNetCore.Mvc;
using MyAdvert.Core.Services;
using MyAdvert.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAdvert.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        private readonly IAdvertService _advertService;

        public NavigationMenuViewComponent(ICategoryService categoryService, IAdvertService advertService)
        {
            _categoryService = categoryService;
            _advertService = advertService;
        }

        // metoda Invoke jest wywoływana w chwili użycia komponentu przez silnik Razor 
        public IViewComponentResult Invoke()
        {
            // klasa bazowa ViewComponent podobnie jak Controler przez zestaw właściwości zapewnia
            // dostęp do obiektu kontekstu jedna z nich RouteData dostarcza informacje jaki
            // adres URL został obsłużony przez system routinngu

            ViewBag.SelectedCategory = RouteData?.Values["categoryId"];

            int currentCategoryId;
            
            int.TryParse( (string)RouteData?.Values["categoryId"], out currentCategoryId);

            var vm = new NavigationMenuViewModel()
            {
                Categories = _advertService.GetUsedCategories(),
                CurrentCategoryId = currentCategoryId
            };

            // do widoku przekazujemy go po przez obiekt ViewBg
            // warto by było utworzyć kolejną klasę modelu widoku i za pomocą niej przekazać informację o wybranej kategorii 

            // w przypadku komponentów w odróżnieniu od widoków szukamy widoku w katalogu: 
            // Shared/Components/NavigationMenu/Default.cshtml

            return View(vm);
        }

    }
}

