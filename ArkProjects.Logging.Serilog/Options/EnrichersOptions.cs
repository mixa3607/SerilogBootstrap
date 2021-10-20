namespace ArkProjects.Logging.Serilog.Options
{
    public class EnrichersOptions
    {
        public bool DisableThreadId { get; set; }
        public bool DisableLogContext { get; set; }
        public bool DisableMachineName { get; set; }
        public bool DisableEnvironmentUserName { get; set; }
        public bool DisableProcessName { get; set; }
        public bool DisableThreadName { get; set; }
        public bool DisableProcessId { get; set; }
        public bool DisableExceptionDetails { get; set; }
        public bool DisableMemoryUsage { get; set; }
        public bool DisableAssemblyName { get; set; }
        public bool DisableAssemblyVersion { get; set; }
        public bool DisableAssemblyInformationalVersion { get; set; }
    }
}