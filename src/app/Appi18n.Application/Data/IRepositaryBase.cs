using System.Collections.Generic;

namespace Appi18n.Application.Data
{
    public interface IRepositoryBase<out T> where T : class
    {
        IEnumerable<T> GetAll();
    }
}
