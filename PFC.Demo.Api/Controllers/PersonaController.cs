using PFC.Demo.BusinessLogic;
using PFC.Demo.Domain.Models.Request;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PFC.Demo.Domain.Controllers
{
    public class PersonaController : ApiController
    {
        // GET api/persona
        public HttpResponseMessage Get()
        {
            try
            {
                var result = PersonaManager.GetAllPersonas();
                if (!result.Success)
                {
                    throw new Exception(result.Message);
                }

                return Request.CreateResponse(result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);

            }
        }

        // GET api/persona/5
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var result = PersonaManager.GetPersonaById(id);
                if (!result.Success)
                {
                    throw new Exception(result.Message);
                }

                return Request.CreateResponse(result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }


        // POST api/persona
        public HttpResponseMessage Post([FromBody] PersonaUpdateModel model)
        {
            try
            {
                var result = PersonaManager.CrearPersona(model);
                if (!result.Success)
                {
                    throw new Exception(result.Message);
                }

                return Request.CreateResponse(result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        // PUT api/persona/5
        public HttpResponseMessage Put(int id, [FromBody] PersonaUpdateModel model)
        {
            try
            {
                var result = PersonaManager.ActualizarPersona(id, model);
                if (!result.Success)
                {
                    throw new Exception(result.Message);
                }

                return Request.CreateResponse(result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        // DELETE api/persona/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var result = PersonaManager.EliminarPersona(id);
                if (!result.Success)
                {
                    throw new Exception(result.Message);
                }

                return Request.CreateResponse(result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        // GET api/Persona/{id}/CuentasBancarias
        [Route("api/Persona/{id}/CuentasBancarias")]
        public HttpResponseMessage GetCuentasBancariasByPersonaId(int id)
        {
            try
            {
                var result = CuentaBancariaManager.GetAllCuentaBancarias(id);
                if (!result.Success)
                {
                    throw new Exception(result.Message);
                }

                return Request.CreateResponse(result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);

            }
        }
    }
}
