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
            Thread.Sleep(item.Duration); // Do something that takes a long time...
            log.LogInformation($"C# Queue trigger function processed: {item.Message} with a duration of {item.Duration} ms.");
        }
    }
}
