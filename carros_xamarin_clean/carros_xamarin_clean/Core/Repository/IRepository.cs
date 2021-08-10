using System.Collections.Generic;

namespace carros_xamarin_clean.Core.Repository
{
    public interface IRepository<T> where T : class
    {
        bool Delete(T entity);
        List<T> GetAll();
        T Get(int id);
        bool Exist(T entity);
        bool AddOrUpdate(T entity);
        int AddOrUpdate(IEnumerable<T> entities);
    }
}
