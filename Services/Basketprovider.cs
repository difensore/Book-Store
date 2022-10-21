using BookStore.Interfaces;
using BookStore.Models;

namespace BookStore.Services
{
    public class Basketprovider:IBasketProvider
    {
        List<Products> basket = new List<Products>();       
        public void AddToBasket(Products product)
        {
           basket.Add(product);            
        }
        public List<Products> Remove(int id)
        {
            basket.RemoveAll(x=>x.Id==id);
            return basket;
        }
        public List<Products> GetBasket()
        {
            return basket;    
        }
    }
}
