using PFC.Demo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace PFC.Demo.ClientApp.Services
{
    public static class CatalogoService
    {
        private static string _baseUrl = $"{Utils.ServiceUrl}/catalogo";

        public static async Task<ResultModel<List<PaisModel>>> GetAllPaises()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"{_baseUrl}/paises");

            if (response.IsSuccessStatusCode)
            {
                if (response.GetResult<ResultModel<List<PaisModel>>>(out var result))
                {
                    return result;
                }
                else if (response.GetResult<ResultModel>(out var model))
                {
                    return new ResultModel<List<PaisModel>>(null, model.Message, model.Success);
                }
            }

            if (response.GetResult<HttpError>(out var error))
            {
                return new ResultModel<List<PaisModel>>(null, error.ExceptionMessage, false);
            }

            return new ResultModel<List<PaisModel>>(null, "Error desconocido", false);
        }

        public static async Task<ResultModel<List<ProvinciaModel>>> GetProvinciasByPaisId(string id)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"{_baseUrl}/pais/{id}/provincias");

            if (response.IsSuccessStatusCode)
            {
                if (response.GetResult<ResultModel<List<ProvinciaModel>>>(out var result))
                {
                    return result;
                }
                else if (response.GetResult<ResultModel>(out var model))
                {
                    return new ResultModel<List<ProvinciaModel>>(null, model.Message, model.Success);
                }
            }

            if (response.GetResult<HttpError>(out var error))
            {
                return new ResultModel<List<ProvinciaModel>>(null, error.ExceptionMessage, false);
            }

            return new ResultModel<List<ProvinciaModel>>(null, "Error desconocido", false);
        }
        public static async Task<ResultModel<List<CiudadModel>>> GetCiudadesByProvinciaId(string id)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"{_baseUrl}/provincia/{id}/ciudades");

            if (response.IsSuccessStatusCode)
            {
                if (response.GetResult<ResultModel<List<CiudadModel>>>(out var result))
                {
                    return result;
                }
                else if (response.GetResult<ResultModel>(out var model))
                {
                    return new ResultModel<List<CiudadModel>>(null, model.Message, model.Success);
                }
            }

            if (response.GetResult<HttpError>(out var error))
            {
                return new ResultModel<List<CiudadModel>>(null, error.ExceptionMessage, false);
            }

            return new ResultModel<List<CiudadModel>>(null, "Error desconocido", false);
        }

        public static List<SelectListItem> ToSelectList(this List<PaisModel> model)
        {
            return model?.Select(x => new SelectListItem
            {
                Text = x.Nombre,
                Value = x.Nombre
            }).ToList() ?? new List<SelectListItem>();
        }

        public static List<SelectListItem> ToSelectList(this List<ProvinciaModel> model)
        {
            return model?.Select(x => new SelectListItem
            {
                Text = x.Nombre,
                Value = x.Nombre
            }).ToList() ?? new List<SelectListItem>();
        }

        public static List<SelectListItem> ToSelectList(this List<CiudadModel> model)
        {
            return model?.Select(x => new SelectListItem
            {
                Text = x.Nombre,
                Value = x.Nombre
            }).ToList() ?? new List<SelectListItem>();
        }
    }
}