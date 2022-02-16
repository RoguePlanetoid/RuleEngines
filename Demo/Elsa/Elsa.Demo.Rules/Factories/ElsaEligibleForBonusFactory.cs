namespace Elsa.Demo.Rules;

/// <summary>
/// Eligible for Bonus Factory
/// </summary>
internal class ElsaEligibleForBonusFactory : BaseFactory, IElsaEligibleForBonusFactory
{
    private readonly IElsaEligibleForPromotionFactory _factory;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="runner">Workflow Runner</param>
    /// <param name="factory">Eligible for Promotion Factory</param>
    public ElsaEligibleForBonusFactory(IBuildsAndStartsWorkflow runner, IElsaEligibleForPromotionFactory factory) : base(runner) => 
        _factory = factory ?? throw new ArgumentNullException(nameof(factory));

    /// <summary>
    /// Evaluate
    /// </summary>
    /// <param name="isEligibleForPromotionFactory"></param>
    /// <param name="model">User Model</param>
    ///  <returns>True if Pass, False if Fail</returns>
    public async ValueTask<bool> EvaluateAsync(UserModel model) =>
        await _factory.EvaluateAsync(model) &&
            await EvaluateAsync<IsEligibleForBonusWorkflow, UserModel>(model);
}
