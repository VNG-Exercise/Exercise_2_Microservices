﻿using ProductService.Helpers;

namespace ProductService.Models.Dtos
{
    public class BaseResponse<T>
    {
        public BaseResponse(T? data, string code, string message)
        {
            Data = data;
            Code = code;
            Message = message;
        }

        public BaseResponse(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public BaseResponse(T? data)
        {
            Data = data;
        }

        public T? Data { get; set; }

        public string Code { get; set; } = StatusCodeResponse.Success;

        public string? Message { get; set; } = null;
    }
}
