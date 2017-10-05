using Model.Model;
using Model.Repository;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;

namespace DataAccess.Repository
{
    public class ClienteRepository : DefaultRepository<Cliente>
    {
        public IEnumerable<Cliente> GetAllByConsultor(string codConsultor)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                return (from c in session.Query<Cliente>() where c.CodIdentificadorTotvs == codConsultor select c).ToList();
            }
        }
    }
}
