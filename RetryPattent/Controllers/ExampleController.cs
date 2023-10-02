using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Polly;


namespace RetryPattent.Controllers;

[ApiController]
[Route("[controller]")]
public class ExampleController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<ExampleController> _logger;
   
    public ExampleController(ILogger<ExampleController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetData")]
    public async Task<IActionResult> Get()
    {
        var retryPolicy = Policy
            .Handle<Exception>()
            .RetryAsync(4, onRetry: (exception, retryCount) =>
            {
                Console.WriteLine($"Error : {exception.Message} ... retryCount :{retryCount} ");
            });

        await retryPolicy.ExecuteAsync(async () =>
        {
            await ConnectToApi();
        });


        return Ok();
    }

    private async Task ConnectToApi()
    {
        try
        {
            var apiUrl = "https://localhost/api/example";
            var client = new HttpClient();
            var response = client.GetAsync(apiUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine($"Error {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Error {ex.Message}");
        }
    }
}

