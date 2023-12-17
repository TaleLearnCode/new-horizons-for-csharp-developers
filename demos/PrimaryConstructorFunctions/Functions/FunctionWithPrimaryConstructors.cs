using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace TaleLearnCode.NewHorizons.PrimaryConstructors.Functions;

public class FunctionWithPrimaryConstructors(ILogger logger, IService service)
{

	[Function("FunctionWithPrimaryConstructors")]
	public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
	{
		logger.LogInformation("C# HTTP trigger function processed a request.");
		var response = req.CreateResponse(HttpStatusCode.OK);
		response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
		response.WriteString(service.GetDistance().ToString() ?? "Unable to determine distance");
		return response;
	}

}