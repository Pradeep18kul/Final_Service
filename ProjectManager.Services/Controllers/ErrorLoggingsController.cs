using ProjectManager.Business.ServiceRequests;
using ProjectManager.Infrastructure.Logging;
using System.Web.Http;

namespace ProjectManager.Services.Controllers
{
    [RoutePrefix("v1/loggings")]
    public class ErrorLoggingsController : ApiController
    {
        readonly ILogger _logger;
        public ErrorLoggingsController(ILogger logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Save([FromBody]LogRequest request)
        {
            if (string.Equals(request.LogType, "info"))
                _logger.Info(request.Message);
            else
                _logger.Error(request.Message);

            return Ok();
        }
    }
}
