namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extensions
/// </summary>
public static class Extensions
{
    /// <summary>
    /// Add Microsoft Rules Engine
    /// </summary>
    /// <param name="services">Service Collection</param>
    /// <returns>Service Collection</returns>
    public static IServiceCollection AddMicrosoftRulesEngine(this IServiceCollection services) =>
        services.AddSingleton<IRulesEngine>(new RulesEngine.RulesEngine(reSettings: new ReSettings 
        { 
            CustomTypes = new Type[] { typeof(Helper) } 
        }))
        .AddScoped<IMicrosoftEligibleForPromotionFactory, MicrosoftEligibleForPromotionFactory>()
        .AddScoped<IMicrosoftEligibleForBonusFactory, MicrosoftEligibleForBonusFactory>();
}