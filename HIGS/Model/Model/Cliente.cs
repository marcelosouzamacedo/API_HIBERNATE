using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    public class Cliente
    {
        public virtual int Id { get; set; }
        public virtual string CodIdentificadorTotvs { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Cpf { get; set; }
        public virtual ProgramaDesconto ProgramaDesconto { get; set; }

    }
}
