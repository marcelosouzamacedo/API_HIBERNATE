using Domain;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class ClienteController : ApiController
    {
        private ClienteDomain _domain = new ClienteDomain();

        // GET api/cliente
        public IEnumerable<Cliente> GetClientes()
        {
            return _domain.GetAll().AsEnumerable();
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
        public HttpResponseMessage PutCliente(int id, [FromBody]Cliente Cliente)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != Cliente.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                _domain.Update(Cliente);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/cliente
        public HttpResponseMessage PostCliente(Cliente Cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _domain.Create(Cliente);

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, Cliente);
                    response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = Cliente.Id }));
                    return response;
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE api/cliente/5
        public HttpResponseMessage DeleteCliente(int id)
        {
            Cliente Cliente = _domain.GetById(id);
            if (Cliente == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            try
            {
                _domain.Delete(Cliente);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, Cliente);
        }
    }
}
