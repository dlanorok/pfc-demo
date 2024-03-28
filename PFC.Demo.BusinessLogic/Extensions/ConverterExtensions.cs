using Newtonsoft.Json;
using PFC.Demo.DataAccess.Entities;
using PFC.Demo.Domain.Models;

namespace PFC.Demo.BusinessLogic.Extensions
{
    public static class ConverterExtensions
    {
        public static T ConvertTo<T>(this object model)
        {
            var json = JsonConvert.SerializeObject(model);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}