using System;
using Serilog.Events;

namespace ArkProjects.Logging.Serilog.Options
{
    public class ElasticOptions
    {
        public bool Enable { get; set; } = true;
        public string? Project { get; set; }
        public string? EnvName { get; set; }
        public string DeadLetterIndexPrefix { get; set; } = "dlx-";
        public int Shards { get; set; } = 1;
        public int Replicas { get; set; } = 0;
        public Uri[]? Nodes { get; set; }
        public LogEventLevel? MinLevel { get; set; }
        public TimeSpan BufferLogShippingInterval { get; set; } = TimeSpan.FromSeconds(5);
    }
}