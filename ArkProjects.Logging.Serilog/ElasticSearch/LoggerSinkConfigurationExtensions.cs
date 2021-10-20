using System;
using ArkProjects.Logging.Serilog.Options;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Configuration;
using Serilog.Formatting;
using Serilog.Sinks.Elasticsearch;

namespace ArkProjects.Logging.Serilog.ElasticSearch
{
    public static class LoggerSinkConfigurationExtensions
    {
        public static LoggerConfiguration CustomElasticSearch(this LoggerSinkConfiguration configuration, IConfigurationSection options, ITextFormatter? customFormatter = null)
            => configuration.CustomElasticSearch(options.Get<ElasticOptions>(), customFormatter);

        public static LoggerConfiguration CustomElasticSearch(this LoggerSinkConfiguration configuration, ElasticOptions options, ITextFormatter? customFormatter = null)
        {
            var assemblyVersion = typeof(LoggerSinkConfigurationExtensions).Assembly.GetName().Version ?? new Version(0, 0, 0);
            var indexFormat = $"serilogs-sink-{assemblyVersion}-{options.EnvName}-{options.Project}-{{0:yyyy.MM.dd}}";
            var esOptions = new ElasticsearchSinkOptions(options.Nodes)
            {
                AutoRegisterTemplate = true,
                AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv7,
                CustomFormatter = customFormatter,
                EmitEventFailure = EmitEventFailureHandling.WriteToSelfLog |
                                   EmitEventFailureHandling.WriteToFailureSink |
                                   EmitEventFailureHandling.RaiseCallback,
                RegisterTemplateFailure = RegisterTemplateRecovery.IndexToDeadletterIndex,
                NumberOfShards = options.Shards,
                NumberOfReplicas = options.Replicas,
                IndexFormat = indexFormat,
                DeadLetterIndexName = options.DeadLetterIndexPrefix + indexFormat,
                BufferLogShippingInterval = options.BufferLogShippingInterval
            };

            var c = configuration.Elasticsearch(esOptions);
            if (options.MinLevel != null)
                c.MinimumLevel.Is(options.MinLevel.Value);
            return c;
        }
    }
}