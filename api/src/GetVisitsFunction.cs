using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Web.Http;

namespace Api;

public class GetVisitsFunction
{
    private readonly IDataService _dataService;

    public GetVisitsFunction(IDataService dataService)
    {
        _dataService = dataService;
    }

    [FunctionName("GetVisits")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "patients/{patientId}/visits")]
        HttpRequest req,
        Guid patientId,
        ILogger log,
        CancellationToken cancellationToken)
    {
        log.LogInformation("GetVisits function processed a request.");

        var result = await _dataService.GetVisitsAsync(patientId, cancellationToken);

        return result switch
        {
            { IsSuccess: true } => new OkObjectResult(result.Result),
            _ => new InternalServerErrorResult()
        };
    }
}