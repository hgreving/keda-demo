using System;
using System.Text;
using Azure.Storage.Queues;
using Newtonsoft.Json;

namespace Scaling.QueueFillApp
{
    class Program
    {
        private const string ConnectionString = "DefaultEndpointsProtocol=http;AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;";

        private const string QueueName = "demo-scaling-items";

        static void Main(string[] args)
        {
            if (args.Length < 1) 
            {
                Console.WriteLine($"Please specify the number of message and optional a duration in seconds.");
                return;
            }
            
            int? duration = null;
            if (args.Length == 2)
            {
                if (int.TryParse(args[1], out var parsedDuration))
                {
                    duration = parsedDuration * 1000;
                }
            }

            var count = 0;
            if (int.TryParse(args[0], out var nrOfMessages)) 
            {
                while (count++ < nrOfMessages)
                {
                    var msg = $"Message {count}";
                    AddMessage(msg, duration);
                    Console.WriteLine($"{msg} added to queue {QueueName}");
                }
            }
        }

        private static void AddMessage(string msg, int? duration)
        {
            var queue = new QueueClient(ConnectionString, QueueName);
            queue.Create();
            var item = new QueueItem { Message = msg, Duration = duration ?? 5000 };
            queue.SendMessage(GetMessageContent(item));
        }

        private static string GetMessageContent(QueueItem queueItem)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(queueItem)));
        }
    }
}
