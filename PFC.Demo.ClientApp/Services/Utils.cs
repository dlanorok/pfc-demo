using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Web.Mvc;

namespace PFC.Demo.ClientApp.Services
{
    public static class Utils
    {
        public static string ServiceUrl => ConfigurationManager.AppSettings["ApiUrl"];
        public static bool GetResult<T>(this HttpResponseMessage response, out T value)
        {
            try
            {
                if (response == null)
                {
                    value = default;
                    return false;
                }
                var json = response.Content.ReadAsStringAsync()?.Result;

                value = JsonConvert.DeserializeObject<T>(json);

                return true;
            }
            catch(Exception ex)
            {
                value = default;
                return false;
            }
        }

        public static T ConvertTo<T>(this object value)
        {
            var json = JsonConvert.SerializeObject(value);

            return JsonConvert.DeserializeObject<T>(json);
        }

        public static IEnumerable<SelectListItem> GetTiposDropdownItems()
        {
            var values = Enum.GetValues(typeof(TipoCuentaEnum));
            foreach (var item in values)
            {
                yield return new SelectListItem
                {
                    Value = $"{item}",
                    Text = Enum.GetName(typeof(TipoCuentaEnum), item)
                };
            }
        }
    }
}