namespace Microsoft.Demo.Rules;

/// <summary>
/// Eligible for Bonus Factory
/// </summary>
public interface IMicrosoftEligibleForBonusFactory
{
    /// <summary>
    /// Evaluate
    /// </summary>
    /// <param name="model">User Model</param>
    ///  <returns>True if Pass, False if Fail</returns>
    ValueTask<bool> EvaluateAsync(UserModel model);
}
