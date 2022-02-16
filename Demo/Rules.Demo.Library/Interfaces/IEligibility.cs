namespace Rules.Demo.Library;

/// <summary>
/// Eligiblity
/// </summary>
public interface IEligibility
{
    /// <summary>
    /// Is Eligible for Bonus
    /// </summary>
    /// <param name="ruleEngineType">Rule Engine Type</param>
    /// <param name="model">User Model</param>
    /// <returns>True if Is, False if Not</returns>
    ValueTask<bool> IsEligibleForBonusAsync(RuleEngineType ruleEngineType, UserModel model);

    /// <summary>
    /// Is Eligible for Promotion
    /// </summary>
    /// <param name="ruleEngineType">Rules Engine Type</param>
    /// <param name="model">User Model</param>
    /// <returns>True if Is, False if Not</returns>
    ValueTask<bool> IsEligibleForPromotionAsync(RuleEngineType ruleEngineType, UserModel model);
}
