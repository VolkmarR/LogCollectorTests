using Serilog;
using Serilog.Events;
using Serilog.Sinks.Grafana.Loki;

namespace LogCollectorTests
{
    public class SerilogConfiguration
    {

        public static void Execute(ConfigurationManager? configurationManager = null)
        {
            var loggerConfig = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .Enrich.WithEnvironmentName()
                .WriteTo.Console();

            if (configurationManager == null)
            {
                Log.Logger = loggerConfig.CreateLogger();
                return;
            }

            var grafanaLokiUrl = configurationManager["LoggingSinks:grafanaLoki:url"];
            if (!string.IsNullOrEmpty(grafanaLokiUrl))
                loggerConfig.WriteTo.GrafanaLoki(grafanaLokiUrl);

            Log.Logger = loggerConfig.CreateLogger();

        }
    }
}