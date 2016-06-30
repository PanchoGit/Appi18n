using System.Collections.Generic;
using NHibernate;

namespace Appi18n.Application.Data
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ISession Session { get; private set; }

        public RepositoryBase(ISession session)
        {
            Session = session;
        }

        public IEnumerable<T> GetAll()
        {
            return Session.CreateCriteria<T>().List<T>();
        }

        public T Save(T item)
        {
            using (var session = Session)
            {
                session.SaveOrUpdate(item);
                session.Flush();
            }
            return item;
        }
    }
}
