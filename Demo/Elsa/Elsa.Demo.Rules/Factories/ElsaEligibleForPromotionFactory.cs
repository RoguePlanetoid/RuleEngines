namespace Elsa.Demo.Rules;

/// <summary>
/// Eligible for Promotion Factory
/// </summary>
internal class ElsaEligibleForPromotionFactory : BaseFactory, IElsaEligibleForPromotionFactory
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="runner">Workflow Runner</param>
    public ElsaEligibleForPromotionFactory(IBuildsAndStartsWorkflow runner) : 
        base(runner) { }

    /// <summary>
    /// Evaluate
    /// </summary>
    /// <param name="model">User Model</param>
    /// <returns>True if Pass, False if Fail</returns>
    public ValueTask<bool> EvaluateAsync(UserModel model) =>
        EvaluateAsync<IsEligibleForPromotionWorkflow, UserModel>(model);
}