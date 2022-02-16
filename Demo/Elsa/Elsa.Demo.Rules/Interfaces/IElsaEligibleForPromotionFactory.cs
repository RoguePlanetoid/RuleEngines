namespace Elsa.Demo.Rules;

/// <summary>
/// Eligible for Promotions Factory
/// </summary>
public interface IElsaEligibleForPromotionFactory
{
    /// <summary>
    /// Evaluate
    /// </summary>
    /// <param name="model">User Model</param>
    ///  <returns>True if Pass, False if Fail</returns>
    ValueTask<bool> EvaluateAsync(UserModel model);
}