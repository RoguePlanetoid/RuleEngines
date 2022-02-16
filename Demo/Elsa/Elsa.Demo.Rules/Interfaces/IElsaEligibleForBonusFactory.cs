namespace Elsa.Demo.Rules;

/// <summary>
/// Eligible for Bonus Factory
/// </summary>
public interface IElsaEligibleForBonusFactory
{
    /// <summary>
    /// Evaluate
    /// </summary>
    /// <param name="model">User Model</param>
    ///  <returns>True if Pass, False if Fail</returns>
    ValueTask<bool> EvaluateAsync(UserModel model);
}
