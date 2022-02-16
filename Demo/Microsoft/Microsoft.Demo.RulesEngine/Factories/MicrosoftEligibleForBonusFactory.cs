namespace Microsoft.Demo.Rules;

/// <summary>
/// Eligible for Bonus Factory
/// </summary>
internal class MicrosoftEligibleForBonusFactory : BaseFactory, IMicrosoftEligibleForBonusFactory
{
    private readonly IRulesConfig _config;
    private readonly IMicrosoftEligibleForPromotionFactory _factory;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="engine">Rules Engine</param>
    /// <param name="config">Rules Config</param>
    /// <param name="factory">Eligible for Promotion Factory</param>
    public MicrosoftEligibleForBonusFactory(IRulesEngine engine, IRulesConfig config, 
        IMicrosoftEligibleForPromotionFactory factory) : base(engine)
    {        
        ArgumentNullException.ThrowIfNull(config);
        ArgumentNullException.ThrowIfNull(factory);
        _config = config;
        _factory = factory;
        AddWorkflows(new IsEligibleForBonusWorkflow());
    }

    /// <summary>
    /// Evaluate
    /// </summary>
    /// <param name="model">User Model</param>
    /// <returns>True if Pass, False if Fail</returns>
    public async ValueTask<bool> EvaluateAsync(UserModel model) =>
        await _factory.EvaluateAsync(model) && 
            await ExecuteWorkflowAnySuccess(nameof(IsEligibleForBonusWorkflow), model, _config);
}
