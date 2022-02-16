namespace Rules.Demo.Library;

/// <summary>
/// Eligible for Bonus Factory
/// </summary>
internal class EligibleForBonusFactory : IEligibleForBonusFactory
{
    private readonly IElsaEligibleForBonusFactory _elsaEligibleForBonusFactory;
    private readonly IMicrosoftEligibleForBonusFactory _microsoftEligibleForBonusFactory;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="elsaEligibleForBonusFactory">Elsa Eligible for Bonus Factory</param>
    /// <param name="microsoftEligibleForBonusFactory">Microsoft Eligible for Bonus Factory</param>
    public EligibleForBonusFactory(
        IElsaEligibleForBonusFactory elsaEligibleForBonusFactory,
        IMicrosoftEligibleForBonusFactory microsoftEligibleForBonusFactory) =>
        (_elsaEligibleForBonusFactory, _microsoftEligibleForBonusFactory) =
        (elsaEligibleForBonusFactory, microsoftEligibleForBonusFactory);

    /// <summary>
    /// Evaluate
    /// </summary>
    /// <param name="ruleEngineType">Rule Engine Type</param>
    /// <param name="model">User Model</param>
    /// <returns>True if Is, False if Not</returns>
    public async ValueTask<bool> EvaluateAsync(RuleEngineType ruleEngineType, UserModel model) =>
        ruleEngineType switch
        {
            RuleEngineType.ElsaRulesEngine => await _elsaEligibleForBonusFactory.EvaluateAsync(model),
            _ => await _microsoftEligibleForBonusFactory.EvaluateAsync(model)
        };
}