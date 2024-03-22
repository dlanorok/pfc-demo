using PFC.Demo.BusinessLogic;
using PFC.Demo.Domain.Models.Request;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PFC.Demo.Domain.Controllers
{
    public class CuentaBancariaController : ApiController
    {
        

        // GET api/CuentaBancaria/5
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var result = CuentaBancariaManager.GetCuentaBancariaById(id);
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


        // POST api/CuentaBancaria
        public HttpResponseMessage Post([FromBody] CuentaBancariaUpdateModel model)
        {
            try
            {
                var result = CuentaBancariaManager.CrearCuentaBancaria(model);
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

        // PUT api/CuentaBancaria/5
        public HttpResponseMessage Put(int id, [FromBody] CuentaBancariaUpdateModel model)
        {
            try
            {
                var result = CuentaBancariaManager.ActualizarCuentaBancaria(id, model);
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

        // DELETE api/CuentaBancaria/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var result = CuentaBancariaManager.EliminarCuentaBancaria(id);
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
