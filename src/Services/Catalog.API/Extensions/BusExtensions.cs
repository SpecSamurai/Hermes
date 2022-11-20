using System.Data.SqlClient;
using Hermes.Catalog.API.Options;
using Microsoft.EntityFrameworkCore;
using NServiceBus.TransactionalSession;
using Hermes.Catalog.API.Constants;

namespace Hermes.Catalog.API.Extensions;

public static class BusExtensions
{
    public static IHostBuilder UseNServiceBus(this IHostBuilder hostBuilder) =>
        hostBuilder.UseNServiceBus(context =>
        {
            var busOptions = context
                .Configuration
                .GetRequiredSection(nameof(BusOptions))
                .Get<BusOptions>() ?? throw new NullReferenceException(ErrorCodes.Bus.InvalidBusOptions);

            var endpointConfiguration = new EndpointConfiguration(typeof(Program).Assembly.GetName().Name);
            endpointConfiguration.LicensePath(busOptions.LicensePath);

            endpointConfiguration
                .UseTransport<RabbitMQTransport>()
                .UseConventionalRoutingTopology(QueueType.Quorum)
                .ConnectionString(busOptions.ConnectionString);

            // endpointConfiguration.Recoverability().Delayed(delayedRetriesSettings =>
            // {
            //     delayedRetriesSettings.NumberOfRetries(6);
            //     delayedRetriesSettings.TimeIncrease(TimeSpan.FromSeconds(1));
            // });

            var persistence = endpointConfiguration.UsePersistence<SqlPersistence>();
            persistence.SqlDialect<SqlDialect.MsSqlServer>();
            persistence.ConnectionBuilder(connectionBuilder: () =>
                new SqlConnection(context.Configuration.GetConnectionString(nameof(CatalogContext))));

            persistence.EnableTransactionalSession();

            endpointConfiguration.EnableOutbox();

            endpointConfiguration.EnableInstallers();
            endpointConfiguration.AuditProcessedMessagesTo("audit");

            // endpointConfiguration
            //     .Conventions()
            //     .DefiningEventsAs(eventType =>
            //         eventType.Namespace != null && eventType.Name.EndsWith("IntegrationEvent"));

            return endpointConfiguration;
        });
}