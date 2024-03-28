using PFC.Demo.BusinessLogic;
using PFC.Demo.Domain.Models.Request;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PFC.Demo.Domain.Controllers
{
    public class CatalogoController : ApiController
    {
        // GET api/catalogo/paises
        [HttpGet, Route("api/catalogo/paises")]
        public HttpResponseMessage GetPaises()
        {
            try
            {
                var result = PaisManager.GetPaises();
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
        
        // GET api/catalogo/paises/{id}/provincias
        [HttpGet, Route("api/catalogo/pais/{id}/provincias")]
        public HttpResponseMessage GetProvincias(string id)
        {
            try
            {
                var result = PaisManager.GetProvinciasByPaisId(id);
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
        
        // GET api/catalogo/paises/{id}/provincias
        [HttpGet, Route("api/catalogo/provincia/{id}/ciudades")]
        public HttpResponseMessage GetCiudades(string id)
        {
            try
            {
                var result = PaisManager.GetCiudadesByProvinciaId(id);
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