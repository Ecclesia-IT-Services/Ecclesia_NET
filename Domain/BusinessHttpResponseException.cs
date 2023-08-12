using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Ecclesia.Domain
{
    public class BusinessHttpResponseException : HttpResponseException
    {
        public BusinessHttpResponseException(HttpStatusCode statusCode) : base(statusCode)
        {
        }

        public BusinessHttpResponseException(HttpResponseMessage response) : base(response)
        {
        }
    }
}
