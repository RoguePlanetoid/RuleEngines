namespace Rules.Demo.Library;

/// <summary>
/// Eligiblity
/// </summary>
internal class Eligiblity : IEligibility
{
    private readonly IEligibleForBonusFactory _eligibleForBonusFactory;
    private readonly IEligibleForPromotionFactory _eligibleForPromotionFactory;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="eligibleForBonusFactory">Eligible for Bonus Factory</param>
    /// <param name="eligibleForPromotionFactory">Eligible for Promotion Factory</param>
    public Eligiblity(IEligibleForBonusFactory eligibleForBonusFactory, IEligibleForPromotionFactory eligibleForPromotionFactory) =>
        (_eligibleForBonusFactory, _eligibleForPromotionFactory) = (eligibleForBonusFactory, eligibleForPromotionFactory);

    /// <summary>
    /// Is Eligible for Bonus
    /// </summary>
    /// <param name="ruleEngineType">Rule Engine Type</param>
    /// <param name="model">User Model</param>
    /// <returns>True if Is, False if Not</returns>
    public ValueTask<bool> IsEligibleForBonusAsync(RuleEngineType ruleEngineType, UserModel model) =>
        _eligibleForBonusFactory.EvaluateAsync(ruleEngineType, model);

    /// <summary>
    /// Is Eligible for Promotion
    /// </summary>
    /// <param name="ruleEngineType">Rule Engine Type</param>
    /// <param name="model">User Model</param>
    /// <returns>True if Is, False if Not</returns>
    public ValueTask<bool> IsEligibleForPromotionAsync(RuleEngineType ruleEngineType, UserModel model) =>
        _eligibleForPromotionFactory.EvaluateAsync(ruleEngineType, model);
}