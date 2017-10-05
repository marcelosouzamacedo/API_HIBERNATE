using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class ClienteModel
    {
        public virtual int Id { get; set; }
        public virtual string CodIdentificadorTotvs { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Cpf { get; set; }
        public virtual int IdProgramaDesconto { get; set; }
    }
}