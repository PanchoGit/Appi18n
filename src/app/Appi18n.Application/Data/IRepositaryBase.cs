using System.Collections.Generic;

namespace Appi18n.Application.Data
{
    public interface IRepositoryBase<T> where T : class
    {
        IEnumerable<T> GetAll();

        T Save(T item);
    }
}
