using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PFC.Demo.Domain.Models
{
    public class ResultModel
    {
        public ResultModel(string message = "OK", bool success = true)
        {
            this.Message = message;
            this.Success = success;
        }
        public string Message { get; set; } = "OK";
        public bool Success { get; set; } = true;
    }


    public class ResultModel<T> : ResultModel
            where T : class
    {
        public ResultModel(T result = default, string message = "OK", bool success = true)
            :base(message, success)
        {
            this.Result = result;
        }
        public T Result { get; set; }
    }

}
