namespace Microsoft.Demo.Rules;

/// <summary>
/// Minimum Age Rule
/// </summary>
internal class MinimumAgeRule : BaseRule
{
    /// <summary>
    /// Constructor
    /// </summary>
    public MinimumAgeRule() : base
    (
        nameof(MinimumDaysRule), 
        "Helper.GetAge(input1.DateOfBirth, input2.CurrentDate) >= input2.DateOfBirthMinimumAge"
    )
    { }
}