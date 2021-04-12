using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IStoreRepository storeRepository;

        public NavigationMenuViewComponent(IStoreRepository repository)
        {
            storeRepository = repository;

        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(storeRepository.Products.Select(p => p.Category).Distinct().OrderBy(p => p));
        }
    }
}