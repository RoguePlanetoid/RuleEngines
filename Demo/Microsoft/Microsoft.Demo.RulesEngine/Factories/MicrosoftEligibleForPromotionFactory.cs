namespace Microsoft.Demo.Rules;

/// <summary>
/// Eligible for Promotion Factory
/// </summary>
internal class MicrosoftEligibleForPromotionFactory : BaseFactory, IMicrosoftEligibleForPromotionFactory
{
    private readonly IRulesConfig _config;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="engine">Rules Engine</param>
    /// <param name="config">Rules Config</param>
    public MicrosoftEligibleForPromotionFactory(IRulesEngine engine, IRulesConfig config) : base(engine)
    {
        ArgumentNullException.ThrowIfNull(config);
        _config = config;
        AddWorkflows(new IsEligibleForPromotionWorkflow());
    }

    /// <summary>
    /// Evaluate
    /// </summary>
    /// <param name="model">User Model</param>
    /// <returns>True if Pass, False if Fail</returns>
    public ValueTask<bool> EvaluateAsync(UserModel model) =>
        ExecuteWorkflowAllSuccess(nameof(IsEligibleForPromotionWorkflow), model, _config);
}