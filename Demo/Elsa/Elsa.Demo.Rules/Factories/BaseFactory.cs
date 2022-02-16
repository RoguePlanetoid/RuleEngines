namespace Elsa.Demo.Rules;

/// <summary>
/// Base Factory
/// </summary>
internal abstract class BaseFactory
{
    private readonly IBuildsAndStartsWorkflow _runner;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="runner"></param>
    public BaseFactory(IBuildsAndStartsWorkflow runner) =>
        _runner = runner ?? throw new ArgumentNullException(nameof(runner));

    /// <summary>
    /// Evaluate
    /// </summary>
    /// <param name="model"></param>
    /// <returns>True if Pass, False if Fail</returns>
    internal async ValueTask<bool> EvaluateAsync<TWorkflow, TModel>(TModel model) where TWorkflow : IWorkflow
    {
        ArgumentNullException.ThrowIfNull(model);
        var result = await _runner.BuildAndStartWorkflowAsync<TWorkflow>(input: new WorkflowInput(model));
        var status = result?.WorkflowInstance?.WorkflowStatus == WorkflowStatus.Finished;
        return status;
    }
}
