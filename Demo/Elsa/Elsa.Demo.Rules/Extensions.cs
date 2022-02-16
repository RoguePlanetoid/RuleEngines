using Elsa.Demo.Rules;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extensions
/// </summary>
public static class Extensions
{
    /// <summary>
    /// Add Elsa Rules Engine
    /// </summary>
    /// <param name="services">Service Collection</param>
    /// <returns>Service Collection</returns>
    public static IServiceCollection AddElsaRulesEngine(this IServiceCollection services) =>
        services.AddElsa(options =>
            options.AddActivitiesFrom<MinimumAgeActivity>()
        )
        .AddScoped<IElsaEligibleForPromotionFactory, ElsaEligibleForPromotionFactory>()
        .AddScoped<IElsaEligibleForBonusFactory, ElsaEligibleForBonusFactory>();
}