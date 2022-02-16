namespace Microsoft.Demo.Rules;

/// <summary>
/// Minimum Days Rule
/// </summary>
internal class MinimumDaysRule : BaseRule
{
    /// <summary>
    /// Constructor
    /// </summary>
    public MinimumDaysRule() : base
    (
        nameof(MinimumDaysRule),
        $"Helper.GetDays(input1.RegisteredDate, input2.CurrentDate) >= input2.RegisteredDateMinimumDays"
    ) { }
}

