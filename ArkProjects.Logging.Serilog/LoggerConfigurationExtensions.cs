using ArkProjects.Logging.Serilog.Options;
using Serilog;
using Serilog.Exceptions;

namespace ArkProjects.Logging.Serilog
{
    public static class LoggerConfigurationExtensions
    {
        public static LoggerConfiguration ConfigureEnrichers(this LoggerConfiguration configuration, EnrichersOptions? options = null)
        {
            if (options?.DisableThreadId != true) configuration = configuration.Enrich.WithThreadId();
            if (options?.DisableThreadName != true) configuration = configuration.Enrich.WithThreadName();
            if (options?.DisableProcessId != true) configuration = configuration.Enrich.WithProcessId();
            if (options?.DisableProcessName != true) configuration = configuration.Enrich.WithProcessName();
            if (options?.DisableLogContext != true) configuration = configuration.Enrich.FromLogContext();
            if (options?.DisableMachineName != true) configuration = configuration.Enrich.WithMachineName();
            if (options?.DisableEnvironmentUserName != true) configuration = configuration.Enrich.WithEnvironmentUserName();
            if (options?.DisableExceptionDetails != true) configuration = configuration.Enrich.WithExceptionDetails();
            if (options?.DisableMemoryUsage != true) configuration = configuration.Enrich.WithMemoryUsage();
            if (options?.DisableAssemblyName != true) configuration = configuration.Enrich.WithAssemblyName();
            if (options?.DisableAssemblyVersion != true) configuration = configuration.Enrich.WithAssemblyVersion();
            if (options?.DisableAssemblyInformationalVersion != true) configuration = configuration.Enrich.WithAssemblyInformationalVersion();
            return configuration;
        }
    }
}