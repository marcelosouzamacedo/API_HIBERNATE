using FluentNHibernate.Mapping;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappings
{
    public class ClienteMap : ClassMap<Cliente>
    {
        public ClienteMap()
        {
            Id(c => c.Id).GeneratedBy.Identity();
            Map(c => c.CodIdentificadorTotvs).Length(4);
            Map(c => c.Cpf);
            Map(c => c.Nome).Length(30);
            References(c => c.ProgramaDesconto, "PROGRAMA_DESCONTO_ID");
            Table("CLIENTE");
        }
    }
}
