namespace Elsa.Demo.Rules;

/// <summary>
/// Is Identity Verified Activity
/// </summary>
internal class IsIdentityVerifiedActivity : BaseActivity
{
    /// <summary>
    /// Is Identity Verified
    /// </summary>
    [ActivityInput]
    public bool IsIdentityVerified { get; set; }

    /// <summary>
    /// On Execute
    /// </summary>
    /// <param name="context">Activity Execution Context</param>
    /// <returns>Activity Execution Result</returns>
    protected override IActivityExecutionResult OnExecute(ActivityExecutionContext context) =>
        Continue<IsIdentityVerifiedActivity>(IsIdentityVerified);
}
