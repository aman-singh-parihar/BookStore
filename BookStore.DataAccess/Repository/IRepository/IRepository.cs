using System.Linq.Expressions;

namespace BookStore.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T: class
    {
        IEnumerable<T> GetAll();
        T? Get(Expression<Func<T, bool>> filter);

        void Add(T item);
        void Delete(T item);
        void Update(T item);

        void DeleteAll(IEnumerable<T> items);

    }
}
