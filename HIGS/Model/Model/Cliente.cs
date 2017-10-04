using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    public class Cliente
    {
        public int Id { get; set; }
        public string CodIdentificadorTotvs { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public ProgramaDesconto ProgramaDesconto { get; set; }

    }
}
