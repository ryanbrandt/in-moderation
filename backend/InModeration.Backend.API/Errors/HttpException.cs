using System;
using System.Net;

namespace InModeration.Backend.API.Errors
{
    public class HttpException : Exception
    {
        public readonly HttpStatusCode Code;

        public HttpException(HttpStatusCode code, string message = null) : base(message)
        {
            Code = code;
        }
    }
}
