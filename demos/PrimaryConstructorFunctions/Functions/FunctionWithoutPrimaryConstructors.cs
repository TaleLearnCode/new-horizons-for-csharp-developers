using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace TaleLearnCode.NewHorizons.PrimaryConstructors;

public class FunctionWithoutPrimaryConstructors
{

	private readonly ILogger _logger;
	private readonly IService _service;

	public FunctionWithoutPrimaryConstructors(
		ILoggerFactory loggerFactory,
		IService service)
	{
		_logger = loggerFactory.CreateLogger<FunctionWithoutPrimaryConstructors>();
		_service = service;
	}

	[Function("Function1")]
	public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
	{
		_logger.LogInformation("C# HTTP trigger function processed a request.");
		var response = req.CreateResponse(HttpStatusCode.OK);
		response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
		response.WriteString(_service.GetDistance().ToString() ?? "Unable to determine distance");
		return response;
	}

}