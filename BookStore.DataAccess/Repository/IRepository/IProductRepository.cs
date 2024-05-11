using BookStore.Models;

namespace BookStore.DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Save();
    }
}
