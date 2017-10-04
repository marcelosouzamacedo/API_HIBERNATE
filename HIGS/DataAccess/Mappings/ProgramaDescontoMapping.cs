using FluentNHibernate.Mapping;
using Model.Model;

namespace DataAccess.Mappings
{
    public class ProgramaDescontoMap : ClassMap<ProgramaDesconto>
    {
        public ProgramaDescontoMap()
        {
            Id(c => c.Id);
            Map(c => c.Nome);
            Table("PAGAMENTO_DESCONTO");
        }
    }
}
