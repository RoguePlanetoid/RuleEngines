namespace Rules.Demo.Library;

/// <summary>
/// Rules Engine Type
/// </summary>
public enum RuleEngineType
{
    [Description("Elsa Rules Engine")]
    ElsaRulesEngine = 1,
    [Description("Microsoft Rules Engine")]
    MicrosoftRulesEngine = 2
}

/// <summary>
/// Rule Engine Type Extensions
/// </summary>
public static class RuleEngineTypeExtensions
{
    /// <summary>
    /// Get Description
    /// </summary>
    /// <param name="ruleEngineType">Rule Engine Type</param>
    /// <returns>Description</returns>
    public static string GetDescription(this RuleEngineType ruleEngineType) =>
        (ruleEngineType.GetType().GetMember(ruleEngineType.ToString())
            .FirstOrDefault()?.GetCustomAttributes(typeof(DescriptionAttribute), false)
                .FirstOrDefault() as DescriptionAttribute)
                    ?.Description ?? string.Empty;
}