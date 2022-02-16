namespace Rules.Demo.Library;

/// <summary>
/// Eligible for Bonus Factory
/// </summary>
public interface IEligibleForBonusFactory
{
    /// <summary>
    /// Evaluate
    /// </summary>
    /// <param name="rulesEngine">Rules Engine</param>
    /// <param name="model">User Model</param>
    /// <returns>True if Is, False if Not</returns>

    ValueTask<bool> EvaluateAsync(RuleEngineType rulesEngine, UserModel model);
}