using System;

namespace Scaling.Function
{
    [Serializable]
    public class QueueItem
    {
        public string Message { get; set; }

        public int Duration { get; set; } = 5000;
    }
}
