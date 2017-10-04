using DataAccess.Repository;
using System.Collections.Generic;

namespace Domain
{
    public class BaseDomain<T> where T : class
    {
        private DefaultRepository<T> _repository = new DefaultRepository<T>();

        public void Create(T model)
        {
            _repository.Create(model);
        }

        public void Update(T model)
        {
            _repository.Update(model);
        }

        public void Delete(T model)
        {
            _repository.Delete(model);
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
