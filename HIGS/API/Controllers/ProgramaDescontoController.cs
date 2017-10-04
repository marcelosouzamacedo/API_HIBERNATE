using Domain;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class ProgramaDescontoController : ApiController
    {
        private ProgramaDescontoDomain _domain = new ProgramaDescontoDomain();

        // GET api/ProgramaDesconto
        public IEnumerable<ProgramaDesconto> GetProgramaDescontos()
        {
            return _domain.GetAll().AsEnumerable();
        }

        // GET api/ProgramaDesconto/5
        public ProgramaDesconto GetProgramaDesconto(int id)
        {
            ProgramaDesconto programaDesconto = _domain.GetById(id);
            if (programaDesconto == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return programaDesconto;
        }

        // PUT api/ProgramaDesconto/5
        public HttpResponseMessage PutProgramaDesconto(int id, ProgramaDesconto programaDesconto)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != programaDesconto.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                _domain.Update(programaDesconto);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/ProgramaDesconto
        public HttpResponseMessage PostProgramaDesconto(ProgramaDesconto programaDesconto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _domain.Create(programaDesconto);

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, programaDesconto);
                    response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = programaDesconto.Id }));
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

        // DELETE api/ProgramaDesconto/5
        public HttpResponseMessage DeleteProgramaDesconto(int id)
        {
            ProgramaDesconto programaDesconto = _domain.GetById(id);
            if (programaDesconto == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            try
            {
                _domain.Delete(programaDesconto);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, programaDesconto);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
