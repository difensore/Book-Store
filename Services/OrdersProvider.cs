using BookStore.Data;
using BookStore.Interfaces;
using BookStore.Models;

namespace BookStore.Services
{
    public class OrdersProvider:IOrdersProvider
    {
        ApplicationDbContext db;
        public OrdersProvider(ApplicationDbContext context)
        {
            db = context;
        }
        public void CreateOrder(int phone, string adress)
        {
            var order = new Orders() { Phone = phone, Adreess = adress, Products = "1" };
            db.Orders.Add(order);
            db.SaveChanges();
        }
    }
}
