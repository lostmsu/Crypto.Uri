namespace Crypto.Uri {
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    public static class ProtocolRouter {
        [FunctionName(nameof(ProtocolRouter))]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log) {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string coin = req.Query["coin"];
            if (string.IsNullOrEmpty(coin))
                return new BadRequestObjectResult("Coin must be specified");
            if (coin != "eth")
                return new BadRequestObjectResult("Coin not supported");

            string payload = req.Query["payload"];

            return new RedirectResult("crypto:eth");
        }
    }
}
