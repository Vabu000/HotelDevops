using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace HotelPlatform.Aggregator.HealthChecks;

public class CatalogServiceHealthCheck : IHealthCheck
{
    private readonly GrpcHealthCheck _healthCheck;

    public CatalogServiceHealthCheck(IConfiguration configuration, ILogger<GrpcHealthCheck> logger)
    {
        var serviceUrl = configuration["GrpcServices:CatalogService"]
            ?? configuration["services__catalog-service__https__0"]
            ?? configuration["services:catalog-service:https:0"]
            ?? configuration["services__catalog-service__http__0"]
            ?? configuration["services:catalog-service:http:0"]
            ?? "https://localhost:7045";

        _healthCheck = new GrpcHealthCheck("Catalog Service", serviceUrl, logger);
    }

    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        => _healthCheck.CheckHealthAsync(context, cancellationToken);
}

public class ReservationServiceHealthCheck : IHealthCheck
{
    private readonly GrpcHealthCheck _healthCheck;

    public ReservationServiceHealthCheck(IConfiguration configuration, ILogger<GrpcHealthCheck> logger)
    {
        var serviceUrl = configuration["GrpcServices:ReservationService"]
            ?? configuration["services__reservation-service__https__0"]
            ?? configuration["services:reservation-service:https:0"]
            ?? configuration["services__reservation-service__http__0"]
            ?? configuration["services:reservation-service:http:0"]
            ?? "https://localhost:7151";

        _healthCheck = new GrpcHealthCheck("Reservation Service", serviceUrl, logger);
    }

    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        => _healthCheck.CheckHealthAsync(context, cancellationToken);
}

public class ReviewsServiceHealthCheck : IHealthCheck
{
    private readonly GrpcHealthCheck _healthCheck;

    public ReviewsServiceHealthCheck(IConfiguration configuration, ILogger<GrpcHealthCheck> logger)
    {
        var serviceUrl = configuration["GrpcServices:ReviewsService"]
            ?? configuration["services__reviews-service__https__0"]
            ?? configuration["services:reviews-service:https:0"]
            ?? configuration["services__reviews-service__http__0"]
            ?? configuration["services:reviews-service:http:0"]
            ?? "https://localhost:7050";

        _healthCheck = new GrpcHealthCheck("Reviews Service", serviceUrl, logger);
    }

    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        => _healthCheck.CheckHealthAsync(context, cancellationToken);
}
