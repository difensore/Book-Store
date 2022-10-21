using BookStore.Models;

namespace BookStore.Interfaces
{
    public interface IBasketProvider
    {
        public void AddToBasket(Products product);
        public List<Products> Remove(int id);
        public List<Products> GetBasket();
    }
}
