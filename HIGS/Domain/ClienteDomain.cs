using DataAccess.Repository;
using Model.Model;
using System;
using System.Collections.Generic;

namespace Domain
{
    public class ClienteDomain : BaseDomain<Cliente>
    {
        
        public IEnumerable<Cliente> GetAllByConsultor(string codConsultor)
        {
            return (new ClienteRepository()).GetAllByConsultor(codConsultor);
        }

        public override void Create(Cliente model)
        {
            model.DataInclusao = DateTime.Now;
            base.Create(model);
        }
    }
}
