namespace Rules.Demo.Library;

/// <summary>
/// Eligible for Promotion Factory
/// </summary>
internal class EligibleForPromotionFactory : IEligibleForPromotionFactory
{
    private readonly IElsaEligibleForPromotionFactory _elsaEligibleForPromotionFactory;
    private readonly IMicrosoftEligibleForPromotionFactory _microsoftEligibleForPromotionFactory;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="elsaEligibleForPromotionFactory">Elsa Eligible for Promotion Factory</param>
    /// <param name="microsoftEligibleForPromotionFactory">Microsoft Eligible for Promotion Factory</param>
    /// <param name="customEligibleForPromotionFactory">Custom Eligible for Promotion Factory</param>
    public EligibleForPromotionFactory(
        IElsaEligibleForPromotionFactory elsaEligibleForPromotionFactory,
        IMicrosoftEligibleForPromotionFactory microsoftEligibleForPromotionFactory) =>
        (_elsaEligibleForPromotionFactory, _microsoftEligibleForPromotionFactory) = 
        (elsaEligibleForPromotionFactory, microsoftEligibleForPromotionFactory);

    /// <summary>
    /// Evaluate
    /// </summary>
    /// <param name="ruleEngineType">Rule Engine Type</param>
    /// <param name="model">User Model</param>
    /// <returns>True if Is, False if Not</returns>
    public async ValueTask<bool> EvaluateAsync(RuleEngineType ruleEngineType, UserModel model) => 
        ruleEngineType switch
        {
            RuleEngineType.ElsaRulesEngine => await _elsaEligibleForPromotionFactory.EvaluateAsync(model),
            _ => await _microsoftEligibleForPromotionFactory.EvaluateAsync(model),
        };
}