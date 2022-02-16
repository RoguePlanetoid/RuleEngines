namespace Elsa.Demo.Rules;

/// <summary>
/// Minimum Age Activity
/// </summary>
internal class MinimumAgeActivity : BaseActivity
{
    /// <summary>
    /// Minimum Age
    /// </summary>
    [ActivityInput]
    public int MinimumAge { get; set; }

    /// <summary>
    /// Current Date
    /// </summary>
    [ActivityInput]
    public DateTime CurrentDate { get; set; }

    /// <summary>
    /// Birth Date
    /// </summary>
    [ActivityInput]
    public DateTime BirthDate { get; set; }

    /// <summary>
    /// On Execute
    /// </summary>
    /// <param name="context">Activity Execution Context</param>
    /// <returns>Activity Execution Result</returns>
    protected override IActivityExecutionResult OnExecute(ActivityExecutionContext context) =>
        Continue<MinimumAgeActivity>(Helper.GetAge(BirthDate, CurrentDate) >= MinimumAge);
}
