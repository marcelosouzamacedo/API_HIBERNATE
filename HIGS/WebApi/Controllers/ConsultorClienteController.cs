using Domain;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace WebApi.Controllers
{
    public class ConsultorClienteController : ApiController
    {
        private ClienteDomain _domain = new ClienteDomain();

        // GET api/cliente/5
        public JsonResult GetCliente(string id)
        {
            var listaClientes = _domain.GetAllByConsultor(id);

            return new JsonResult() { Data = new { IsValid = true, List = listaClientes } };
        }
    }
}
