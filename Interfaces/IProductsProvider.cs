using BookStore.Models;

namespace BookStore.Interfaces
{
    public interface IProductsProvider
    {
        public Task<IndexViewModel> GetProductsAsync(string name, int page = 1, SortState sortOrder = SortState.NameAsc);
        public Products GetById(int id);
    }
}
