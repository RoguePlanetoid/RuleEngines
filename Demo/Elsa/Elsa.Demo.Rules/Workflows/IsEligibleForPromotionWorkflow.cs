namespace Elsa.Demo.Rules;

/// <summary>
/// Is Eligible for Promotion Workflow
/// </summary>
internal class IsEligibleForPromotionWorkflow : IWorkflow
{
    private readonly IRulesConfig _config;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="config">Rules Config</param>
    public IsEligibleForPromotionWorkflow(IRulesConfig config) =>
        _config = config ?? throw new ArgumentNullException(nameof(config));

    /// <summary>
    /// Build
    /// </summary>
    /// <param name="builder">Workflow Builder</param>
    public void Build(IWorkflowBuilder builder) => 
        builder.WithName(nameof(IsEligibleForPromotionWorkflow))
            .Then<MinimumDaysActivity>(
                activity => activity
                .Set(s => s.Input, s => s.Input)
                .Set(s => s.MinimumDays, _config.RegisteredDateMinimumDays)
                .Set(s => s.CurrentDate, _config.CurrentDate)
                .Set(s => s.SourceDate, s => s.GetInput<IEligibleForPromotion>()!.RegisteredDate)
            )
            .Then<IsIdentityVerifiedActivity>(
                activity => activity
                .Set(s => s.Input, s => s.Input)
                .Set(s => s.IsIdentityVerified, s => s.GetInput<IEligibleForPromotion>()!.IsIdentityVerified))
            .Finish();
}