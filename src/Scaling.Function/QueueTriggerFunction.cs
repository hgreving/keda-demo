using System.Threading;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Scaling.QueueFillApp;

namespace Scaling.QueueTriggers.Function
{
    public static class QueueTriggerFunction
    {
        [FunctionName("QueueTriggerFunction")]
        public static void Run([QueueTrigger("demo-scaling-items", Connection = "AzureWebJobsStorage")]string myQueueItem, ILogger log)
        {
            var item = JsonConvert.DeserializeObject<QueueItem>(myQueueItem);
            Thread.Sleep(5000); // Do somehing that takes a long time...
            log.LogInformation($"C# Queue trigger function processed: {item.Message}");
            //The input is not a valid Base-64 string as it contains a non-base 64 character, more than two padding characters, or an illegal character among the padding characters.
        }
    }
}
