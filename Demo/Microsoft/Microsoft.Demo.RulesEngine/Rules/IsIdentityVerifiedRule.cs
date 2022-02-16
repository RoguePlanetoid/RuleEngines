namespace Microsoft.Demo.Rules;

/// <summary>
/// Is Identity Verified Rule
/// </summary>
internal class IsIdentityVerifiedRule : BaseRule
{
    /// <summary>
    /// Constructor
    /// </summary>
    public IsIdentityVerifiedRule() : base 
    (
        nameof(IsIdentityVerifiedRule), 
        $"input1.IsIdentityVerified == true"
    ) { }
}