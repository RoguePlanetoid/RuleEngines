namespace Microsoft.Demo.Rules;

/// <summary>
/// Eligible for Promotios Factory
/// </summary>
public interface IMicrosoftEligibleForPromotionFactory
{
    /// <summary>
    /// Evaluate
    /// </summary>
    /// <param name="model">User Model</param>
    ///  <returns>True if Pass, False if Fail</returns>
    ValueTask<bool> EvaluateAsync(UserModel model);
}