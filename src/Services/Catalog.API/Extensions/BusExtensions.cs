using System.Data.SqlClient;
using Hermes.Catalog.API.Options;
using NServiceBus;

namespace Hermes.Catalog.API.Extensions;

public static class BusExtensions
{
    public static IHostBuilder UseNServiceBus(this IHostBuilder hostBuilder)
    {
        hostBuilder.UseNServiceBus(context =>
        {
            var busOptions = context
                .Configuration
                .GetRequiredSection(nameof(BusOptions))
                .Get<BusOptions>();

            var endpointConfiguration = new EndpointConfiguration(typeof(Program).Assembly.GetName().Name);
            endpointConfiguration.LicensePath(busOptions.LicensePath);

            endpointConfiguration
                .UseTransport<RabbitMQTransport>()
                .UseConventionalRoutingTopology(QueueType.Quorum)
                .ConnectionString(busOptions.ConnectionString);

            var persistence = endpointConfiguration.UsePersistence<SqlPersistence>();
            persistence.SqlDialect<SqlDialect.MsSqlServer>();
            persistence.ConnectionBuilder(connectionBuilder: () =>
                new SqlConnection(context.Configuration.GetConnectionString(nameof(CatalogContext))));

            endpointConfiguration.EnableOutbox();
            endpointConfiguration.EnableInstallers();
            endpointConfiguration.AuditProcessedMessagesTo("audit");

            endpointConfiguration
                .Conventions()
                .DefiningEventsAs(eventType =>
                    eventType.Namespace != null && eventType.Name.EndsWith("IntegrationEvent"));

            return endpointConfiguration;
        });

        return hostBuilder;
    }
}