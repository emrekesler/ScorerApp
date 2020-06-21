using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Response
{
    public class Response<T> 
    {
        public Response(T data = default(T), bool isSuccess = false, string message = "")
        {
            IsSuccess = isSuccess;
            Message = isSuccess ? "" : message != "" ? message : "Bir Hata Oluştu";
            Data = data;
        }

        public T Data { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}
