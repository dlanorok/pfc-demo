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
    public static class CuentaBancariaService
    {
        private static string _baseUrl = $"{Utils.ServiceUrl}/CuentaBancaria";
        public static async Task<ResultModel<CuentaBancariaEntity>> GetCuentaBancariaById(int id)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"{_baseUrl}/{id}");

            if (response.IsSuccessStatusCode)
            {
                if(response.GetResult<ResultModel<CuentaBancariaEntity>>(out var result))
                {
                    return result;
                } else if(response.GetResult<ResultModel>(out var model))
                {
                    return new ResultModel<CuentaBancariaEntity>(null, model.Message, model.Success);
                }
            }

            if (response.GetResult<HttpError>(out var error))
            {
                return new ResultModel<CuentaBancariaEntity>(null, error.Message, false);
            }

            return new ResultModel<CuentaBancariaEntity>(null, "Error desconocido", false);
        }

        public static async Task<ResultModel> CrearCuentaBancaria(CuentaBancariaUpdateModel model)
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

        public static async Task<ResultModel> ActualizarCuentaBancaria(int id, CuentaBancariaUpdateModel model)
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

        public static async Task<ResultModel> EliminarCuentaBancaria(int id)
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