namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extensions
/// </summary>
public static class Extensions
{
    /// <summary>
    /// Add Demo
    /// <param name="services">Service Collection</param>
    /// <param name="currentDateTime">Current Date Time</param>
    /// <param name="dateOfBirthMinimumAge">Date Of Birth Minimum Age</param>
    /// <param name="registeredDateMinimumDays">Registered Date Minimum Days</param>
    /// <returns>Service Collection</returns>
    public static IServiceCollection AddDemo(this IServiceCollection services,
        Func<DateTime> currentDateTime, int dateOfBirthMinimumAge, int registeredDateMinimumDays) =>
        services
        .AddElsaRulesEngine()
        .AddMicrosoftRulesEngine()
        .AddSingleton<IRulesConfig>(new RulesConfig(currentDateTime, dateOfBirthMinimumAge, registeredDateMinimumDays))
        .AddScoped<IEligibleForPromotionFactory, EligibleForPromotionFactory>()
        .AddScoped<IEligibleForBonusFactory, EligibleForBonusFactory>()
        .AddScoped<IUsers, Users>()
        .AddScoped<IEligibility, Eligiblity>();        
}