using System;
using System.Text;
using Azure.Storage.Queues;
using Newtonsoft.Json;

namespace Scaling.QueueFillApp
{
    class Program
    {
        // docker run -p 8888:8888 -p 9999:9999 -v c:/azurite:/workspace mcr.microsoft.com/azure-storage/azurite azurite -l /workspace -d /workspace/debug.log --blobPort 8888 --blobHost 0.0.0.0 --queuePort 9999 --queueHost 0.0.0.0 --loose --skipApiVersionCheck
        // ipconfig -> use local ip here, localhost won't work!
        private const string ConnectionString = "DefaultEndpointsProtocol=http;AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;";

        private const string QueueName = "demo-scaling-items";

        static void Main(string[] args)
        {
            //Console.WriteLine($"How many messages do you want to submit to the queue {QueueName}?");

            //var input = Console.ReadLine();
            var input = args[0];
            var count = 0;
            if (int.TryParse(input, out var nrOfMessages)) 
            {
                while (count++ < nrOfMessages)
                {
                    var msg = $"Message {count}";
                    AddMessage(msg);
                    Console.WriteLine($"{msg} added to queue {QueueName}");
                }
            }
            
            // Console.ReadLine();
        }

        private static void AddMessage(string msg)
        {
            //var connectionString = Environment.GetEnvironmentVariable("STORAGE_CONNECTIONSTRING");

            var queue = new QueueClient(ConnectionString, QueueName);
            queue.Create();
            var item = new QueueItem { Message = msg };
            queue.SendMessage(GetMessageContent(item));
        }

        private static string GetMessageContent(QueueItem queueItem)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(queueItem)));
        }
    }
}
