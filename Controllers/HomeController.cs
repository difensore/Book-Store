using BookStore.Interfaces;
using BookStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductsProvider _productsProvider;
        private readonly IBasketProvider _basket;
        public HomeController(ILogger<HomeController> logger, IProductsProvider productsProvider, IBasketProvider basketProvider)
        {
            _logger = logger;
            _productsProvider = productsProvider;   
            _basket = basketProvider;
        }

        public IActionResult Index(string TypeofProduct,  int page=1, SortState sortOrder = SortState.NameAsc)
        {           
            IndexViewModel products = _productsProvider.GetProductsAsync(TypeofProduct, page, sortOrder).Result;
            return View(products);
        }

        public IActionResult Description(int product)
        {

            return View(_productsProvider.GetById(product));
        }
        public IActionResult AddToBasket(int product, int action, string TypeofProduct, int page = 1, SortState sortOrder = SortState.NameAsc)
        {
            if (!User.Identity.IsAuthenticated)
            {
                 Redirect("~/Identity/Account/Login");
            }
            if (action == 0)
            {
                _basket.AddToBasket(_productsProvider.GetById(product));
            }
            return RedirectToAction("Index", "Home", new { TypeofProduct= TypeofProduct, page=page, sortOrder=sortOrder }); 
            
        }
        public IActionResult Basket(int product, int act)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("~/Identity/Account/Login");
            }            
            else if (act==3)
            {
                return View(_basket.GetBasket());
            }
            else
            {
                return View(_basket.Remove(product));
            }           
        }
        [HttpGet]
        public IActionResult Purchase()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Purchase(int phone,string adrerss)
        {

            return View("Purchased");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}