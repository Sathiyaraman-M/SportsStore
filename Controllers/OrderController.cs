using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository OrderRepository;
        private Cart cart;

        public OrderController(IOrderRepository orderRepository, Cart cartService){
            OrderRepository = orderRepository;
            cart = cartService;
        }
        public ViewResult Checkout()
        {
            return View(new Order());
        }

        [HttpPost]
        public IActionResult Checkout(Order order){
            if(cart.Lines.Count == 0){
                ModelState.AddModelError("","Sorry, your cart is empty!");
            }
            if(ModelState.IsValid){
                order.Lines = cart.Lines.ToArray();
                OrderRepository.SaveOrder(order);
                cart.Clear();
                return RedirectToPage("/Completed", new { orderId = order.OrderID});
            } else {
                return View();
            }
        }
    }
}