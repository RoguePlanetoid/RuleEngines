namespace Microsoft.Demo.Rules;

/// <summary>
/// Is Eligible for Promotion Workflow
/// </summary>
internal class IsEligibleForPromotionWorkflow : BaseWorkflow
{
    /// <summary>
    /// Constructor
    /// </summary>
    public IsEligibleForPromotionWorkflow() : base
    (
        nameof(IsEligibleForPromotionWorkflow),
        new List<Rule>
        {
            new MinimumDaysRule(),
            new IsIdentityVerifiedRule()
        }
    ) { }
}
