namespace Elsa.Demo.Rules;

/// <summary>
/// Is Eligible for Bonus Workflow
/// </summary>
internal class IsEligibleForBonusWorkflow : IWorkflow
{
    private readonly IRulesConfig _config;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="config">Rules Config</param>
    public IsEligibleForBonusWorkflow(IRulesConfig config) =>
        _config = config ?? throw new ArgumentNullException(nameof(config));

    /// <summary>
    /// Build
    /// </summary>
    /// <param name="builder">Workflow Builder</param>
    public void Build(IWorkflowBuilder builder) => 
        builder.WithName(nameof(IsEligibleForBonusWorkflow))
        .Then<MinimumAgeActivity>(
            activity => activity
            .Set(s => s.MinimumAge, _config.DateOfBirthMinimumAge)
            .Set(s => s.CurrentDate, _config.CurrentDate)
            .Set(s => s.BirthDate, s => s.GetInput<IEligibleForBonus>()!.DateOfBirth)  
        )
        .Finish();
}