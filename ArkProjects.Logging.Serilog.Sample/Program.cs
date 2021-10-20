using System;
using ArkProjects.Logging.Serilog.ElasticSearch;
using ArkProjects.Logging.Serilog.Options;
using Serilog;
using Serilog.Events;

namespace ArkProjects.Logging.Serilog.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var cfg = new LoggerConfiguration();
            cfg.WriteTo.CustomElasticSearch(new ElasticOptions()
            {
                EnvName = "dev",
                Project = "sample",
                Nodes = new[] { new Uri("http://test.host:9200") }
            });
            cfg.WriteTo.Console();
            cfg.MinimumLevel.Is(LogEventLevel.Verbose);
            cfg.MinimumLevel.Override("Microsoft", LogEventLevel.Warning);
            cfg.ConfigureEnrichers(new());

            var logger = cfg.CreateLogger();
            logger.Information("Hello World!");
        }
    }
}