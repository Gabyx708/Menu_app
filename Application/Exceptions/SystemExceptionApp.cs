using Application.Response.GenericResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public  class SystemExceptionApp : Exception
    {
        public string _message;
        public SystemResponse _response;
        public SystemExceptionApp(string message,int code)
        {
            _message = message;
            _response = new SystemResponse
            {
                StatusCode = code,
                Message = message
            };
        }

    }
}
