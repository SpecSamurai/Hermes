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

            var endpointConfiguration = new EndpointConfiguration(busOptions.EndpointName);
            endpointConfiguration.LicensePath(busOptions.LicensePath);

            endpointConfiguration
                .UseTransport<RabbitMQTransport>()
                .UseConventionalRoutingTopology(QueueType.Quorum)
                .ConnectionString(busOptions.ConnectionString);

            var persistence = endpointConfiguration.UsePersistence<SqlPersistence>();
            persistence.SqlDialect<SqlDialect.MsSqlServer>();
            persistence.ConnectionBuilder(connectionBuilder: () =>
                new SqlConnection(context.Configuration.GetConnectionString(nameof(CatalogContext))));

            persistence.EnableTransactionalSession();

            endpointConfiguration.EnableOutbox();

            endpointConfiguration.EnableInstallers();
            endpointConfiguration.SendFailedMessagesTo("error");
            endpointConfiguration.AuditProcessedMessagesTo("audit");

            return endpointConfiguration;
        });
}