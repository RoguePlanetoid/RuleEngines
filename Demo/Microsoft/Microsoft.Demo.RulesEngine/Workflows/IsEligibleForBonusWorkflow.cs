namespace Microsoft.Demo.Rules;

/// <summary>
/// Is Eligible for Bonus Workflow
/// </summary>
internal class IsEligibleForBonusWorkflow : BaseWorkflow
{
    /// <summary>
    /// Constructor
    /// </summary>
    public IsEligibleForBonusWorkflow() : base
    (
        nameof(IsEligibleForBonusWorkflow),
        new List<Rule>
        {
            new MinimumAgeRule()
        }
    ) { }
}
