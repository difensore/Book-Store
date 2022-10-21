using BookStore.Data;
using BookStore.Interfaces;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BookStore.Services
{
    public class ProductsProvider : IProductsProvider
    {
        ApplicationDbContext db;
        public ProductsProvider(ApplicationDbContext context)
        {
            db = context;
        }
        public async Task<IndexViewModel> GetProductsAsync(string name, int page = 1, SortState sortOrder = SortState.NameAsc)
        {
            int pageSize = 3;
            IQueryable<Products> products = db.Products;
            if (!string.IsNullOrEmpty(name))
            {
                products = products.Where(p => p.ProductType==name);
            }
            switch (sortOrder)
            {
                case SortState.NameDesc:
                    products = products.OrderByDescending(s => s.Name);
                    break;
                case SortState.PriceAsc:
                    products = products.OrderBy(s => s.Price);
                    break;
                case SortState.PriceDesc:
                    products = products.OrderByDescending(s => s.Price);
                    break;
                default:
                    products = products.OrderBy(s => s.Name);
                    break;
            }
            var count = await products.CountAsync();
            var items = await products.Skip((page-1) * pageSize).Take(pageSize).ToListAsync();
            IndexViewModel viewModel = new IndexViewModel(items,
                new PageViewModel(count, page, pageSize),
                new FilterViewModel( name),
                new SortViewModel(sortOrder)
                );
            return viewModel;
        }
        public Products GetById(int id)
        {
            var selectedProduct = db.Products.First(p => p.Id == id);
            return selectedProduct;         
                                 
        }
        public List<Products> getProduct()
        {
            return db.Products.ToList();
        }
    }
}
