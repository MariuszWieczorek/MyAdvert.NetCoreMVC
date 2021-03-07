using Microsoft.AspNetCore.Mvc;
using MyAdvert.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAdvert.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public NavigationMenuViewComponent(IAdvertService advertService, ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // metoda Invoke jest wywoływana w chwili użycia komponentu przez silnik Razor 
        public IViewComponentResult Invoke()
        {
            // klasa bazowa ViewComponent podobnie jak Controler przez zestaw właściwości zapewnia
            // dostęp do obiektu kontekstu jedna z nich RouteData dostarcza informacje jaki adres URL zostało bsłużony przez system routinngu

            ViewBag.SelectedCategory = RouteData?.Values["category"];
            // do widoku przekazujemy po przez obiekt ViewBg
            // warto by było utworzyć kolejną klasę modelu widoku i za pomocą niej przekazać informację o wybranej kategorii 
            // w przypadku komponentów szukamy widoku 
            // Shared/Components/NavigationMenu/Default.cshtml
            return View(_categoryService.GetCategories());
        }

    }
}
