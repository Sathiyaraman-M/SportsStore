using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {
        public int PageSize = 4;
        private IStoreRepository repository;
        public HomeController(IStoreRepository storeRepository)
        {
            repository = storeRepository;
        }
        public ViewResult Index(int ProductPage = 1)
        {
            return View(new ProductListViewModel
                {
                    Products = repository.Products
                        .OrderBy(p => p.ProductId)
                        .Skip((ProductPage - 1)*PageSize)
                        .Take(PageSize)
                    ,
                    pagingInfo = new PagingInfo() {
                        CurrentPage = ProductPage,
                        ItemsPerPage = PageSize,
                        TotalProducts = repository.Products.Count() 

                }});
        }
    }
}





//TODO: Pagination using Tag Helpers