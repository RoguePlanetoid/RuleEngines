namespace Microsoft.Demo.Rules;

/// <summary>
/// Base Workflow
/// </summary>
internal abstract class BaseWorkflow : Workflow
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="name">Workflow Name</param>
    /// <param name="rules">Rules</param>
    public BaseWorkflow(string name, IEnumerable<Rule> rules) =>
        (WorkflowName, Rules) = 
        (name ?? throw new ArgumentNullException(nameof(name)), 
        rules ?? throw new ArgumentNullException(nameof(rules)));
}
