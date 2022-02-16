namespace Microsoft.Demo.Rules;

/// <summary>
/// Base Factory
/// </summary>
internal abstract class BaseFactory
{
    private readonly IRulesEngine _engine;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="engine">Rules Engine</param>
    public BaseFactory(IRulesEngine engine) =>
        _engine = engine ?? throw new ArgumentNullException(nameof(engine));
    
    /// <summary>
    /// Add Workflows
    /// </summary>
    /// <param name="workflows">Workflows</param>
    protected void AddWorkflows(params Workflow[] workflows) =>
        _engine.AddOrUpdateWorkflow(workflows);

    /// <summary>
    /// Execute Workflow All Success
    /// </summary>
    /// <param name="workflowName">Workflow Name</param>
    /// <param name="inputs">Inputs</param>
    /// <returns>True if Any Pass, False if None Pass</returns>
    protected async ValueTask<bool> ExecuteWorkflowAllSuccess(string workflowName, params object[] inputs) =>
         (await ExecuteWorkflowAsync(workflowName, inputs)).All(a => a.IsSuccess);

    /// <summary>
    /// Execute Workflow Any Success
    /// </summary>
    /// <param name="workflowName">Workflow Name</param>
    /// <param name="inputs">Inputs</param>
    /// <returns>True if Any Pass, False if None Pass</returns>
    protected async ValueTask<bool> ExecuteWorkflowAnySuccess(string workflowName, params object[] inputs) =>
         (await ExecuteWorkflowAsync(workflowName, inputs)).Any(a => a.IsSuccess);

    /// <summary>
    /// Execute Workflow
    /// </summary>
    /// <param name="workflowName">Workflow Name</param>
    /// <param name="inputs">Inputs</param>
    /// <returns>List of Rule Result Tree</returns>
    private ValueTask<List<RuleResultTree>> ExecuteWorkflowAsync(string workflowName, params object[] inputs) =>
        _engine.ExecuteAllRulesAsync(workflowName, inputs);
}

