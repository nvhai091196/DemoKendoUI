using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace WebApiStudy.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BaseApiController : ApiController
    {
        public class ApiResponse<T>
        {
            public bool Success { get; set; }
            public string Message { get; set; }
            public T Data { get; set; }
        }
    }
}
