using Domain;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ClienteController : ApiController
    {
        private ClienteDomain _domain = new ClienteDomain();
        private ProgramaDescontoDomain _programaDomain = new ProgramaDescontoDomain();

        // GET api/cliente
        public JsonResult GetClientes()
        {
            var list = _domain.GetAll().ToList();

            return new JsonResult() { Data = new { IsValid = true, List = list } };
        }

        // GET api/cliente/5
        public Cliente GetCliente(int id)
        {
            Cliente Cliente = _domain.GetById(id);
            if (Cliente == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return Cliente;
        }

        // PUT api/cliente/5
        public JsonResult PutCliente(int id, [FromBody]Cliente Cliente)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult() { Data = new { isValid = false } };
            }

            if (id != Cliente.Id)
            {
                return new JsonResult() { Data = new { isValid = false } };
            }

            try
            {
                _domain.Update(Cliente);
            }
            catch (Exception ex)
            {
                return new JsonResult() { Data = new { isValid = false } };
            }

            return new JsonResult() { Data = new { isValid = true } };
        }

        // POST api/cliente
        public JsonResult PostCliente(ClienteModel clienteModel)
        {
            try
            {
                if (string.IsNullOrEmpty(clienteModel.Nome) || string.IsNullOrEmpty(clienteModel.CodIdentificadorTotvs) || clienteModel.IdProgramaDesconto == 0)
                    return new JsonResult() { Data = new { IsValid = false, Message = "Preencha todos os campos" } };
                if (ModelState.IsValid)
                {
                    Cliente model = new Cliente();
                    model.ProgramaDesconto = _programaDomain.GetById(clienteModel.IdProgramaDesconto);
                    model.CodIdentificadorTotvs = clienteModel.CodIdentificadorTotvs;
                    model.Cpf = clienteModel.Cpf;
                    model.Nome = clienteModel.Nome;

                    _domain.Create(model);

                    clienteModel.Id = model.ProgramaDesconto.Id;

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, clienteModel);
                    response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = clienteModel.Id }));

                    return new JsonResult() { Data = new { IsValid = true } };
                }
                else
                {
                    return new JsonResult() { Data = new { IsValid = false, Message = "Ocorreu um erro." } };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE api/cliente/5
        public JsonResult DeleteCliente(int id)
        {
            Cliente Cliente = _domain.GetById(id);
            if (Cliente == null)
            {
                return new JsonResult() { Data = new { isValid = false } };
            }
            try
            {
                _domain.Delete(Cliente);

            }
            catch (Exception ex)
            {
                return new JsonResult() { Data = new { isValid = false } };
            }

            return new JsonResult() { Data = new { isValid = true } };
        }
    }
}
