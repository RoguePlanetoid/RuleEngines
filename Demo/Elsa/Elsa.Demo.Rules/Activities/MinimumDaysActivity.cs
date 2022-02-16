namespace Elsa.Demo.Rules;

/// <summary>
/// Minimum Days Activity
/// </summary>
internal class MinimumDaysActivity : BaseActivity
{
    /// <summary>
    /// Minimum Days
    /// </summary>
    [ActivityInput]
    public int MinimumDays { get; set; }

    /// <summary>
    /// Current Date
    /// </summary>
    [ActivityInput]
    public DateTime CurrentDate { get; set; }

    /// <summary>
    /// Source Date
    /// </summary>
    [ActivityInput]
    public DateTime SourceDate { get; set; }

    /// <summary>
    /// On Execute
    /// </summary>
    /// <param name="context">Activity Execution Context</param>
    /// <returns>Activity Execution Result</returns>
    protected override IActivityExecutionResult OnExecute(ActivityExecutionContext context) =>
        Continue<MinimumDaysActivity>(Helper.GetDays(SourceDate, CurrentDate) >= MinimumDays);
}
