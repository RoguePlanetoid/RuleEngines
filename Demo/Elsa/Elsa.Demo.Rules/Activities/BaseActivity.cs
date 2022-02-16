namespace Elsa.Demo.Rules;

/// <summary>
/// Base Activity
/// </summary>
internal abstract class BaseActivity : Activity
{
    /// <summary>
    /// Input
    /// </summary>
    [ActivityInput]
    public object? Input { get; set; }

    /// <summary>
    /// Output
    /// </summary>
    [ActivityOutput]
    public object? Output { get; set; }

    /// <summary>
    /// Continue
    /// </summary>
    /// <param name="value">Value</param>
    protected IActivityExecutionResult Continue<TActivity>(bool value) where TActivity : Activity
    { 
        ArgumentNullException.ThrowIfNull(value);
        Output = Input; // Pass Output of Previous Activity to Next Activity
        return value ? Done() : Fault(nameof(TActivity));
    }
}
