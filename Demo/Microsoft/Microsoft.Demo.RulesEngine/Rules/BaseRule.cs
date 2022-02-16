namespace Microsoft.Demo.Rules;

/// <summary>
/// Base Rule
/// </summary>
internal abstract class BaseRule : Rule
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="name">Rule Name</param>
    /// <param name="expression">Expression</param>
    public BaseRule(string name, string expression) =>    
        (RuleExpressionType, RuleName, Expression) = 
        (RuleExpressionType.LambdaExpression, 
        name ?? throw new ArgumentNullException(nameof(name)), 
        expression ?? throw new ArgumentNullException(nameof(expression)));
}
