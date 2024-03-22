using PFC.Demo.Domain.Models;
using PFC.Demo.Domain.Models;
using PFC.Demo.Domain.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace PFC.Demo.ClientApp.Services
{
    public static class PersonaService
    {
        private static string _baseUrl = $"{Utils.ServiceUrl}/Persona";
        public static async Task<ResultModel<PersonaViewModel>> GetPersonaById(int id)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"{_baseUrl}/{id}");

            if (response.IsSuccessStatusCode)
            {
                if(response.GetResult<ResultModel<PersonaViewModel>>(out var result))
                {
                    return result;
                } else if(response.GetResult<ResultModel>(out var model))
                {
                    return new ResultModel<PersonaViewModel>(null, model.Message, model.Success);
                }
            }

            if (response.GetResult<HttpError>(out var error))
            {
                return new ResultModel<PersonaViewModel>(null, error.ExceptionMessage, false);
            }

            return new ResultModel<PersonaViewModel>(null, "Error desconocido", false);
        }

        public static async Task<ResultModel<List<CuentaBancariaEntity>>> GetCuentaBancariasByPersonaId(int id)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"{_baseUrl}/{id}/CuentasBancarias");

            if (response.IsSuccessStatusCode)
            {
                if (response.GetResult<ResultModel<List<CuentaBancariaEntity>>>(out var result))
                {
                    return result;
                }
                else if (response.GetResult<ResultModel>(out var model))
                {
                    return new ResultModel<List<CuentaBancariaEntity>>(null, model.Message, model.Success);
                }
            }

            if (response.GetResult<HttpError>(out var error))
            {
                return new ResultModel<List<CuentaBancariaEntity>>(null, error.ExceptionMessage, false);
            }

            return new ResultModel<List<CuentaBancariaEntity>>(null, "Error desconocido", false);
        }

        public static async Task<ResultModel<List<PersonaEntity>>> GetAllPersonas()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"{_baseUrl}");

            if (response.IsSuccessStatusCode)
            {
                if (response.GetResult<ResultModel<List<PersonaEntity>>>(out var result))
                {
                    return result;
                }
                else if (response.GetResult<ResultModel>(out var model))
                {
                    return new ResultModel<List<PersonaEntity>>(null, model.Message, model.Success);
                }
            }

            if (response.GetResult<HttpError>(out var error))
            {
                return new ResultModel<List<PersonaEntity>>(null, error.ExceptionMessage, false);
            }

            return new ResultModel<List<PersonaEntity>>(null, "Error desconocido", false);
        }

        public static async Task<ResultModel> CrearPersona(PersonaUpdateModel model)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.PostAsJsonAsync($"{_baseUrl}", model);

            if (response.IsSuccessStatusCode)
            {
                if (response.GetResult<ResultModel>(out var result))
                {
                    return new ResultModel(result.Message, result.Success);
                }
            }

            if (response.GetResult<HttpError>(out var error))
            {
                return new ResultModel(error.ExceptionMessage, false);
            }

            return new ResultModel("Error desconocido", false);
        }

        public static async Task<ResultModel> ActualizarPersona(int id, PersonaUpdateModel model)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.PutAsJsonAsync($"{_baseUrl}/{id}", model);

            if (response.IsSuccessStatusCode)
            {
                if (response.GetResult<ResultModel>(out var result))
                {
                    return new ResultModel(result.Message, result.Success);
                }
            }

            if (response.GetResult<HttpError>(out var error))
            {
                return new ResultModel(error.ExceptionMessage, false);
            }

            return new ResultModel("Error desconocido", false);
        }

        public static async Task<ResultModel> EliminarPersona(int id)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.DeleteAsync($"{_baseUrl}/{id}");

            if (response.IsSuccessStatusCode)
            {
                if (response.GetResult<ResultModel>(out var result))
                {
                    return new ResultModel(result.Message, result.Success);
                }
            }

            if (response.GetResult<HttpError>(out var error))
            {
                return new ResultModel(error.ExceptionMessage, false);
            }

            return new ResultModel("Error desconocido", false);
        }
    }
}