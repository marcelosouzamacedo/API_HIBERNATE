using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repository
{
    public interface IDefaultRepository<T> where T : class
    {
        void Create(T model);
        void Update(T model);
        void Delete(T model);
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}