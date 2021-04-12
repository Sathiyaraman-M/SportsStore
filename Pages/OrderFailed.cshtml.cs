using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportsStore.Models;

namespace SportsStore.Pages
{
    public class OrderFailedModel : PageModel
    {
        public Cart cart;
        public OrderFailedModel(Cart _cart)
        {
            cart = _cart;
        }
    }
}