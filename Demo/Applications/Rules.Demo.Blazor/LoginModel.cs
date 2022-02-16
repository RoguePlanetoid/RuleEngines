namespace Rules.Demo.Blazor;

/// <summary>
/// Login Model
/// </summary>
public class LoginModel
{
    /// <summary>
    /// Username
    /// </summary>
    [Required]
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// Password
    /// </summary>
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// Rule Engine Type
    /// </summary>
    public RuleEngineType RuleEngineType { get; set; } = RuleEngineType.ElsaRulesEngine;
}
