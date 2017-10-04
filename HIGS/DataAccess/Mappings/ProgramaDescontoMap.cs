using FluentNHibernate.Mapping;
using Model.Model;

namespace DataAccess.Mappings
{
    public class ProgramaDescontoMap : ClassMap<ProgramaDesconto>
    {
        public ProgramaDescontoMap()
        {
            Id(c => c.Id).GeneratedBy.Identity();
            Map(c => c.Nome);
            Table("PROGRAMA_DESCONTO");
        }
    }
}
