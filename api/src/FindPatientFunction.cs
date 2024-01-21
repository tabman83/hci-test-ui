using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Api;

public class FindPatientFunction
{
    private readonly IDataService _dataService;

    public FindPatientFunction(IDataService dataService)
    {
        _dataService = dataService;
    }

    [FunctionName("FindPatient")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "patients/find/{name}")] HttpRequest req,
        string name,
        ILogger log,
        CancellationToken cancellationToken = default)
    {
        log.LogInformation("FindPatient function processed a request.");
        
        var result = await _dataService.FindPatientAsync(name, cancellationToken);

        return result switch
        {
            { IsSuccess: true } => new OkObjectResult(result.Result),
            { IsSuccess: false, Error: InvalidOperationException } => new NotFoundResult(),
            _ => new ObjectResult(result.Error.Message) { StatusCode = 500 }
        };
    }
}