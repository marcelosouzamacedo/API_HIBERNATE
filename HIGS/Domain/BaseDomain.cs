using DataAccess.Repository;
using System.Collections.Generic;

namespace Domain
{
    public class BaseDomain<T> where T : class
    {
        internal DefaultRepository<T> _repository = new DefaultRepository<T>();

        public virtual void Create(T model)
        {
            _repository.Create(model);
        }

        public virtual void Update(T model)
        {
            _repository.Update(model);
        }

        public virtual void Delete(T model)
        {
            _repository.Delete(model);
        }

        public virtual T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
